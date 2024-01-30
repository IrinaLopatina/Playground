// See https://aka.ms/new-console-template for more information
using MemberRegister;

Console.WriteLine("Starting registering members....");

IRegisterHandler registerHandler = new RegisterHandler() { };

while (true)
{
    string name = registerHandler.RegisterValidName();
    if (string.IsNullOrEmpty(name))
    {
        registerHandler.SaveRegisterToFile();
        Console.WriteLine("Exiting the program...");
        return;
    }

    DateOnly birthDate = registerHandler.RegisterValidBirthDate();

    registerHandler.AddPerson(name, birthDate);
}


