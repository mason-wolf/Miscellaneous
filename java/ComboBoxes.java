String[] options = {"option 1" , "option 2", "option 3"};

final JComboBox actions = new JComboBox(options);

String selectedOption = (String)options.getSelectedItem();

// or

String selectedOption = options.getSelectedItem().toString();

