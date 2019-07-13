namespace ForeachVsLINQForEachVsUnityForEach.Models
{
    using System;

    public class Address : ICloneable
    {
        public int? Id { get; set; }

        public string CountryCode { get; set; }

        public int CountryId { get; set; }

        public int? CityId { get; set; }

        public int? StateId { get; set; }

        public string ZipCode { get; set; }

        public string ZipCodeTruncated { get; set; }

        public override bool Equals(object obj)
        {
            Address address = obj as Address;

            if (address == null)
            {
                return false;
            }

            return this.Equals(address);
        }

        public bool Equals(Address address)
        {
            if (this.Id.HasValue && address.Id.HasValue)
            {
                return this.Id == address.Id;
            }

            return this.CountryCode == address.CountryCode
                && this.CountryId == address.CountryId
                && this.CityId == address.CityId
                && this.StateId == address.StateId
                && this.ZipCode == address.ZipCode;
        }

        public override int GetHashCode()
        {
            return this.Id ?? (this.CountryCode, this.CountryId, this.CityId, this.StateId, this.ZipCode).GetHashCode();
        }

        #region ICloneable members

        public object Clone()
        {
            return (Address)this.MemberwiseClone();
        }

        #endregion ICloneable members
    }
}
