using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trello.Boards;

namespace Trello
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static int id = 0;

        Trello trello;

        private void Form1_Load(object sender, EventArgs e)
        {
            panel6.AutoScroll = true;
            trello = Trello.GetTrello();
            string color = "Blue";
            var board = trello.addBoard("No Name Board", color);
            id = board.ID;
            trello.addRow(board, "To Do");
            trello.addRow(board, "Doing");
            trello.addRow(board, "Done");
            DrawRows(board);
            panel2.BackColor = Color.FromName(color);
            panel2.AutoScroll = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            BoardProperty boardProForm = new BoardProperty();
            boardProForm.ShowDialog();
            panel2.Visible = true;
            string name = boardProForm.name;
            string color = boardProForm.color;
            var board = trello.addBoard(name, color);
            id = board.ID;
            label2.Text = name;
            trello.addRow(board, "To Do");
            trello.addRow(board, "Doing");
            trello.addRow(board, "Done");
            DrawRows(board);
            panel2.BackColor = Color.FromName(color);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            panel2.BackColor = colorDialog1.Color;
            trello.ChangeBoardColor(colorDialog1.Color.Name, id);
        }

        private void toolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            TextBox boardname = new TextBox();
            boardname.Visible = true;
            boardname.Left = 130;
            boardname.Top = 6;
            boardname.Size = new Size(200, 10);
            boardname.Font = new Font("", 16);
            Controls.Add(boardname);
            boardname.BringToFront();
            boardname.KeyPress += Boardname_KeyPress;
        }

        private void Boardname_KeyPress(object sender, KeyPressEventArgs e)
        {

            var boardname = sender as TextBox;
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                trello.ChangeBoardName(boardname.Text, id);
                label2.Text = boardname.Text;
                boardname.Visible = false;

            }
        }

        private void deleteBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            trello.DeleteBoardById(id);
            panel2.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {

            panel6.Controls.Clear();
            if (panel6.Visible == true)
            {
                panel6.Visible = false;
            }

            else if (trello.getBoards().Count > 0)
            {
                int left = 0;
                int top = 20;
                panel6.Visible = true;
                Controls.Add(panel6);
                panel6.Left = 23;
                panel6.Top = 43;
                panel6.BringToFront();
                panel6.Height = 339;
                panel6.Width = 200;
                foreach (var item in trello.getBoards())
                {
                    Button btn = new Button();
                    btn.Width = 200;
                    btn.Height = 45;
                    btn.Left = left;
                    btn.Top = top;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Roboto Cn", 12, FontStyle.Italic);
                    btn.BackColor = Color.FromArgb(2, 106, 167);
                    btn.Text = item.Name;
                    btn.Click += Btn_Click;
                    btn.Name = item.ID.ToString();
                    panel6.Controls.Add(btn);
                    top += btn.Height + 5;
                    // panel6.Height += btn.Height;
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Visible = true;
            var btn = sender as Button;
            string color = trello.getBoardId(Convert.ToInt32(btn.Name)).Color;
            panel2.BackColor = Color.FromName(color);
            id = Convert.ToInt32(btn.Name);
            label2.Text = btn.Text;
            int left = 41, top = 46;
            foreach (var item in trello.getRowsForBoard(Convert.ToInt32(btn.Name)))
            {
                Panel panel = new Panel();
                panel.MaximumSize = new Size(255, 472);
                panel.AutoScroll = true;
                panel.BackColor = Color.FromArgb(226, 228, 230);
                panel.Width = 255;
                panel.Height = 81;
                panel.Left = left;
                panel.Top = top;
                panel.Name = item.ID.ToString();
                Label label = new Label();
                label.Font = new Font("Roboto Cn", 12, FontStyle.Italic);
                label.BackColor = Color.Transparent;
                label.Left = 3;
                label.Top = 2;
                label.Width = 46;
                label.Height = 19;
                label.Text = item.Name;
                label.AutoSize = true;
                Button addbutton = new Button();
                addbutton.Left = 215;
                addbutton.Top = 3;
                addbutton.Width = 24;
                addbutton.Height = 23;
                addbutton.FlatStyle = FlatStyle.Flat;
                addbutton.FlatAppearance.BorderSize = 0;
                addbutton.BackgroundImage = Image.FromFile(@"C:\Users\hp1\source\repos\Trello\Trello\Resources\....png");
                addbutton.BackgroundImageLayout = ImageLayout.Stretch;
                addbutton.ContextMenuStrip = new ContextMenuStrip();
                ToolStripItem item1 = addbutton.ContextMenuStrip.Items.Add("Change Name");
                item1.Click += İtem1_Click;
                ToolStripItem item2 = addbutton.ContextMenuStrip.Items.Add("Delete Row");
                item2.Click += İtem2_Click;
                Button cardButton = new Button();
                top = DrawTask(item.ID, panel, top);
                cardButton.Left = -1;
                cardButton.Top = top;
                cardButton.FlatStyle = FlatStyle.Flat;
                cardButton.FlatAppearance.BorderSize = 0;
                cardButton.Width = 209;
                cardButton.Height = 27;
                cardButton.Name = item.ID.ToString(); 
                cardButton.BackColor = Color.Transparent;
                cardButton.Text = "Add a card...";
                cardButton.TextAlign = ContentAlignment.MiddleLeft;
                cardButton.Font = new Font("Roboto Cn", 12, FontStyle.Italic);
                cardButton.ForeColor = Color.FromArgb(131, 140, 145);
                cardButton.Click += CardButton_Click;
                panel.Controls.Add(label);
                panel.Controls.Add(addbutton);
                panel.Controls.Add(cardButton);
                panel2.Controls.Add(panel);
                panel.BringToFront();
                top = 46;
                left += panel.Width + 65;
            }
            pictureBox2.Left = left;
            panel2.Controls.Add(pictureBox2);
            panel6.Visible = false;
        }

        private void DrawRows(Board board)
        {
            panel2.Controls.Clear();
            int count = 0, left = 41, top = 46;
            foreach (var item in trello.getRowsForBoard(board.ID))
            {
                Panel panel = new Panel();
                panel.MaximumSize = new Size(255,472);
                panel.AutoScroll = true;
                panel.BackColor = Color.FromArgb(226, 228, 230);
                panel.Width = 255;
                panel.Height = 81;
                panel.Left = left;
                panel.Top = top;
                panel.Name = item.ID.ToString();
                Label label = new Label();
                label.Font = new Font("Roboto Cn", 12, FontStyle.Italic);
                label.BackColor = Color.Transparent;
                label.Left = 3;
                label.Top = 2;
                label.Width = 46;
                label.Height = 19;
                label.Text = item.Name;
                label.AutoSize = true;
                Button addbutton = new Button();
                addbutton.Left = 215;
                addbutton.Top = 3;
                addbutton.Width = 24;
                addbutton.Height = 23;
                addbutton.FlatStyle = FlatStyle.Flat;
                addbutton.FlatAppearance.BorderSize = 0;
                addbutton.BackgroundImage = Image.FromFile(@"C:\Users\hp1\source\repos\Trello\Trello\Resources\....png");
                addbutton.BackgroundImageLayout = ImageLayout.Stretch;
                addbutton.ContextMenuStrip = new ContextMenuStrip();
                ToolStripItem item1 = addbutton.ContextMenuStrip.Items.Add("Change Name");
                item1.Click += İtem1_Click;
                ToolStripItem item2 = addbutton.ContextMenuStrip.Items.Add("Delete Row");
                item2.Click += İtem2_Click;
                top = DrawTask(item.ID, panel, top);
                Button cardButton = new Button();
                cardButton.Left = -1;
                cardButton.Top = top;
                cardButton.FlatStyle = FlatStyle.Flat;
                cardButton.FlatAppearance.BorderSize = 0;
                cardButton.Width = 209;
                cardButton.Height = 27;
                cardButton.Name = item.ID.ToString();
                cardButton.BackColor = Color.Transparent;
                cardButton.Text = "Add a card...";
                cardButton.TextAlign = ContentAlignment.MiddleLeft;
                cardButton.Font = new Font("Roboto Cn", 12, FontStyle.Italic);
                cardButton.ForeColor = Color.FromArgb(131, 140, 145);
                cardButton.Click += CardButton_Click;
                panel.Controls.Add(label);
                panel.Controls.Add(addbutton);
                panel.Controls.Add(cardButton);
                panel2.Controls.Add(panel);
                panel.BringToFront();
                top = 46;
                left += panel.Width + 65;
            }
            pictureBox2.Left = left;
            panel2.Controls.Add(pictureBox2);
            panel6.Visible = false;
        }

        private void CardButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            EnterName enterName = new EnterName();
            enterName.ShowDialog();
            trello.AddTask(trello.GetRowById(Convert.ToInt32(button.Name)), EnterName.name);
            DrawRows(trello.getBoardId(id));
        }

        private int DrawTask(int id, Panel panel, int top)
        {
            int left = 1;
            top = 49;
            foreach (var item in trello.GetRowById(id).getTasks())
            {
                RichTextBox textBox = new RichTextBox();
                textBox.Left = left;
                textBox.Top = top;
                //textBox.FlatStyle = FlatStyle.Flat;
                //textBox.FlatAppearance.BorderSize = 0;
                textBox.Width = 209;
                textBox.Height = 70;
                textBox.AutoSize = true;
                //textBox.MaximumSize = new Size(209, 27); 
                textBox.Name = item.ID.ToString();
                //textBox.BackColor = Color.Transparent;
                textBox.Text = item.Name;
                //textBox.TextAlign = ContentAlignment.MiddleLeft;
                textBox.Font = new Font("Roboto Cn", 12, FontStyle.Italic);
                textBox.ForeColor = Color.FromArgb(131, 140, 145);
                textBox.Enabled = false;
                Button addbutton = new Button();
                addbutton.Left = textBox.Width + 5;
                addbutton.Top = top;
                addbutton.Width = 24;
                addbutton.Height = 23;
                addbutton.FlatStyle = FlatStyle.Flat;
                addbutton.FlatAppearance.BorderSize = 0;
                addbutton.BackgroundImage = Image.FromFile(@"C:\Users\hp1\source\repos\Trello\Trello\Resources\....png");
                addbutton.BackgroundImageLayout = ImageLayout.Stretch;
                addbutton.ContextMenuStrip = new ContextMenuStrip();
                ToolStripItem draganddrop = addbutton.ContextMenuStrip.Items.Add("Drag and Drop");
                ToolStripItem changetask = addbutton.ContextMenuStrip.Items.Add("Change Name");
                ToolStripItem deletetask = addbutton.ContextMenuStrip.Items.Add("Delete Task");
                changetask.Name = textBox.Name;
                deletetask.Name = textBox.Name;
                draganddrop.Name = textBox.Name;
                draganddrop.Click += Draganddrop_Click;
                changetask.Click += Changetask_Click;
                deletetask.Click += Deletetask_Click;
                top = top + textBox.Height;
                panel.Controls.Add(addbutton);
                panel.Controls.Add(textBox);
                panel.Height = top + textBox.Height;
            }
            return top;
        }

        private void Deletetask_Click(object sender, EventArgs e)
        {
            var stripitem = sender as ToolStripItem;
            foreach (var item in panel2.Controls.OfType<Panel>())
            {
                foreach (var item2 in item.Controls.OfType<Button>())
                {
                    if (item2.ContextMenuStrip != null)
                    {
                        foreach (ToolStripItem item3 in item2.ContextMenuStrip.Items)
                        {
                            if (item3 == stripitem)
                            {
                                //MessageBox.Show(item.Controls.OfType<Label>().First().Text);
                                var textbox = item.Controls.OfType<RichTextBox>().Where(x => x.Name == stripitem.Name).First();
                                panel2.Controls.Remove(item2);
                                panel2.Controls.Remove(textbox);
                                trello.DeleteTask(trello.GetRowById(Convert.ToInt32(item.Name)), Convert.ToInt32(stripitem.Name));
                                //trello.DeleteRow(id, Convert.ToInt32(item.Name));
                                DrawRows(trello.getBoardId(id));
                            }
                        }
                    }
                }
            }
        }

        private void Changetask_Click(object sender, EventArgs e)
        {
            var stripitem = sender as ToolStripItem;
            foreach (var item in panel2.Controls.OfType<Panel>())
            {
                foreach (var item2 in item.Controls.OfType<Button>())
                {
                    if (item2.ContextMenuStrip != null)
                    {
                        foreach (ToolStripItem item3 in item2.ContextMenuStrip.Items)
                        {
                            if (item3 == stripitem)
                            {
                                //MessageBox.Show(item.Controls.OfType<Label>().First().Text);
                                EnterName enterName = new EnterName();
                                enterName.ShowDialog();
                                item.Controls.OfType<RichTextBox>().Where(x=>x.Name == stripitem.Name).First().Text = EnterName.name;
                                trello.ChangeTaskContent(trello.GetRowById(Convert.ToInt32(item.Name)), EnterName.name, Convert.ToInt32(stripitem.Name));
                            }
                        }
                    }
                }
            }
        }

        private void Draganddrop_Click(object sender, EventArgs e)
        {
            var stripitem = sender as ToolStripItem;
            foreach (var item in panel2.Controls.OfType<Panel>())
            {
                foreach (var item2 in item.Controls.OfType<Button>())
                {
                    if (item2.ContextMenuStrip != null)
                    {
                        foreach (ToolStripItem item3 in item2.ContextMenuStrip.Items)
                        {
                            if (item3 == stripitem)
                            {
                                ChooseRow chooseRow = new ChooseRow(id);
                                chooseRow.ShowDialog();
                                trello.DragAndDrop(Convert.ToInt32(item.Name), ChooseRow.Id, Convert.ToInt32(stripitem.Name));
                                DrawRows(trello.getBoardId(id));
                                break;
                            }
                        }
                    }
                }
            }
            
            
        }

        private void İtem2_Click(object sender, EventArgs e)
        {
            var stripitem = sender as ToolStripItem;
            foreach (var item in panel2.Controls.OfType<Panel>())
            {
                foreach (var item2 in item.Controls.OfType<Button>())
                {
                    if (item2.ContextMenuStrip != null)
                    {
                        foreach (ToolStripItem item3 in item2.ContextMenuStrip.Items)
                        {
                            if (item3 == stripitem)
                            {
                                //MessageBox.Show(item.Controls.OfType<Label>().First().Text);
                                panel2.Controls.Remove(item);
                                trello.DeleteRow(id, Convert.ToInt32(item.Name));
                                DrawRows(trello.getBoardId(id));
                            }
                        }
                    }
                }
            }
        }

        private void İtem1_Click(object sender, EventArgs e)
        {
            var stripitem = sender as ToolStripItem;
            foreach (var item in panel2.Controls.OfType<Panel>())
            {
                foreach (var item2 in item.Controls.OfType<Button>())
                {
                    if (item2.ContextMenuStrip != null)
                    {
                        foreach (ToolStripItem item3 in item2.ContextMenuStrip.Items)
                        {
                            if (item3 == stripitem)
                            {
                                //MessageBox.Show(item.Controls.OfType<Label>().First().Text);
                                EnterName enterName = new EnterName();
                                enterName.ShowDialog();
                                item.Controls.OfType<Label>().First().Text = EnterName.name;
                                trello.ChangeRowName(trello.getBoardId(id), EnterName.name, Convert.ToInt32(item.Name));
                            }
                        }
                    }
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            EnterName name = new EnterName();
            name.ShowDialog();
            trello.addRow(id, EnterName.name);
            DrawRows(trello.getBoardId(id));
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
