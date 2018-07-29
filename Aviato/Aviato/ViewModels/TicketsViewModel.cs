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
    public class TicketsViewModel : ViewModelBase
    {
        TicketService _ticketService;
        INavigationService _navigationService;

        ObservableCollection<Ticket> _tickets;
        public ObservableCollection<Ticket> Tickets
        {
            get
            {
                return _tickets;
            }
            set
            {
                _tickets = value;
                RaisePropertyChanged(() => Tickets);
            }
        }

        public ICommand NewTicket { get; private set; }
        public ICommand AddTicket { get; private set; }
        public ICommand UpdateTicket { get; private set; }
        public ICommand DeleteTicket { get; private set; }

        private Ticket _ticket;
        public Ticket Ticket
        {
            get
            {
                return _ticket;
            }
            set
            {
                _ticket = value;
                if (Ticket != null)
                {
                    TicketId = Ticket.Id;
                }
                RaisePropertyChanged(() => Ticket);
            }
        }

        int _ticketId = 0;
        public int TicketId
        {
            get { return _ticketId; }
            set
            {
                _ticketId = value;
                RaisePropertyChanged(() => TicketId);
            }
        }

        private Ticket _selectedTicket;
        public Ticket SelectedTicket
        {
            get { return _selectedTicket; }
            set
            {
                _selectedTicket = value;
                Ticket = _selectedTicket;

                RaisePropertyChanged(() => SelectedTicket);
            }
        }


        public TicketsViewModel(INavigationService navigationService)
        {
            _ticketService = new TicketService();
            _navigationService = navigationService;

            NewTicket = new RelayCommand(New);
            AddTicket = new RelayCommand(Create);
            UpdateTicket = new RelayCommand(Update);
            DeleteTicket = new RelayCommand(Delete);

            LoadTickets().ConfigureAwait(false);
            Ticket = new Ticket();
        }

        async void Create()
        {
            await _ticketService.Create(Ticket);
            await LoadTickets().ConfigureAwait(false);
        }

        async void Update()
        {
            await _ticketService.Update(Ticket);
            await LoadTickets().ConfigureAwait(false);
        }

        async void Delete()
        {
            await _ticketService.Delete(Ticket.Id);
            Ticket = new Ticket();
            await LoadTickets().ConfigureAwait(false);
        }

        void New()
        {
            Ticket = new Ticket();
        }

        async Task LoadTickets()
        {
            Tickets = new ObservableCollection<Ticket>();
            foreach (var ticket in await _ticketService.GetAll())
            {
                Tickets.Add(ticket);
            }
        }
    }
}
