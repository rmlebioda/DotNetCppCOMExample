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
        Guid("73D59933-45DF-4A6C-894A-7D193C09290A")
    ]
    public interface IComInterface2
    {
        void ICI2Test1();
        void ICI2Test2();
        void ICI2Test3();
    }
}
