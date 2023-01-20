using System;
using System.Collections.Generic;
using System.Text;
using DocumentationAttribute.CustomAttribute;

namespace DocumentationAttribute.Implementation
{
   public class DocumentedAtrribute
    {
        public  void GetDocs()
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
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
