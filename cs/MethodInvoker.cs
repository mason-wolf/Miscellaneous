// call from another thread, passing DeviceList object
// as parameter from the callback

this.Invoke((MethodInvoker)delegate
{
    DeviceList.SelectedIndex = 0;

    if (DeviceList.Items.Count > 1)
    {
        ProgressBar.Visible = true;
    }
});
