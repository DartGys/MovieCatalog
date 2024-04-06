namespace MovieCatalog.WebUI.Models
{
    public class FilmVm
    {
        public string Name { get; set; }
        public string Director { get; set; }
        public DateTime Release { get; set; }
        public IReadOnlyList<string>? Categories { get; set; }
    }
}
