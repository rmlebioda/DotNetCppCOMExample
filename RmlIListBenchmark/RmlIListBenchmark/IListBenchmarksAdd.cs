using BenchmarkDotNet.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmlIListBenchmark
{
    [MemoryDiagnoser]
    public class IListBenchmarksAdd
    {
        [Params((int)1e1, (int)1e2, (int)1e3, (int)1e5, (int)1e6, (int)1e7)]
        public int IListCount;

        [ParamsSource(nameof(ValuesForList))]
        public IList<int> List;

        public IEnumerable<IList<int>> ValuesForList => BenchmarkRun.IListTypes;

        [IterationCleanup]
        public void IterationCleanup()
        {
            List.Clear();
        }

        [Benchmark]
        public void Add()
        {
            for (int i = 0; i < IListCount; i++)
            {
                List.Add(i);
            }
        }
    }
}
