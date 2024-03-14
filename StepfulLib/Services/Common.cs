using System;
using System.Diagnostics.Contracts;
namespace StepfulLib;

public interface IBusinessService { }

public interface IUser {
    public string? Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? EncryptedPassword { get; set; }
    public bool IsValid { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ProfilePicUrl { get; set; }
    public int Ratings { get; set; } //1-5
}


public static class SLog{
    public static void Write(string Message){
        Console.WriteLine("### Stepful Log #### " + DateTime.Now + " - " + Message);
    }
}

public static class Utility
{
    public static int GenerateRandomNumber(int min=0, int max=100)
    {
        Random random = new Random();
        return random.Next(min, max);
    }
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class EntityNameAttribute : Attribute
{   private string name;

    public EntityNameAttribute(string name)
    {
        this.name = name;
    }
}

public enum Location
{
    California,
    NewYork,
    London,
    Tokyo
}

public enum Speciality
{
    PatientSafety,
    PainManagement,
    Ethics,
    MentalHealth,
    EatingDisorders,
    Cardiovascular
}

