using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class Member
    {
        public int MemberID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<MemberCommentView> MemberComments { get; set; }

        public override string ToString()
        {
            return $"f: {FirstName} l^{LastName} {MemberID}";
        }
    }

    public class Comment
    {
        public int CommentID { get; set; }
        public string Message { get; set; }

        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<MemberCommentView> MemberComments { get; set; }

        public override string ToString()
        {
            return $"id: {CommentID} M^{Message} ";
        }
    }

    public class MemberCommentView
    {
        public int MemberID { get; set; }
        public int CommentID { get; set; }
        public int Something { get; set; }
        public string SomethingElse { get; set; }

        public virtual Member Member { get; set; }
        public virtual Comment Comment { get; set; }
        public override string ToString()
        {
            return $"id: {CommentID} M^{MemberID} {Something} k{SomethingElse}";
        }
    }
    public class MyContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<MemberCommentView> MemberComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .HasMany(s => s.Comments)
            .WithMany(c => c.Members)
            .UsingEntity<MemberCommentView>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-I7Q35NQ\\SQLEXPRESS;Database=ManyToMany;User Id=sa;Password=Admin@1234;MultipleActiveResultSets=true;TrustServerCertificate=true;");
        }
    }
}
