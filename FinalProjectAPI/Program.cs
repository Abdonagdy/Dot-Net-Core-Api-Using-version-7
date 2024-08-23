using Application;
using Application.Contracts;
using Application.Contracts.Addresses;
using Application.Contracts.OrderDetailss;
using Application.Contracts.Orders;
using Application.Contracts.ShoppingMethods;
using Application.Contracts.User;
using Application.Contracts.UserAddresses;
using Application.Contracts.Wishlist;
using Application.Features.ShoppingMethods.Queries.GetAllShoppingMethods;
using DbContextL;
using Domian;
using Dtos.ConfigSMTPEmail;
using Dtos.EmailServices;
using FinalProjectAPI.EmailTemplate;
using FluentValidation;
using InfraStructure;
using InfraStructure.Addresses;
using InfraStructure.Helpers;
using InfraStructure.OrderDetailses;
using InfraStructure.Orders;
using InfraStructure.ShoppingMethods;
using InfraStructure.UserAddresses;
using InfraStructure.Users;
using InfraStructure.Wishlists;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);











///B
builder.Services.Configure<Jwt>(builder.Configuration.GetSection("JWT"));

builder.Services.AddDbContext<Context>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Dbconnectionstring")));
//builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;



});
builder.Services.AddIdentity<User, Role>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<Context>()
  .AddDefaultTokenProviders();
builder.Services.Configure<DataProtectionTokenProviderOptions>(options => options.TokenLifespan = TimeSpan.FromHours(10));
builder.Services.AddMediatR(config =>
{ config.RegisterServicesFromAssembly(typeof(GetAllShoppingMethodsHandler).Assembly); });
//Email

builder.Services.Configure<SMTPConfigModel>(builder.Configuration.GetSection("SMTPConfig"));


builder.Services.AddScoped<IEmailService, EmailService>();



builder.Services.AddValidatorsFromAssembly(typeof(GetAllShoppingMethodsHandler).Assembly);

///////////B
builder.Services.AddScoped<IUserAccountRepository, UserAccountRepository>();
builder.Services.AddScoped<IUserRepository, Userrepository>();

////////////////////
///Eyad
///
builder.Services.AddScoped<IShoppingMethod, ShoppingMethodRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserReviewRepository, UserReviewRepository>();
builder.Services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IUserAddressesRepository, UserAddressRepository>();
builder.Services.AddScoped<IWishlistRepository, WishlistRepository>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<Jwt>();

builder.Services.AddCors();
///////////////////

///////
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = false;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    ()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!))
    };
});





//"Data Source=DESKTOP-ONV4S7L;Initial Catalog=ASPDB;Integrated Security=True;MultipleActiveResultSets=True;encrypt=false"));
//builder.Configuration.GetConnectionString("Dbconnectionstring")));

//builder.Services.AddControllers();

var app = builder.Build();

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:4200","http://example.com","https://anglur1.mize.com.sa","https://localhost:5001/","https://mize.com.sa/","http://localhost:5145","http://sig.mize.sa/","http://sig.mize.sa")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
});

////
app.UseAuthentication();
app.UseAuthorization();
////

app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();
 