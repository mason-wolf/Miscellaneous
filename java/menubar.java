
        JMenuBar MenuBar = new JMenuBar();
        JMenu FileMenu = new JMenu("File");
        
        JMenuItem NewMenuItem = new JMenuItem("New");

        FileMenu.add(NewMenuItem);


        MenuBar.add(FileMenu);
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
        
       window.setJMenuBar(MenuBar);
