import java.awt.*;
import java.awt.*;
import javax.swing.*;

public class SwingFrame {
	public static void initiateWindow() {
		JFrame window = new JFrame("app");
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
