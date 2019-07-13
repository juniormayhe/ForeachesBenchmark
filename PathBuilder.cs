namespace ForeachVsLINQForEachVsUnityForEach
{
    using ForeachVsLINQForEachVsUnityForEach.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public static class PathBuilder
    {
        public static List<Path> BuildPathsWithUnityForEach(List<int> stockPoints, int deliveryType, Address deliveryAddress, string userCurrency, bool isHazmat)
        {
            var paths = new List<Path>();
            
            Unity.Interception.Utilities.EnumerableExtensions.ForEach(stockPoints, stockPointId => paths.Add(BuildPathForStockPoint(stockPointId, deliveryType, deliveryAddress, userCurrency, isHazmat)));

            return paths;
        }

        public static List<Path> BuildPathsWithCollectionForEach(List<int> stockPoints, int deliveryType, Address deliveryAddress, string userCurrency, bool isHazmat)
        {
            var paths = new List<Path>();

            stockPoints?.ForEach(stockPointId => paths.Add(BuildPathForStockPoint(stockPointId, deliveryType, deliveryAddress, userCurrency, isHazmat)));

            return paths;
        }

        public static List<Path> BuildPathsWithRegularForeach(List<int> stockPoints, int deliveryType, Address deliveryAddress, string userCurrency, bool isHazmat)
        {
            var paths = new List<Path>();

            foreach (int stockPointId in stockPoints)
            {
                paths.Add(BuildPathForStockPoint(stockPointId, deliveryType, deliveryAddress, userCurrency, isHazmat));
            }

            return paths;
        }

        public static List<Path> BuildPathsWithParallelForeach(List<int> stockPoints, int deliveryType, Address deliveryAddress, string userCurrency, bool isHazmat)
        {
            var paths = new List<Path>();

            ParallelOptions parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = 8
            };

            Parallel.ForEach(stockPoints, parallelOptions, stockPointId =>
            {
                paths.Add(BuildPathForStockPoint(stockPointId, deliveryType, deliveryAddress, userCurrency, isHazmat));
            });

            return paths;
        }

        private static Path BuildPathForStockPoint(int stockPointId, int deliveryType, Address deliveryAddress, string userCurrency, bool isHazmat)
        {
            Path path = new Path
            {
                StockPointId = stockPointId,
                Itinerary = BuildItineraryWithGenericOrigin(deliveryAddress, deliveryType, userCurrency, isHazmat)
            };

            return path;
        }

        private static List<Track> BuildItineraryWithGenericOrigin(Address deliveryAddress, int deliveryType, string userCurrency, bool isHazmat)
        {
            Track track = new Track
            {
                Destination = new Place
                {
                    CountryCode = deliveryAddress?.CountryCode,
                    ZipCode = deliveryAddress?.ZipCode,
                    CityId = deliveryAddress?.CityId,
                    IsGeneric = deliveryAddress == null
                },
                ShippingInfo = new ShippingInfo
                {
                    ServiceType = deliveryType,
                    Costs = new List<Cost> { new Cost() { Value = 0, CurrencyCode = userCurrency } },
                    IsHazmat = isHazmat
                },
                Position = 1
            };

            return new List<Track> { track };
        }

    }
}
