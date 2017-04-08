using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TAIFood.Data;
using TAIFood.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace TAIFood
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RestaurantPage : Page
    {
        private Food onFocus = null;
        private Restaurant restaurant;

        public RestaurantPage()
        {
            this.InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            restaurant = FakeRepository.FakeRestaurant(5);
            FoodListView.ItemsSource = restaurant.Menu;


            RestaurantNameTextBlock.Text = restaurant.Name;
            RestaurantDescriptionTextBlock.Text = restaurant.Description;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void FoodListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Food food = e.ClickedItem as Food;

            if (food != onFocus)
            {
                onFocus?.ToggleVisibility();
                food.ToggleVisibility();
            }

            onFocus = food;
            RefreshLikeButtons();
        }

        private void RefreshLikeButtons()
        {
            if (onFocus != null)
            {
                LikeButton.Visibility = DislikeButton.Visibility = Visibility.Visible;
                LikeButton.IsEnabled = !onFocus.Liked;
                DislikeButton.IsEnabled = !onFocus.Disliked;
            }
        }

        private void LikeButton_Click(object sender, RoutedEventArgs e)
        {
            onFocus?.Like();
            RefreshLikeButtons();
        }

        private void DislikeButton_Click(object sender, RoutedEventArgs e)
        {
            onFocus?.Dislike();
            RefreshLikeButtons();
        }

        private async void InsertFoodButton_Click(object sender, RoutedEventArgs e)
        {
            AddFoodDialog dialog = new AddFoodDialog();
            dialog.Restaurant = restaurant;
            await dialog.ShowAsync();
        }
    }
}
