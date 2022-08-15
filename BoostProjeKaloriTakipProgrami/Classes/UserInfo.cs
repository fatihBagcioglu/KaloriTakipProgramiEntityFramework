using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostProjeKaloriTakipProgrami.Classes
{
    [Table("UserInfos")]
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }

        [Required, ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public double Height { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public GenderEnum Gender { get; set; }

        public User User { get; set; }
    }
}
