using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RmlComExample.ComPartialInheritanceTest
{
    [Guid("CC626F08-7041-4A4F-AFF3-1FF977F3BDD5")]
    public partial interface IComPartial : IComInterface2
    {
        void ICPartial2();
    }
}
