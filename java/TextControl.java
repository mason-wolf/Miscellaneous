import java.awt.*;
import java.awt.*;
import javax.swing.*;
import javax.swing.JTextArea;

public class TextControls {
	public static void initiateWindow() {
		JFrame window = new JFrame("app");
		JPanel content = new JPanel();
		JTextField textField = new JTextField(20);
		JTextArea textArea = new JTextArea(0,0);
		textField.setSize(125, 25);
		textField.setLocation(50, 50);
		textArea.setSize(150,150);
		textArea.setLocation(100,100);
		content.setLayout(null);
		content.add(textField);
		content.add(textArea);
		window.setContentPane(content);
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
