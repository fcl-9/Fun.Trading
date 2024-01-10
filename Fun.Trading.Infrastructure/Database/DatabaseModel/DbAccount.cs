using System.ComponentModel.DataAnnotations;

namespace Fun.Trading.Infrastructure.Database.DatabaseModel
{
    public class DbAccount
    {
        [Key]
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public IList<DbTransaction> Transactions { get; set; }
    }
}
