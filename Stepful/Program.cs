using Microsoft.OpenApi.Models;
using Stepful.Components;
using System.Net.Http;
using Microsoft.Extensions.Hosting;
using StepfulLib;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using System.Collections.Generic;

using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;


namespace Stepful;

public class Program {
    public static void Main(string[] args) {

        var builder = WebApplication.CreateBuilder(args);

        //builder.Services.AddOpenAIChatCompletion("gpt-3.5-turbo", "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");

        var dbConfig = builder.Configuration.GetSection("DatabaseSettings");
        DatabaseSettings dbSettings = new DatabaseSettings();
        dbConfig.Bind(dbSettings);

        var aiConfig = builder.Configuration.GetSection("AiSettings");
        AiSettings aiSettings = new AiSettings();
        aiConfig.Bind(aiSettings);

        builder.Services.AddSingleton<IAgent, Agent>(provider => {
            return new Agent(aiSettings);
        });

        builder.Services.AddBlazorise(options =>
        {
            options.Immediate = true;
        })
        .AddBootstrapProviders()
        .AddFontAwesomeIcons();

        builder.Services.AddRazorComponents().AddInteractiveServerComponents();
        builder.Services.AddRazorPages();


        builder.Services.Configure<DataAccess>(dbConfig);
     
        builder.Services.AddScoped<IStudentService, StudentService>(provider =>{
            return new StudentService(dbSettings);
        });

        builder.Services.AddScoped<ICoachService, CoachService>(provider => {
            return new CoachService(dbSettings);
        });


        builder.Services.AddScoped(sp =>
        new HttpClient
        {
             BaseAddress = new Uri(builder.Configuration["FrontendUrl"] ?? "https://localhost:4297")
             //BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
        });
       
       
        builder.Services.AddHttpClient();   
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(c =>{
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Stepful API", Version = "v1" });
        });
        var app = builder.Build();
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseRouting();
        app.MapControllers();
        app.UseSwagger();
        app.UseSwaggerUI(c =>{
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Stepful API v1");
        });
        app.UseStaticFiles();
        app.UseAntiforgery();
        app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
        app.Run();
        //app.Run("http://0.0.0.0:8080");     // For Docker Cloud Deployment
    }
}