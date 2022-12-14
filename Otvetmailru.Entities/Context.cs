using Microsoft.EntityFrameworkCore;
using Otvetmailru.Entities.Models;
using Otvetmailru.Entity.Models;

namespace Otvetmailru.Entity;
public class Context : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Attachments> Attachments { get; set; }
    public DbSet<Likes> Likes { get; set; }
    public DbSet<Question> Questions { get; set; }

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
        builder.Entity<Question>().HasOne(x => x.User)
            .WithMany(x => x.Questions)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region Answers

        builder.Entity<Answer>().ToTable("answers");
        builder.Entity<Answer>().HasKey(x => x.Id);
        builder.Entity<Answer>().HasOne(x => x.Question)
            .WithMany(x => x.Answers)
            .HasForeignKey(x => x.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);    
        builder.Entity<Answer>().HasOne(x => x.User)
            .WithMany(x => x.Answers)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Answer>().HasOne(x => x.ParentAnswer)
            .WithMany(x => x.ChildrenAnswers)
            .HasForeignKey(x => x.ParentAnswerId)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion

        #region Attachments

        builder.Entity<Attachments>().ToTable("attachments");
        builder.Entity<Attachments>().HasKey(x => x.Id);

        #endregion

        #region Likes

        builder.Entity<Likes>().ToTable("likes");
        builder.Entity<Likes>().HasKey(x => x.Id);

        builder.Entity<Likes>().HasOne(x => x.Answer)
            .WithMany(x => x.AmountOfLikes)
            .HasForeignKey(x => x.AnswerId)
            .OnDelete(DeleteBehavior.Cascade);    
        builder.Entity<Likes>().HasOne(x => x.User)
            .WithMany(x => x.Likes)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        #endregion
        
        
        #region AnswerHasAttachment

        builder.Entity<AnswerHasAttachment>().ToTable("answerHasAttachment");
        builder.Entity<AnswerHasAttachment>().HasKey(x => x.Id);
        builder.Entity<AnswerHasAttachment>().HasOne(x => x.Answer)
            .WithMany(x => x.Attachments)
            .HasForeignKey(x => x.AnswerId)
            .OnDelete(DeleteBehavior.Cascade);    
        builder.Entity<AnswerHasAttachment>().HasOne(x => x.Attachments)
            .WithMany(x => x.AnswerHasAttachments)
            .HasForeignKey(x => x.AttachmentsId)
            .OnDelete(DeleteBehavior.Cascade);

        #endregion
        
        #region QuestionHasAttachment

        builder.Entity<QuestionHasAttachment>().ToTable("questionHasAttachment");
        builder.Entity<QuestionHasAttachment>().HasKey(x => x.Id);
        builder.Entity<QuestionHasAttachment>().HasOne(x => x.Question)
            .WithMany(x => x.Attachments)
            .HasForeignKey(x => x.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);    
        builder.Entity<QuestionHasAttachment>().HasOne(x => x.Attachments)
            .WithMany(x => x.QuestionHasAttachments)
            .HasForeignKey(x => x.AttachmentsId)
            .OnDelete(DeleteBehavior.Cascade);

        #endregion
    }
}