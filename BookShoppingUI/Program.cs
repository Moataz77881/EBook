using BookShopping.Business.services.ConvertFiles;
using BookShoppingUI.Data;
using BookShoppingUI.Repository.BookRepo;
using BookShoppingUI.services.BookServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookShoppingUI
{
    public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			var connectionString = builder.Configuration.GetConnectionString("ApplicationAuth") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
			builder.Services.AddDbContext<ApplicationAuthDbContext>(options =>
				options.UseSqlServer(connectionString));
			
			builder.Services.AddDbContext<ApplicationDbContext>(
				options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationData")));
			
			builder.Services.AddDatabaseDeveloperPageExceptionFilter();

			builder.Services
				.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddEntityFrameworkStores<ApplicationAuthDbContext>()
				.AddDefaultUI()
				.AddDefaultTokenProviders();

			builder.Services.AddScoped<IBookService,BookService>();
            builder.Services.AddScoped<IBookRepo,BookRepository>();
			builder.Services.AddScoped<IConvertFile, ConvertFileToString>();

            builder.Services.AddControllersWithViews();

			var app = builder.Build();
			using (var scop = app.Services.CreateScope())
			{
				await DbSeeder.seedDataToTheDatabase(scop.ServiceProvider);
			}

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
				{
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

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
			app.MapRazorPages();

			app.Run();
		}
	}
}
