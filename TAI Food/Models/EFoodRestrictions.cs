using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAIFood.Models
{
    [Flags]
    public enum EFoodRestriction
    {
        None = 0,
        Vegetarian = 1,
        Vegan = 2,
        Gluten = 4,
        Lactose = 8,
        Salt = 16,
        Sugar = 32
    }
}
