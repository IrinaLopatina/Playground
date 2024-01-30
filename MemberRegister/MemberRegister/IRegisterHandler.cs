namespace MemberRegister
{
    public interface IRegisterHandler
    {
        string RegisterName();
        DateOnly RegisterBirthDate();
        void SaveRegisterToFile();
    }
}
