namespace MemberRegister
{
    public class Person
    {
        private static readonly int nameLengthMin = 5;
        private static readonly int ageMin = 15;
        public string Name { get; private set; } = string.Empty;
        public DateOnly BirthDate { get; private set; } = DateOnly.MinValue;

        public Person(string name, DateOnly birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public static void ValidateName(string input)
        {
            if (!string.IsNullOrEmpty(input) && input.Length < nameLengthMin)
                throw new ArgumentException($"Length of the name must contain {nameLengthMin} or more symbols. Correct the name.");
        }

        public static void ValidateBirthDate(string input)
        {
            var birthDate = DateOnly.Parse(input);

            if (birthDate.Year + ageMin > DateOnly.FromDateTime(DateTime.Now).Year)
                throw new ArgumentException($"Person can be a member from the year when he/she turns {ageMin}. Correct the birth date.");
        }

    }
}
