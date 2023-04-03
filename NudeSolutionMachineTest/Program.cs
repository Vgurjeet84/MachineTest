using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using NudeSolutionMachineTest.Class;
using NudeSolutionMachineTest.Data;
using NudeSolutionMachineTest.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICategory, Category>();

builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<MachineTestDbContext>(Options =>
Options.UseSqlServer(builder.Configuration.GetConnectionString("MachineTestConnectionString"))
);

builder.Services.AddControllersWithViews()
           .AddNewtonsoftJson(options =>
           {
               options.SerializerSettings.ContractResolver = new DefaultContractResolver();
           });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();

app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin() );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); 

app.Run();
