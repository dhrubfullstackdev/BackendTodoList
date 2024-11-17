using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BackendTodoList.Model
{
    public class User
    {
            [Key]
            [Required]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int id { get; set; }
            [Column("username",TypeName ="varchar(100)")]
            public string? username { get; set; }
            public string? password { get; set; }
            public string? email_address { get; set; }
            public DateTime created_date { get; set; }
            public DateTime updated_date { get; set; }       

            public ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
    }
}
