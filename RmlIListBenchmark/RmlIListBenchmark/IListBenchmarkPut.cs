using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmlIListBenchmark
{
    [MemoryDiagnoser]
    public class IListBenchmarkPut
    {
        [Params((int)1e1, (int)1e2, (int)1e3, (int) 1e4, (int)1e5, (int)1e6, (int)1e7)]
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
        public void Put()
        {
            for (int i = 0; i < IListCount; i++)
            {
                List[i] = i + 1;
            }
        }

        [IterationCleanup]
        public void IterationCleanup()
        {
            List.Clear();
        }
    }
}
