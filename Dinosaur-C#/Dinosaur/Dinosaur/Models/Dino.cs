namespace Dinosaur.Models
{
    public class Dino
    {
        public string species { get; set; }
        public double weight { get; set; }
        public int height { get; set; }
        public string diet { get; set; }
        public string where { get; set; }
        public string when { get; set; }
        public string fact { get; set; }

        public string ImageUrl { get; set; }
        public List<Dino> Dinos { get; set; }

        public Dino() { }  // Default constructor

        public Dino(string species, double weight, int height, string diet, string where, string when, string fact)
        {
            this.species = species;
            this.weight = weight;
            this.height = height;
            this.diet = diet;
            this.where = where;
            this.when = when;
            this.fact = fact;
        }

        public void CompareHeight(int Height)
        {
            if(this.height > Height)
            {
                this.fact = $"{this.species} is taller than human";
            } 
            else if (this.height < Height)
            {
                this.fact = $"{this.species} is shorter than human";
            } 
            else
            {
                this.fact = $"{this.species} has the same height as human";
            }
        }

        public void CompareWeight(double Weight)
        {
            if (this.weight > Weight)
            {
                this.fact = $"{this.species} is heavier than human";
            }
            else if (this.weight < Weight)
            {
                this.fact = $"{this.species} is lighter than human";
            }
            else
            {
                this.fact = $"{this.species} has the same weight as human";
            }
        }

        public void CompareDiet(string Diet)
        {
            if (this.diet == Diet)
            {
                this.fact = $"{this.species} and human have the same diet";
            }
            else
            {
                this.fact = $"{this.species} and human have different diet";
            }
        }

        public string getRandomFact()
        {
            Random random = new Random();
            int index = random.Next(0, this.Dinos.Count % 10);
            return this.Dinos[index].fact;
        }
    }
}
