public partial class RemoteSessionTerminator : Form
   {
       public RemoteSessionTerminator()
       {
           InitializeComponent();
       }

       private void DisconnectButton_Click(object sender, EventArgs e)
       {

           try
           {
               ProcessStartInfo RemoteSessionTerminator = new ProcessStartInfo();
               RemoteSessionTerminator.UseShellExecute = false;
               RemoteSessionTerminator.CreateNoWindow = true;
               RemoteSessionTerminator.FileName = @"c:\windows\system32\reset.exe";
               RemoteSessionTerminator.RedirectStandardError = true;
               RemoteSessionTerminator.Arguments = "Session Console /Server:" + DeviceName.Text.Remove(0, 2);

               using (Process proc = Process.Start(RemoteSessionTerminator))
               {
                   using (System.IO.StreamReader reader = proc.StandardError)
                   {
                       string result = reader.ReadToEnd();
                   }
               }
           }

           catch
           {
               MessageBox.Show("Remote session termination is not supported on this system.");
           }

           this.Close();
       }
   }
