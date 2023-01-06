using DomainModel.Content;
using DomainModel.Navigation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //  InitDataBase(modelBuilder);
        }

        private void InitDataBase(ModelBuilder modelBuilder)
        {
          
        }

        #region Navigation

        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        #endregion

        #region Content

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Callback> Callbacks { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<BlockList> BlockLists { get; set; }

        #endregion

    }
}