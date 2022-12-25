using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RmlComExample.ComPartialInheritanceTest
{
    [Guid("F3400CA1-8751-4EE2-A684-17630637E400")]
    [ComVisible(true)]
    public class PartialCom : IComPartial
    {
        public void ICI1Test1()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public void ICI1Test2()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public void ICI2Test1()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public void ICI2Test2()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public void ICI2Test3()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public void ICPartial1()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public void ICPartial2()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public void ICPartial3()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public void IE1Test()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public void IE2Test()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }
    }
}

