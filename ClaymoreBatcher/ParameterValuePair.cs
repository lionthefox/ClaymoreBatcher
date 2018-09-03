using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaymoreBatcher
{
  public class ParameterValuePair
  {
    public string Parameter { get; set; }
    public string Value { get; set; }

    public ParameterValuePair(string parameter, string value)
    {
      Parameter = parameter ?? throw new ArgumentNullException(nameof(parameter));
      Value = value ?? throw new ArgumentNullException(nameof(value));
    }

    public override string ToString()
    {
      return $"Paramerter:{Parameter}, Value:{Value}";
    }
  }
}
