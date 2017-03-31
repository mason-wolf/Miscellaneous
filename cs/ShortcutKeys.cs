this.KeyDown += new KeyEventHandler(this.CTRL_F_Pressed);
/*
public partial class MainWindow : Form
{
    public MainWindow()
    {
        this.KeyDown += new KeyEventHandler(this.CTRL_F_Pressed);
    }
*/

public void CTRL_F_Pressed(object sender, KeyEventArgs e)
{
if (e.KeyCode == Keys.F)
{
switch (ActionReportDataView.SelectedIndex) {
case 0:
    NewSearchWindow("assets");
    break;
case 1:
    NewSearchWindow("ec");
    break;
case 2:
    NewSearchWindow("accounts");
    break;
case 3:
    TransferSearch TransferSearch = new TransferSearch();
    TransferSearch.Show();
    break;
case 4:
    IssuedSearch IssuedSearch = new IssuedSearch();
    IssuedSearch.Show();
    break;
case 5:
    ActionLogDataView.SelectAll();
    break;
}
}
}
