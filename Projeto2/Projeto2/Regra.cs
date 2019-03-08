using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2
{
    class Regra
    {
        private string Sucessor;
        private string Predecessor;

        public string predecessor
        {
            get
            {
                return Predecessor;
            }
            set
            {
                Predecessor = value;
            }
        }
        public string sucessor
        {
            get
            {
                return Sucessor;
            }
            set
            {
                Sucessor = value;
            }
        }
    }
}
