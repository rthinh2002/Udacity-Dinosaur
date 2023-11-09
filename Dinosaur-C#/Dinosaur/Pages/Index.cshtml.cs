using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dinosaur.Models;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using System.Xml.Linq;

namespace Dinosaur.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private List<Dino> Dinos {  get; set; }
        public IReadOnlyList<Dino> ReadableDinos => Dinos;
        public bool Submitted { get; set; }
        [BindProperty]
        public Human Human { get; set; } = new Human();

        public IndexModel(IWebHostEnvironment webHostEnvironment, ILogger<IndexModel> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        // Fetch the data from Json file
        public void OnGet()
        {
            var ContentRoot = _webHostEnvironment.ContentRootPath;
            var JsonPath = Path.Combine(ContentRoot, "Data", "dino.json");
            var jsonData = System.IO.File.ReadAllText(JsonPath);

            var DinosData = JsonSerializer.Deserialize<Dino>(jsonData);
            Dinos = DinosData.Dinos;
        }

        public void OnPost()
        {
            try
            {
                // Load the Dinos data from the JSON file
                var ContentRoot = _webHostEnvironment.ContentRootPath;
                var JsonPath = Path.Combine(ContentRoot, "Data", "dino.json");
                var jsonData = System.IO.File.ReadAllText(JsonPath);

                var DinosData = JsonSerializer.Deserialize<Dino>(jsonData);
                Dinos = DinosData.Dinos;
                foreach (var dino in Dinos)
                {
                    Random random = new Random();
                    var index = random.Next(0, 2);
                    switch (index)
                    {
                        case 0:
                            dino.CompareHeight(Human.Height);
                            break;
                        case 1:
                            dino.CompareWeight(Human.Weight);
                            break;
                        case 2:
                            dino.CompareDiet(Human.Diet);
                            break;
                    }
                    dino.ImageUrl = $"/images/{dino.species.ToLower()}.png"; 
                    if(dino.species == "Pigeon")
                    {
                        dino.fact = "All birds are dinosaurs";
                    }
                }
                this.Submitted = true;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}