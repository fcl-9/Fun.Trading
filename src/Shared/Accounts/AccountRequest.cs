﻿namespace Fun.Trading.Api.Controllers
{
    namespace YourNamespace.Controllers
    {
        public class AccountRequest
        {
            public int OwnerId { get; set; }
            public AccountType AccountType { get; set; }
            public decimal Balance { get; set; }
        }
    }
}
