using InfrastuctureLayer.DbContexts;
using InfrastructureLayer.InfrastructureRegistration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region AddInfraStructureServies

builder.Services.AddInfraStructureServices();

#endregion

#region // Cors Config

builder.Services.AddCors(options =>
{

    options.AddPolicy("CustomerPolicy", x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

});

#endregion


builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(Options => Options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CustomerPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
