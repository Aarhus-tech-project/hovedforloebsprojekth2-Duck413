using CollectionManagerApi.Data;
using CollectionManagerApi.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
// Services 
builder.Services.AddScoped<CollectionService>();
builder.Services.AddScoped<ItemService>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendOnly", policy =>
    {
        //policy.WithOrigins("http://www.gr02.prog.skylab.academy")
       policy.WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
// Login
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});
builder.Services.AddAuthorization();
//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// DbContext: use SQL Server when a connection string is provided; otherwise use InMemory for Development
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (!string.IsNullOrWhiteSpace(connectionString))
{
    builder.Services.AddDbContext<MyDbContext>(options =>
        options.UseSqlServer(connectionString));
}
else if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<MyDbContext>(options =>
        options.UseInMemoryDatabase("Dev_CollectionManager"));
}
else
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' was not found. In non-development environments a valid connection string is required.");
}


var app = builder.Build();


//Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseCors("FrontendOnly");

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => Results.Redirect("/swagger/index.html"));

// Apply pending migrations (if any) at startup for the SQL Server provider.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var db = services.GetRequiredService<MyDbContext>();
        if (db.Database.IsRelational())
        {
            var migrations = db.Database.GetMigrations();
            if (migrations.Any())
            {
                db.Database.Migrate();
            }
            else
            {
                var logger = services.GetService<ILogger<Program>>();
                logger?.LogInformation("No EF Core migrations were found; skipping database migration.");
            }
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetService<ILogger<Program>>();
        logger?.LogError(ex, "An error occurred while migrating or initializing the database.");
        // In a production scenario you might want to re-throw to fail-fast.
    }
}

app.Run();
