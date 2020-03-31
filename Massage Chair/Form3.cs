using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Massage_Chair
{
    public partial class Form3 : Form
    {
        private SerialPort Form3Port;
        public SerialPort Form3Port1 { get => Form3Port; set => Form3Port = value; }

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
