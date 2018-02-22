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
    public partial class BoardProperty : Form
    {
        public BoardProperty()
        {
            InitializeComponent();
        }

        public string name, color;
        bool okay = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (okay)
                {
                    name = textBox1.Text;
                    Close();
                }
            }
            else
            {
                okay = false;
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            if (colorDialog1.Color != null)
            {
                color = colorDialog1.Color.Name;
                button2.BackColor = colorDialog1.Color;
                okay = true;
            }
            else
            {
                okay = false;
            }
        }
    }
}
