namespace ForeachVsLINQForEachVsUnityForEach.Models
{
    using System.Collections.Generic;

    public class ShippingInfo
    {
        public int ServiceType { get; set; }

        public IEnumerable<Cost> Costs { get; set; }

        public bool IsHazmat { get; set; }

        public int? CourierServiceId { get; set; }
    }
}
