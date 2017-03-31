import java.awt.*;
import java.awt.event.*;
import java.util.*;
import java.util.List;
import javax.swing.*;
import javax.swing.border.TitledBorder;
import java.awt.Color;
import java.awt.FlowLayout;
import javax.swing.BorderFactory;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.border.Border;
import javax.swing.JOptionPane;
import java.util.Properties;
import java.io.*;
import java.io.FileOutputStream;
import java.io.FileNotFoundException;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.OutputStream;
import javax.swing.JTextArea;
import java.nio.charset.Charset;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.concurrent.Callable;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class boa {

    String[] ActionOptionList = {"Search", "Send Notification",
        "Log Off User", "Lock Machine", "Restart Machine",
        "Locate Device", "Install Program", "Uninstall Program",
        "Get Installed Programs", "Get Installed Printers",
        "Show Processes", "Kill Process"};
    private final JTextField TargetMachineField = new JTextField(20);
    public final JTextArea ActionLogContainer = new JTextArea();
    private final JTextArea TaskResultContainer = new JTextArea(0,0);
    private final JTextArea textArea = new JTextArea(20, 20);
    private final JComboBox ActionOptions = new JComboBox(ActionOptionList);
    private JButton startButton = new JButton("Query");
    private JButton stopButton = new JButton("Abort");
    private JProgressBar bar = new JProgressBar();
    private BackgroundTask backgroundTask;
    private final ActionListener buttonActions = new ActionListener() {
        @Override
        public void actionPerformed(ActionEvent ae) {
            if(TargetMachineField.getText().equals("")) {
                JOptionPane.showMessageDialog(null,"Please enter machine or user you wish to query.", "Error", JOptionPane.PLAIN_MESSAGE);
            }
            else {
                String selectedOption = (String)ActionOptions.getSelectedItem();
                
                JButton source = (JButton) ae.getSource();
                if (source == startButton) {
                    textArea.setText(null);
                    startButton.setEnabled(false);
                    String TargetMachine = TargetMachineField.getText();
                    String Action = ActionOptions.getSelectedItem().toString();
                    settingsparser Settings = new settingsparser();
                    Settings.Set("last_device_queried", TargetMachine);
                    Settings.Set("last_query", Action);
                    if(Action == "Search") {
                        stopButton.setVisible(true);
                        stopButton.setEnabled(true);
                        Settings.Set("script", "C:\\ProgramData\\Boa\\GetClient.ps1");
                        ActionLogContainer.append("Searching for client \n'" + TargetMachine + "'...\n");
                        backgroundTask = new BackgroundTask();
                        backgroundTask.execute();
                        bar.setVisible(true);
                        bar.setIndeterminate(true);
                    }
                    if(Action == "Send Notification") {
                        Settings.Set("script", "C:\\ProgramData\\Boa\\send-message.ps1");
                        String message = JOptionPane.showInputDialog(null, "Message:", "Send Notification", JOptionPane.PLAIN_MESSAGE);
                        Settings.Set("message_to_send", message);
                        backgroundTask = new BackgroundTask();
                        backgroundTask.execute();
                        bar.setVisible(true);
                        bar.setIndeterminate(true);
                    }
                    if(Action == "Log Off User") {
                        Settings.Set("script", "C:\\ProgramData\\Boa\\logoff-user.ps1");
                        int response = JOptionPane.showConfirmDialog(null, "Log off users currently logged onto " + TargetMachine + "?", "Log Off User",
                        JOptionPane.YES_NO_OPTION, JOptionPane.QUESTION_MESSAGE);
                         if (response == JOptionPane.NO_OPTION) {}
                             else if (response == JOptionPane.YES_OPTION) {
                              backgroundTask = new BackgroundTask();
                              backgroundTask.execute();
                              bar.setVisible(true);
                              bar.setIndeterminate(true);
                     }
                  }
                  if(Action == "Lock Machine") {
                      Settings.Set("script", "C:\\ProgramData\\Boa\\lockmachine.ps1");
                      backgroundTask = new BackgroundTask();
                       backgroundTask.execute();
                       bar.setVisible(true);
                       bar.setIndeterminate(true);
                  }
                    if(Action == "Restart Machine") {
                      Settings.Set("script", "C:\\ProgramData\\Boa\\restart-machine.ps1");
                      backgroundTask = new BackgroundTask();
                      backgroundTask.execute();
                      bar.setVisible(true);
                      bar.setIndeterminate(true);
                  }
               }
                else if (source == stopButton) {
                    backgroundTask.cancel(true);
                    backgroundTask.done();
                }
                
            }
        }
    };
    
    private class BackgroundTask extends SwingWorker<Integer, String> {
        private int status;
        private String device;
        public BackgroundTask() {
        }
        @Override
        protected Integer doInBackground() {
            try {
                SettingsParser Settings = new SettingsParser();
                String query = Settings.Get("last_query");
                String script = Settings.Get("script");
                ProcessBuilder pb = new ProcessBuilder("powershell", script);
                pb.redirectErrorStream(true);
                Process p = pb.start();
                String s;
                BufferedReader stdout = new BufferedReader(
                new InputStreamReader(p.getInputStream()));
                while ((s = stdout.readLine()) != null && !isCancelled()) {
                    publish(s);
                }
                if (!isCancelled()) {
                    status = p.waitFor();
                }
                p.getInputStream().close();
                p.getOutputStream().close();
                p.getErrorStream().close();
                p.destroy();
                } catch (Exception ex) {
                ex.printStackTrace(System.err);
            }
            return status;
        }
        @Override
        protected void done() {
            boa boa = new boa();
            try {
                String result = boa.readFile("log.txt");
                TaskResultContainer.setText(result);
                SettingsParser Settings = new SettingsParser();
                String query = Settings.Get("last_query");
                String client = Settings.Get("last_device_queried");
                String message = Settings.Get("message_to_send");
                boolean searchComplete = result.contains("ComputerName");
                boolean messageSent = result.contains("sent");
                boolean loggedOff = result.contains("logged off");
                boolean locked = result.contains("locked");
                boolean reboot = result.contains("reboot successful");
                if(searchComplete) {
                    Pattern p = Pattern.compile("ComputerName");
                    Matcher m = p.matcher(result);
                    int occurences = 0;
                    while(m.find()) {
                        occurences +=1;
                    }
                    ActionLogContainer.append("\n" + occurences + " results found.\n");
                }
                if(messageSent) {
                    ActionLogContainer.append("\nNotification was sent to: \n" + client +"\n");
                }
                if(loggedOff) {
                    ActionLogContainer.append("\nLogged off users on:\n" + client + "\n");
                }
                if(locked) {
                    ActionLogContainer.append("\nLocked workstation:\n " + client + "\n");
                }
                if(reboot) {
                    ActionLogContainer.append("\nRestarted machine:\n" + client + "\n");
                }
            }
            catch(Exception e) {}
            try {
                Thread.sleep(2000);
                File dfile = new File("log.txt");
                dfile.delete();
            }
            catch(Exception e) {}
            stopButton.setEnabled(false);
            stopButton.setVisible(false);
            startButton.setEnabled(true);
            bar.setIndeterminate(false);
            bar.setVisible(false);
        }
    }
    JFrame window = new JFrame("Base Oversight Accumulator");
    JPanel content = new JPanel();
    
    public void initiateWindow() {
        // create the main window (the frame)
        
        // add menu bar, FILE, EDIT, TOOLS, HELP
        JMenuBar MenuBar = new JMenuBar();
        JMenu FileMenu = new JMenu("File");
        JMenuItem NewMenuItem = new JMenuItem("New Session");
        JMenuItem SaveMenuItem = new JMenuItem("Save Log");
        JMenuItem OptionsMenuItem = new JMenuItem("Options"); // ip prefix, mail address
        JMenuItem ExitMenuItem = new JMenuItem("Exit");
        FileMenu.add(NewMenuItem);
        FileMenu.add(SaveMenuItem);
        FileMenu.add(OptionsMenuItem);
        FileMenu.add(ExitMenuItem);
        JMenu EditMenu = new JMenu("Edit");
        JMenuItem RedoMenuItem = new JMenuItem("Redo Operation");
        JMenuItem RemoteFindMenuItem = new JMenuItem("Remote Find");
        JMenuItem RemoteRegistryMenuItem = new JMenuItem("Remote Registry");
        JMenuItem PreferencesMenuItem = new JMenuItem("Preferences"); // local mode, window style, Task Bar, CLI, alias
        EditMenu.add(RedoMenuItem);
        EditMenu.add(RemoteFindMenuItem);
        EditMenu.add(RemoteRegistryMenuItem);
        EditMenu.add(PreferencesMenuItem);
        JMenu ToolsMenu = new JMenu("Tools");
        JMenuItem TerminalMenuItem = new JMenuItem("Bash Terminal");
        JMenuItem CIPSMenuItem = new JMenuItem("CIPS Visualization Component");
        JMenuItem SpeedTestMenuItem = new JMenuItem("Network Speed Test");
        ToolsMenu.add(TerminalMenuItem);
        ToolsMenu.add(CIPSMenuItem);
        ToolsMenu.add(SpeedTestMenuItem);
        JMenu HelpMenu = new JMenu("Help");
        JMenuItem DocMenuItem = new JMenuItem("Documentation");
        JMenuItem AboutMenuItem = new JMenuItem("About");
        HelpMenu.add(DocMenuItem);
        HelpMenu.add(AboutMenuItem);
        MenuBar.add(FileMenu);
        MenuBar.add(EditMenu);
        MenuBar.add(ToolsMenu);
        MenuBar.add(HelpMenu);
        // shows the results of the tasks
        JScrollPane TaskScrollPane = new JScrollPane(TaskResultContainer);
        TaskScrollPane.setBounds(20,25,440,470);
        TaskScrollPane.setVerticalScrollBarPolicy(ScrollPaneConstants.VERTICAL_SCROLLBAR_AS_NEEDED);
        TaskResultContainer.setEditable(false);
        // TaskResultContainer.setBorder(BorderFactory.createTitledBorder("Task Results"));
        TaskResultContainer.setSize(500,260);
        TaskResultContainer.setLocation(20,20);
        //  Font font = new Font("Verdana", Font.BOLD, 12);
        //  TaskResultContainer.setFont(font);
        JLabel ActionOptionsContainer = new JLabel("");
        ActionOptionsContainer.setBorder(BorderFactory.createLineBorder(Color.gray));
        ActionOptionsContainer.setSize(170, 141);
        ActionOptionsContainer.setLocation(490, 28);
        final JLabel TargetMachineLabel = new JLabel("Target Machine/User:");
        TargetMachineLabel.setSize(125,25);
        TargetMachineLabel.setLocation(500, 35);
        TargetMachineField.setSize(150, 25);
        TargetMachineField.setLocation(500, 55);
        NewMenuItem.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                int response = JOptionPane.showConfirmDialog(null, "Are you sure you want to start a new session?", "New Session",
                JOptionPane.YES_NO_OPTION, JOptionPane.QUESTION_MESSAGE);
                if (response == JOptionPane.NO_OPTION) {}
                else if (response == JOptionPane.YES_OPTION) {
                    TaskResultContainer.setText("");
                    ActionLogContainer.setText("");
                    TargetMachineField.setText("");
                }
        }});
        ActionOptions.setSelectedIndex(0);
        ActionOptions.setSize(150, 25);
        ActionOptions.setLocation(500, 120);
        // create the content handler within the window
        JScrollPane LogScrollPane = new JScrollPane(ActionLogContainer);
        LogScrollPane.setBounds(490, 195, 170, 300);
        LogScrollPane.setVerticalScrollBarPolicy(ScrollPaneConstants.VERTICAL_SCROLLBAR_AS_NEEDED);
        //   ActionLogContainer.setBorder(BorderFactory.createTitledBorder("Action Log"));
        ActionLogContainer.setEditable(false);
        ActionLogContainer.setLineWrap(true);
        Font font = new Font("Verdana", Font.PLAIN, 10);
        ActionLogContainer.setFont(font);
        window.setSize(700,580);
        window.setDefaultCloseOperation(window.EXIT_ON_CLOSE);
        content.setLayout(null);
        // add all the previously created content to the panel
        //       statusLabel.setLocation(40,40);
        //       statusLabel.setSize(125,25);
        startButton.setSize(70,25);
        startButton.setLocation(500,85);
        startButton.setToolTipText("Queries Active Directory for user or workstation information.");
        stopButton.setSize(70,18);
        stopButton.setLocation(245,499);
        bar.setVisible(false);
        stopButton.setVisible(false);
        bar.setSize(200,15);
        bar.setLocation(20,500);
        startButton.addActionListener(buttonActions);
        //     stopButton.setEnabled(false);
        stopButton.addActionListener(buttonActions);
        //     content.add(statusLabel);
        content.add(LogScrollPane);
        //       content.add(buttonPanel);
        content.add(TaskScrollPane);
        content.add(LogScrollPane);
        content.add(ActionOptionsContainer);
        content.add(TargetMachineLabel);
        content.add(TargetMachineField);
        content.add(startButton);
        content.add(stopButton);
        content.add(bar);
        content.add(ActionOptions);
        window.setJMenuBar(MenuBar);
        window.setContentPane(content);
        window.setVisible(true);
    }
    private String readFile(String pathname) throws IOException {
        File file = new File(pathname);
        StringBuilder fileContents = new StringBuilder((int)file.length());
        Scanner scanner = new Scanner(file);
        String lineSeparator = System.getProperty("line.separator");
        try {
            while(scanner.hasNextLine()) {
                fileContents.append(scanner.nextLine() + lineSeparator);
            }
            return fileContents.toString();
            } finally {
            scanner.close();
        }
    }
    
    public void message(String title, String text) {
        JOptionPane.showMessageDialog(null,text, title, JOptionPane.PLAIN_MESSAGE);
    }
    public static void main(String[] args) throws FileNotFoundException {
        try {
            // Set System L&F
            UIManager.setLookAndFeel(
            UIManager.getSystemLookAndFeelClassName());
        }
        catch (Exception e) {
            // handle exception
        }
        SwingUtilities.invokeLater(new Runnable() {
            public void run() {
                new boa().initiateWindow();
            }
        });
    }
}
