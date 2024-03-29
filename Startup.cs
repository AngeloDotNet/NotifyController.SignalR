namespace Chat_SignalR;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<CookiePolicyOptions>(options =>
        {
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.None;
        });

        services.AddMvc();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "API_Chat_SignalR", Version = "v1" });
        });

        services.AddSignalR();
    }

    public void Configure(WebApplication app)
    {
        IWebHostEnvironment env = app.Environment;

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API_Chat_SignalR v1"));
        }
        else
        {
            app.UseExceptionHandler("/Error");
        }

        app.UseStaticFiles();
        app.UseCookiePolicy();

        app.UseRouting();
        app.UseEndpoints(routes =>
        {
            routes.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            routes.MapHub<ChatHub>("/chatHub");
        });
    }
}