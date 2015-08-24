namespace Archimedes.Data.Models
{
    public class Rule : IModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Source { get; set; }
        public string Motivation { get; set; }
        public string Status { get; set; }
    }
}
