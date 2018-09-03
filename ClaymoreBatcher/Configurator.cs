using System;
using System.Windows.Forms;

namespace ClaymoreBatcher
{
  public partial class Configurator : Form
  {
    private readonly string _path;
    private readonly Parameter[] _parameters;
    public string NewPath { get; set; }

    public Parameter SelectedParameter
    {
      get { return _parameters[comboBox1.SelectedIndex]; }
    }

    public Configurator()
    {
      InitializeComponent();

      //Configurator
      Closed += Configurator_Closed;

      //comboBox1
      comboBox1.ValueMember = "Info";
      comboBox1.DisplayMember = "Name";
      comboBox1.DataSource = _parameters;

      //textBox2
      textBox2.Text = _path;

      //button1
      AcceptButton = button1;
    }

    public Configurator(string path, Parameter[] parameters)
    {
      _path = path;
      _parameters = parameters;
      InitializeComponent();

      //Configurator
      Closed += Configurator_Closed;

      //comboBox1
      comboBox1.ValueMember = "Info";
      comboBox1.DisplayMember = "Name";
      comboBox1.DataSource = _parameters;

      //textBox2
      textBox2.Text = _path;

      //button1
      AcceptButton = button1;
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      richTextBox1.Text = comboBox1.SelectedValue.ToString();
      var rangeHandler = new RangeHandler(SelectedParameter);
      rangeHandler.ShowRange(comboBox1, richTextBox2);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      var rangeHandler = new RangeHandler(textBox1.Text, SelectedParameter);
      rangeHandler.AddParam(comboBox1, listView1, richTextBox2);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      var fileCreator = new FileCreator(_path, NewPath, listView1);
      fileCreator.CreateFile();
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
