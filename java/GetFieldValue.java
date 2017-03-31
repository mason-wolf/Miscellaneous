import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import javax.swing.JOptionPane;
public class GetFieldValue {
	public static void initiateWindow() {
		JFrame window = new JFrame();
		JPanel content = new JPanel();
		final JTextField field = new JTextField();
		JButton button = new JButton("Get Value");
		field.setSize(150,25);
		button.setSize(150,25);
		button.setLocation(25, 100);
		button.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				String value = field.getText();
				JOptionPane.showMessageDialog(null, value, value, JOptionPane.PLAIN_MESSAGE);
			}
		});
		window.setSize(250,250);
		window.setDefaultCloseOperation(window.EXIT_ON_CLOSE);
		window.setContentPane(content);
		content.setLayout(null);
		content.add(field);
		content.add(button);
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
