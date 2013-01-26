using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiimoteLib;

namespace WiiSteer
{
    public delegate void WiimoteChangedEventHandler(object sender, WiimoteChangedEventArgs e);

    class Wiimote
    {
        WiimoteLib.Wiimote innerWiimote;

        double lastY;

        const int CALIBRATION_TURNS = 20;
        const int CALIBRATION_PAUSE = 50;

        public event WiimoteChangedEventHandler WiimoteChanged;

        protected virtual void OnWiimoteChanged(WiimoteChangedEventArgs e)
        {
            if (WiimoteChanged != null)
                WiimoteChanged(this, e);
        }

        private bool _Connected;
        public bool Connected
        {
            get
            {
                return this._Connected;
            }
            private set
            {
                this._Connected = value;
            }
        }

        public Wiimote()
        {
            innerWiimote = new WiimoteLib.Wiimote();
            innerWiimote.WiimoteChanged += innerWiimote_WiimoteChanged;

            lastY = Double.PositiveInfinity;
        }

        void innerWiimote_WiimoteChanged(object sender, WiimoteChangedEventArgs e)
        {
            WiimoteState ws = innerWiimote.WiimoteState;

            if (float.IsInfinity(ws.AccelState.Values.Y))
                return;

            if (double.IsInfinity(lastY))
            {
                lastY = ws.AccelState.Values.Y;
                return;
            }

            OnWiimoteChanged(e);

            lastY = ws.AccelState.Values.Y;
        }

        public void Connect()
        {
            if (Connected) return;

            lastY = Double.PositiveInfinity;

            innerWiimote.Connect();
            innerWiimote.SetReportType(InputReport.ButtonsAccel, true);
            innerWiimote.SetLEDs(false, true, false, true);
            Connected = true;
        }

        public void Disconnect()
        {
            if (!Connected) return;

            innerWiimote.Disconnect();
            Connected = false;
        }
    }
}
