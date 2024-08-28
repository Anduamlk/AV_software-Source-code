using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Habesha
{
    public partial class Protection : Form
    {
        public Protection()
        {
            InitializeComponent();
        }

        private void Protection_Load(object sender, EventArgs e)
        {

        }
        private FileSystemWatcher watcher;

        public void Start()
        {
            watcher = new FileSystemWatcher();
            watcher.Path = @"C:\Users\ahduy\Downloads\Telegram Desktop";
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = "*.*";
            watcher.Created += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.Changed += OnChanged;
            watcher.Renamed += OnRenamed;
            watcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (ScanFile(e.FullPath))
            {
               
            }
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            if (ScanFile(e.FullPath))
            {
               
            }
        }

        private bool ScanFile(string filePath)
        {
            var scanner = new SignatureBased();
            return scanner.ScanFile(filePath);
        }
    }
}
