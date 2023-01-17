using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentationAttribute.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.All)]
    public class DescriptionAttribute : Attribute
    {

        public string Description { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }

        public DescriptionAttribute(string description)
        {
            Description = description;
        }

        public DescriptionAttribute(string description, string input = "Input", string output = "Output")
        {
            Description = description;
            Input = input;
            Output = output;
        }


    }
}
