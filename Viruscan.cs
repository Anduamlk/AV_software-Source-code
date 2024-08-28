using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Diagnostics;
using System.IO;

namespace Habesha
{
    public partial class Viruscan : Form
    {
        private Viruscan scan;
        private Protection protection;
        private NotifiMange notifiMnge;


        public Viruscan()
        {
            InitializeComponent();
          
        } 
        private SignatureBased scanner;


        public void ScanDirectory(string directoryPath)
        {
            /*foreach (string filePath in Directory.GetFiles(directoryPath))
            {
                if (scanner.ScanFile(filePath))
                {
                    Console.WriteLine($"Malware detected: {filePath}");
                }
            }*/
        }
        private void ScanButton_Click(object sender, EventArgs e)
        {
           
        }
        private void Viruscan_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
        
           
     }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
           Habesha ha = new Habesha();
            ha.Show();
            this.Hide();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
           // StartDefenderScan("Scan the Virus ");
            string directoryPath = txtPath.Text;
            if (System.IO.Directory.Exists(directoryPath))
            {
                scan.ScanDirectory(directoryPath);
                notifiMnge.ShowAlert("Scan complete.");
            }
            else
            {
                notifiMnge.ShowAlert("Directory not found.");
            }
        }

        private void btnFullScan_Click(object sender, EventArgs e)
        {
           // StartDefenderScan("Scan all system");
        }
        private void StartDefenderScan(string scanType)
        {
            try
            {
                string fe = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), @"Windows Defender\MpCmdRun.exe");

                if (!File.Exists(fe))
                {
                    MessageBox.Show("Please install Windows Defender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string arguments = scanType == "Scan" ? "-Scan -ScanType 1" : "-Scan -ScanType 2";

                ProcessStartInfo ps = new ProcessStartInfo
                {
                    FileName = fe,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(ps))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        lbl.Text = ParseDefenderOutput(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ParseDefenderOutput(string output)
        {
            if (output.Contains("Malware found: 0"))
            {
                return "No Malware found.";
            }
            else if (output.Contains("Malware found:"))
            {
                return "Malware detected!";
            }
            else
            {
                return "Scan Completed Your Device is Safe";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form fo = new Form();
            fo.Show();
            this.Hide();
        }
    }
    }

