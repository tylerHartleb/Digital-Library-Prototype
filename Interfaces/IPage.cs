using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC_481_Digital_Library_Prototype.Interfaces
{
    public interface IPage
    {
        public string Name { get; set; }

        public abstract void ReDrawContent();
    }
}
