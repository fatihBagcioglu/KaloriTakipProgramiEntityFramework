using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostProjeKaloriTakipProgrami.Classes
{
    [Table("UserDetails")]
    public class UserDetail
    {
        [Key]
        public int Id { get; set; }

        [Required, ForeignKey("User")]
        public int UserId { get; set; }

        [Required, ForeignKey("Meals")]
        public int MealId { get; set; }

        public DateTime Date { get; private set; } = DateTime.Now;

        public User User { get; set; }
        public ICollection<Meal> Meals { get; set; }
    }
}
