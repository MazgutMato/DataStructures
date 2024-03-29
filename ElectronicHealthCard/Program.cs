using ElectronicHealthCard;
using ElectronicHealthCard.Controllers;
using BlazorDownloadFile;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<PatientsController>();
builder.Services.AddSingleton<HospitalsController>();
builder.Services.AddSingleton<HospitalizationController>();
builder.Services.AddSingleton<InsuranceController>();

builder.Services.AddBlazorDownloadFile();

await builder.Build().RunAsync();
