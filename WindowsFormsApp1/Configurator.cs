using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ClaymoreBatcher
{
    public partial class Configurator : Form
    {
        public string Path { get; }
        public string NewPath { get; set; }
        private readonly Parameter[] _parameters;

        public Configurator(string path, Parameter[] par)
        {
            Path = path;
            _parameters = par;
            InitializeComponent();

            //Configurator
            Closed += Configurator_Closed;

            //comboBox1
            comboBox1.ValueMember = "Info";
            comboBox1.DisplayMember = "Name";
            comboBox1.DataSource = _parameters;

            //textBox2
            textBox2.Text = Path;

            //button1
            AcceptButton = button1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = comboBox1.SelectedValue.ToString();

            if (_parameters[comboBox1.SelectedIndex].Range == "Numbers")
            {
                richTextBox2.Text = "Any Number";
            }

            else if (_parameters[comboBox1.SelectedIndex].Range != null)
            {
                var range = _parameters[comboBox1.SelectedIndex].Range;
                var result = "";
                for (var i = 0; i < range.Length - 1; i++)
                {
                    result = result + range[i] + ", ";
                }

                result = result + range[range.Length - 1];
                richTextBox2.Text = result;
            }
            else
            {
                richTextBox2.Text = "A-Z & 0-9";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const string error = "Please insert a value.";
            const string header = "Empty Value";
            const string header1 = "Forbidden Value";
            const string error1 = "Inserted Value not allowed!";
            var range = _parameters[comboBox1.SelectedIndex].Range;
            if (string.IsNullOrEmpty(textBox1.Text)) MessageBox.Show(error, header);
            else if (range == null)
            {
                string[] row = {comboBox1.SelectedItem.ToString(), textBox1.Text};
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }

            else if (range == "Numbers") // HIER VERBESSERN
            {
                var valid = textBox1.Text.All(char.IsDigit);

                if(valid)
                {
                    string[] row = { comboBox1.SelectedItem.ToString(), textBox1.Text };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }

                else
                {
                    MessageBox.Show(error1, header1);
                }
            }

            else
            {
                var listRange = new List<string>();
                foreach (var c in range)
                {
                    listRange.Add(c.ToString());
                }

                var valid = (listRange.Contains(textBox1.Text));
                if (valid)
                {
                    string[] row = {comboBox1.SelectedItem.ToString(), textBox1.Text};
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
                else
                {
                    MessageBox.Show(error1, header1);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var sourceFile = System.IO.Path.Combine(NewPath ?? Path, "StartMiner.bat");
            var destFile = System.IO.Path.Combine(desktopPath, "StartMiner.bat");
            const string exe = "EthDcrMiner64.exe";
            const string header = "Batch file created!";
            const string msg = "The batch file (and a shortcut on your desktop) have been created.";
            string[] settings = new string[]
            {
                "setx GPU_FORCE_64BIT_PTR 0", "setx GPU_MAX_HEAP_SIZE 100", "setx GPU_USE_SYNC_OBJECTS 1",
                "setx GPU_MAX_ALLOC_PERCENT 100", "setx GPU_SINGLE_ALLOC_PERCENT 100"
            };

            var fs = new FileStream(NewPath == null ? Path + @"\StartMiner.bat" : NewPath + @"\StartMiner.bat",
                FileMode.Create, FileAccess.Write);
            var sw = new StreamWriter(fs);
            
            try
            {

                foreach (var s in settings)
                {
                    sw.WriteLine(s);
                }

                sw.WriteLine(exe);
                for (var i = 0; i < listView1.Items.Count; i++)
                {
                    sw.WriteLine("-" + listView1.Items[i].Text + " " + listView1.Items[i].SubItems[1].Text);
                }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                sw.Close();
                File.Copy(sourceFile, destFile, true);
                MessageBox.Show(msg, header);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() != DialogResult.OK) return;
                NewPath = folderDialog.SelectedPath;
                textBox2.Text = NewPath;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var markedItem = listView1.FocusedItem;
            listView1.Items.Remove(markedItem);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void Configurator_Closed(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
