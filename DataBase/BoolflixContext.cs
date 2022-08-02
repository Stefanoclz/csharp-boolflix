using csharp_boolflix.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_boolflix.DataBase
{
    public class BoolflixContext : DbContext
    {
        public DbSet<VideoContent> VideoContents { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<PlayedHistory> PlayedHistories { get; set; }
        public DbSet<Playlist> Playlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=boolflix-db;Integrated Security=True");
        }
    }
}
