namespace MemberRegister
{
    public class RegisterHandler: IRegisterHandler
    {
        const string fileName = "MemberRegister.txt";
        const string separator = "\t";
        readonly List<Person> register = new() { };

        public string RegisterValidName()
        {
            var input = string.Empty;
            var validName = false;

            Console.WriteLine("Register name of the person.");
            Console.WriteLine("Empty name exits the program and writes register to the file.");

            while (validName == false)
            {
                input = Console.ReadLine();
                try
                {
                    Person.ValidateName(input);
                    validName = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return input;
        }
        public DateOnly RegisterValidBirthDate() 
        {
            var input = string.Empty;
            var validBirthDate = false;

            Console.WriteLine("Register birth date of the person.");
            Console.WriteLine("Person can be a member from the year of he/she turns 15 years.");

            while (validBirthDate == false)
            {
                input = Console.ReadLine();
                try
                {
                    Person.ValidateBirthDate(input);
                    validBirthDate = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return DateOnly.Parse(input);
        }


        public void AddPerson(string name, DateOnly birthDate) //valid parameter values
        {
            register.Add(new Person(name, birthDate));
        }

        public void SaveRegisterToFile()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
            
            Console.WriteLine($"Starting adding {register.Count} new members to the file...");
            using (var streamWriter = new StreamWriter(path, true))
            {
                register.ForEach(x => streamWriter.WriteLine(FormatPersonLine(x)));
            }
            Console.WriteLine("Registered members saved (added) to the file...");     
        }

        private static string FormatPersonLine(Person person)
        {
            return $"{person.Name}{separator}{person.BirthDate}";
        }
    }
}
