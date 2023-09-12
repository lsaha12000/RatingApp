namespace RatingApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string AuhorName { get; set;}
        public virtual List<Raing> Raings { get; set;}
        public virtual Author? Author { get; set; }

    }
}
