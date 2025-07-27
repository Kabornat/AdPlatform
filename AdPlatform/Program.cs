using AdPlatform;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<AdPlatformRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var adPlatformRepository = app.Services.GetRequiredService<AdPlatformRepository>();
await adPlatformRepository.LoadFromFileAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
