using CSharpEgitimKampi601.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi601.Services
{
    public class CustomerOperations
    {
        public void AddCustomer(Customer customer)
        {
            // Add customer to database
            var connection = new MongoDbConnection();
            var customerCollection = connection.GetCustomersCollection();

            var document = new BsonDocument
            {
                { "Firstname", customer.Firstname },
                { "Lastname", customer.Lastname },
                { "City", customer.City },
                { "Balance", customer.Balance },
                { "ShoppingCount", customer.ShoppingCount }
            };

            customerCollection.InsertOne(document);
        }
        public void UpdateCustomer(string id)
        {
            // Update customer in database
            //var connection = new MongoDbConnection();
            //var customerCollection = connection.GetCustomersCollection();

            //var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(txt_id));
            //var update = Builders<BsonDocument>.Update.Set("Balance", 1000);
            //customerCollection.InsertOne(filter, update);

        }
        public void DeleteCustomer(string email)
        {
            // Delete customer from database
        }
        public void GetCustomer(string email)
        {
            // Get customer from database
        }
    }
}
