using Fun.Trading.Api.Configurations;
using Fun.Trading.Infrastructure.Database.Repository;
using Microsoft.EntityFrameworkCore;
using Mapster;
using MapsterMapper;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureAuthServices(builder.Configuration);

builder.Services.AddDbContext<AppDbContext>(opts => opts.UseSqlite("Data Source=Trading.db"));

builder.Services.AddScoped<ITickerRepository, TickerRepository>();
builder.Services.AddScoped<IAcountRepository, AccountRepository>();

// Register Mapster TypeAdapterConfig and Mapster IMapper (ServiceMapper).
// This will scan the current assembly for any IRegister implementations (Mapster "Registers").
var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
typeAdapterConfig.Scan(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton(typeAdapterConfig);

builder.Services.AddScoped<IMapper, Mapper>();

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
