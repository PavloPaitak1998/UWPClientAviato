using Aviato.Models;
using Aviato.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Aviato.ViewModels
{
    public class DeparturesViewModel : ViewModelBase
    {
        DepartureService _departureService;
        INavigationService _navigationService;

        ObservableCollection<Departure> _departures;
        public ObservableCollection<Departure> Departures
        {
            get
            {
                return _departures;
            }
            set
            {
                _departures = value;
                RaisePropertyChanged(() => Departures);
            }
        }

        public ICommand NewDeparture { get; private set; }
        public ICommand AddDeparture { get; private set; }
        public ICommand UpdateDeparture { get; private set; }
        public ICommand DeleteDeparture { get; private set; }

        private Departure _departure;
        public Departure Departure
        {
            get
            {
                return _departure;
            }
            set
            {
                _departure = value;
                if (Departure != null)
                {
                    DepartureId = Departure.Id;
                }
                RaisePropertyChanged(() => Departure);
            }
        }

        int _departureId = 0;
        public int DepartureId
        {
            get { return _departureId; }
            set
            {
                _departureId = value;
                RaisePropertyChanged(() => DepartureId);
            }
        }

        private Departure _selectedDeparture;
        public Departure SelectedDeparture
        {
            get { return _selectedDeparture; }
            set
            {
                _selectedDeparture = value;
                Departure = _selectedDeparture;

                RaisePropertyChanged(() => SelectedDeparture);
            }
        }


        public DeparturesViewModel(INavigationService navigationService)
        {
            _departureService = new DepartureService();
            _navigationService = navigationService;

            NewDeparture = new RelayCommand(New);
            AddDeparture = new RelayCommand(Create);
            UpdateDeparture = new RelayCommand(Update);
            DeleteDeparture = new RelayCommand(Delete);

            LoadDepartures().ConfigureAwait(false);
            Departure = new Departure();
        }

        async void Create()
        {
            await _departureService.Create(Departure);
            await LoadDepartures().ConfigureAwait(false);
        }

        async void Update()
        {
            await _departureService.Update(Departure);
            await LoadDepartures().ConfigureAwait(false);
        }

        async void Delete()
        {
            await _departureService.Delete(Departure.Id);
            Departure = new Departure();
            await LoadDepartures().ConfigureAwait(false);
        }

        void New()
        {
            Departure = new Departure();
        }

        async Task LoadDepartures()
        {
            Departures = new ObservableCollection<Departure>();
            foreach (var departure in await _departureService.GetAll())
            {
                Departures.Add(departure);
            }
        }
    }
}
