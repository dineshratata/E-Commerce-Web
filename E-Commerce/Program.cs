using InfrastuctureLayer.DbContexts;
using InfrastructureLayer.InfrastructureRegistration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ApplicationLayer.ServiceRegistration;
using InfrastructureLayer.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region AddInfraStructureServies

builder.Services.AddInfraStructureServices();

#endregion

#region // AddApplication Services 

builder.Services.AddApplicationServices();

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

#region // Configuration for DataSeed


 static async void UpdatadatabaseAsync(IHost host)
{

    using (var scope = host.Services.CreateScope())
    {

        var services = scope.ServiceProvider;


        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();

            if (context.Database.IsSqlServer())
            {
                context.Database.Migrate();


            }

            await SeedData.SeedDataAsync(context);


        }
        catch (Exception ex)
        {

            var logger = scope.ServiceProvider.GetRequiredService <ILogger<Program>>();

            logger.LogError(ex, "Error Occured");


           
        }

    }



}






#endregion


var app = builder.Build();
UpdatadatabaseAsync(app);

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
