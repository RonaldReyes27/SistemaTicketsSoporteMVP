using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaTicketsSoporteMVP.Models.Entities;


namespace SistemaTicketsSoporteMVP.Views.Interfaces
{
    //TODO interfaz que define como se comunica la vista con el presentador
    public interface ITicketView
    {
        // Datos de entrada
        public string Titulo { get; }
        public string Descripcion { get; }
        public int SelectedTicketId { get; }

        // Datos de salida
        public void MostrarTickets(IEnumerable<Ticket> tickets);
        public void MostrarMensaje(string mensaje);

        // Eventos
        event EventHandler CrearTicket;
        event EventHandler CerrarTicket;
    }
}
