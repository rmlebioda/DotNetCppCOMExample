using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RmlComExample.ComPartialInheritanceTest
{
    [
        ComVisible(true),
        InterfaceType(ComInterfaceType.InterfaceIsIDispatch)
    ]
    public partial interface IComPartial : IComInterface1, IExampleInterface1, IExampleInterface2
    {
        void ICPartial1();
        void ICPartial3();
    }
}
