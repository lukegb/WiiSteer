using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using vJoyInterfaceWrap;

namespace WiiSteer
{
    class PseudoJoystick
    {
        vJoy wrappedJoystick = new vJoy();
        uint wrappedJoystickId;
        bool hasSetup = false;
        long Xmax, Ymax, Zmax;

        public PseudoJoystick() { }

        public void Setup(uint id)
        {
            if (hasSetup) throw new InvalidOperationException("PseudoJoystick already setup!");

            wrappedJoystickId = id;

            if (!wrappedJoystick.vJoyEnabled()) throw new InvalidOperationException("vJoy doesn't appear to be installed. Please install vJoy from http://vjoystick.sf.net");

            VjdStat status = wrappedJoystick.GetVJDStatus(wrappedJoystickId);
            switch (status)
            {
                case VjdStat.VJD_STAT_OWN:
                    throw new InvalidOperationException(String.Format("vJoy Device {0} already owned. Try restarting this application.", id));
                case VjdStat.VJD_STAT_FREE:
                    // great!
                    break;
                case VjdStat.VJD_STAT_BUSY:
                    throw new InvalidOperationException(String.Format("vJoy Device {0} already in use by another application.", id));
                case VjdStat.VJD_STAT_MISS:
                    throw new InvalidOperationException(String.Format("vJoy Device {0} is not installed or is disabled. Please ensure you've installed vJoy from http://vjoystick.sourceforge.net", id));
                case VjdStat.VJD_STAT_UNKN:
                    throw new InvalidOperationException(String.Format("vJoy Device {0} is experiencing an unknown error.", id));
            }

            // now acquire it
            if (!wrappedJoystick.AcquireVJD(wrappedJoystickId))
            {
                throw new InvalidOperationException(String.Format("vJoy Device {0} could not be acquired.", id));
            }

            wrappedJoystick.ResetVJD(wrappedJoystickId);

            wrappedJoystick.GetVJDAxisMax(wrappedJoystickId, HID_USAGES.HID_USAGE_X, ref Xmax);
            wrappedJoystick.GetVJDAxisMax(wrappedJoystickId, HID_USAGES.HID_USAGE_Y, ref Ymax);
            wrappedJoystick.GetVJDAxisMax(wrappedJoystickId, HID_USAGES.HID_USAGE_Z, ref Zmax);
        }

        private int RescaleAxis(float inp, long maxval) {
            // input is between -1 and 1
            // output must be between 0 and maxval
            if (inp < -1) inp = -1f;
            if (inp > 1) inp = 1f;

            // between 0 and 2
            inp += 1f;

            double outp;
            outp = (maxval / 2L);
            outp *= inp;

            return (int)outp;
        }

        public void InformNewWiimoteState(WiimoteLib.WiimoteState ws)
        {
            // make a report
            vJoy.JoystickState iReport = new vJoy.JoystickState();

            // specify device
            iReport.bDevice = (byte)wrappedJoystickId;

            // now position data:
            iReport.AxisX = RescaleAxis(-ws.AccelState.Values.Y, Xmax);
            iReport.AxisY = RescaleAxis(ws.AccelState.Values.X, Ymax);
            iReport.AxisZ = RescaleAxis(ws.AccelState.Values.Z, Zmax);

            // now buttons
            iReport.Buttons = WiimoteToUint(ws);

            wrappedJoystick.UpdateVJD(wrappedJoystickId, ref iReport);
        }

        private uint WiimoteToUint(WiimoteLib.WiimoteState ws)
        {
            // field goes:
            // a, b, +, -, home, 1, 2, any directional
            uint output = 0;
            output = (uint)(((ws.ButtonState.Left ? 0x1 : 0x0) << 10) |
                            ((ws.ButtonState.Down ? 0x1 : 0x0) << 9) |
                            ((ws.ButtonState.Up ? 0x1 : 0x0) << 8) |
                            ((ws.ButtonState.Right ? 0x1 : 0x0) << 7) |
                            ((ws.ButtonState.A ? 0x1 : 0x0) << 6) |
                            ((ws.ButtonState.B ? 0x1 : 0x0) << 5) |
                            ((ws.ButtonState.Plus ? 0x1 : 0x0) << 4) |
                            ((ws.ButtonState.Minus ? 0x1 : 0x0) << 3) |
                            ((ws.ButtonState.Home ? 0x1 : 0x0) << 2) |
                            ((ws.ButtonState.One ? 0x1 : 0x0) << 1) |
                            ((ws.ButtonState.Two ? 0x1 : 0x0) << 0));
            return output;
        }
    }
}
