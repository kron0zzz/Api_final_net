using System.ComponentModel.DataAnnotations;

namespace Api_final.DTOs
{
    public class UserRegisterDto
    {
        [Required]
        public string UserName { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";
    }
}
