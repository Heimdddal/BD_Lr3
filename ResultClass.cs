using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_Lr3
{
    internal class ResultClass
    {
        public BitcoinPrice cours { get; set; }

        public ResultClass(BitcoinPrice cours)
        {
            this.cours = cours;
        }
    }
}
