using AutoMapper;
using Fun.Trading.Api.Configurations;
using Fun.Trading.Api.Controllers.YourNamespace.Controllers;
using Fun.Trading.Infrastructure.Database.DatabaseModel;
using Fun.Trading.Infrastructure.Database.Repository;
using Microsoft.EntityFrameworkCore;
using Shared.Transactions;
using System;
using System.Linq.Expressions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureAuthServices(builder.Configuration);

builder.Services.AddDbContext<AppDbContext>(opts => opts.UseSqlite("Data Source=Trading.db"));

builder.Services.AddScoped<ITickerRepository, TickerRepository>();
builder.Services.AddScoped<IAcountRepository, AccountRepository>();

builder.Services.AddAutoMapper(typeof(AccountProfile), typeof(TransactionProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<AccountRequest, DbAccount>()
            .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.OwnerId))
            .ForMember(dest => dest.AccountType, opt => opt.MapFrom(src => src.AccountType.ToString()))
            .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Balance));

        CreateMap<DbAccount, AccountResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.Id))
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
