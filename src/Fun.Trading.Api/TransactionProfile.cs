using Fun.Trading.Infrastructure.Database.DatabaseModel;
using Mapster;
using Shared.Transactions;

public class TransactionProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {

        if (config == null) throw new ArgumentNullException(nameof(config));

        // Simple mapping: Mapster maps matching properties by name automatically.
        config.NewConfig<DbTransaction, Transaction>();
    }
}
