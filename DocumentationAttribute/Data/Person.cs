using System;
using System.Collections.Generic;
using System.Text;
using DocumentationAttribute.CustomAttribute;

namespace DocumentationAttribute.Data
{
    [Description("Person Model")]
    public class Person
    {
        [Description("FirstName Property of the Person Model.")]
        public string FirstName { get; set; }

        [Description("LastName Property of the Person Model.")]
        public string LastName { get; set; }

        [Description("Email Property of the Person Model.")]
        public string Email { get; set; }

        [Description("Gender Property of the Person Model.")]
        public int Age { get; set; }

        [Description("Default constructor with no parameter.")]
        public Person()
        {

        }

        [Description("A Second Constructor overload with four parameter")]
        public Person(string firstname,string lastname, string email, int age)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Age = age;

        }

    [Description("This list holds information about users.")]
    public static List<Person> persons = new List<Person>();

    [Description("This method creates an instance of a Person and also display the information on the console.")]
        public static void Display()
        {
        persons.Add(new Person("Henry","Ugochukwu","h.ugochukwu@genesystechhub.com",18));

            foreach (var person in persons)
            {
                Console.WriteLine($"Name: {person.FirstName}" +
                    $" {person.LastName}, Email: {person.Email}, Age: {person.Age}.");
            }
        }
    }
}
