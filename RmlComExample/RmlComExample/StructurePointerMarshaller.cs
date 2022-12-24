using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RmlComExample
{
    internal class StructurePointerMarshaller : ICustomMarshaler
    {
        private static ICustomMarshaler GetInstance(string pstrCookie)
        {
            if (!Instances.ContainsKey(pstrCookie))
                Instances.Add(pstrCookie, new StructurePointerMarshaller(pstrCookie));

            return Instances[pstrCookie];
        }
        private static readonly Dictionary<string, StructurePointerMarshaller> Instances = new Dictionary<string, StructurePointerMarshaller>();

        private readonly Type CookieType;
        private StructurePointerMarshaller(string pstrCookie)
        {
            Console.WriteLine(typeof(DeviceData).AssemblyQualifiedName);
            try
            {
                CookieType = Type.GetType(pstrCookie);
                if (CookieType is null)
                    throw new NullReferenceException();
            }
            catch (Exception e)
            {
                throw new MarshalDirectiveException($"Failed to find type of `{pstrCookie}`, make sure you can find this type with method Type.GetType(string) that is passable with MarshalCookie", e);
            }
        }

        public void CleanUpManagedData(object ManagedObj)
        {
            // nothing to do
        }

        public void CleanUpNativeData(IntPtr pNativeData)
        {
            // nothing to do
        }

        public int GetNativeDataSize()
        {
#if WIN32
            return 4;
#else
            return 8;
#endif
        }

        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            if (ManagedObj.GetType().GetGenericTypeDefinition() == typeof(StructurePointer<>))
            {
                return (IntPtr)typeof(StructurePointer<>).GetField("DeviceIdentifier").GetValue(ManagedObj);
            }

            throw new MarshalDirectiveException("Invalid ManagedObj passed to marshal to Native pointer, expected StructurePointer<T>");
        }

        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            Type repositoryType = typeof(StructurePointer<>).MakeGenericType(CookieType);
            return Activator.CreateInstance(repositoryType, new object[] { pNativeData });
        }
    }
}
