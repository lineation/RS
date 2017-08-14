using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.Diagnostics;


namespace MachineVision
{
    public class LightController
    {
        public enum Channel { FirstChannel, SecondChannel, ThirdChannel, FourthChannel };
        private SerialPort serialPort;

        public LightController(uint portNumber)
        {
            serialPort = new SerialPort(); 
            serialPort.PortName = "Com" + portNumber.ToString();
        }

        private void SetPortNumber(uint portNumber)
        {
            serialPort.PortName = "Com" + portNumber.ToString();
        }

        private bool Open()
        {
            serialPort.BaudRate = 19200;
            try
            {
                serialPort.Open();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;
        }

        public void Close()
        {
            serialPort.Close();
        }

        public void SetLuminance(Channel channel, uint lightValue)
        {
            string command = null;

            switch (channel)
            {
                case Channel.FirstChannel:
                    command = "SA";
                    break;
                case Channel.SecondChannel:
                    command = "SB";
                    break;
                case Channel.ThirdChannel:
                    command = "SD";
                    break;
                case Channel.FourthChannel:
                    command = "SC";
                    break;
                default:
                    break;
            }


            if ((lightValue / 100) > 0)
            {
                command += string.Format("0{0}", lightValue);
                //Debug.WriteLine("(lightValue / 10) > 0  " + command);
            }
            else if ((lightValue / 10) > 0)
            {
                command += string.Format("00{0}", lightValue);
                //Debug.WriteLine("(lightValue / 100) > 0  " + command);
            }
            else
            {
                command += string.Format("000{0}", lightValue);
                //Debug.WriteLine("else  " + command);
            }

            command += "#\r\n";
            serialPort.Write(command);
        }

        public uint GetLuminance(Channel channel)
        {
            switch (channel)
            {
                case Channel.FirstChannel:
                    break;
                case Channel.SecondChannel:
                    break;
                case Channel.ThirdChannel:
                    break;
                case Channel.FourthChannel:
                    break;
            }

            //serialPort.Read();

            return 0;
        }
    }
}
