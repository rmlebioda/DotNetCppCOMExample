using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RmlIListBenchmark
{
    public static class BenchmarkRun
    {
        public static IEnumerable<IList<int>> IListTypes => new IList<int>[] { new List<int>() };

        public static void Main(string[] args)
        {
            BenchmarkRunner.Run(
                Assembly.GetExecutingAssembly(),
                ManualConfig
                    .Create(DefaultConfig.Instance)
                    .WithOption(ConfigOptions.JoinSummary, true)
                    .WithOption(ConfigOptions.StopOnFirstError, true)
            );
        }
    }
}
