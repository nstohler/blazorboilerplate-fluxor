using Blazor.Fluxor;
using BlazorBoilerplate.Client.Services.Contracts;
using BlazorBoilerplate.Client.Services.Implementations;
using BlazorBoilerplate.Client.States;
using BlazorBoilerplate.Client.Store.Services;
using BlazorBoilerplate.Shared.AuthorizationDefinitions;
using MatBlazor;
using Microsoft.AspNetCore.Blazor.Http;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace BlazorBoilerplate.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorizationCore(config =>
            {
                config.AddPolicy(Policies.IsAdmin, Policies.IsAdminPolicy());
                config.AddPolicy(Policies.IsUser, Policies.IsUserPolicy());
                config.AddPolicy(Policies.IsReadOnly, Policies.IsUserPolicy());
               // config.AddPolicy(Policies.IsMyDomain, Policies.IsMyDomainPolicy());  Only works on the server end
            });

            services.AddFluxor(options =>
            {
                options.UseDependencyInjection(typeof(Startup).Assembly);
                options.AddMiddleware<Blazor.Fluxor.ReduxDevTools.ReduxDevToolsMiddleware>();
                options.AddMiddleware<Blazor.Fluxor.Routing.RoutingMiddleware>();
                options.AddMiddleware<ComponentNotifierMiddleware>();
                //options.AddReactiveStore(services);
            });

            services.AddScoped<IdentityAuthenticationStateProvider>();
            services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<IdentityAuthenticationStateProvider>());
            services.AddScoped<IAuthorizeApi, AuthorizeApi>();
            services.AddLoadingBar();
            services.Add(new ServiceDescriptor(typeof(IUserProfileApi), typeof(UserProfileApi), ServiceLifetime.Scoped));
            services.AddScoped<AppState>();

            services.AddScoped<ComponentNotifierService>();

            services.AddMatToaster(config =>
            {
                config.Position = MatToastPosition.BottomRight;
                config.PreventDuplicates = true;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
                config.MaximumOpacity = 95;
                config.VisibleStateDuration = 3000;
            });
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            // Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTc4Njk1QDMxMzcyZTMzMmUzMFlxK1hFNmxUb1BzUU9Wd2VFYzRsR1BkaGZLbW9Ca3Fpak9UdVJiN01tTTg9;MTc4Njk2QDMxMzcyZTMzMmUzMFlxK1hFNmxUb1BzUU9Wd2VFYzRsR1BkaGZLbW9Ca3Fpak9UdVJiN01tTTg9");

            WebAssemblyHttpMessageHandler.DefaultCredentials = FetchCredentialsOption.Include;
            app.UseLoadingBar();
            app.AddComponent<App>("app");
        }
    }
}
