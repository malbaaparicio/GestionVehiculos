using GestionVehiculos.Domain;
using GestionVehiculos.Domain.Abstract;
using GestionVehiculos.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionVehiculos.WebUI.Controllers
{
    public class CochesController : Controller {

        public ICoches coches;
        public int pageSize = 8;

        public CochesController(ICoches coches)
        {
            this.coches = coches;
        }
        // GET: GetCoches
        public ViewResult ListaCoches(string filtro, string valor, int page = 1)
        {
            ListaCochesPaginado listaCochesPaginado = null;
            if(filtro == null || string.IsNullOrEmpty(valor))
            {
                listaCochesPaginado = new ListaCochesPaginado()
                {
                    coches = coches.GetCoches.                    
                    OrderBy(z => z.Cocheid).
                    Skip((page - 1) * pageSize).
                    Take(pageSize),

                    pagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = coches.GetCoches.Count() 
                    },
                    filtro = filtro,
                    terminoBusqueda = valor

                };
            }
            else if(filtro == "Marca")
            {
                listaCochesPaginado = new ListaCochesPaginado()
                {
                    coches = coches.GetCoches.
                    Where(p => p.Marca.ToLower() == valor.ToLower()).
                    OrderBy(z => z.Cocheid).
                    Skip((page - 1) * pageSize).
                    Take(pageSize),

                    pagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = valor == null ?
                    coches.GetCoches.Count() :
                    coches.GetCoches.Where(z => z.Marca.ToLower() == valor.ToLower()).Count()
                    },
                    filtro = filtro,
                    terminoBusqueda = valor

                };
            }
            else if (filtro == "Modelo")
            {
                listaCochesPaginado = new ListaCochesPaginado()
                {
                    coches = coches.GetCoches.
                    Where(p => p.Modelo.ToLower() == valor.ToLower()).
                    OrderBy(z => z.Cocheid).
                    Skip((page - 1) * pageSize).
                    Take(pageSize),

                    pagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = valor == null ?
                    coches.GetCoches.Count() :
                    coches.GetCoches.Where(z => z.Modelo.ToLower() == valor.ToLower()).Count()
                    },
                    filtro = filtro,
                    terminoBusqueda = valor

                };
            }
            else if (filtro == "Matrícula")
            {
                listaCochesPaginado = new ListaCochesPaginado()
                {
                    coches = coches.GetCoches.
                    Where(p => p.Matricula.ToLower() == valor.ToLower()).
                    OrderBy(z => z.Cocheid).
                    Skip((page - 1) * pageSize).
                    Take(pageSize),

                    pagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = valor == null ?
                    coches.GetCoches.Count() :
                    coches.GetCoches.Where(z => z.Matricula.ToLower() == valor.ToLower()).Count()
                    },
                    filtro = filtro,
                    terminoBusqueda = valor

                };
            }


            return View(listaCochesPaginado);
        }              

        public ViewResult Edit(int cocheId) {
            Coches coche = coches.GetCoches.Where(z => z.Cocheid == cocheId).FirstOrDefault();
            return View(coche);
        }

        public ViewResult Ver(int cocheId) {
            Coches coche = coches.GetCoches.Where(z => z.Cocheid == cocheId).FirstOrDefault();
            return View(coche);
        }

        [HttpPost]
        public ActionResult Edit (Coches coche) {
            if(ModelState.IsValid) {
                coches.SaveCoche(coche);
                TempData["mensaje"] = "El coche con matrícula " + coche.Matricula + " ha sido actualizado";
                return RedirectToAction("ListaCoches");
            }
            else {
                return View(coche);
            }
        }

        public ViewResult Create() {
            return View(new Coches());
        }

        [HttpPost]
        public ActionResult Create (Coches coche) {
            if(ModelState.IsValid) {
                coches.CrearCoche(coche);
                TempData["mensaje"] = "El coche con matrícula " + coche.Matricula + " ha sido creado";
                return RedirectToAction("ListaCoches");
            }
            else {
                return View(coche);
            }
        }

        [HttpPost]
        public ActionResult Borrar (Coches coche) {
            Coches cocheBorrar = coches.BorrarCoche(coche);
            if(cocheBorrar != null) {
                TempData["mensaje"] = "El coche con matrícula " + cocheBorrar.Matricula + " ha sido borrado";
                
            }
            return RedirectToAction("ListaCoches");
        }
    }
}