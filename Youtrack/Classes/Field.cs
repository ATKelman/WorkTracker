using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtrack.Classes
{
    public class Field
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public bool CanBeEmpty { get; set; }
    }
}
