using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using pc2_web_repaso.Sale.Application.Internal.CommandServices;
using pc2_web_repaso.Sale.Application.Internal.QueryServices;
using pc2_web_repaso.Sale.Domain.Repositories;
using pc2_web_repaso.Sale.Domain.Services;
using pc2_web_repaso.Sale.Infrastructure.Persistence.EFC.Repositories;
using pc2_web_repaso.Shared.Domain.Repositories;
using pc2_web_repaso.Shared.Infrastructure.Persistence.EFC.Configuration;
using pc2_web_repaso.Shared.Infrastructure.Persistence.EFC.Repositories;
using pc2_web_repaso.Shared.Interfaces.ASP.Configuration;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers( options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));
// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels
builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (connectionString == null) return;
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error)
            .EnableDetailedErrors();
});
// Configure Lowercase Urls
builder.Services.AddRouting(options => options.LowercaseUrls = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo()
            {
                Title = "Cotton Knit 2 SAC.",
                Version = "v2",
                Description = "Cotton Knit 2",
                TermsOfService = new Uri("https://cottonknit.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = " Cotton Knit 2 SAC.",
                    Email = "contact@cottonknit.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
    });

// Configure Dependency Injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); 

// PurchaseOrder Bounded Context Injection Configuration
builder.Services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
builder.Services.AddScoped<IPurchaseOrderQueryService, PurchaseOrderQueryService>();
builder.Services.AddScoped<IPurchaseOrderCommandService, PurchaseOrderCommandService>();

var app = builder.Build();

// Verify Database Objects are Created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

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
