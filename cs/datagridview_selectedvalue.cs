         int selectedrowindex = ECDataView.SelectedCells[0].RowIndex;
         DataGridViewRow selectedRow = ECDataView.Rows[selectedrowindex];
         string a = Convert.ToString(selectedRow.Cells["ID"].Value);
         MessageBox.Show(a);