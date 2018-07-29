using Aviato.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Aviato
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            myFrame.Navigate(typeof(HomeView));
            textHeader.Text = "Home";
        }

        private void gamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }

        private void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (flightItem.IsSelected)
            {
                myFrame.Navigate(typeof(FlightView));
                textHeader.Text = "Flights";
            }
            else if (ticketItem.IsSelected)
            {
                myFrame.Navigate(typeof(TicketView));
                textHeader.Text = "Tickets";
            }
            else if (stewardessItem.IsSelected)
            {
                myFrame.Navigate(typeof(StewardessView));
                textHeader.Text = "Stewardesses";
            }
            else if (pilotItem.IsSelected)
            {
                myFrame.Navigate(typeof(PilotView));
                textHeader.Text = "Pilots";
            }
            else if (crewItem.IsSelected)
            {
                myFrame.Navigate(typeof(CrewView));
                textHeader.Text = "Crews";
            }
            else if (departureItem.IsSelected)
            {
                myFrame.Navigate(typeof(DepartureView));
                textHeader.Text = "Departures";
            }
            else if (planeItem.IsSelected)
            {
                myFrame.Navigate(typeof(PlaneView));
                textHeader.Text = "Planes";
            }
            else if (planeTypeItem.IsSelected)
            {
                myFrame.Navigate(typeof(PlaneTypeView));
                textHeader.Text = "Plane Types";
            }
        }

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(typeof(HomeView));
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}
