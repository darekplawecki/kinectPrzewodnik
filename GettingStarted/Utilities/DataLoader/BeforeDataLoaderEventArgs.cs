using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przewodnik.Utilities.DataLoader
{
    class BeforeDataLoaderEventArgs : EventArgs
    {
        public string Status { get; private set; }

        public BeforeDataLoaderEventArgs(string status)
        {
            Status = status;
        }


    }
}
