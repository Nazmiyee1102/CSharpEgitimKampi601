using CSharpEgitimKampi601.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
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

        public List<Customer> GetAllCustomers()
        {
            var connection = new MongoDbConnection();
            var customerCollection = connection.GetCustomersCollection();
            var customers = customerCollection.Find(new BsonDocument()).ToList();
            List<Customer> customerList = new List<Customer>();
            foreach (var c in customers)
            {
                customerList.Add(new Customer
                {
                    CustomerId = c["_id"].ToString(),
                    Firstname = c["Firstname"].ToString(),
                    Lastname = c["Lastname"].ToString(),
                    City = c["City"].ToString(),
                    Balance = decimal.Parse(c["Balance"].ToString()),
                    ShoppingCount = int.Parse(c["ShoppingCount"].ToString())
                });
            }

            return customerList;
        }
        public void UpdateCustomer(Customer customer)
        {
            // Update customer in database
            var connection = new MongoDbConnection();
            var customerCollection = connection.GetCustomersCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(customer.CustomerId));//güncellenecek değeri filtreler
            var updatedValue = Builders<BsonDocument>.Update
                .Set("Firstname", customer.Firstname)
                .Set("Lastname", customer.Lastname)
                .Set("City", customer.City)
                .Set("Balance", customer.Balance)
                .Set("ShoppingCount", customer.ShoppingCount);
            customerCollection.UpdateOne(filter, updatedValue);

        }
        public void DeleteCustomer(string id)
        {
            // Delete customer from database
            var connection = new MongoDbConnection();
            var customerCollection = connection.GetCustomersCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));//silinecek değeri filtreler
            customerCollection.DeleteOne(filter);//silme işlemi yapar. mongodb de silme işlemini deleteone metodu yapar.
        }

        public Customer GetCustomerById(string id)
        {
            var connection = new MongoDbConnection();
            var customerCollection = connection.GetCustomersCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var customer = customerCollection.Find(filter).FirstOrDefault();
            return new Customer
            {
                CustomerId = customer["_id"].ToString(),
                Firstname = customer["Firstname"].ToString(),
                Lastname = customer["Lastname"].ToString(),
                City = customer["City"].ToString(),
                Balance = decimal.Parse(customer["Balance"].ToString()),
                ShoppingCount = int.Parse(customer["ShoppingCount"].ToString())
            };

        }
    }
}
