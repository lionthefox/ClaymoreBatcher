using System;
using System.Collections;
using System.Collections.Generic;

namespace ClaymoreBatcher
{
    public class Parameter : IEnumerable<char>
    {
        public string Name { get; set; }
        public string Info { get; set; }
        public string Range { get; set; }

        public Parameter(string name, string info)
        {
            Name = name;
            Info = info;
        }

        public Parameter(string name, string info, string range)
        {
            Name = name;
            Info = info;
            Range = range;

        }

        public override string ToString()
        {
            return Name;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<char> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
