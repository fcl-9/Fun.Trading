using System.ComponentModel.DataAnnotations;

namespace Fun.Trading.Infrastructure.Database.DatabaseModel
{
    public class DbTransaction
    {
        [Key]
        public int Id { get; set; }
    }
}