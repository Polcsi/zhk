using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PlanetDownLoaderApp
{
    public class Program
    {
        private string[] content = ReadFile("planets.txt");
        private FileDownLoad fileDownLoader = new FileDownLoad();
        private List<Planet> planets = new List<Planet>();
        static void Main(string[] args)
        {
            Program program = new Program();
            program.fileDownLoader.StartDownLoad("","images");

            try
            {
                foreach (string item in program.content)
                {
                    program.planets.Add(new Planet(item));
                }

                foreach (Planet planet in program.planets)
                {
                    program.fileDownLoader.StartDownLoad(planet.Url, $"images/{planet.Name}.jpg");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            

            Console.ReadKey();
        }
        private static string[] ReadFile(string path = null)
        {
            if(path is null)
            {
                Console.WriteLine("You did not provide file path.");
                return null;
            }
            try
            {
                string[] textInput = File.ReadAllLines(path);
                Console.WriteLine("File Successfully Read!");
                return textInput;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File cannot be found.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("'path' exceeds the maxium supported path length.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have permission to create this file.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"An exception occurred:\nError code: " +
                                  $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
            }
            return null;
        }
    }
}
