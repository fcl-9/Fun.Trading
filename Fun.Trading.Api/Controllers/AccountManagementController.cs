namespace Fun.Trading.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;

    namespace YourNamespace.Controllers
    {
        [Route("api/accounts")]
        [ApiController]
        public class AccountController : ControllerBase
        {
            /// <summary>
            /// 
            /// </summary>
            /// <returns>Returns a list of user accounts</returns>
            /// <exception cref="NotImplementedException"></exception>
            [HttpGet]
            public IActionResult GetAccounts()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Returns details of a specific user account.</returns>
            /// <exception cref="NotImplementedException"></exception>
            [HttpGet("{id}")]
            public IActionResult GetAccount(int id)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Returns details of a specific user account.</returns>
            /// <exception cref="NotImplementedException"></exception>
            [HttpGet("{id}/balance")]
            public IActionResult GetAccountBalance(int id)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Returns a list of transactions for a specific user account.</returns>
            /// <exception cref="NotImplementedException"></exception>
            [HttpGet("{id}/transactions")]
            public IActionResult GetAccountTransactions(int id)
            {
                throw new NotImplementedException();
            }

        }
    }
}
