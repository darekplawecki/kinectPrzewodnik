using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przewodnik.Utilities.DataLoader
{
    class DataLoaderEventArgs : EventArgs
    {
        public int Many { get; private set; }
        public int Of { get; private set; }

        public DataLoaderEventArgs(int many, int of)
        {
            Many = many;
            Of = of;
        }


    }
}
