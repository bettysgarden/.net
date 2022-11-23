using Microsoft.EntityFrameworkCore;
using Otvetmailru.Entities.Models;

namespace Otvetmailru.Entities;
public class Context : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Attachments> Attachments { get; set; }
    public DbSet<Comments> Comments { get; set; }
    public DbSet<Likes> Likes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }

    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Users
        
        builder.Entity<User>().ToTable("users");
        builder.Entity<User>().HasKey(x => x.Id);
        
        #endregion
        
        #region Questions

        builder.Entity<Question>().ToTable("questions");
        builder.Entity<Question>().HasKey(x => x.Id);
        //builder.Entity<Question>().Property(x => x.UserId).IsRequired(false);
       
        #endregion

        #region Answers

        builder.Entity<Answer>().ToTable("answers");
        builder.Entity<Answer>().HasKey(x => x.Id);
        // builder.Entity<Answer>().HasOne(x => x.Question)
        //                         .WithMany(x => x.)
        //                         .HasForeignKey(x => x.ParentSpecialityId)
        //                         .OnDelete(DeleteBehavior.Restrict);

        #endregion

        #region Attachments

        builder.Entity<Attachments>().ToTable("attachments");
        builder.Entity<Attachments>().HasKey(x => x.Id);

        #endregion

        #region Comments

        builder.Entity<Comments>().ToTable("comments");
        builder.Entity<Comments>().HasKey(x => x.Id);

        #endregion

        #region Likes

        builder.Entity<Likes>().ToTable("likes");
        builder.Entity<Likes>().HasKey(x => x.Id);

        #endregion

        #region Quizzes

        builder.Entity<Quiz>().ToTable("quizzes");
        builder.Entity<Quiz>().HasKey(x => x.Id);

        #endregion
        #region AnswerHasAttachment

        builder.Entity<AnswerHasAttachment>().ToTable("answerHasAttachment");
        builder.Entity<AnswerHasAttachment>().HasKey(x => x.Id);

        #endregion
        #region QuestionHasAttachment

        builder.Entity<QuestionHasAttachment>().ToTable("questionHasAttachment");
        builder.Entity<QuestionHasAttachment>().HasKey(x => x.Id);

        #endregion
        #region CommentHasAttachment

        builder.Entity<CommentHasAttachment>().ToTable("commentHasAttachment");
        builder.Entity<CommentHasAttachment>().HasKey(x => x.Id);

        #endregion
    }
}