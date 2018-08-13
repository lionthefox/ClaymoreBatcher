using System;
using System.Collections;
using System.Collections.Generic;

namespace ClaymoreBatcher
{
    public enum RangeType
    {
        Regular, //Specified range allowed
        Numbers, //Only Numbers allowed
        RangeAndCommas, //Specified range of numbers allowed and ","
        Negative, //Specified range allowed and "-"
        NegativeAndCommas, //Specified range allowed and "," and "-"
        NoRange, //Anything is allowed
        //TODO NumbersAndCommas (Any numbers and "-" allowed)
  }

    public class Parameter
    {
        public string Name { get; set; }
        public string Info { get; set; }
        public string Range { get; set; }

        public RangeType RangeType;

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

        public Parameter(string name, string info, RangeType rangeType)
        {
            Name = name;
            Info = info;
            RangeType = rangeType;

        }

        public Parameter(string name, string info, string range, RangeType rangeType)
        {
            Name = name;
            Info = info;
            Range = range;
            RangeType = rangeType;

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
