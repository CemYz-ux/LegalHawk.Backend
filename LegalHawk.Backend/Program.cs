using LegalHawk.Backend.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetEntryAssembly()!.GetName().Name!}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddScoped<ISieveProcessor, SieveProcessor>();

builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddScoped<DatabaseContextSeeder>();

builder.Services.AddScoped<ILegalContractService, LegalContractService>();

builder.Services.AddMvc(options =>
{
    options.Filters.Add(typeof(ExceptionHandlerAttribute));
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await SeedDatabaseOnceAsync(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static async Task SeedDatabaseOnceAsync(WebApplication app)
{
    var scope = app.Services.CreateScope();
    {
        var initialiser = scope.ServiceProvider.GetRequiredService<DatabaseContextSeeder>();
        await initialiser.SeedAsync();
    }
}