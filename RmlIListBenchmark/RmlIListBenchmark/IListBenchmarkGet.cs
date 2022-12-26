using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmlIListBenchmark
{
    [MemoryDiagnoser]
    public class IListBenchmarkGet
    {
        [Params((int)1e1, (int)1e2, (int)1e3, (int) 1e4)]
        public int IListCount;

        [ParamsSource(nameof(ValuesForList))]
        public IList<int> List;

        public IEnumerable<IList<int>> ValuesForList => BenchmarkRun.IListTypes;

        [IterationSetup]
        public void IterationSetup()
        {
            for (int i = 0; i < IListCount; i++)
            {
                List.Add(i);
            }
        }

        [Benchmark]
        public void Get()
        {
            for (int i = 0; i < IListCount; i++)
            {
                Trace.Assert(1 == List.Count(element => element == i), "Unexpected number of elements in IList");
            }
        }

        [IterationCleanup]
        public void IterationCleanup()
        {
            List.Clear();
        }
    }
}
