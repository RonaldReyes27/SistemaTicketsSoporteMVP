using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaTicketsSoporteMVP.Models.Entities;


namespace SistemaTicketsSoporteMVP.Models.Repositories
{
    public class InMemoryTicketRepository : ITicketRepository
    {
        //TODO creamos una lista privada de tickets para almacenar los tickets en memoria
        private readonly List<Ticket> _tickets = new List<Ticket>();

        //implementamos los metodos de la interfaz ITicketRepository
        public void Add(Ticket ticket)
            {
                _tickets.Add(ticket);
            }

            public IEnumerable<Ticket> GetAll()
            {
                return _tickets;
            }

            public Ticket GetById(int id)
            {
                return _tickets.FirstOrDefault(t => t.Id == id);
            }
        
    }
}

//TODO esta clase solo gestiona almacenamiento en memoria, no crea tickets ni maneja logica de negocio