using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace SimpleMultiThreading
{
    public partial class MultiThreading : Form
    {
        private Thread t_Red, t_Blue;
        private Random rdm;

        public MultiThreading()
        {
            InitializeComponent();
        }

        private void MultiThreading_Load(object sender, EventArgs e)
        {
            rdm = new Random();
        }

        private void btn_Red_Click(object sender, EventArgs e)
        {
            t_Red = new Thread(thread_Red);
            t_Red.Start();
        }

        private void thread_Red()
        {

            for (int i = 0; i < 10; i++ )
            {
                this.CreateGraphics().DrawRectangle(new Pen(Brushes.Red, 5), new Rectangle(rdm.Next(0, this.Width), rdm.Next(0, this.Height), 30, 30));
                Thread.Sleep(1000);
            }
            MessageBox.Show("Red Complete");
        }

        private void thread_Blue()
        {
            for (int i = 0; i < 10; i++)
            {
                this.CreateGraphics().DrawRectangle(new Pen(Brushes.Blue, 5), new Rectangle(rdm.Next(0, this.Width), rdm.Next(0, this.Height), 30, 30));
                Thread.Sleep(1000);
            }
            MessageBox.Show("Blue Complete");
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void btn_Blue_Click(object sender, EventArgs e)
        {
            t_Blue = new Thread(thread_Blue);
            t_Blue.Start();
        }
    }
}
