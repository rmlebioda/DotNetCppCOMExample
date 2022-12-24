using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RmlComExample
{
    [
        ComVisible(true),
        ProgId("RmlComExample.Cellphone.0.1"),
        Guid("A0C1C523-8307-4CD5-8566-180A55914EEC")
    ]
    public class Cellphone : IDevice
    {
        public void Test(ref DeviceData deviceData)
        {
            Console.WriteLine("[Cellphone] Called Test with passed as address struct, device identifier: " + deviceData.DeviceIdentifier);
            //MessageBox.Show("[Cellphone] Called Test with pointer " + structurePointer.StructPointer.ToString("X"));
            throw new Exception("My own Exception() with custom message from method Test()");
        }

        public void Test2(ref StructurePointer<DeviceData> structurePointer)
        {
            Console.WriteLine("[Cellphone] Called Test2 with pointer " + structurePointer.StructPointer.ToString("X"));
            //MessageBox.Show("[Cellphone] Called Test2 with pointer " + structurePointer.StructPointer.ToString("X"));
        }

        public void Test3(StructurePointer<DeviceData> structurePointer)
        {
            Console.WriteLine("[Cellphone] Called Test3 with pointer " + structurePointer.StructPointer.ToString("X") + " and value: " + structurePointer.UnmanagedData.DeviceIdentifier);
            //MessageBox.Show("[Cellphone] Called Test3 with pointer " + structurePointer.StructPointer.ToString("X"));
        }
    }
}

