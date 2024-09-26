using Banana.UI.Components;
using Banana.UI.Mqtt;
using Banana.UI.Mqtt.Message;
using QuickKit.Blazor.Configuration;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRadzenCookieThemeService(options =>
{
    options.Name = "AmbiTrack";
    options.Duration = TimeSpan.FromDays(365);
});

builder.Services.AddSingleton<IMessageService, MessageService>();
builder.Services.AddSingleton<ConectarMqtt>();
builder.Services.AddBlazorSupport();
builder.Services.AddRadzenComponents();

builder.Services.AddScoped<ThemeService>();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

var conector = app.Services.GetRequiredService<ConectarMqtt>();
await conector.Conectar();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
