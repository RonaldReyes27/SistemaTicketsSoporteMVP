using System;
using System.Collections.Generic;
using System.Windows;
using SistemaTicketsSoporteMVP.Models.Entities;
using SistemaTicketsSoporteMVP.Models.Repositories;
using SistemaTicketsSoporteMVP.Presenters;
using SistemaTicketsSoporteMVP.Views.Interfaces;

namespace SistemaTicketsSoporteMVP.Views
{
    // MainWindow actúa como la Vista dentro del patrón MVP
    public partial class MainWindow : Window, ITicketView
    {
        // Eventos que el Presenter va a escuchar
        public event EventHandler CrearTicket;
        public event EventHandler CerrarTicket;

        // Referencia al Presenter
        private readonly TicketPresenter _presenter;

        public MainWindow()
        {
            InitializeComponent(); // Inicializa los componentes visuales (XAML)

            // Se crea el Presenter y se le inyecta la Vista (this) y el Repositorio
            _presenter = new TicketPresenter(this, new InMemoryTicketRepository());
        }

        // Propiedad que devuelve el texto del título del ticket desde la UI
        public string Titulo => TxtTitulo.Text;

        // Propiedad que devuelve la descripción del ticket desde la UI
        public string Descripcion => TxtDescripcion.Text;

        // Obtiene el ID del ticket seleccionado en la lista
        public int SelectedTicketId
        {
            get
            {
                // Verifica si el elemento seleccionado es un Ticket
                if (LstTickets.SelectedItem is Ticket ticket)
                    return ticket.Id;

                // Retorna 0 si no hay ticket seleccionado
                return 0;
            }
        }

        // Muestra la lista de tickets en el control visual
        public void MostrarTickets(IEnumerable<Ticket> tickets)
        {
            // Se limpia el origen de datos
            LstTickets.ItemsSource = null;

            // Se asigna la nueva lista de tickets
            LstTickets.ItemsSource = tickets;
        }

        // Muestra un mensaje al usuario
        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(
                mensaje,
                "Sistema de Tickets",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );
        }

        // Evento del botón Crear Ticket
        private void BtnCrearTicketClick(object sender, RoutedEventArgs e)
        {
            // Dispara el evento para que el Presenter lo maneje
            CrearTicket?.Invoke(this, EventArgs.Empty);
        }

        // Evento del botón Cerrar Ticket
        private void BtnCerrarTicketClick(object sender, RoutedEventArgs e)
        {
            // Dispara el evento para que el Presenter lo maneje
            CerrarTicket?.Invoke(this, EventArgs.Empty);
        }
    }
}