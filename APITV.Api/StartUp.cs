using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

// using APITV.Infrastructure.Filters;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using APITV.Infrastructure.Data;
using APITV.Application.Mapping;
// using APITV.Common.Interfaces.Repositories;
// using APITV.Infrastructure;
// using APITV.Infrastructure.Repositories;
// using APITV.Common.Interfaces.Services;
// using APITV.Application.Services;
// using APITV.Domain.Interfaces;
// using APITV.Common.Helpers;
// using APITV.Domain.Interfaces.Repositories;
// using APITV.Domain.Interfaces.Services;
// using APITV.Infrastructure.Repositories;
// using APITV.Application.Services;
// using Api.Domain.Interfaces.Repositories;
// using Api.Domain.Interfaces.Services;

namespace APITV.Api;

public class StartUp(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;

    public IConfiguration Configuration => _configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(
            options =>
            {
                // options.Filters.Add<GlobalExceptionFilter>();
            }
        )
            .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
            options.JsonSerializerOptions.WriteIndented = true;
        });

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "APITV Project API", Version = "v1" });
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlFilePath);

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme{
                Reference = new OpenApiReference{
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
        });

        services.AddEndpointsApiExplorer();

        // Add DB Connection string
        services.AddDbContext<ApiTvDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ApiDevString") ?? throw new InvalidOperationException("Database Connection String Not Found...")).UseLazyLoadingProxies()
        );

        // Add Mappers
        services.AddAutoMapper(typeof(MappingProfile).Assembly);

        // Configure Cors
        services.AddCors(options => options.AddPolicy("corsPolicy", builder =>
        {
            builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
        }));

        // Add Serivces

        // Add Repositories

        services.AddHttpContextAccessor();

        // Add Cashing
        services.AddResponseCaching();

        // Add JWT
        services.AddAuthentication(opttions =>
        {
            opttions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opttions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Configuration["Authentication:Issuer"],
                ValidAudience = Configuration["Authentication:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:SecretKey"]!))
            };
        });

        services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new RequestCulture("es-MX");
            options.SupportedCultures = new List<CultureInfo> { new CultureInfo("es-MX") };
            options.RequestCultureProviders.Clear();
        });

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
    {
        //app.UseLogResponseHttp();

        app.UseCors("corsPolicy");

        app.UseHttpsRedirection();

        // Configure the HTTP request pipeline.
        if (environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseStaticFiles();
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "APITV Project V1");
            options.RoutePrefix = string.Empty;
        });

        app.UseRouting();

        app.UseResponseCaching();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
