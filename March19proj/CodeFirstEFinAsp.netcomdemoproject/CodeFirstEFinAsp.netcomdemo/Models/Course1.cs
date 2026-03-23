using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace CodeFirstEFinAsp.netcomdemo.Models
{
    public class Course1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { set; get; }

        [Required]
        [Column("Stitle", TypeName = "varchar")]
        public string Title { set; get; }

        [Required]
        [MaxLength(220)]
        public string Description { set; get; }

        public float fullprice { set; get; }

        public Author1? Author { set; get; }
        public int AuthorId { set; get; }



    }
}
