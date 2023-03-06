using System.ComponentModel.DataAnnotations;

namespace TodoWebApi.Models.Dto
{
    public class TodoDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public int Complated { get; set; }
    }
}
