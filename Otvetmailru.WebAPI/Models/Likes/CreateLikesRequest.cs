namespace Otvetmailru.WebAPI.Models;

public class CreateLikesRequest
{
    public Guid AnswerId  { get; set; }
    public Guid UserId  { get; set; }
}