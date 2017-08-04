namespace Iau.NotifCenter.DataAccess.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NotifCenterContext : DbContext
    {
        public NotifCenterContext()
            : base("name=NotifCenterContext")
        {
        }

        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Message)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.SenderId);
        }
    }
}
