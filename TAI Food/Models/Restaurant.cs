using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace TAIFood.Models
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Geopoint Location { get; set; }
        public ObservableCollection<Food> Menu { get; set; }
        public double LikeRatio
        {
            get
            {
                double likes = Likes;
                double dislikes = Dislikes;
                double total = likes + dislikes;
                return likes / total * 100;
            }
        }
        public int Likes
        {
            get
            {
                int sum = 0;
                foreach (Food f in Menu)
                {
                    sum += f.Likes;
                }
                return sum;
            }
        }
        public int Dislikes
        {
            get
            {
                int sum = 0;
                foreach (Food f in Menu)
                {
                    sum += f.Dislikes;
                }
                return sum;
            }
        }
    }
}
