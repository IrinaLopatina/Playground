namespace MemberRegister
{
    public interface IRegisterHandler
    {
        /// <summary>
        /// Gets a valid name from the user input
        /// </summary>
        /// <returns>Valid name</returns>
        string RegisterValidName();
        
        /// <summary>
        /// Gets a valid birth date from the user input
        /// </summary>
        /// <returns>Valid birth date</returns>
        DateOnly RegisterValidBirthDate();

        /// <summary>
        /// Adds Person to member registry
        /// </summary>
        /// <param name="name">Valid name</param>
        /// <param name="birthDate">Valid birth day</param>
        void AddPerson(string name, DateOnly birthDate);
            
        /// <summary>
        /// Appends new register members to the file
        /// </summary>
        void SaveRegisterToFile();
    }
}
