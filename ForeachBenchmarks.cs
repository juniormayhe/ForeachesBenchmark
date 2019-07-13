namespace ForeachVsLINQForEachVsUnityForEach
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Order;
    using ForeachVsLINQForEachVsUnityForEach.Models;
    using System.Collections.Generic;

    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class ForeachBenchmarks
    {
        List<int> requestMerchantStockPoints;
        Address deliveryAddress;

        [GlobalSetup]
        public void GlobalSetup()
        {
            requestMerchantStockPoints = new List<int>() { 9945, 10144 };
            deliveryAddress = new Address { Id = 1, CountryId = 121, ZipCode = "3333-333" };
        }

        [Benchmark(Baseline = true)]
        public void RegularForeach()
        {
            PathBuilder.BuildPathsWithRegularForeach(requestMerchantStockPoints, 89, deliveryAddress, "EUR", isHazmat: false);
        }

        [Benchmark]
        public void CollectionForeach()
        {
            PathBuilder.BuildPathsWithCollectionForEach(requestMerchantStockPoints, 89, deliveryAddress, "EUR", isHazmat: false);
        }

        [Benchmark]
        public void UnityForeach()
        {
            PathBuilder.BuildPathsWithUnityForEach(requestMerchantStockPoints, 89, deliveryAddress, "EUR", isHazmat: false);
        }

        [Benchmark]
        public void ParallelForeach()
        {
            PathBuilder.BuildPathsWithParallelForeach(requestMerchantStockPoints, 89, deliveryAddress, "EUR", isHazmat: false);
        }
    }
}