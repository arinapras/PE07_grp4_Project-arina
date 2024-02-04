using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PE07_grp4_Project.Client;
using PE07_grp4_Project.Client.Services;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

/*builder.Services.AddHttpClient("PE07_grp4_Project.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();*/

builder.Services.AddHttpClient("PE07_grp4_Project.ServerAPI", (sp, client) => { 
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress); 
    client.EnableIntercept(sp); })
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("PE07_grp4_Project.ServerAPI"));

builder.Services.AddHttpClientInterceptor();
builder.Services.AddScoped<HttpInterceptorService>();

builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
