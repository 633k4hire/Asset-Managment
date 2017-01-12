using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Asset_Managment
{
    public partial class ScannerSettings : Form
    {
       
        public ScannerSettings()
        {
            InitializeComponent();
        }
        public ScannerSettings(System.IO.Ports.SerialPort port)
        {            
            InitializeComponent();
            serialPort1 = port;

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void ScannerSettings_Load(object sender, EventArgs e)
        {
            var ports = System.IO.Ports.SerialPort.GetPortNames();
            if (ports.Length > 0)
            {
                portname.Items.AddRange(ports);
                portname.Text = serialPort1.PortName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm.updateSerialPort(serialPort1);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void baud_ValueChanged(object sender, EventArgs e)
        {
            serialPort1.BaudRate = Convert.ToInt32(baud.Value);
        }

        private void Databits_ValueChanged(object sender, EventArgs e)
        {
            serialPort1.DataBits = Convert.ToInt32(Databits.Value);
        }

        private void discardnull_CheckedChanged(object sender, EventArgs e)
        {
            serialPort1.DiscardNull = discardnull.Checked;
        }

        private void parityreplace_TextChanged(object sender, EventArgs e)
        {
            try
            {
                serialPort1.ParityReplace = (Encoding.ASCII.GetBytes(parityreplace.Text))[0];
            }
            catch { }
        }

        private void portname_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = portname.Text;
        }

        private void readbuffer_ValueChanged(object sender, EventArgs e)
        {
            serialPort1.ReadBufferSize = Convert.ToInt32(readbuffer.Value);
        }

        private void readtimeout_ValueChanged(object sender, EventArgs e)
        {
            serialPort1.ReadTimeout = Convert.ToInt32(readtimeout.Value);
        }

        private void recievedbytethreshold_ValueChanged(object sender, EventArgs e)
        {
            serialPort1.ReceivedBytesThreshold = Convert.ToInt32(recievedbytethreshold.Value);
        }

        private void rtsenabled_CheckedChanged(object sender, EventArgs e)
        {
            serialPort1.RtsEnable = rtsenabled.Checked;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox3.Text)
            {
                case "None":
                    serialPort1.StopBits = System.IO.Ports.StopBits.None;
                    break;
                case "One":
                    serialPort1.StopBits = System.IO.Ports.StopBits.One;
                    break;
                case "Two":
                    serialPort1.StopBits = System.IO.Ports.StopBits.Two;
                    break;
                case "OnePointFive":
                    serialPort1.StopBits = System.IO.Ports.StopBits.OnePointFive;
                    break;
                default:
                    MessageBox.Show("Please Select Valid Option");
                    break;
            }
        }

        private void handshake_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(handshake.Text)
            {
                case "None":
                    serialPort1.Handshake = System.IO.Ports.Handshake.None;
                    break;
                case "XOnXOff":
                    serialPort1.Handshake = System.IO.Ports.Handshake.XOnXOff;
                    break;
                case "RequestToSend":
                    serialPort1.Handshake = System.IO.Ports.Handshake.RequestToSend;
                    break;
                case "RequestToSendXOnXOff":
                    serialPort1.Handshake = System.IO.Ports.Handshake.RequestToSendXOnXOff;
                    break;
                default:
                    MessageBox.Show("Please Select Valid Entry");
                    break;

            }
        }

        private void writebuffer_ValueChanged(object sender, EventArgs e)
        {
            serialPort1.WriteBufferSize = Convert.ToInt32(writebuffer.Value);
        }

        private void writetimeout_ValueChanged(object sender, EventArgs e)
        {
            serialPort1.WriteTimeout = Convert.ToInt32(writetimeout.Value);
        }

        private void dtrenabled_CheckedChanged(object sender, EventArgs e)
        {
            serialPort1.DtrEnable = dtrenabled.Checked;
        }

        private void parity_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(parity.Text)
            {
                case "None":
                    serialPort1.Parity = System.IO.Ports.Parity.None;
                    break;
                case "Odd":
                    serialPort1.Parity = System.IO.Ports.Parity.Odd;
                    break;
                case "Even":
                    serialPort1.Parity = System.IO.Ports.Parity.Even;
                    break;
                case "Mark":
                    serialPort1.Parity = System.IO.Ports.Parity.Mark;
                    break;
                case "Space":
                    serialPort1.Parity = System.IO.Ports.Parity.Space;
                    break;
                default:
                    MessageBox.Show("Please Select Valid Entry");
                    break;
            }
        }
    }
    
}
