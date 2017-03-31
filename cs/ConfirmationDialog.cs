if (MessageBox.Show("Are you sure you want to make these modifications? This action cannot be undone.",
"Confirm Changes", MessageBoxButtons.YesNo) == DialogResult.Yes)
{
    string Manufacturer = ManufacturerField.Text;
    foreach (string item in ItemsToUpdate)
    {
        dbconnect mysql = new dbconnect();
        mysql.SelectQuery("UPDATE assets SET manufacturer='" + Manufacturer.ToUpper() + "' WHERE id='" + item + "'");
        mysql.CloseConnection();
    }
    MessageBox.Show("Update complete.");
}
