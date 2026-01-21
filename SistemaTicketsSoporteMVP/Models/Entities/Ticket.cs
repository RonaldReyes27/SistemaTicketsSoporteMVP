using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTicketsSoporteMVP.Models.Entities
{
    //creamos la enumeracion TicketStatus con los estados Abierto y Cerrado
    public enum TicketStatus
    {
        Abierto,
        Cerrado
    }
    //creamos la clase Ticket con las propiedades Id, Titulo, Descripcion y Estado
    public class Ticket
    {
        public int Id { get; }
        public string Titulo { get; }
        public string Descripcion { get; }
        public TicketStatus Estado { get; private set; }


        //creamos el constructor de la clase Ticket
        public Ticket(int id, string titulo, string descripcion)
        {
            Id = id;
            Titulo = titulo;
            Descripcion = descripcion;
            Estado = TicketStatus.Abierto;
        }

        //creamos el metodo Cerrar que cambia el estado del ticket a Cerrado, por default siempre estara Abierto
        //es un comportamiento propio de la clase Ticket, no involucra logica externa
        public void Cerrar()
        {
            Estado = TicketStatus.Cerrado;
        }
    }
}

//En este archivo, cumplimos los principios SOLID 

//Single R: La clase Ticket tiene una única responsabilidad, que es representar un ticket de soporte con sus propiedades y comportamientos relacionados.
//Abierto/Cerrado: La clase Ticket está abierta para la extensión (podemos agregar más propiedades o métodos si es necesario) pero cerrada para la modificación (no necesitamos cambiar el código existente para agregar nuevas funcionalidades).
//Liskov: No aplicable directamente en este caso, ya que no hay herencia involucrada.
//Segregación de Interfaces: No aplicable directamente en este caso, ya que no hay interfaces involucradas.
//Inversión de Dependencias: No aplicable directamente en este caso, ya que no hay dependencias entre clases involucradas.

