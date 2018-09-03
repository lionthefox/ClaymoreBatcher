using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ClaymoreBatcher
{
  public class BatchReader
  {
    public List<ParameterValuePair> ReadBatch(string batchPath)
    {
      var sr = new StreamReader(batchPath);
      var parameterValuePairs = new List<ParameterValuePair>();

      try
      {
        for (var i = 0; i < 6; i++)
        {
          sr.ReadLine();
        }

        string line;
        while ((line = sr.ReadLine()) != null)
        {
          line = line.Remove(0, 1);
          const char split = ' ';
          var substrings = line.Split(split);
          parameterValuePairs.Add(new ParameterValuePair(substrings[0], substrings[1]));
        }
      }

      catch (Exception exception)
      {
        MessageBox.Show("Failed to read batch.", "Error");
      }

      finally
      {
        sr.Close();
      }

      return parameterValuePairs;
    }
  }
}
