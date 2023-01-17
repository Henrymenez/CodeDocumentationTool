using DocumentationAttribute.Implementation;

namespace ConsoleTester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            DocumentedAtrribute documentedAtrribute = new DocumentedAtrribute();
            documentedAtrribute.GetDocs();
        }
    }
}