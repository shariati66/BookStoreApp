using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    public class BookViewModel
    {
        public int Id { get; set; } = 1;
        [Required(ErrorMessage ="name is required")]
        public string Name { get; set; }
        public string Author { get; set; }
        [Range(1000,double.MaxValue,ErrorMessage ="Price Range must Greater than 1000")]
        public double Price { get; set; }
        [Required(ErrorMessage ="Publish date must be added")]
        public DateTime PublishDate { get; set; }
    }
}
