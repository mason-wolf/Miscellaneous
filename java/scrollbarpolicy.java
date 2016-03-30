        JScrollPane LogScrollPane = new JScrollPane(TEXTAREA);
        LogScrollPane.setBounds(490, 195, 170, 300);
        LogScrollPane.setVerticalScrollBarPolicy(ScrollPaneConstants.VERTICAL_SCROLLBAR_AS_NEEDED);
        ActionLogContainer.setEditable(false);
        ActionLogContainer.setLineWrap(true);
        Font font = new Font("Verdana", Font.PLAIN, 10);
        ActionLogContainer.setFont(font);
