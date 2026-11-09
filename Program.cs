using TemperatureBlazorApp.Services;

var options = new WebApplicationOptions
{
    Args = args,
    WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "wwwroot")
};

var builder = WebApplication.CreateBuilder(options);

// Добавляем поддержку компонентов Blazor Server для .NET 8
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Регистрация сервисов бизнес-логики
builder.Services.AddSingleton<TemperatureService>();
builder.Services.AddSingleton<AppDataService>();

var app = builder.Build();

// Настройка конвейера HTTP-запросов (Middleware)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Маппинг для .NET 8 с поддержкой интерактивности
app.MapRazorComponents<TemperatureBlazorApp.Components.App>()
    .AddInteractiveServerRenderMode();

app.Run();
