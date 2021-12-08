using System;
using System.Collections.Generic;
using System.Text;
// Serial Port
using System.IO.Ports;
using System.Threading;

namespace EqApp
{
    public class SerialCom
    {
        // Create the serial port with basic settings
        private SerialPort Port = new SerialPort();

        public SerialCom()
        {
            // Default Setting
            SetPortName("COM1");
            SetBaudRate(9600);
            SetDataBits(8);
            SetStopBits(System.IO.Ports.StopBits.One);
            SetParity(System.IO.Ports.Parity.None);
        }

        // Display Avaliable Ports
        public static string[] GetAvaliablePorts()
        {

            return SerialPort.GetPortNames();
        }

        public void SetPortName(string portName)
        {
            Port.PortName = portName;
        }
        public string GetPortName()
        {
            return Port.PortName;
        }
        public void SetBaudRate(int baudRate)
        {
            Port.BaudRate = baudRate;
        }
        public int GetBaudRate()
        {
            return Port.BaudRate;
        }

        public void SetParity(Parity parity)
        {
            Port.Parity = parity;
        }
        public Parity GetParity()
        {
            return Port.Parity;
        }
        public void SetDataBits(int dataBits)
        {
            Port.DataBits = dataBits;
        }
        public int GetDataBits()
        {
            return Port.DataBits;
        }

        public void SetStopBits(StopBits stopBits)
        {
            Port.StopBits = stopBits;
        }
        public StopBits GetStopBits()
        {
            return Port.StopBits;
        }

        public void SetPortHandshake(Handshake handshake)
        {
            Port.Handshake = handshake;
        }
        public Handshake GetHandshake()
        {
            return Port.Handshake;
        }

        public void Send(string data)
        {
            try
            {
                Port.Open();
                Port.Write(data);
                Port.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: {0}.", e);
            }
        }

    }
}
