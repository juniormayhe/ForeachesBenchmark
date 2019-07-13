namespace ForeachVsLINQForEachVsUnityForEach
{
    using BenchmarkDotNet.Running;
    using System;

    static class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ForeachBenchmarks>();
            Console.ReadLine();
        }
    }
}
