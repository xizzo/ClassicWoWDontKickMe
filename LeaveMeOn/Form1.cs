using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

namespace LeaveMeOn
{
    public partial class Form1 : Form
    {

        List<WindowsInput.Native.VirtualKeyCode> ListKeys = new List<WindowsInput.Native.VirtualKeyCode>();
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            AddActions();
        }

        private void AddActions()
        {
            ListKeys.Add(WindowsInput.Native.VirtualKeyCode.VK_Z);
            ListKeys.Add(WindowsInput.Native.VirtualKeyCode.VK_S);
            ListKeys.Add(WindowsInput.Native.VirtualKeyCode.VK_D);    
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                btnStart.Text = "Start";
            }
            else
            {
                timer1.Start();
                btnStart.Text = "Stop";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lstLog.Items.Add($"[{DateTime.Now}] Insert Actions");
            Application.DoEvents();

            int i = random.Next(0, ListKeys.Count);
            InputSimulator inputSim = new InputSimulator();
            inputSim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);
            inputSim.Keyboard.KeyDown(ListKeys[i]);

            System.Threading.Thread.Sleep(random.Next(500, 1500));

            inputSim.Keyboard.KeyUp(ListKeys[i]);

            timer1.Stop();
            timer1.Interval = random.Next(3 * 60000, 4 * 60000);
            timer1.Start();

        }
    }
}
