using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaTicketsSoporteMVP.Models.Entities;
using SistemaTicketsSoporteMVP.Models.Repositories;
using SistemaTicketsSoporteMVP.Views.Interfaces;

namespace SistemaTicketsSoporteMVP.Presenters
{
    //el presentador actua como intermediario entre la vista y el modelo
    public class TicketPresenter
    {
        private readonly ITicketView _view; //referencia a la vista
        private readonly ITicketRepository _repository; //referencia al repositorio de tickets, que tiene la logica
                                                        //de almacenamiento (y esta la del modelo)
        private int _nextId = 1; //contador para asignar ids unicos a los tickets

        //constructor que recibe la vista y el repositorio por inyeccion de dependencias
        public TicketPresenter(ITicketView view, ITicketRepository repository) 
        {
            _view = view; 
            _repository = repository; 

            _view.CrearTicket += OnCrearTicket; //suscribimos los metodos a los eventos de la vista
            _view.CerrarTicket += OnCerrarTicket;

            CargarTickets(); //cargamos los tickets al iniciar el presentador
        }

        //metodo que maneja la creacion de un nuevo ticket, es privado porque solo lo usa el presentador
        private void OnCrearTicket(object sender, System.EventArgs e)
        {
            var titulo = _view.Titulo;
            var descripcion = _view.Descripcion;

            if (string.IsNullOrWhiteSpace(titulo))
            {
                _view.MostrarMensaje("El título es obligatorio.");
                return;
            }

            var ticket = new Ticket(_nextId++, titulo, descripcion);
            _repository.Add(ticket);

            CargarTickets();
        }

        //metodo que maneja el cierre de un ticket existente
        private void OnCerrarTicket(object sender, System.EventArgs e)
        {
            var ticket = _repository.GetById(_view.SelectedTicketId); //obtenemos el ticket seleccionado en la vista

            if (ticket == null)
            {
                _view.MostrarMensaje("Debe seleccionar un ticket.");
                return;
            }

            ticket.Cerrar();
            CargarTickets();
        }

        //metodo que carga los tickets desde el repositorio y los muestra en la vista
        private void CargarTickets()
        {
            var tickets = _repository.GetAll(); //obtenemos todos los tickets del repositorio
                                                //y los pasamos a la vista
            _view.MostrarTickets(tickets);
        }
    }
}

//si mas adelante queremos cambiar algo de la vista o del modelo, no necesitamos modificar el presentador
//cumpliendo con la arquitectura MVP 

//Tambien se cumplen los principios SOLID 

//Single R: La clase TicketPresenter tiene una única responsabilidad, que es actuar como intermediario entre la vista y el modelo
//Abierto/Cerrado: podemos agregar más funcionalidades pero no necesitamos cambiar el código existente para agregarlas 
//Liskov: no, porque no hay herencia
//Segregación de Interfaces: TicketPresenter depende de interfaces (ITicketView e ITicketRepository) en lugar de implementaciones concretas, lo que permite una mayor flexibilidad y desacoplamiento.
//Inversión de Dependencias: TicketPresenter depende de abstracciones (interfaces) en lugar de concreciones, lo que facilita la prueba y el mantenimiento del código.


//el presenter no conoce la implementacion concreta de la vista ni del repositorio, solo interactua con las interfaces