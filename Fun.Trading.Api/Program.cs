using AutoMapper;
using Fun.Trading.Api.Accounts.Models;
using Fun.Trading.Api.Controllers.YourNamespace.Controllers;
using Fun.Trading.Api.DependencyInjectionConfigurations;
using Fun.Trading.Infrastructure.Database.DatabaseModel;
using Fun.Trading.StaticData.Infrastructure.Database.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureAuthServices(builder.Configuration);

builder.Services.AddDbContext<AppDbContext>(opts => opts.UseSqlite("Data Source=Trading.db"));

builder.Services.AddScoped<ITickerRepository, TickerRepository>();
builder.Services.AddScoped<IAcountRepository, AccountRepository>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<AccountProfile>();
    cfg.AddProfile<TransactionProfile>();
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<Account, DbAccount>()
            .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.OwnerId))
            .ForMember(dest => dest.AccountType, opt => opt.MapFrom(src => src.AccountType.ToString()))
            .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Balance));

        CreateMap<DbAccount, Account>()
            .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.OwnerId))
            .ForMember(dest => dest.AccountType, opt => opt.MapFrom(src => Enum.Parse<AccountType>(src.AccountType)))
            .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Balance));
    }
}

public class TransactionProfile : Profile
{
    public TransactionProfile()
    {
        CreateMap<DbTransaction, Transaction>();
    }
}
