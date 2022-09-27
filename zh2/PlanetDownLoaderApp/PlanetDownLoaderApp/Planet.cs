namespace PlanetDownLoaderApp
{
    public class Planet
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public Planet(string planet)
        {
            string[] planetParts = planet.Split(';');
            Name = planetParts[0];
            Url = planetParts[1];
        }
    }
}
