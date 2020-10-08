using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace EFF_V1_0.Classes_EFF_V1_0
{
    class General_Classes
    {
        internal class Parameter
        {
            internal string Name { get; set; }            
            internal ParameterType Type { get; set; }            
            internal BuiltInParameterGroup BIPName { get; set; }
            internal bool Instance { get; set; }
            
            internal Parameter(string name, ParameterType type, BuiltInParameterGroup bIPName, bool instance)
            {
                Name = name;
                Type = type;
                BIPName = bIPName;
                Instance = instance;                
            }
            public override string ToString()
            {
                return $"{"{"}{Name}, {Type}, {BIPName}, {Instance}{"}"}";
            }
        }
        internal class SharedParameter : Parameter
        {            
            internal string GroupName { get; set; }          

            internal SharedParameter(string name, string groupName, ParameterType type, BuiltInParameterGroup bIPName, bool instance) : base(name, type, bIPName, instance)
            {
                GroupName = groupName;                
            }
            public override string ToString()
            {
                return $"{"{"}{Name}, {GroupName}, {Type}, {BIPName}, {Instance}{"}"}";
            }
        }
    }
}

