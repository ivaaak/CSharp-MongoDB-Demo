using MongoCore.Domain.Model;
using MongoCore.Repository.Interface;
using System;

namespace MongoCore
{
    public class Demo
    {

        private readonly IMongoRepository mongoRepository;

        public Demo(IMongoRepository mongoRepository)
        {
            this.mongoRepository = mongoRepository;
        }

        public void DemoCall()
        {
            //Get records
            var records = mongoRepository.GetAll<UserModel>("Users");
            foreach (var item in records.Result)
            {
                Console.WriteLine($"{item.Id}: {item.FirstName}: {item.LastName} ");
                if (item.Address != null)
                {
                    Console.WriteLine(item.Address.City);
                }
            }

            //Read a record
            var userRecord = mongoRepository.GetById<UserModel>("8dcc7170-c154-407a-9a4e-f335c8fbd46e");

            //Update a record 
            userRecord.Result.BirthDate = new DateTime(1982, 10, 31, 0, 0, 0, DateTimeKind.Utc);
            var updatedAddress = new UserAddress()
            {
                City = "Sofia",
                StreetAddress = "Maria Luisa",
                PostCode = "1000",
                Country = "bg"
            };
            mongoRepository.Update<UserAddress>(userRecord.Id, updatedAddress);

            //Delete record
            mongoRepository.Delete<UserModel>(userRecord.Id);

            //Read data from object
            var nameRecords = mongoRepository.GetAll<UserModel>("Users");

            foreach (var item in records.Result)
            {
                Console.WriteLine($"{item.Id}: {item.FirstName}: {item.LastName} ");
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
