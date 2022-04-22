using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace StorageDB
{
    public class Products
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string ProductName { get; set; } = null!;

        [BsonElement("currentStatus")]
        public int CurrentStatus { get; set; }

        [BsonElement("dateEntry")]
        public int DateEntry { get; set; }
        [BsonElement("sku")]
        public string Sku { get; set; }
        [BsonElement("imgPath")]
        public string? ImgPath { get; set; }
        [BsonElement("existence")]
        public decimal Existence { get; set; }
        [BsonElement("idproduct")]
        public int Idproduct { get; set; }
        [BsonElement("unitPrice")]
        public decimal UnitPrice { get; set; }
    }
}
