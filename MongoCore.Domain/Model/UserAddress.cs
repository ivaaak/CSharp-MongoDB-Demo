namespace MongoCore.Domain.Model
{
    public class UserAddress
    {
        public string UserName { get; set; }

        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }

        public string Country { get; set; }
    }
}
