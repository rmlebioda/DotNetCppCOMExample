using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RmlComExample.ComPropertyTest
{
    [
        ComVisible(true),
        InterfaceType(ComInterfaceType.InterfaceIsIDispatch),
        Guid("10DC2A47-0351-460A-AF24-E77C81F854C3")
    ]
    public interface IComPropertyTest
    {
        void Test();
        int State { get; set; }
        void Test2();
    }
}
