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
    public partial class ChooseRow : Form
    {
        public ChooseRow(int id)
        {
            InitializeComponent();
            Id = id;
            rows = new List<Rows.Row>();
        }
        public static int Id;
        public static int index;
        static List<Rows.Row> rows; 
        private void ChooseRow_Load(object sender, EventArgs e)
        {
            LoadRow(Id);
            foreach (var item in rows)
            {
                comboBox1.Items.Add(item.Name);
            }
        }

        private static void LoadRow(int id)
        {
            rows.AddRange(Trello.GetTrello().getRowsForBoard(id));
        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                if(comboBox1.Items[i] == comboBox1.SelectedItem)
                {
                    index = i;
                    break;
                }
            }
            Id = rows[index].ID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem != null)
            {
                Close();
            }
        }
    }
}
