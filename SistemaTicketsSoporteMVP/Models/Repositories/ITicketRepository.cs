using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaTicketsSoporteMVP.Models.Entities;


namespace SistemaTicketsSoporteMVP.Models.Repositories
{
    public interface ITicketRepository
    {
        public void Add(Ticket ticket); // agregar un ticket
        IEnumerable<Ticket> GetAll();// obtener todos los tickets
        Ticket GetById(int id);// obtener un ticket por su id
    }
}
