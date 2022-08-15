using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostProjeKaloriTakipProgrami.Classes
{
    [Table("Meals")]
    public class Meal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public MealEnum Name { get; set; }

        [Required]
        public double TotalCalories { get; private set; } = 0;

        [ForeignKey("Foods")]
        public int FoodId { get; set; }

        public ICollection<Food> Foods { get; set; }
    }
}
