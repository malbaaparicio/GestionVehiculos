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
    public class DelegacionesController : Controller
    {
        public IDelegaciones delegaciones;
        public int pageSize = 8;

        public DelegacionesController (IDelegaciones delegaciones)
        {
            this.delegaciones = delegaciones;           
        }


        // GET: Delegaciones
        public ViewResult ListaDelegaciones(string filtro, string valor, int page = 1)
        {
            ListaDelegacionesPaginado listaDelegacionesPaginado = null;
            if(filtro == null || string.IsNullOrEmpty(valor))
            {
                listaDelegacionesPaginado = new ListaDelegacionesPaginado()
                {
                    delegaciones = delegaciones.GetDelegaciones.
                    OrderBy(z => z.Delegacionid).
                    Skip((page - 1) * pageSize).
                    Take(pageSize),

                    pagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = delegaciones.GetDelegaciones.Count()
                    },
                    filtro = filtro,
                    terminoBusqueda = valor
                };
            }
            else if(filtro == "Nombre")
            {
                listaDelegacionesPaginado = new ListaDelegacionesPaginado()
                {
                    delegaciones = delegaciones.GetDelegaciones. 
                    Where(p => p.Nombre.ToLower().Contains(valor.ToLower())).
                    OrderBy(z => z.Delegacionid).
                    Skip((page - 1) * pageSize).
                    Take(pageSize),

                    pagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = valor == null ?
                        delegaciones.GetDelegaciones.Count() : 
                        delegaciones.GetDelegaciones.Where(z => z.Nombre.ToLower().Contains(valor.ToLower())).Count()
                    },
                    filtro = filtro,
                    terminoBusqueda = valor
                };
            }
            else if (filtro == "Dirección")
            {
                listaDelegacionesPaginado = new ListaDelegacionesPaginado()
                {
                    delegaciones = delegaciones.GetDelegaciones.
                    Where(p => p.Direccion.ToLower().Contains(valor.ToLower())).
                    OrderBy(z => z.Delegacionid).
                    Skip((page - 1) * pageSize).
                    Take(pageSize),

                    pagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = valor == null ?
                        delegaciones.GetDelegaciones.Count() :
                        delegaciones.GetDelegaciones.Where(z => z.Direccion.ToLower().Contains(valor.ToLower())).Count()
                    },
                    filtro = filtro,
                    terminoBusqueda = valor
                };
            }
            else if (filtro == "Teléfono")
            {
                listaDelegacionesPaginado = new ListaDelegacionesPaginado()
                {
                    delegaciones = delegaciones.GetDelegaciones.
                    Where(p => p.Telefono.ToLower() == valor.ToLower()).
                    OrderBy(z => z.Delegacionid).
                    Skip((page - 1) * pageSize).
                    Take(pageSize),

                    pagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = valor == null ?
                        delegaciones.GetDelegaciones.Count() :
                        delegaciones.GetDelegaciones.Where(z => z.Telefono.ToLower() == valor.ToLower()).Count()
                    },
                    filtro = filtro,
                    terminoBusqueda = valor
                };
            }
            else if (filtro == "Localidad")
            {
                listaDelegacionesPaginado = new ListaDelegacionesPaginado()
                {
                    delegaciones = delegaciones.GetDelegaciones.
                    Where(p => p.Localidad.ToLower().Contains(valor.ToLower())).
                    OrderBy(z => z.Delegacionid).
                    Skip((page - 1) * pageSize).
                    Take(pageSize),

                    pagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = valor == null ?
                        delegaciones.GetDelegaciones.Count() :
                        delegaciones.GetDelegaciones.Where(z => z.Localidad.ToLower().Contains(valor.ToLower())).Count()
                    },
                    filtro = filtro,
                    terminoBusqueda = valor
                };
            }
            else if (filtro == "Email")
            {
                listaDelegacionesPaginado = new ListaDelegacionesPaginado()
                {
                    delegaciones = delegaciones.GetDelegaciones.
                    Where(p => p.Email.ToLower() == valor.ToLower()).
                    OrderBy(z => z.Delegacionid).
                    Skip((page - 1) * pageSize).
                    Take(pageSize),

                    pagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = valor == null ?
                        delegaciones.GetDelegaciones.Count() :
                        delegaciones.GetDelegaciones.Where(z => z.Email.ToLower() == valor.ToLower()).Count()
                    },
                    filtro = filtro,
                    terminoBusqueda = valor
                };
            }
            return View(listaDelegacionesPaginado);
        }

        public ViewResult Ver(int delegacionId)
        {
            Delegaciones delegacion = delegaciones.GetDelegaciones.Where(z => z.Delegacionid == delegacionId).FirstOrDefault();
            return View(delegacion);
        }

        public ViewResult Edit(int delegacionId)
        {
            Delegaciones delegacion = delegaciones.GetDelegaciones.Where(z => z.Delegacionid == delegacionId).FirstOrDefault();
            return View(delegacion);
        }

        [HttpPost]
        public ActionResult Edit(Delegaciones delegacion)
        {
            if (ModelState.IsValid)
            {
                delegaciones.SaveDelegacion(delegacion);
                TempData["mensaje"] = "La delegación ha sido actualizada";
                return RedirectToAction("ListaDelegaciones");
            }
            else
            {
                return View(delegacion);
            }
        }

        public ViewResult Create()
        {
            return View(new Delegaciones());
        }

        [HttpPost]
        public ActionResult Create(Delegaciones delegacion)
        {
            if (ModelState.IsValid)
            {
                delegaciones.CrearDelegacion(delegacion);
                TempData["mensaje"] = "La delegación " + delegacion.Nombre + " ha sido creada";
                return RedirectToAction("ListaDelegaciones");
            }
            else
            {
                return View(delegacion);
            }
        }

        [HttpPost]
        public ActionResult Borrar(Delegaciones delegacion)
        {
            Delegaciones delegacionBorrar = delegaciones.BorrarDelegacion(delegacion);
            if (delegacionBorrar != null)
            {
                TempData["mensaje"] = "La delegación " + delegacionBorrar.Nombre + " ha sido borrada";

            }
            return RedirectToAction("ListaDelegaciones");
        }

    }
}