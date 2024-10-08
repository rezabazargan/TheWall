using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheWall.Application.Model;
using TheWall.SQL;
using TheWall.Application;
using TheWall.Application.Contracts;

var builder = WebApplication.CreateBuilder(args);


builder.Services.RegisterApplication();
builder.Services.AddDbContext<IdentityDatabaseContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("IdentitySQl")));
builder.Services.AddAuthorization();

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<IdentityDatabaseContext>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/login",
    async (UsernamePasswordLoginModel req, ILoginProvider loginProvider, CancellationToken cancellationToken) =>
        await loginProvider.LoginAsync(req, cancellationToken));

app.MapPost("/register",
    async (RegisterRequest model, IRegisterHandler registerHandler, CancellationToken cancellationToken) =>
        await registerHandler.RegisterAsync(model, cancellationToken));

app.Run();