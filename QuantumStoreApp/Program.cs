using QuantumStore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterServices();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});



builder.Services.AddAutoMapper(typeof(AssemblyMarker));

builder.Services.AddDatabaseContext(builder.Configuration);

var app = builder.Build();
app.UseCors("AllowAll");


// Configure the HTTP request pipeline.
app.ConfigurePipeline();

app.Run();
