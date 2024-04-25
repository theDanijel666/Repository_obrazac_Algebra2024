using System.ComponentModel;

namespace mvc_algebra_knjizara.Models
{
    public class Book
    {
        [DisplayName("ID knjige")]
        public int BookId { get; set; }
        [DisplayName("Naslov knjige")]
        public string Title { get; set; }
        [DisplayName("Kratki opis")]
        public string Description { get; set; }
        [DisplayName("Žanr")]
        public string Genre { get; set; }
        [DisplayName("Na zalihi")]
        public int Stock { get; set; }
        [DisplayName("Datum izdavanja")]
        public DateTime ReleaseDate { get; set; }
        [DisplayName("Autor")]
        public string Author { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
