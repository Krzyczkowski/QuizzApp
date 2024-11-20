namespace QuizzApp.Models;

public class User{
    public Guid Id{get;set;} 
    public string FirstName{get;set;} 
    public string LastName{get;set;}
    public string Email{get;set;}
    public string Password{get;set;}

    public ICollection<CorrectAnswer> CorrectAnswers { get; set; }= null!;
    public User(Guid id, string firstName, string lastName, string email, string password){
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }
    public User(string firstName, string lastName, string email, string password){
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }
}