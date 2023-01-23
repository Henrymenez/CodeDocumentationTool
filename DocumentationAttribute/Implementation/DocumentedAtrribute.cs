using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DocumentationAttribute.CustomAttribute;
using System.Reflection;

namespace DocumentationAttribute.Implementation
{
   public class DocumentedAtrribute
    {

        private static void writeStringToTxt(string text)
        {
            string path = @"C:\Users\USER\Desktop\bezao\CodeDocumentationTool\DocumentationAttribute\Data\data.txt";
            // This text is added only once to the file.
            if (!File.Exists(path))
            {

                File.WriteAllText(path, text);
            }
            else
            {
                File.AppendAllText(path, "\n" + text);
            }

        }
       /* public static void GetDocs()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    
                    var members = type.GetMembers();
                    foreach (var member in members)
                    {
                        var attributes = member.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        if (attributes.Length > 0)
                        {

                            Console.WriteLine("Type name: " + type.Name);
                            Console.WriteLine("Member Type: {0}", member.MemberType);
                            Console.WriteLine("Name: {0}", member.Name);
                            Console.WriteLine($"Description: {((DescriptionAttribute)attributes[0]).Description}");
                            writeStringToTxt($"Type name: {type.Name} \n " +
                               $"Member Type: {member.MemberType} \n" +
                               $"Name: {member.Name} \n " +
                               $"Description: {((DescriptionAttribute)attributes[0]).Description}");
                           
                            Console.WriteLine();
                        }
                    }
                }
            }
            Console.WriteLine("file successfully written");
        }*/


        public static void GetDocs()
        {
            var assembly = Assembly.GetExecutingAssembly();

            Console.WriteLine("Assembly name: " + assembly.FullName);

            Console.WriteLine();

            Type[] types = assembly.GetTypes();



            foreach (Type type in types)
            {
                DisplayType(type);

                DisplayConstructor(type);

                DisplayProperties(type);

                DisplayMethods(type);

                Console.WriteLine();

            }



        }

        // Display methods

        private static void DisplayMethods(Type type)
        {

            var methods = type.GetMethods();

            foreach (var method in methods)
            {
                var documentattribute = (DescriptionAttribute)method.GetCustomAttribute(typeof(DescriptionAttribute));

                if (documentattribute != null)
                {
                    Console.WriteLine("\t Method: " + method.Name);

                    Console.WriteLine("\t Description: " + documentattribute.Description);

                    Console.WriteLine("\t Input: " + documentattribute.Input);

                    Console.WriteLine("\t Output: " + documentattribute.Output + "\n");
                }


            }
        }


        // Display properties

        private static void DisplayProperties(Type type)
        {

            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var documentattribute = (DescriptionAttribute)property.GetCustomAttribute(typeof(DescriptionAttribute));

                if (documentattribute != null)
                {
                    Console.WriteLine("\t Property: " + property.Name);

                    Console.WriteLine("\t Description: " + documentattribute.Description + "\n");
                }


            }
        }


        //// Display constructors
        private static void DisplayConstructor(Type type)
        {

            var constructors = type.GetConstructors();

            foreach (var constructor in constructors)
            {
                var documentattribute = (DescriptionAttribute)constructor.GetCustomAttribute(typeof(DescriptionAttribute));

                if (documentattribute != null)
                {
                    Console.WriteLine("\t Constructor: " + constructor.Name);

                    Console.WriteLine("\t Description: " + documentattribute.Description);

                    Console.WriteLine("\t Input: " + documentattribute.Input);

                    Console.WriteLine("\t Output: " + documentattribute.Output + "\n");
                }

            }
        }

        private static void DisplayType(Type type)
        {
            var documentAttribute = (DescriptionAttribute)type.GetCustomAttribute(typeof(DescriptionAttribute));

            if (documentAttribute != null && type.IsClass)
            {
                Console.WriteLine("Class: " + type.Name);

                Console.WriteLine("Description: " + documentAttribute.Description);

                Console.WriteLine();

            }
            else if (documentAttribute != null && type.IsEnum)
            {
                Console.WriteLine("Enum: " + type.Name);

                Console.WriteLine("Description: " + documentAttribute.Description + "\n");

                Console.WriteLine();
            }
            else if (documentAttribute != null && type.IsInterface)
            {
                Console.WriteLine("Interface: " + type.Name);

                Console.WriteLine("Description: " + documentAttribute.Description + "\n");
            }
        }
    }
}
