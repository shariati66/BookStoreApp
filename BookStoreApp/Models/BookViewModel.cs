using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    public class BookViewModel
    {
        [Range(1,int.MaxValue,ErrorMessage ="Id must greater than One")]
        public int Id { get; set; }
        [Required(ErrorMessage ="name is required")]
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        [Required(ErrorMessage ="Publish date must be added")]
        public DateTime PublishDate { get; set; }
    }
}
