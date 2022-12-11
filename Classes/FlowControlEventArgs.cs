using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC_481_Digital_Library_Prototype.Classes
{
    public class FlowControlEventArgs : EventArgs
    {
        public string book { get; set; } = "";
        public string format { get; set; } = "";
    }
}
