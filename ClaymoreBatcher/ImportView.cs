using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClaymoreBatcher
{
  public partial class ImportView : Form
  {
    private readonly string _batchPath;

    public ImportView()
    {
      InitializeComponent();    
    }

    public ImportView(string batchPath)
    {
      InitializeComponent();
      _batchPath = batchPath;
      var batchReader = new BatchReader();
      var parameterValuePairs = batchReader.ReadBatch(_batchPath);

      foreach (var parameterValuePair in parameterValuePairs)
      {
        string[] row = { parameterValuePair.Parameter, parameterValuePair.Value };
        var listViewItem = new ListViewItem(row);
        listView1.Items.Add(listViewItem);
      }
    }
  }
}
