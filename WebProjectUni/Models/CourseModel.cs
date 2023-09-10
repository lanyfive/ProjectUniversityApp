using System.ComponentModel.DataAnnotations;

namespace WebProjectUni.Models
{
    public class CourseModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do curso!")]
        public string Name { get; set; }
        
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
