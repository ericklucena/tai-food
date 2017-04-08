using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace TAIFood.Models
{
    public class Food : INotifyPropertyChanged
    {
        public Food ()
        {
            ExtraInfoVisibility = Visibility.Collapsed;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        private bool _Liked;
        public bool Liked { get { return _Liked; } }
        private bool _Disliked;
        public bool Disliked { get { return _Disliked; } }
        public int _Likes;
        public int Likes { get { return _Likes; } }
        public int _Dislikes;
        public int Dislikes { get { return _Dislikes; } }
        public EFoodRestriction FoodRestrictions { get; set; }
        public double Price { get; set; }

        public bool VeganSafe { get { return (FoodRestrictions & EFoodRestriction.Vegan) != EFoodRestriction.None; } }
        public bool VegetarianSafe { get { return (FoodRestrictions & EFoodRestriction.Vegetarian) != EFoodRestriction.None; } }
        public bool GlutenSafe { get { return (FoodRestrictions & EFoodRestriction.Gluten) != EFoodRestriction.None; } }
        public bool LactoseSafe { get { return (FoodRestrictions & EFoodRestriction.Lactose) != EFoodRestriction.None; } }
        public bool SaltSafe { get { return (FoodRestrictions & EFoodRestriction.Salt) != EFoodRestriction.None; } }
        public bool SugarSafe { get { return (FoodRestrictions & EFoodRestriction.Sugar) != EFoodRestriction.None; } }

        public double LikeRatio
        {
            get
            {
                double total = _Likes + _Dislikes;
                return _Likes / total * 100;
            }
        }

        private Visibility extraInfoVisibility;
        public Visibility ExtraInfoVisibility {
            get { return this.extraInfoVisibility; }
            set
            {
                if (value != extraInfoVisibility)
                {
                    this.extraInfoVisibility = value;
                    NotifyPropertyChanged("ExtraInfoVisibility");
                }
            }
        }
        public string PriceString
        {
            get
            {
                return "R$ " + Price;
            }
        }


        public void ToggleVisibility()
        {
            if (ExtraInfoVisibility == Visibility.Collapsed)
                ExtraInfoVisibility = Visibility.Visible;
            else
                ExtraInfoVisibility = Visibility.Collapsed;
        }

        public void Like()
        {
            if (!Liked)
            {
                _Likes++;
                _Liked = true;
                NotifyPropertyChanged("Likes");
                NotifyPropertyChanged("Liked");
            }
            if (Disliked)
            {
                _Disliked = false;
                _Dislikes--;
                NotifyPropertyChanged("Disliked");
                NotifyPropertyChanged("Dislikes");
            }

            NotifyPropertyChanged("LikeRatio");
        }

        public void Dislike()
        {
            if (!Disliked)
            {
                _Dislikes++;
                _Disliked = true;
                NotifyPropertyChanged("Dislikes");
                NotifyPropertyChanged("Disliked");
            }
            if (Liked)
            {
                _Liked = false;
                _Likes--;
                NotifyPropertyChanged("Likes");
                NotifyPropertyChanged("Liked");
            }

            NotifyPropertyChanged("LikeRatio");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
