namespace Project.Domain.AccountDomain {
    public class AccountAddress {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Detailedaddress { get; set; }
    }
}