using FetchDataBlazorAuto.Client.Pages;
using FetchDataBlazorAuto.Client.Services;
using FetchDataBlazorAuto.Components;
using FetchDataBlazorAuto.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddTransient<ISomeDataService, SomeDataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(FetchDataBlazorAuto.Client._Imports).Assembly);


app.MapGet("/api/fetch-data", async (ISomeDataService service) =>
{
    return TypedResults.Ok(await service.GetNumbersAsync());
});

app.Run();
