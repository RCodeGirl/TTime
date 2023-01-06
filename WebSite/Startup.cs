using System;
using DomainModel.Framework.Email;
using Interfaces.Common;
using Interfaces.Content;
using Interfaces.Initializer;
using Interfaces.Navigation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;
using Services.Common;
using Services.Content;
using Services.Initializer;
using Services.Navigation;

namespace WebSite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            });

            services.ConfigureApplicationCookie(options => { options.ExpireTimeSpan = TimeSpan.FromMinutes(10); });

            services.AddTransient<IDbInitializer, DbInitializer>();
            services.AddTransient<ISliderService, SliderService>();
            services.AddTransient<IArticleService, ArticleService>();
            services.AddTransient<ICallbackService, CallbackService>();
            services.AddTransient<IPageService, PageService>();
            services.AddTransient<IPartnersService, PartnersService>();
            services.AddTransient<IBlockListService, BlockListService>();
            services.AddTransient<IBlockService, BlockService>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<IMenuItemService, MenuItemService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<ISettingService, SettingService>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<ISaleService, SaleSevice>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<WorkContext>();

            services.AddSingleton<IEmailConfiguration>(Configuration.GetSection("EmailConfiguration")
                .Get<EmailConfiguration>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var dbInitializer = scope.ServiceProvider.GetService<IDbInitializer>();
                dbInitializer.Initialize();
                dbInitializer.SeedData();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "Admin",
                    "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
