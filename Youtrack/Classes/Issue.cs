using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtrack.Classes
{
    public class Issue
    {
        // Standard Fields
        public string ProjectName { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }

        // Custom Fields 
        public List<Field> CustomFields { get; set; }

        public Issue()
        {
            CustomFields = new List<Field>();
        }
    }
}
