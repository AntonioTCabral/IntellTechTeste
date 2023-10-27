using Microsoft.EntityFrameworkCore;
using QuickOrderApplication.Interfaces.Repositories;
using QuickOrderApplication.Interfaces.Services;
using QuickOrderApplication.Services;
using QuickOrderApplication.Services.SignalIR;
using QuickOrderInfrastructure.DataBase;
using QuickOrderInfrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

// inside ConfigureServices method
builder.Services.AddDbContext<QuickOrderContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<IDisheItemRepository, DisheItemRepository>();
builder.Services.AddScoped<IDisheItemService, DisheItemService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<OrderStatusHub>("/orderhub");
app.UseCors("AllowAllOrigins");
app.Run();