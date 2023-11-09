namespace Dinosaur.Models
{
    public class Human
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int Height { get; set; }
        public string Diet {  get; set; }

        public Human() { }

        public Human(string name, double weight, int height, string diet) { this.Name = name; this.Weight = weight; this.Height = height; this.Diet = diet; }
    }
}
