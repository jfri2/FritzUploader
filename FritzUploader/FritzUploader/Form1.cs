﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.Diagnostics;

namespace FritzUploader
{
    public partial class Form1 : Form
    {
        // Public Variables

        // Private Variables
        private string[] ports;
        private string mcuText;
        private string uploadCommandText;
        private string mcuCmdText;
        private string serialPortText;
        private string filePathText;

        // Public Functions
        public Form1()
        {
            InitializeComponent();
        }

        // Private Functions
        private void Form1_Load(object sender, EventArgs e)
        {
            // Get a list of serial port names
            ports = SerialPort.GetPortNames();

            // Display serial port names in dropdowns
            foreach (var port in ports)
            { 
                CommPortBox.Items.Add(port);
            }
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            // Get file path
            OpenFileDialog ofd = new OpenFileDialog();
            if ((mcuText == "ATmega328p") || (mcuText == "ATmega328pb"))
            {
                ofd.Filter = "Hex Files(*.hex)|*.hex";
            }
            else if (mcuText == "ATSAMD21")
            {
                ofd.Filter = "Bin Files(*.bin)|*bin";
            }

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePathText = ofd.FileName.ToString();
                textBox1.Text = filePathText;
            }
        }

        private void McuBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            if ((mcuText == "ATmega328p") || (mcuText == "ATmega328pb"))
            {
                uploadCommandText = @"/C avrdude.exe -F -v -p" + mcuCmdText + @" -cstk500v1 -P" + serialPortText + @" -b115200 -D -Uflash:w:" + filePathText + @":i";
            }
            else if (mcuText == "ATSAMD21")
            {
                uploadCommandText = @"/C bossac.exe -i -d --port=" + serialPortText + @" -U true -i -e -w -v " + filePathText + @" -R";
            }

            Debug.WriteLine(uploadCommandText);

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = uploadCommandText;
            process.StartInfo = startInfo;
            process.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CommPortBox.Items.Clear();

            // Refresh serial port names
            ports = SerialPort.GetPortNames();

            // Display refreshed serial port names in dropdown
            foreach (var port in ports)
            {
                CommPortBox.Items.Add(port);
            }
        }

        private void CommPortBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPortText = CommPortBox.SelectedItem.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            mcuText = comboBox2.SelectedItem.ToString();    // Get string from box

            switch (mcuText)
            {
                case "ATmega328p":
                    mcuCmdText = "m328p";
                    break;
                case "Atmega328pb":
                    mcuCmdText = "m328pb";
                    break;
                case "ATSAMD21":
                    break;
                default:
                    mcuCmdText = "m328p";   // default to ATmega328p
                    break;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
