using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Poly.Models;
using PolyFix.Models;

namespace Mvc.RoleAuthorization.Data
{
	public class ApplicationDbContext : IdentityDbContext<PolyFixAppUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
		{

		}

		public DbSet<Notification> Notifications { get; set; }

		public DbSet<Project> Projects { get; set; }
		public DbSet<Tsk> Tsks { get; set; }
		public DbSet<CompletedSurvey> CompletedSurveys { get; set; }

		public DbSet<UserProject> UserProjects { get; set; }

		public DbSet<UserTask> UserTasks { get; set; }


		public DbSet<RoleMenuPermission> RoleMenuPermission { get; set; }

		public DbSet<NavigationMenu> NavigationMenu { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<RoleMenuPermission>()
			.HasKey(c => new { c.RoleId, c.NavigationMenuId});

			builder.Entity<UserProject>()
			.HasKey(c => new { c.ProjectId, c.UserId });


			builder.Entity<UserProject>()
			.HasOne(c => c.User)
			.WithMany(d => d.UserProject)
			.HasForeignKey(c => c.UserId) ;

			builder.Entity<UserProject>()
			.HasOne(c => c.Project)
			.WithMany(d => d.UserProject)
			.HasForeignKey(c => c.ProjectId);


			builder.Entity<UserTask>()
			.HasKey(c => new { c.TskId, c.UserId });

			builder.Entity<UserTask>()
			.HasOne(c => c.User)
			.WithMany(d => d.UserTask)
			.HasForeignKey(c => c.UserId) ;

			builder.Entity<UserTask>()
			.HasOne(c => c.Tsk)
			.WithMany(d => d.UserTask)
			.HasForeignKey(c => c.TskId);

			base.OnModelCreating(builder);
		}

		
	}
}