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
    public class PlaneTypesViewModel : ViewModelBase
    {
        PlaneTypeService _planeTypeService;
        INavigationService _navigationService;

        ObservableCollection<PlaneType> _planeTypes;
        public ObservableCollection<PlaneType> PlaneTypes
        {
            get
            {
                return _planeTypes;
            }
            set
            {
                _planeTypes = value;
                RaisePropertyChanged(() => PlaneTypes);
            }
        }

        public ICommand NewPlaneType { get; private set; }
        public ICommand AddPlaneType { get; private set; }
        public ICommand UpdatePlaneType { get; private set; }
        public ICommand DeletePlaneType { get; private set; }

        private PlaneType _planeType;
        public PlaneType PlaneType
        {
            get
            {
                return _planeType;
            }
            set
            {
                _planeType = value;
                if (PlaneType != null)
                {
                    PlaneTypeId = PlaneType.Id;
                }
                RaisePropertyChanged(() => PlaneType);
            }
        }

        int _planeTypeId = 0;
        public int PlaneTypeId
        {
            get { return _planeTypeId; }
            set
            {
                _planeTypeId = value;
                RaisePropertyChanged(() => PlaneTypeId);
            }
        }

        private PlaneType _selectedPlaneType;
        public PlaneType SelectedPlaneType
        {
            get { return _selectedPlaneType; }
            set
            {
                _selectedPlaneType = value;
                PlaneType = _selectedPlaneType;

                RaisePropertyChanged(() => SelectedPlaneType);
            }
        }


        public PlaneTypesViewModel(INavigationService navigationService)
        {
            _planeTypeService = new PlaneTypeService();
            _navigationService = navigationService;

            NewPlaneType = new RelayCommand(New);
            AddPlaneType = new RelayCommand(Create);
            UpdatePlaneType = new RelayCommand(Update);
            DeletePlaneType = new RelayCommand(Delete);

            LoadPlaneTypes().ConfigureAwait(false);
            PlaneType = new PlaneType();
        }

        async void Create()
        {
            await _planeTypeService.Create(PlaneType);
            await LoadPlaneTypes().ConfigureAwait(false);
        }

        async void Update()
        {
            await _planeTypeService.Update(PlaneType);
            await LoadPlaneTypes().ConfigureAwait(false);
        }

        async void Delete()
        {
            await _planeTypeService.Delete(PlaneType.Id);
            PlaneType = new PlaneType();
            await LoadPlaneTypes().ConfigureAwait(false);
        }

        void New()
        {
            PlaneType = new PlaneType();
        }

        async Task LoadPlaneTypes()
        {
            PlaneTypes = new ObservableCollection<PlaneType>();
            foreach (var planeType in await _planeTypeService.GetAll())
            {
                PlaneTypes.Add(planeType);
            }
        }
    }
}
