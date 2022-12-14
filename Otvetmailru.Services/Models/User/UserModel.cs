using Otvetmailru.Entities.Models;

namespace Otvetmailru.Services.Models;

public class UserModel : BaseModel
{
    public string PasswordHash { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    
    public string LastName { get; set; }
    public string FirstName { get; set; } // фио 
    public string SecondName { get; set; }
    public string Nickname { get; set; }
    public DateTime Birthday { get; set; }
    
    public bool Vip { get; set; }
    public int CountAnswers { get; set; }
    public int CountQuestions { get; set; }
    public int CountBest { get; set; } 

}