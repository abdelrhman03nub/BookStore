using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }


        [Required]
        public string Title { get; set; }

        [Range(1,100000)]
        public decimal Price { get; set; }


        
        public  int AuthorId { get; set; }


        public Author? Author { get; set; }


    }
}
