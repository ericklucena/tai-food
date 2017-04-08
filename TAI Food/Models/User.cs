using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAIFood.Models
{
    class User
    {
        public string Name { get; set; }
        public EFoodRestriction FoodRestrictions { get; set; }
    }
}
