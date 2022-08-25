using FaktureAPI;
using FaktureAPI.Data;
using Microsoft.EntityFrameworkCore;


var corsPolicy = "CorsPolicy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureRepositoryWrapper();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(    
        o => o.UseNpgsql(builder.Configuration.GetConnectionString("POSDb"))
    );


builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: corsPolicy,
        policy =>
        {
            policy.WithOrigins("http://localhost:7069")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
