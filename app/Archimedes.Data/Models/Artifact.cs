namespace Archimedes.Data.Models
{
    public class Artifact : IModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
    }
}