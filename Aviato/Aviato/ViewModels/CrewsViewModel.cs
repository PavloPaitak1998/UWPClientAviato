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
    public class CrewsViewModel:ViewModelBase
    {
        CrewService _crewService;
        INavigationService _navigationService;

        ObservableCollection<Crew> _crews;
        public ObservableCollection<Crew> Crews
        {
            get
            {
                return _crews;
            }
            set
            {
                _crews = value;
                RaisePropertyChanged(() => Crews);
            }
        }

        public ICommand NewCrew { get; private set; }
        public ICommand AddCrew { get; private set; }
        public ICommand UpdateCrew { get; private set; }
        public ICommand DeleteCrew { get; private set; }

        private Crew _crew;
        public Crew Crew
        {
            get
            {
                return _crew;
            }
            set
            {
                _crew = value;
                if (Crew != null)
                {
                    CrewId = Crew.Id;
                }
                RaisePropertyChanged(() => Crew);
            }
        }

        int _crewId = 0;
        public int CrewId
        {
            get { return _crewId; }
            set
            {
                _crewId = value;
                RaisePropertyChanged(() => CrewId);
            }
        }

        private Crew _selectedCrew;
        public Crew SelectedCrew
        {
            get { return _selectedCrew; }
            set
            {
                _selectedCrew = value;
                Crew = _selectedCrew;

                RaisePropertyChanged(() => SelectedCrew);
            }
        }


        public CrewsViewModel(INavigationService navigationService)
        {
            _crewService = new CrewService();
            _navigationService = navigationService;

            NewCrew = new RelayCommand(New);
            AddCrew = new RelayCommand(Create);
            UpdateCrew = new RelayCommand(Update);
            DeleteCrew = new RelayCommand(Delete);

            LoadCrews().ConfigureAwait(false);
            Crew = new Crew();
        }

        async void Create()
        {
            await _crewService.Create(Crew);
            await LoadCrews().ConfigureAwait(false);
        }

        async void Update()
        {
            await _crewService.Update(Crew);
            await LoadCrews().ConfigureAwait(false);
        }

        async void Delete()
        {
            await _crewService.Delete(Crew.Id);
            Crew = new Crew();
            await LoadCrews().ConfigureAwait(false);
        }

        void New()
        {
            Crew = new Crew();
        }

        async Task LoadCrews()
        {
            Crews = new ObservableCollection<Crew>();
            foreach (var crew in await _crewService.GetAll())
            {
                Crews.Add(crew);
            }
        }

    }
}
