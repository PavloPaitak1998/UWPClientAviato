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
    public class PilotsViewModel : ViewModelBase
    {
        PilotService _pilotService;
        INavigationService _navigationService;

        ObservableCollection<Pilot> _pilots;
        public ObservableCollection<Pilot> Pilots
        {
            get
            {
                return _pilots;
            }
            set
            {
                _pilots = value;
                RaisePropertyChanged(() => Pilots);
            }
        }

        public ICommand NewPilot { get; private set; }
        public ICommand AddPilot { get; private set; }
        public ICommand UpdatePilot { get; private set; }
        public ICommand DeletePilot { get; private set; }

        private Pilot _pilot;
        public Pilot Pilot
        {
            get
            {
                return _pilot;
            }
            set
            {
                _pilot = value;
                if (Pilot != null)
                {
                    PilotId = Pilot.Id;
                }
                RaisePropertyChanged(() => Pilot);
            }
        }

        int _pilotId = 0;
        public int PilotId
        {
            get { return _pilotId; }
            set
            {
                _pilotId = value;
                RaisePropertyChanged(() => PilotId);
            }
        }

        private Pilot _selectedPilot;
        public Pilot SelectedPilot
        {
            get { return _selectedPilot; }
            set
            {
                _selectedPilot = value;
                Pilot = _selectedPilot;

                RaisePropertyChanged(() => SelectedPilot);
            }
        }


        public PilotsViewModel(INavigationService navigationService)
        {
            _pilotService = new PilotService();
            _navigationService = navigationService;

            NewPilot = new RelayCommand(New);
            AddPilot = new RelayCommand(Create);
            UpdatePilot = new RelayCommand(Update);
            DeletePilot = new RelayCommand(Delete);

            LoadPilots().ConfigureAwait(false);
            Pilot = new Pilot();
        }

        async void Create()
        {
            await _pilotService.Create(Pilot);
            await LoadPilots().ConfigureAwait(false);
        }

        async void Update()
        {
            await _pilotService.Update(Pilot);
            await LoadPilots().ConfigureAwait(false);
        }

        async void Delete()
        {
            await _pilotService.Delete(Pilot.Id);
            Pilot = new Pilot();
            await LoadPilots().ConfigureAwait(false);
        }

        void New()
        {
            Pilot = new Pilot();
        }

        async Task LoadPilots()
        {
            Pilots = new ObservableCollection<Pilot>();
            foreach (var pilot in await _pilotService.GetAll())
            {
                Pilots.Add(pilot);
            }
        }
    }
}
