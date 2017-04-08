using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TAIFood.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers.Provider;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace TAIFood
{
    public sealed partial class AddFoodDialog : ContentDialog
    {
        public Restaurant Restaurant { get; set; }

        public AddFoodDialog()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Food food = new Food()
            {
                Name = name.Text,
                Description = description.Text,
                Price = double.Parse(price.Text),
                FoodRestrictions = EFoodRestriction.None
            };

            if (vegan.IsChecked == true)
            {
                food.FoodRestrictions |= EFoodRestriction.Vegan;
            }
            if (vegetarian.IsChecked == true)
            {
                food.FoodRestrictions |= EFoodRestriction.Vegetarian;
            }
            if (lactose.IsChecked == true)
            {
                food.FoodRestrictions |= EFoodRestriction.Lactose;
            }
            if (gluten.IsChecked == true)
            {
                food.FoodRestrictions |= EFoodRestriction.Gluten;
            }
            if (salt.IsChecked == true)
            {
                food.FoodRestrictions |= EFoodRestriction.Salt;
            }
            if (sugar.IsChecked == true)
            {
                food.FoodRestrictions |= EFoodRestriction.Sugar;
            }

            Restaurant.Menu.Add(food);

            this.Hide();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Hide();
        }
    }
}
