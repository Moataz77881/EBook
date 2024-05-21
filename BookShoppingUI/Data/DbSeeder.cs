using BookShoppingUI.Enums;
using Microsoft.AspNetCore.Identity;

namespace BookShoppingUI.Data
{
	public class DbSeeder
	{
		public static async Task seedDataToTheDatabase(IServiceProvider service) 
		{
			var rolMang = service.GetService<RoleManager<IdentityRole>>();
			var userMang = service.GetService<UserManager<IdentityUser>>();
			
			// add roles to database
			await rolMang.CreateAsync(new IdentityRole(Roles.Admain.ToString()));
			await rolMang.CreateAsync(new IdentityRole(Roles.User.ToString()));

			var admin = new IdentityUser 
			{
				Email= "admin@gmail.com",
				UserName = "admin@gmail.com",
				EmailConfirmed = true,
				
			};

			//add admin to database
			var userExist = await userMang.FindByEmailAsync(admin.Email);
			if(userExist is null) 
			{
				await userMang.CreateAsync(admin, "Admin@123");
				await userMang.AddToRoleAsync(admin, Roles.Admain.ToString());
			}


		}
	}
}
