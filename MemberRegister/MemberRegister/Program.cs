// See https://aka.ms/new-console-template for more information
using MemberRegister;

Console.WriteLine("Starting registering members....");

RegisterHandler registerHandler = new() { };

while (true)
{
    string name = registerHandler.RegisterName();
    if (string.IsNullOrEmpty(name))
    {
        registerHandler.SaveRegisterToFile();
        Console.WriteLine("Exiting the program...");
        return;
    }

    DateOnly birthDate = registerHandler.RegisterBirthDate();

    registerHandler.AddPersonToRegister(name, birthDate);
}


