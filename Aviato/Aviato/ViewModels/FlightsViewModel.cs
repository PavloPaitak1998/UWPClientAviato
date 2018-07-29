using Aviato.Models;
using Aviato.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Aviato.ViewModels
{
    public class FlightsViewModel: ViewModelBase
    {
        FlightService _flightService;
        INavigationService _navigationService;

        ObservableCollection<Flight> _flights;
        public ObservableCollection<Flight> Flights
        {
            get
            {
                return _flights;
            }
            set
            {
                _flights = value;
                RaisePropertyChanged(() => Flights);
            }
        }

        public ICommand NewFlight { get; private set; }
        public ICommand AddFlight { get; private set; }
        public ICommand UpdateFlight { get; private set; }
        public ICommand DeleteFlight { get; private set; }

        private Flight _flight;
        public Flight Flight
        {
            get
            {
                return _flight;
            }
            set
            {
                _flight = value;
                if (Flight != null)
                {
                    FlightId = Flight.Id;
                }
                RaisePropertyChanged(() => Flight);
            }
        }

        int _flightId = 0;
        public int FlightId
        {
            get { return _flightId; }
            set
            {
                _flightId = value;
                RaisePropertyChanged(() => FlightId);
            }
        }

        private Flight _selectedFlight;
        public Flight SelectedFlight
        {
            get { return _selectedFlight; }
            set
            {
                _selectedFlight = value;
                Flight = _selectedFlight;

                RaisePropertyChanged(() => SelectedFlight);
            }
        }


        public FlightsViewModel(INavigationService navigationService)
        {
            _flightService = new FlightService();
            _navigationService = navigationService;

            NewFlight = new RelayCommand(New);
            AddFlight = new RelayCommand(Create);
            UpdateFlight = new RelayCommand(Update);
            DeleteFlight = new RelayCommand(Delete);

            LoadFlights().ConfigureAwait(false);
            Flight = new Flight();
        }

        async void Create()
        {
            await _flightService.Create(Flight);
            await LoadFlights().ConfigureAwait(false);
        }

        async void Update()
        {
            await _flightService.Update(Flight);
            await LoadFlights().ConfigureAwait(false);
        }

        async void Delete()
        {
            await _flightService.Delete(Flight.Id);
            Flight = new Flight();
            await LoadFlights().ConfigureAwait(false);
        }

        void New()
        {
            Flight = new Flight();
        }

        async Task LoadFlights()
        {
            Flights = new ObservableCollection<Flight>();
            //Flights.Add(new Flight() { Id = 1, Number = 1111, PointOfDeparture = "Lviv", DepartureTime = DateTime.Now, Destination = "London", DestinationTime = DateTime.Now });
            //Flights.Add(new Flight() { Id = 1, Number = 1111, PointOfDeparture = "Lviv", DepartureTime = DateTime.Now, Destination = "London", DestinationTime = DateTime.Now });
            foreach (var flight in await _flightService.GetAll())
            {
                Flights.Add(flight);
            }
        }
    }
}
