using System;
using System.Runtime.Serialization;

namespace ToSoftware.Shop.Catalog.Api.Messages
{
    [DataContract]
    public class ProductResponseMessage
    {
        [DataMember]
        public Guid Code { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public string FormattedPrice { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }
    }
}