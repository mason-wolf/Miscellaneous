private string[] RetrieveDeviceList()
{
    string[] DeviceListItems = new string[DeviceList.Items.Count];

    for(int i = 0; i < DeviceList.Items.Count; i++)
    {
        DeviceListItems[i] = DeviceList.Items[i].ToString();
    }

    return DeviceListItems;
}
