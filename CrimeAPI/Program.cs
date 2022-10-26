var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("MongoDb"));
builder.Services.AddCustomServices();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCustomCors();
builder.Services.AddCustomMiddlewares();
builder.Services.AddHttpClient();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
