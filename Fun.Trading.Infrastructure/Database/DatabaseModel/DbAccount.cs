using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fun.Trading.Infrastructure.Database.DatabaseModel
{
    public class DbAccount
    {
        [Key]
        public int AccountId { get; set; }
        public int OwnerId { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
    }
}
