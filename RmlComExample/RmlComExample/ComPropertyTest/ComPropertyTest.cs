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
        Guid("E3BE29B9-5DE6-44DF-8EFC-E58821236996")
    ]
    public class ComPropertyTest : IComPropertyTest
    {
        private int _state = 0;
        public int State
        {
            get => _state;
            set
            {
                Console.WriteLine("Passed value: " + value);
                _state = value;
            }
        }

        public void Test()
        {
            throw new NotImplementedException("Test()");
        }

        public void Test2()
        {
            throw new NotImplementedException("Test2()");
        }
    }
}
