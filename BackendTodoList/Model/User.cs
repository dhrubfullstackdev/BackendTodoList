using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace BackendTodoList.Model
{
        public class User
        {
            [Key]
            public int id { get; set; }

            public string username { get; set; }

            public string password { get; set; }

            public string email_address { get; set; }
        }

}
