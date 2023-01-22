using System.Reflection;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Services;
using ILeaveTypeService = HR.LeaveManagement.MVC.Contracts.ILeaveTypeService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<IClient, Client>(cl => cl.BaseAddress = new Uri("https://localhost:44348"));
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();
builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();
var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();