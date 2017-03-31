import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import javax.swing.JOptionPane;

public class ActionListenerButton {

	public static void initiateWindow() {
		ActionListener buttonAction = new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				JOptionPane.showMessageDialog(null,"Message goes here", "message", JOptionPane.PLAIN_MESSAGE);
			}
		};
		JButton button = new JButton("click");
		button.setSize(150, 25);
		JFrame window = new JFrame();
		JPanel content = new JPanel();
		window.setContentPane(content);
		button.addActionListener(buttonAction);
		content.add(button);
		content.setLayout(null);
		window.setSize(500,500);
		window.setDefaultCloseOperation(window.EXIT_ON_CLOSE);
		window.setVisible(true);
	}
	public static void main(String[] args) {
		SwingUtilities.invokeLater(new Runnable() {
			public void run() {
			initiateWindow();
			}
		});
	}
}
