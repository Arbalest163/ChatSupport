using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder.Services);

var app = builder.Build();

Configure(app);

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddAutoMapper(config =>
    {
        config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
        config.AddProfile(new AssemblyMappingProfile(typeof(IChatSupportDbContext).Assembly));
    });
    services.AddApplication();
    services.AddPersistence(builder.Configuration);

    services.AddControllers().AddNewtonsoftJson(o =>
    {
        o.SerializerSettings.Converters.Add(new IsoDateTimeConverter());
    });
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
        string filePath = Path.Combine(AppContext.BaseDirectory,
            "ChatSupport.Api.xml");
        c.IncludeXmlComments(filePath);
    });
}

void Configure(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ChatSupportDbContext>();
        db.Migrate();
    }

    app.UseCustomExceptionHandler();
    //app.UseHttpsRedirection();

    app.MapControllers();
}