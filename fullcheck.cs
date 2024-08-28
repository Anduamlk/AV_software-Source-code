using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Habesha
{
    public partial class fullcheck : Form
    {
        public fullcheck()
        {
            InitializeComponent();
        }

        private void fullcheck_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
           Qickscan qs = new Qickscan();
            qs.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Habesha ha = new Habesha();
            ha.Show();
            this.Hide();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            string pathToScan = txtFilePath.Text;

            if (string.IsNullOrWhiteSpace(pathToScan) || !File.Exists(pathToScan))
            {
                MessageBox.Show("Please select a valid file to scan.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ScanFileWithDefender(pathToScan);
        }
        private void ScanFileWithDefender(string filePath)
        {
            try
            {
                string defenderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), @"Windows Defender\MpCmdRun.exe");

                if (!File.Exists(defenderPath))
                {
                    MessageBox.Show("Windows Defender is not installed or the path is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = defenderPath,
                    Arguments = $"-Scan -ScanType 3 -File \"{filePath}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        lblResult.Text = ParseDefenderOutput(result);
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
            if (output.Contains("Threats found: 0"))
            {
                return "No threats found.";
            }
            else if (output.Contains("Threats found:"))
            {
                return "Threat detected!";
            }
            else
            {
                return "Scan completed. See details in the output.";
            }
        }
    }
}
