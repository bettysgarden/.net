using Otvetmailru.Entities.Models;

namespace Otvetmailru.Services.Models;

public class UpdateUserModel
{
    public string Email { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; } // фио 
    public string SecondName { get; set; }
    public string Nickname { get; set; }
}