using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ClaymoreBatcher
{
  class RangeHandler
  {
    public string Text { get; set; }
    public Parameter SelectedParameter;

    public RangeHandler(Parameter selectedParameter)
    {
      SelectedParameter = selectedParameter;
    }

    public RangeHandler(string text, Parameter selectedParameter)
    {
      Text = text;
      SelectedParameter = selectedParameter;
    }

    public string Range
    {
      get { return SelectedParameter.Range; }
    }

    public RangeType RangeType
    {
      get { return SelectedParameter.RangeType; }
    }

    public void AddParam(ComboBox comboBox1, ListView listView1, RichTextBox richTextBox2)
    {
      const string error = "Please insert a value.";
      const string header = "Empty Value";
      const string header1 = "Forbidden Value";
      const string error1 = "Inserted Value not allowed!";
      switch (RangeType)
      {
        case 0: //Specified range allowed
          AddRegularParam(comboBox1, listView1, error, header, error1, header1);
          break;
        case (RangeType) 1: //Only Numbers allowed
          AddNumberParam(comboBox1, listView1, error, header, error1, header1);
          break;
        case (RangeType) 2: //Specified range of numbers allowed and ","
          AddParamNumbersAndCommas(comboBox1, listView1, error, header, error1, header1);
          break;
        case (RangeType) 3: //Specified range allowed and "-"
          AddParamNegative(comboBox1, listView1, error, header, error1, header1);
          break;
        case (RangeType) 4: //Specified range allowed and "," and "-"
          AddParamNegativeCommas(comboBox1, listView1, error, header, error1, header1);
          break;
        case (RangeType) 5: //Anything is allowed
          AddParamNoRange(comboBox1, listView1, error, header, error1, header1);
          break;
      }
    }

    public void ShowRange(ComboBox comboBox1, RichTextBox richTextBox2)
    {
      switch (RangeType)
      {
        case 0: //Specified range allowed
          ShowRangeRegular(richTextBox2);
          break;
        case (RangeType) 1: //Only Numbers allowed
          richTextBox2.Text = "Any positive number";
          break;
        case (RangeType) 2: //Specified range of numbers allowed and ","
          ShowRangeAndCommas(richTextBox2);
          break;
        case (RangeType) 3: //Specified range allowed and "-"
          ShowRangeNegative(richTextBox2);
          break;
        case (RangeType) 4: //Specified range allowed and "," and "-"
          ShowRangeNegativeAndCommas(richTextBox2);
          break;
        case (RangeType) 5: //Anything is allowed
          richTextBox2.Text = "Anything but special characters";
          break;
      }
    }

    private void ShowRangeNegativeAndCommas(RichTextBox richTextBox2)
    {
      var minuses4 = Range.LastIndexOf("-") - 1;
      var result4 = "-" + Range[1] + ", ";
      for (var i = 2; i < minuses4 + 2; i = i + 2)
      {
        result4 = result4 + Range[i] + Range[i + 1] + ", ";
      }

      for (var i = minuses4 + 3; i < Range.Length - 1; i++)
      {
        result4 = result4 + Range[i] + ", ";
      }

      result4 = result4 + Range[Range.Length - 1];
      result4 = result4.Remove(result4.Length - 1);
      richTextBox2.Text = result4 + "and commas";
    }

    private void ShowRangeNegative(RichTextBox richTextBox2)
    {
      var minuses3 = Range.LastIndexOf("-") - 1;
      var result3 = "-" + Range[1] + ", ";
      for (var i = 2; i < minuses3 + 2; i = i + 2)
      {
        result3 = result3 + Range[i] + Range[i + 1] + ", ";
      }

      for (var i = minuses3 + 3; i < Range.Length - 1; i++)
      {
        result3 = result3 + Range[i] + ", ";
      }

      result3 = result3 + Range[Range.Length - 1];
      richTextBox2.Text = result3;
    }

    private void ShowRangeAndCommas(RichTextBox richTextBox2)
    {
      var result2 = "";
      for (var i = 0; i < Range.Length - 1; i++)
      {
        result2 = result2 + Range[i] + ", ";
      }

      result2 = result2 + Range[Range.Length - 1];
      richTextBox2.Text = result2 + " and commas";
    }

    private void ShowRangeRegular(RichTextBox richTextBox2)
    {
      var result0 = "";
      for (var i = 0; i < Range.Length - 1; i++)
      {
        result0 = result0 + Range[i] + ", ";
      }

      result0 = result0 + Range[Range.Length - 1];
      richTextBox2.Text = result0;
    }

    private void AddParamNoRange(ComboBox comboBox1, ListView listView1, string error, string header, string error1,
      string header1)
    {
      var regex = new Regex("^[a-zA-Z0-9 ]*$");
      if (string.IsNullOrEmpty(Text)) //FIX
      {
        MessageBox.Show(error, header);
        return;
      }
      else if (!regex.IsMatch(Text))
      {
        MessageBox.Show(error1, header1);
        return;
      }

      {
        string[] row4 = {comboBox1.SelectedItem.ToString(), Text};
        var listViewItem4 = new ListViewItem(row4);
        listView1.Items.Add(listViewItem4);
      }
    }

    private void AddParamNegativeCommas(ComboBox comboBox1, ListView listView1, string error, string header,
      string error1, string header1)
    {
      if (string.IsNullOrEmpty(Text))
      {
        MessageBox.Show(error, header);
      }
      else
      {
        var valid4 = true;
        var listRange = new List<string>() {",", "-"};
        foreach (var c in Range)
        {
          listRange.Add(c.ToString());
        }

        foreach (var c in Text)
        {
          if (!valid4) break;
          foreach (var t in listRange)
          {
            if (t.Contains(c))
            {
              valid4 = true;
              break;
            }

            valid4 = false;
          }
        }

        if (valid4)
        {
          string[] row = {comboBox1.SelectedItem.ToString(), Text};
          var listViewItem = new ListViewItem(row);
          listView1.Items.Add(listViewItem);
        }
        else
        {
          MessageBox.Show(error1, header1);
        }
      }
    }

    private void AddParamNegative(ComboBox comboBox1, ListView listView1, string error, string header, string error1,
      string header1)
    {
      if (string.IsNullOrEmpty(Text))
      {
        MessageBox.Show(error, header);
      }
      else
      {
        var listRange = new List<string>() {"-"};
        var valid3 = true;
        foreach (var c in Range)
        {
          listRange.Add(c.ToString());
        }

        foreach (var c in Text)
        {
          if (!valid3) break;
          foreach (var t in listRange)
          {
            if (t.Contains(c))
            {
              valid3 = true;
              break;
            }

            valid3 = false;
          }
        }

        if (valid3)
        {
          string[] row = {comboBox1.SelectedItem.ToString(), Text};
          var listViewItem = new ListViewItem(row);
          listView1.Items.Add(listViewItem);
        }
        else
        {
          MessageBox.Show(error1, header1);
        }
      }
    }

    private void AddParamNumbersAndCommas(ComboBox comboBox1, ListView listView1, string error, string header,
      string error1, string header1)
    {
      if (string.IsNullOrEmpty(Text))
      {
        MessageBox.Show(error, header);
      }
      else
      {
        var valid2 = true;
        var listRange = new List<string>() {","};
        foreach (var c in Range)
        {
          listRange.Add(c.ToString());
        }

        foreach (var c in Text)
        {
          if (!valid2) break;
          foreach (var t in listRange)
          {
            if (t.Contains(c))
            {
              valid2 = true;
              break;
            }

            valid2 = false;
          }
        }

        if (valid2)
        {
          string[] row = {comboBox1.SelectedItem.ToString(), Text};
          var listViewItem = new ListViewItem(row);
          listView1.Items.Add(listViewItem);
        }
        else
        {
          MessageBox.Show(error1, header1);
        }
      }
    }

    private void AddNumberParam(ComboBox comboBox1, ListView listView1, string error, string header, string error1,
      string header1)
    {
      if (string.IsNullOrEmpty(Text))
      {
        MessageBox.Show(error, header);
      }
      else
      {
        var valid1 = Text.All(char.IsDigit);
        if (valid1)
        {
          string[] row1 = {comboBox1.SelectedItem.ToString(), Text};
          var listViewItem1 = new ListViewItem(row1);
          listView1.Items.Add(listViewItem1);
        }
        else
        {
          MessageBox.Show(error1, header1);
        }
      }
    }

    private void AddRegularParam(ComboBox comboBox1, ListView listView1, string error, string header, string error1,
      string header1)
    {
      if (string.IsNullOrEmpty(Text))
      {
        MessageBox.Show(error, header);
      }
      else
      {
        var listRange = new List<string>();
        foreach (var c in Range)
        {
          listRange.Add(c.ToString());
        }

        var valid0 = listRange.Contains(Text);
        if (valid0)
        {
          string[] row = {comboBox1.SelectedItem.ToString(), Text};
          var listViewItem = new ListViewItem(row);
          listView1.Items.Add(listViewItem);
        }
        else
        {
          MessageBox.Show(error1, header1);
        }
      }
    }
  }
}
