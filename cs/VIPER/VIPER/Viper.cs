using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIPER
{

    public partial class Viper : Form 
    {

        Thread ScanSystem;

        public Viper()
        {
            InitializeComponent();
            ProductList.RowHeadersVisible = false;
            Directory.ExpandAll();
        }

        private void Viper_Load(object sender, EventArgs e)
        {
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {
                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        try {
                            ProductList.Rows.Add(subkey.GetValue("DisplayName").ToString(), subkey.GetValue("DisplayVersion").ToString(),
                                subkey.GetValue("Publisher").ToString(), subkey.GetValue("UninstallString"));
                        }
                        catch
                        {

                        }
                    }
                }
            }

            List<string> threats = new List<string>();
            try
            {
                using (StreamReader r = new StreamReader("config\\threats.db"))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        if (line != "")
                        {
                            threats.Add(line);
                        }
                    }
                }

                foreach (string threat in threats)
                {
                    VulnerabilityList.Items.Add(threat);
                }
            }

            catch
            {

            }

            }

        private void Directory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = Directory.SelectedNode;

            if (node.Text == "Storage")
            {
                StorageBox.Visible = true;
                DetectedVulnerabilities.Visible = false;
                MSIInstallers.Visible = false;
            }

            if (node.Text.Contains("Detected"))
            {
                DetectedVulnerabilities.Visible = true;
                StorageBox.Visible = false;
                MSIInstallers.Visible = false;
            }

            if (node.Text == "MSI Installers")
            {
                MSIInstallers.Visible = true;
                DetectedVulnerabilities.Visible = false;
                StorageBox.Visible = false;
            }
        }


        private void AddVulnerabilityButton_Click(object sender, EventArgs e)
        {
            string id = VulnerabilityTextBox.Text;
                try
                {
                    File.AppendAllText(@"config\\threats.db", id + Environment.NewLine);
                }
                catch
                {

                }

                VulnerabilityList.Items.Add(id);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VulnerabilityList.Items.Count != 0)
            {
                try
                {
                    string item = VulnerabilityList.SelectedItem.ToString();
                    string tempFile = Path.GetTempFileName();
                    string filePath = "config\\threats.db";

                    using (var sr = new StreamReader(filePath))
                    {
                        using (var sw = new StreamWriter(tempFile))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                if (line != item)
                                {
                                    sw.WriteLine(line);
                                }
                            }
                        }
                    }

                    File.Delete(filePath);
                    File.Move(tempFile, filePath);
                }

                catch
                {

                }

                VulnerabilityList.Items.Remove(VulnerabilityList.SelectedItem);
            }
        }

        private void ScanButton_Click(object sender, EventArgs e)
        {
            DetectedVulnerabilitiesList.Items.Clear();

            Console.Clear();
            Console.AppendText("Starting scan..");
            ScanButton.Enabled = false;
            AbortButton.Visible = true;

            Scanner Scanner = new Scanner(Console, VulnerabilityList, Directory, ScanButton, AbortButton, PatchButton);
            ScanSystem = new Thread(() => Scanner.Initiate());
            ScanSystem.Start();
            try
            {
                SearchInstalled();
            }
            catch
            {

            }
        }

        public void SearchInstalled()
        {

            var vulnerabilityList = new ArrayList(VulnerabilityList.Items);

            foreach (DataGridViewRow row in ProductList.Rows)
            {
                foreach (var vulnerability in vulnerabilityList)
                {
                    if (row.Cells[3].Value.ToString().Contains(vulnerability.ToString()))
                    {
                        DetectedVulnerabilitiesList.Items.Add(row.Cells[0].Value.ToString() + " " + row.Cells[1].Value.ToString());
                        RemovalKey.Items.Add(row.Cells[3].Value.ToString());
                    }
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(VulnerabilityList.SelectedItem.ToString());
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "taskkill";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = false;
            p.StartInfo.Arguments = @"/im wmic.exe /f";
            p.Start();
            AbortButton.Visible = false;
            ScanButton.Enabled = true;
            p.Close();
            p.Dispose();
            ScanSystem.Abort();
            Console.Clear();
            Console.AppendText("Scan Aborted.\n");
        }

        private void PatchButton_Click(object sender, EventArgs e)
        {
            Scanner Scanner = new Scanner(Console, VulnerabilityList, Directory, ScanButton, AbortButton, PatchButton);
            ScanSystem = new Thread(() => Scanner.Patch());
            ScanSystem.Start();
        }

        private void StorageMenuOptions_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
