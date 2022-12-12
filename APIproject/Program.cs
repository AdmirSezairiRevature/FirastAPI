using BusinessLayer;
using RepoLayer;
namespace APIproject
{

    class Program
    {

        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //Adding our new the services to the container. This tells the compiler to create these objects.
            //Transient services are created every time they are requested from the service container. 
            //Scoped services are created once per HTTP request.
            //Singleton services are created when the program starts. Every subsequesnt call to it uses the same object.
            builder.Services.AddScoped<IRepoLayerClass, RepoLayerClass>();
            builder.Services.AddScoped<IBusinessClass, BusinessClass>();
            // builder.Services.AddSingleton<Logger, MyLogger>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

