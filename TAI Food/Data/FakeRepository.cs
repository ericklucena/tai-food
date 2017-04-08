using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAIFood.Models;

namespace TAIFood.Data
{
    class FakeRepository
    {
        public static List<Restaurant> GetRestaurants(int size)
        {
            List<Restaurant> restaurants = new List<Restaurant>();

            for (int i = 0; i < size; i++)
            {
                restaurants.Add(FakeRestaurant(4));
            }

            return restaurants;
        }

        private static Food FakeFood()
        {
            Random r = new Random();

            Food food = new Food()
            {
                Name = "TAI Food",
                Description = "TAI Description; TAI Description; TAI Description; ",
                _Likes = r.Next(0, 5),
                _Dislikes = r.Next(0, 5),
                FoodRestrictions = EFoodRestriction.Lactose | EFoodRestriction.Salt,
                Price = 123.45
            };
            return food;
        }

        public static Restaurant FakeRestaurant(int menuSize)
        {
            Restaurant restaurant = new Restaurant()
            {
                Name = "TAI Restaurant",
                Description = "TAI Description; TAI Description; TAI Description; TAI Description; TAI Description; ",
                Menu = new System.Collections.ObjectModel.ObservableCollection<Food>()
            };

            for (int i = 0; i < menuSize; i++)
            {
                restaurant.Menu.Add(FakeFood());
            }

            return restaurant;
        }
    }
}
