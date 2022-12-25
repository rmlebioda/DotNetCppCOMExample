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
        InterfaceType(ComInterfaceType.InterfaceIsIDispatch),
        Guid("61590327-F801-4DE0-ACB8-26684D2B02AC")
    ]
    public interface IComInterface1
    {
        void ICI1Test1();
        void ICI1Test2();
    }
}
