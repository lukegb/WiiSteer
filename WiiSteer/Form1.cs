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

namespace WiiSteer
{
    public partial class Form1 : Form
    {
        Wiimote wm;
        PseudoJoystick pj;

        delegate void SetRotationLabelCallback(double newRotation);

        public Form1()
        {
            InitializeComponent();

            wm = new Wiimote();
        }

        private void LogEntry(string entry)
        {
            logArea.AppendText(String.Format("\r\n[{0}] {1}", DateTime.Now.ToShortTimeString(), entry));
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (wm.Connected)
                {
                    try
                    {
                        wm.WiimoteChanged -= wm_WiimoteChanged;
                    }
                    catch (Exception) { }
                    wm.Disconnect();
                    connectBtn.Text = "Connect";
                    LogEntry("Disconnected.");
                }
                else
                {
                    wm.Connect();
                    connectBtn.Text = "Disconnect";
                    LogEntry("Connected.");
                    wm.WiimoteChanged += wm_WiimoteChanged;
                }
            }
            catch (WiimoteLib.WiimoteNotFoundException)
            {
                LogEntry("No Wiimote is connected to this computer. Are you sure you connected it correctly?");
            }
            catch (IOException ioe)
            {
                LogEntry(ioe.Message);
            }
        }

        void wm_WiimoteChanged(object sender, WiimoteLib.WiimoteChangedEventArgs e)
        {
            SetRotationLabel(e.WiimoteState.AccelState.Values.Y);
            pj.InformNewWiimoteState(e.WiimoteState);
        }

        void SetRotationLabel(double newRotation)
        {
            if (rotationLabel.InvokeRequired) {
                SetRotationLabelCallback d = new SetRotationLabelCallback(SetRotationLabel);
                this.Invoke(d, new object[] { newRotation });
            }
            else {
                this.rotationLabel.Text = newRotation.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // initialise vJoy
            pj = new PseudoJoystick();
            try
            {
                pj.Setup(1);
                connectBtn.Enabled = true;
            }
            catch (InvalidOperationException ex)
            {
                LogEntry("Joystick not set up correctly: " + ex.Message);
            }
            catch (Exception ex)
            {
                LogEntry("Exception trying to set up vJoy: " + ex.ToString());
            }
        }
    }
}
