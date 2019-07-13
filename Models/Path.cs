namespace ForeachVsLINQForEachVsUnityForEach.Models
{
    using System.Collections.Generic;

    public class Path
    {
        public int? StockPointId { get; set; }
        public List<Track> Itinerary { get; set; }
    }
}
