namespace ForeachVsLINQForEachVsUnityForEach.Models
{
    public class Track
    {
        public int Position { get; set; }

        public Place Origin { get; set; }

        public Place Destination { get; set; }

        public ShippingInfo ShippingInfo { get; set; }

        public Track Clone()
        {
            return (Track)this.MemberwiseClone();
        }
    }
}
