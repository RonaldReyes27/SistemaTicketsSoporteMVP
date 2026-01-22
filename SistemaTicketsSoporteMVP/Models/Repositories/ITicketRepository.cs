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
        //TODO esta interfaz solo define los metodos que debe tener un repositorio de tickets
        public void Add(Ticket ticket); // agregar un ticket
        IEnumerable<Ticket> GetAll();// obtener todos los tickets
        Ticket GetById(int id);// obtener un ticket por su id
    }
}
