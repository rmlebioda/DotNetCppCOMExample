using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RmlComExample
{
    [
        ComVisible(true),
        //InterfaceType(ComInterfaceType.InterfaceIsIDispatch),
        InterfaceType(ComInterfaceType.InterfaceIsIDispatch),
        Guid("08CED5FB-285D-4167-93CE-1E7376C35FD5")
    ]
    public interface IDevice
    {
        void Test(ref DeviceData structurePointer);
        void Test2(ref StructurePointer<DeviceData> structurePointer);
        void Test3([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructurePointerMarshaller), MarshalCookie = "RmlComExample.DeviceData, RmlComExample")] StructurePointer<DeviceData> structurePointer);
    }
}

