using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LWSInjector
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            if (btnAttach.Text.Equals("Attached"))
            {
                btnAttach.Text = "Attach to Anomaly";
                btnAttach.BackColor = Color.FromArgb(76, 71, 68);
                btnAttach.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 0);
                return;
            }

            Process anomaly = getAnomaly();
            if (anomaly == null)
            {
                MessageBox.Show("S.T.A.L.K.E.R. Anomaly is not running yet", "LWS-Injector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            InjectorAPI.InjectionReturnCodes returnValue = InjectorAPI.InjectLoadLibrary(LWS_DLL.Data, anomaly.ProcessName);
            if (returnValue != InjectorAPI.InjectionReturnCodes.Success)
            {
                MessageBox.Show("Failed to attach executor to process: " + returnValue.ToString(), "LWS-Injector", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnAttach.Text = "Attached";
            btnAttach.BackColor = Color.FromArgb(0, 64, 0);
            btnAttach.FlatAppearance.BorderColor = Color.Green;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool isMouseDown;
        int mouseX;
        int mouseY;

        private void pnlForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                mouseX = e.X;
                mouseY = e.Y;
            }
        }

        private void pnlForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        private void pnlForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                SetDesktopLocation(MousePosition.X - mouseX, MousePosition.Y - mouseY);
            }
        }

        private Process getAnomaly()
        {
            Process[] procs = Process.GetProcesses().Where(p => p.MainWindowHandle != IntPtr.Zero && p.ProcessName.Contains("AnomalyDX")).ToArray();
            return procs.Length != 0 ? procs[0] : null;
        }
    }
}
