using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BLAZOR.UI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;
using BlazorStrap;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Services.ScopeLibrary.ScopeHandler;
using Services.ScopeLibrary.ScopeRequirement;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using SERVICIOS;
using Blazored.SessionStorage;

namespace BLAZOR.UI
{
    public class Startup
    {


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {   
            //AUTH0
            string domain = Configuration["Auth0:Domain"];
            string clientId = Configuration["Auth0:ClientId"];
            string clientSecret = Configuration["Auth0:ClientSecret"];
            string audience = Configuration["Auth0:Audience"];
            //AUTH0


            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddBootstrapCSS();
            services.AddProtectedBrowserStorage();
            services.AddBlazoredSessionStorage();

            services.AddI18nText<Startup>(options =>
            options.PersistanceLevel = Toolbelt.Blazor.I18nText.PersistanceLevel.SessionAndLocal);

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var httpClientHanndler = new HttpClientHandler();
            httpClientHanndler.ServerCertificateCustomValidationCallback =
                (message, cert, chai, errors) => true;

            services.AddSingleton(new HttpClient(httpClientHanndler)
            {
                BaseAddress = new Uri(ApplicationSettings.Current.CurrentApi)

        });

            //AUTH0
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect("Auth0", options =>
            {
        //tocamos esto tambien.
            options.Authority = $"https://{domain}";
            options.ClientId = clientId;
            options.ClientSecret = clientSecret;

            options.ResponseType = "code";

            options.Scope.Clear();
            options.Scope.Add("openid");
            options.Scope.Add("profile");

            options.CallbackPath = new PathString("/callback");

            // Configure the Claims Issuer to be Auth0
            options.ClaimsIssuer = "Auth0";
                // Saves tokens to the AuthenticationProperties
                options.SaveTokens = true;

            // Authorization //
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name",
                    RoleClaimType = $"https://schemas.{domain}/roles"
                };

                options.Events = new OpenIdConnectEvents
                {
                    //Add audience parameter
                    OnRedirectToIdentityProvider = context =>
                    {
                        context.ProtocolMessage.SetParameter("audience", audience);
                        return Task.FromResult(0);
                    },

                    //Add event when token were validated
                    OnTokenValidated = context =>
                    {
                        //set security token
                        string secJwt = context.SecurityToken.RawData;
                        //set access token
                        string accessJwt = context.TokenEndpointResponse.AccessToken;
                        //read access token
                        var handler = new JwtSecurityTokenHandler();
                        var jwt = handler.ReadJwtToken(accessJwt);
                        //get permissions from access token
                        List<Claim> permissions = jwt.Claims.Where(x => x.Type == "permissions").ToList();
                        //add permission to user claims (in this case add new identity)
                        context.Principal.AddIdentity(new ClaimsIdentity(permissions));

                        //this is a test to get response from api
                        //in this part yo have to save token on a global var and call api on page component
                        //
                        //var client3 = new RestClient("https://localhost:44339/WeatherForecast");
                        //var request3 = new RestRequest(Method.GET);
                        //request3.AddHeader("authorization", $"Bearer {accessJwt}");
                        //IRestResponse response3 = client3.Execute(request3);
                        //
                        //

                        return Task.FromResult(0);
                    },
                    // handle the logout redirection
                    OnRedirectToIdentityProviderForSignOut = (context) =>
                    {
                        var logoutUri = $"https://{Configuration["Auth0:Domain"]}/v2/logout?client_id={Configuration["Auth0:ClientId"]}";

                        var postLogoutUri = context.Properties.RedirectUri;
                        if (!string.IsNullOrEmpty(postLogoutUri))
                        {
                            if (postLogoutUri.StartsWith("/"))
                            {
             // transform to absolute
                      var request = context.Request;
                                postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
                            }
                            logoutUri += $"&returnTo={ Uri.EscapeDataString(postLogoutUri)}";
                        }

                        context.Response.Redirect(logoutUri);
                        context.HandleResponse();

                        return Task.CompletedTask;
                    }
                };
            });

            // Add policies
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.Requirements.Add(new HasScopeRequirement("read:Admin", $"https://{domain}/")));
                options.AddPolicy("User", policy => policy.Requirements.Add(new HasScopeRequirement("read:User", $"https://{domain}/")));
            });
            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
            //AUTH0 -cierra

            services.AddHttpContextAccessor();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTA3MjE4QDMxMzkyZTMyMmUzME9VRDdXem96Z1FFRnVVY3NQK2R3bmIxQUVOUDVYUUQxQ0dlTy8rUGFIem89");
            app.UseStaticFiles();

            app.UseRouting();
            //AUTH0
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
            //AUTH0
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
