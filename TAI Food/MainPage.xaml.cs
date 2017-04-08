using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TAIFood.Data;
using TAIFood.Models;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace TAIFood
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Restaurant> Restaurants { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            Restaurants = FakeRepository.GetRestaurants(6);
            RestaurantListView.ItemsSource = Restaurants;
            CenterMap();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void RestaurantListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(RestaurantPage));
        }

        private async void CenterMap()
        {
            string errorMessage = null;

            try
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                {
                    Geolocator geolocator = new Geolocator();
                    Geoposition geoposition = null;
                    geoposition = await geolocator.GetGeopositionAsync();
                    
                    await MainMapControl.TrySetViewAsync(geoposition.Coordinate.Point, 16, 0, 0, Windows.UI.Xaml.Controls.Maps.MapAnimationKind.Bow);
                    //mapControl.Center = geoposition.Coordinate.Point;
                    //mapControl.ZoomLevel = 16;
                });
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            if (errorMessage != null)
            {
                MessageDialog msg = new MessageDialog("Não foi possível localizar o seu dispositivo. Por favor verifique se o sistema de localização de seu telefone está ativado para uma melhor experiência de uso.", "Seu GPS está ativado?");
                await msg.ShowAsync();
            }


        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPage));
        }
    }
}
