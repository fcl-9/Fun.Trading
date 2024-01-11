namespace Fun.Trading.Api.Controllers
{
    namespace YourNamespace.Controllers
    {

        public class AccountResponse
        {
            public int Id { get; set; }
            public int OwnerId { get; set; }
            public string AccountType { get; set; } = null!;
            public decimal Balance { get; set; }
        }
    }
}
