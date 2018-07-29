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
    public class PlanesViewModel : ViewModelBase
    {
        PlaneService _planeService;
        INavigationService _navigationService;

        ObservableCollection<Plane> _planes;
        public ObservableCollection<Plane> Planes
        {
            get
            {
                return _planes;
            }
            set
            {
                _planes = value;
                RaisePropertyChanged(() => Planes);
            }
        }

        public ICommand NewPlane { get; private set; }
        public ICommand AddPlane { get; private set; }
        public ICommand UpdatePlane { get; private set; }
        public ICommand DeletePlane { get; private set; }

        private Plane _plane;
        public Plane Plane
        {
            get
            {
                return _plane;
            }
            set
            {
                _plane = value;
                if (Plane != null)
                {
                    PlaneId = Plane.Id;
                }
                RaisePropertyChanged(() => Plane);
            }
        }

        int _planeId = 0;
        public int PlaneId
        {
            get { return _planeId; }
            set
            {
                _planeId = value;
                RaisePropertyChanged(() => PlaneId);
            }
        }

        private Plane _selectedPlane;
        public Plane SelectedPlane
        {
            get { return _selectedPlane; }
            set
            {
                _selectedPlane = value;
                Plane = _selectedPlane;

                RaisePropertyChanged(() => SelectedPlane);
            }
        }


        public PlanesViewModel(INavigationService navigationService)
        {
            _planeService = new PlaneService();
            _navigationService = navigationService;

            NewPlane = new RelayCommand(New);
            AddPlane = new RelayCommand(Create);
            UpdatePlane = new RelayCommand(Update);
            DeletePlane = new RelayCommand(Delete);

            LoadPlanes().ConfigureAwait(false);
            Plane = new Plane();
        }

        async void Create()
        {
            await _planeService.Create(Plane);
            await LoadPlanes().ConfigureAwait(false);
        }

        async void Update()
        {
            await _planeService.Update(Plane);
            await LoadPlanes().ConfigureAwait(false);
        }

        async void Delete()
        {
            await _planeService.Delete(Plane.Id);
            Plane = new Plane();
            await LoadPlanes().ConfigureAwait(false);
        }

        void New()
        {
            Plane = new Plane();
        }

        async Task LoadPlanes()
        {
            Planes = new ObservableCollection<Plane>();
            foreach (var plane in await _planeService.GetAll())
            {
                Planes.Add(plane);
            }
        }
    }
}
