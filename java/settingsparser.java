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

public class SettingsParser {
	String SettingsFilePath = "settings.properties";
	Properties Settings = new Properties();

	public String Get(String whichKeyToGet) {
		String retrievedKey;
		try {
			Settings.load(new FileInputStream(SettingsFilePath));
		}
		catch(Exception e) {}
		retrievedKey = Settings.getProperty(whichKeyToGet);
		return retrievedKey;
	}
	
	public void Set(String whichKeyToSet, String keyValue) {
		OutputStream output = null;
		try {
			output = new FileOutputStream(SettingsFilePath);
			Settings.setProperty(whichKeyToSet, keyValue);
			Settings.store(output, null);
			output.close();
		}
		catch(Exception e) {}
	}
}

// usage 
// Settings.Set("FIELD", "VALUE");
// Settings.Get("FIELD");
