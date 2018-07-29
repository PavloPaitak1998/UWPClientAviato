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
    public class StewardessViewModel : ViewModelBase
    {
        StewardessService _stewardessService;
        INavigationService _navigationService;

        ObservableCollection<Stewardess> _stewardesses;
        public ObservableCollection<Stewardess> Stewardesses
        {
            get
            {
                return _stewardesses;
            }
            set
            {
                _stewardesses = value;
                RaisePropertyChanged(() => Stewardesses);
            }
        }

        public ICommand NewStewardess { get; private set; }
        public ICommand AddStewardess { get; private set; }
        public ICommand UpdateStewardess { get; private set; }
        public ICommand DeleteStewardess { get; private set; }

        private Stewardess _stewardess;
        public Stewardess Stewardess
        {
            get
            {
                return _stewardess;
            }
            set
            {
                _stewardess = value;
                if (Stewardess != null)
                {
                    StewardessId = Stewardess.Id;
                }
                RaisePropertyChanged(() => Stewardess);
            }
        }

        int _stewardessId = 0;
        public int StewardessId
        {
            get { return _stewardessId; }
            set
            {
                _stewardessId = value;
                RaisePropertyChanged(() => StewardessId);
            }
        }

        private Stewardess _selectedStewardess;
        public Stewardess SelectedStewardess
        {
            get { return _selectedStewardess; }
            set
            {
                _selectedStewardess = value;
                Stewardess = _selectedStewardess;

                RaisePropertyChanged(() => SelectedStewardess);
            }
        }


        public StewardessViewModel(INavigationService navigationService)
        {
            _stewardessService = new StewardessService();
            _navigationService = navigationService;

            NewStewardess = new RelayCommand(New);
            AddStewardess = new RelayCommand(Create);
            UpdateStewardess = new RelayCommand(Update);
            DeleteStewardess = new RelayCommand(Delete);

            LoadStewardesss().ConfigureAwait(false);
            Stewardess = new Stewardess();
        }

        async void Create()
        {
            await _stewardessService.Create(Stewardess);
            await LoadStewardesss().ConfigureAwait(false);
        }

        async void Update()
        {
            await _stewardessService.Update(Stewardess);
            await LoadStewardesss().ConfigureAwait(false);
        }

        async void Delete()
        {
            await _stewardessService.Delete(Stewardess.Id);
            Stewardess = new Stewardess();
            await LoadStewardesss().ConfigureAwait(false);
        }

        void New()
        {
            Stewardess = new Stewardess();
        }

        async Task LoadStewardesss()
        {
            Stewardesses = new ObservableCollection<Stewardess>();
            foreach (var stewardess in await _stewardessService.GetAll())
            {
                Stewardesses.Add(stewardess);
            }
        }
    }
}
