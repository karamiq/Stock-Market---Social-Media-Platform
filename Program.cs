using api.Data;
using api.interfaces;
using api.repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;




var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.WebHost.UseUrls("http://*:3000");
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
}
);

var app = builder.Build();

// Auto-create tables in development (not for production)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
    db.Database.EnsureCreated();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    var urls = app.Urls.Any() ? string.Join(", ", app.Urls) : "http://localhost:3000";
    Console.WriteLine($"Swagger UI is available at: {urls}/swagger");
}
app.UseHttpsRedirection();
app.MapControllers();
app.Run();