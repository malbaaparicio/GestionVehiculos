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
        public ICoches coches;
        public IDelegaciones delegaciones;
        public IClientes clientes;
        public int pageSize = 8;

        public ReservasController(IReservas reservas, ICoches coches, IDelegaciones delegaciones, IClientes clientes)
        {
            this.reservas = reservas;      
            this.coches = coches;
            this.delegaciones = delegaciones;
            this.clientes = clientes;
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

        public ViewResult Edit(int reservaId)
        {
            Reservas reserva = reservas.GetReservas.Where(z => z.Reservarid == reservaId).FirstOrDefault();
            ViewBag.Coches = coches.GetCoches.Select(z => new SelectListItem
            {
                Text = z.Marca + " " +z.Modelo + " " + z.Matricula,
                Value = z.Cocheid.ToString()
            });
            ViewBag.Clientes = clientes.GetClientes.Select(z => new SelectListItem
            {
                Text = z.Nombre + " " + z.Apellidos,
                Value = z.Clienteid.ToString()
            });
            ViewBag.Delegaciones = delegaciones.GetDelegaciones.Select(z => new SelectListItem
            {
                Text = z.Nombre,
                Value = z.Delegacionid.ToString()
            });
            return View(reserva);
        }

        [HttpPost]
        public ActionResult Edit(Reservas reserva)
        {
            if (ModelState.IsValid)
            {
                reservas.SaveReserva(reserva);
                TempData["mensaje"] = "La reserva ha sido actualizada";
                return RedirectToAction("ListaReservas");
            }
            else
            {
                return View(reserva);
            }
        }

        public ViewResult Create()
        {
            ViewBag.Coches = coches.GetCoches.Select(z => new SelectListItem
            {
                Text = z.Marca + " " + z.Modelo + " " + z.Matricula,
                Value = z.Cocheid.ToString()
            });
            ViewBag.Clientes = clientes.GetClientes.Select(z => new SelectListItem
            {
                Text = z.Nombre + " " + z.Apellidos,
                Value = z.Clienteid.ToString()
            });
            ViewBag.Delegaciones = delegaciones.GetDelegaciones.Select(z => new SelectListItem
            {
                Text = z.Nombre,
                Value = z.Delegacionid.ToString()
            });
            return View(new Reservas());
        }

        [HttpPost]
        public ActionResult Create(Reservas reserva)
        {
            if (ModelState.IsValid)
            {
                reservas.CrearReserva(reserva);
                TempData["mensaje"] = "La reserva " + reserva.FechaReserva + " ha sido creada";
                return RedirectToAction("ListaReservas");
            }
            else
            {
                return View(reserva);
            }
        }

        [HttpPost]
        public ActionResult Borrar(Reservas reserva)
        {
            Reservas reservaBorrar = reservas.BorrarReserva(reserva);
            if (reservaBorrar != null)
            {
                TempData["mensaje"] = "La reserva " + reservaBorrar.FechaReserva + " ha sido borrada";

            }
            return RedirectToAction("ListaReservas");
        }

    }
}