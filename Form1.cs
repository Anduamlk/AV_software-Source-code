using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Habesha
{
    public partial class Habesha : Form
    {
        bool sideBar_Expand = true;
        private Update update;
        private NotifiMange notifiMange;
        private Protection protection;
        private Viruscan scan;
        public Habesha()
        {
            InitializeComponent();
            update = new Update();
            notifiMange = new NotifiMange();
            protection = new Protection();
            scan = new Viruscan();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           fullcheck fc = new fullcheck();
            fc.Show();
            this.Hide();
          
         
           
    
            
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Application.Exit();        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Contact co = new Contact();
            co.ShowDialog();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Encrypt en = new Encrypt();
            en.ShowDialog();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {        

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sideBar_Expand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sideBar_Expand = false;
                    sidebarTimer.Stop();
                    
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sideBar_Expand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void guna2Button6_Click_2(object sender, EventArgs e)
        {
                   
            
        }

        private void sidebar_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
           Viruscan fc = new Viruscan();
            fc.Show();
            this.Hide();
        }

        private void guna2Button9_Click_1(object sender, EventArgs e)
        {
            Encrypt en = new Encrypt();
            en.ShowDialog();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button6_Click_3(object sender, EventArgs e)
        {
            Viruscan vs = new Viruscan();   
            vs.ShowDialog();
            this.Hide();    
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Contact co = new Contact();
            co.ShowDialog();    
            this.Hide();
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button12_Click_1(object sender, EventArgs e)
        {
            Encrypt en = new Encrypt();
            en.ShowDialog();
            this.Hide();
        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            Qickscan vs = new Qickscan();
            vs.ShowDialog();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
        
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void guna2Button1_Click_2(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2PictureBox2_Click_1(object sender, EventArgs e)
        {
            Contact co = new Contact();
            co.ShowDialog();
            this.Hide();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnCheckUpdates_Click(object sender, EventArgs e)
        {
            await update.CheckForUpdatesAsync();
            notifiMange.ShowAlert("Update Check Complete");
        }

        private void btnShowAlert_Click(object sender, EventArgs e)
        {
            notifiMange.ShowAlert("This is a test alert");
        }

        private void btnStartProtection_Click(object sender, EventArgs e)
        {
            protection.Start();
            notifiMange.ShowAlert("Real-Time Protection Started");
        }
    }
}
