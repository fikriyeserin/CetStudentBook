using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CetStudentBook.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 2)]
        public string Name { get; set; }


        [StringLength(200, MinimumLength = 2)]
        public string Author { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }


        [Range(1, 10000)]
        public int PageCount { get; set; }

        [Required]
        public bool IsSecondHand { get; set; }
    }

}

