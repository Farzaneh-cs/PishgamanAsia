using Carpet.API;
using Carpet.Application;
using Carpet.Application.Common.Mapping;
using Carpet.DBContext;
using Carpet.Domain.UsersRoles;
using Carpet.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddCors(options => options.AddPolicy("AllowAll", option =>
{
    option.AllowAnyHeader();
    option.AllowAnyMethod();
    option.AllowAnyOrigin();
}));


builder.Services.AddApplication();
builder.Services.AddInfrastructure();


//builder.Services.AddAuthorization(options =>
//{
//    AuthorizationPolicies.AddCustomAuthorizationPolicies(options);
//});

AuthControl.SetBearerTokenSwagger(builder);
AuthControl.AddAuthentication(builder);

var app = builder.Build();
await SeedData.SeedUserRole(app);

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
