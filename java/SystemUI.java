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
