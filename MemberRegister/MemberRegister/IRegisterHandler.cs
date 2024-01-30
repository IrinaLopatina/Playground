using System.Xml.Linq;

namespace MemberRegister
{
    public interface IRegisterHandler
    {
        string RegisterValidName();
        DateOnly RegisterValidBirthDate();

        void AddPerson(string name, DateOnly birthDate);
        void SaveRegisterToFile();
    }
}
