using Aviato.ViewModels;
using Aviato.Views;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace Aviato
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var navigationService = new NavigationService();
            navigationService.Configure(nameof(FlightsViewModel), typeof(FlightView));

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
            }
            else
            {
                // Create run time view services and models
            }

            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            SimpleIoc.Default.Register<FlightsViewModel>();
            SimpleIoc.Default.Register<TicketsViewModel>();
            SimpleIoc.Default.Register<DeparturesViewModel>();
            SimpleIoc.Default.Register<StewardessViewModel>();
            SimpleIoc.Default.Register<PilotsViewModel>();
            SimpleIoc.Default.Register<CrewsViewModel>();
            SimpleIoc.Default.Register<PlanesViewModel>();
            SimpleIoc.Default.Register<PlaneTypesViewModel>();

        }


        public FlightsViewModel FlightsVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FlightsViewModel>();
            }
        }
        public TicketsViewModel TicketsVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TicketsViewModel>();
            }
        }
        public DeparturesViewModel DeparturesVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DeparturesViewModel>();
            }
        }
        public StewardessViewModel StewardessesVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StewardessViewModel>();
            }
        }
        public PilotsViewModel PilotsVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PilotsViewModel>();
            }
        }
        public CrewsViewModel CrewsVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CrewsViewModel>();
            }
        }
        public PlanesViewModel PlanesVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PlanesViewModel>();
            }
        }
        public PlaneTypesViewModel PlaneTypesVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PlaneTypesViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
