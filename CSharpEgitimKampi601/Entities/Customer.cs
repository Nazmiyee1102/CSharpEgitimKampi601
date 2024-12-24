using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi601.Entities
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerId { get; set; }//mongodb de ıd ler string olarak tutulur.

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string City { get; set; }

        public decimal Balance { get; set; }

        public int ShoppingCount { get; set; }
    }
}
