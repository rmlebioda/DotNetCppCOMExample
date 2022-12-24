using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RmlComExample
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct StructurePointer
    {
        public IntPtr StructPointer;
    }

    public class StructurePointer<T>
    {
        public IntPtr StructPointer;

        public StructurePointer(IntPtr structPointer)
        {
            StructPointer = structPointer;
        }

        public T UnmanagedData => Marshal.PtrToStructure<T>(StructPointer);
    }
}
