using gameServices.Services;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddSingleton<IApiIGDB>(new ApiRAWG(configuration.GetSection("ApiUrl").Value.ToString(), configuration.GetSection("ApiKey").Value.ToString()));
builder.Services.AddSingleton<IGameServices, GameServices>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
