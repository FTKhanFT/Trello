using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trello
{
    public partial class EnterName : Form
    {
        public EnterName()
        {
            InitializeComponent();
        }

        public static string name;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text))
            {
                name = textBox1.Text;
                Close();
            }
        }
    }
}
