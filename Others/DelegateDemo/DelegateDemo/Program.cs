namespace DelegateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            people.Add(new Person { Name = "Travis", Age = 32 });
            people.Add(new Person { Name = "Nick", Age = 37 });
            people.Add(new Person { Name = "Leon", Age = 1 });
            people.Add(new Person { Name = "Peter", Age = 15 });
            people.Add(new Person { Name = "Grandy", Age = 70 });

            DisplayFilteredPeopleUsingDelegate(people, BabyFilter);
            DisplayFilteredPeopleUsingFunc(people, BabyFilter); 
        }
        public delegate bool FilterDelegate(Person p);
        public static bool BabyFilter(Person p)
        {
            if (p.Age < 5)
            {
                return true;
            }
            return false;
        }

        static void DisplayFilteredPeopleUsingDelegate(List<Person> people, FilterDelegate filter)
        {
            foreach (Person p in people)
            {
                if (filter(p))
                {
                    Console.WriteLine(p.Name);
                }
            }
        }

        static void DisplayFilteredPeopleUsingFunc(List<Person> people, Func<Person, bool> filter)
        {
            foreach (Person p in people)
            {
                if (filter(p))
                {
                    Console.WriteLine(p.Name);
                }
            }
        }
    }
}
