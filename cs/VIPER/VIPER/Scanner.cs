using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIPER
{

    class Scanner
    {
        RichTextBox Console;
        ListBox VulnerabilityList;
        TreeView Threats;
        Button Start;
        Button Stop;
        Button Patcher;

        public Scanner(RichTextBox ConsoleContainer, ListBox VulnerabilityContainer, TreeView ThreatNode, Button Scan, Button Abort, Button PatchButton)
        {
            Console = ConsoleContainer;
            VulnerabilityList = VulnerabilityContainer;
            Threats = ThreatNode;
            Start = Scan;
            Stop = Abort;
            Patcher = PatchButton;
        }

        public void Patch()
        {
            Patcher.Invoke((Action)delegate {
                Patcher.Enabled = false;
            });

            StreamReader reader;

            var vulnerabilities = new ArrayList(VulnerabilityList.Items);

            foreach (var vulnerability in vulnerabilities)
            {
                using (Process p = new Process())
                {
                    p.StartInfo.FileName = "msiexec.exe";
                    p.StartInfo.CreateNoWindow = false;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.RedirectStandardError = true;
                    p.StartInfo.RedirectStandardInput = true;
                    p.StartInfo.Arguments = "/x {" + vulnerability.ToString() + "} /quiet /L*v " + Environment.CurrentDirectory.ToString() + "\\config\\vulnerability" + ".txt";
                    p.Start();

                    try
                    {
                        using (reader = p.StandardOutput)
                        {
                            while (reader != null)
                            {
                                string result = reader.ReadLine();
                                if (result != null)
                                {
                                    Console.Invoke((Action)delegate
                                    {
                                        Console.Clear();
                                        Console.AppendText("Removing " + vulnerability.ToString() + "...\n");
                                    });
                                }
                                else
                                {
                                    Console.Invoke((Action)delegate
                                    {
                                        string log = File.ReadAllText(Environment.CurrentDirectory.ToString() + "\\config\\vulnerability.txt");
                                        Console.AppendText(log);
                                        Console.SelectionStart = Console.Text.Length;
                                        Console.ScrollToCaret();
                                    });
                                    reader.Close();
                                }
                            }
                        }
                    }
                    catch 
                    {
                        p.Close();
                        p.Dispose();
                    }
                }

                Console.Invoke((Action)delegate
                {
                    Console.AppendText("Removed " + vulnerability + ".\n");
                });

                Patcher.Invoke((Action)delegate
                {
                    Patcher.Enabled = true;
                });

            }
        }

        public void Initiate()
        {

            StreamReader reader;
            int vulnerabilityCount = 0;

            using (Process p = new Process())
            {
                p.StartInfo.FileName = "wmic";
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.Arguments = "product list brief";
                p.Start();

                try
                {
                    using (reader = p.StandardOutput)
                    {
                        while (reader != null)
                        {
                            string result = reader.ReadLine();

                            Console.Invoke((Action)delegate
                            {
                                if (result != null)
                                {
                                    Console.AppendText(result + "\n");
                                    Console.SelectionStart = Console.Text.Length;
                                    Console.ScrollToCaret();
                                }
                                else
                                {
                                    reader.Close();
                                }
                            });
                        }
                    }
                }
                catch
                {
                    p.Close();
                    p.Dispose();

                    Console.Invoke((Action)delegate {

                        var vulnerabilityList = new ArrayList(VulnerabilityList.Items);

                        foreach (var item in vulnerabilityList)
                        {

                            if (Console.Text.Contains(item.ToString()))
                            {
                                vulnerabilityCount++;
                            }
                        }

                        Console.SelectionColor = System.Drawing.Color.Yellow;
                        Console.AppendText("Scan complete. (" + vulnerabilityCount.ToString() + ") vulnerabilities detected.");
                        Console.SelectionColor = System.Drawing.Color.LightGreen;
                    });


                    Threats.Invoke((Action)delegate
                    {
                            try
                            {
                                    Threats.SelectedNode = Threats.Nodes[0].Nodes[0];
                                    Threats.SelectedNode.Text = "Detected (" + vulnerabilityCount.ToString() + ")";
                                    Threats.SelectedNode = Threats.Nodes[0].Nodes[0];
                        }
                            catch
                            {

                            }
                    });

                    Start.Invoke((Action)delegate
                    {
                        Start.Enabled = true;
                    });

                    Stop.Invoke((Action)delegate {
                        Stop.Visible = false;
                    });

                    Patcher.Invoke((Action)delegate
                    {
                        Patcher.Enabled = true;
                    });
                }
            }
        }
    }
}
