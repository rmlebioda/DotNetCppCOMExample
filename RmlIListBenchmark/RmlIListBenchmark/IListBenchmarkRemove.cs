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
    public class IListBenchmarkRemove
    {
        [Params((int)1e1, (int)1e2, (int)1e3, (int) 1e4, (int)1e5)]
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
        public void Remove()
        {
            for (int i = IListCount - 2; i >= 0; i--)
            {
                List.Remove(i);
            }
            List.Remove(IListCount - 1);
            Trace.Assert(List.Count == 0);
        }

        [IterationCleanup]
        public void IterationCleanup()
        {
            List.Clear();
        }
    }
}
