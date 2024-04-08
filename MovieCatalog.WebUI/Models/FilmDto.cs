namespace MovieCatalog.WebUI.Models
{
    public class FilmDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public DateTime Release { get; }
    }
}
