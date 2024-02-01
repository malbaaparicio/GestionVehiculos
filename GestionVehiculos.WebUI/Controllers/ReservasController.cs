using GestionVehiculos.Domain;
using GestionVehiculos.Domain.Abstract;
using GestionVehiculos.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionVehiculos.WebUI.Controllers
{
    public class ReservasController : Controller
    {
        public IReservas reservas;
        public int pageSize = 8;

        public ReservasController(IReservas reservas)
        {
            this.reservas = reservas;            
        }


        // GET: Reservas
        public ViewResult ListaReservas(string filtro, string valor, int page = 1) 
        {
            ListaReservasPaginado listaReservasPaginado = null;
            if(filtro == null || string.IsNullOrEmpty(valor))
            {
                listaReservasPaginado = new ListaReservasPaginado()
                {
                    reservas = reservas.GetReservas.
                    OrderBy(z => z.Reservarid).
                    Skip((page - 1) * pageSize).
                    Take(pageSize),
                    pagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = reservas.GetReservas.Count()
                    },
                    filtro = filtro, 
                    terminoBusqueda = valor
                };
            }
            return View(listaReservasPaginado);
        }

        public ViewResult Ver(int reservaId)
        {
            Reservas reserva = reservas.GetReservas.Where(z=>z.Reservarid == reservaId).FirstOrDefault();
            return View(reserva);
        }
    }
}