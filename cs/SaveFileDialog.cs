SaveFileDialog saveFileDialog1 = new SaveFileDialog();
saveFileDialog1.Filter = "Comma Seperate Value Files (*.csv) |*.csv|Text Documents (*.txt) |*.txt";
saveFileDialog1.Title = "Save file..";
saveFileDialog1.ShowDialog();

if (saveFileDialog1.FileName != "")
{

    System.IO.FileStream fs =
       (System.IO.FileStream)saveFileDialog1.OpenFile();
    fs.Close();
    System.Windows.Forms.IDataObject objectSave = Clipboard.GetDataObject();
    DataView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
    DataView.SelectAll();

    Clipboard.SetDataObject(DataView.GetClipboardContent());
     DataView.ClearSelection();

        File.WriteAllText(saveFileDialog1.FileName, Clipboard.GetText(TextDataFormat.CommaSeparatedValue));
if (objectSave != null)
    {
    Clipboard.SetDataObject(objectSave);
    }
}
