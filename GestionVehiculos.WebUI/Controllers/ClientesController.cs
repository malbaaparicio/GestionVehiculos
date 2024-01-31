using GestionVehiculos.Domain;
using GestionVehiculos.Domain.Abstract;
using GestionVehiculos.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace GestionVehiculos.WebUI.Controllers
{
    public class ClientesController : Controller
    {
        public IClientes clientes;
        public int pageSize = 8;
        public ClientesController(IClientes clientes)
        {
            this.clientes = clientes;
        }
        
        // GET: Clientes
        public ViewResult ListaClientes(string filtro, string valor, int page = 1)
        {
            ListaClientesPaginado listaClientesPaginado = null;
            if(filtro == null || string.IsNullOrEmpty(valor))
            {
                listaClientesPaginado = new ListaClientesPaginado()
                {
                    clientes = clientes.GetClientes.
                    OrderBy(z => z.Clienteid).
                    Skip((page - 1) * pageSize).
                    Take(pageSize),

                    pagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = clientes.GetClientes.Count()
                    },
                    filtro = filtro,
                    terminoBusqueda = valor

                };
            }
            else if(filtro == "Nombre"){
                listaClientesPaginado = new ListaClientesPaginado()
                {
                    clientes = clientes.GetClientes.
                    Where(p => p.Nombre.ToLower() == valor.ToLower()).
                    OrderBy(z => z.Clienteid).
                    Skip((page - 1) * pageSize).
                    Take(pageSize),

                    pagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = valor == null ?
                    clientes.GetClientes.Count() :
                    clientes.GetClientes.Where(z => z.Nombre.ToLower() == valor.ToLower()).Count()
                    },
                    filtro = filtro,
                    terminoBusqueda = valor

                };
            }
            else if(filtro == "Apellidos")
            {
                listaClientesPaginado = new ListaClientesPaginado()
                {
                    clientes = clientes.GetClientes.
                    Where(p => p.Apellidos.ToLower().Contains(valor.ToLower())).
                    OrderBy(z => z.Clienteid).
                    Skip((page - 1) * pageSize).
                    Take(pageSize),

                    pagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = valor == null ?
                    clientes.GetClientes.Count() :
                    clientes.GetClientes.Where(z => z.Apellidos.ToLower().Contains(valor.ToLower())).Count()
                    },
                    filtro = filtro,
                    terminoBusqueda = valor

                };
            }
            else if (filtro == "Nif")
            {
                listaClientesPaginado = new ListaClientesPaginado()
                {
                    clientes = clientes.GetClientes.
                    Where(p => p.NIF.ToLower() == valor.ToLower()).
                    OrderBy(z => z.Clienteid).
                    Skip((page - 1) * pageSize).
                    Take(pageSize),

                    pagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = valor == null ?
                    clientes.GetClientes.Count() :
                    clientes.GetClientes.Where(z => z.NIF.ToLower() == valor.ToLower()).Count()
                    },
                    filtro = filtro,
                    terminoBusqueda = valor

                };
            }
            else if (filtro == "Telefono")
            {
                listaClientesPaginado = new ListaClientesPaginado()
                {
                    clientes = clientes.GetClientes.
                    Where(p => p.Telefono.ToLower() == valor.ToLower()).
                    OrderBy(z => z.Clienteid).
                    Skip((page - 1) * pageSize).
                    Take(pageSize),

                    pagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = valor == null ?
                    clientes.GetClientes.Count() :
                    clientes.GetClientes.Where(z => z.Telefono.ToLower() == valor.ToLower()).Count()
                    },
                    filtro = filtro,
                    terminoBusqueda = valor

                };
            }
            else if (filtro == "Email")
            {
                listaClientesPaginado = new ListaClientesPaginado()
                {
                    clientes = clientes.GetClientes.
                    Where(p => p.Email.ToLower() == valor.ToLower()).
                    OrderBy(z => z.Clienteid).
                    Skip((page - 1) * pageSize).
                    Take(pageSize),

                    pagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = valor == null ?
                    clientes.GetClientes.Count() :
                    clientes.GetClientes.Where(z => z.Email.ToLower() == valor.ToLower()).Count()
                    },
                    filtro = filtro,
                    terminoBusqueda = valor

                };
            }


            return View(listaClientesPaginado);
        }

        public ViewResult Ver(int clienteId)
        {
            Clientes cliente = clientes.GetClientes.Where(z => z.Clienteid == clienteId).FirstOrDefault();
            return View(cliente);
        }

        public ViewResult Edit(int clienteId)
        {
            Clientes cliente = clientes.GetClientes.Where(z => z.Clienteid == clienteId).FirstOrDefault();
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Edit(Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                clientes.SaveCliente(cliente);
                TempData["mensaje"] = "El cliente ha sido actualizado";
                return RedirectToAction("ListaClientes");
            }
            else
            {
                return View(cliente);
            }
        }

        public ViewResult Create()
        {
            return View(new Clientes());
        }

        [HttpPost]
        public ActionResult Create(Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                clientes.CrearCliente(cliente);
                TempData["mensaje"] = "El cliente " + cliente.Nombre + " " + cliente.Apellidos + " ha sido creado";
                return RedirectToAction("ListaClientes");
            }
            else
            {
                return View(cliente);
            }
        }

        [HttpPost]
        public ActionResult Borrar(Clientes cliente)
        {
            Clientes clienteBorrar = clientes.BorrarCliente(cliente);
            if (clienteBorrar != null)
            {
                TempData["mensaje"] = "El cliente " + clienteBorrar.Nombre + " " + clienteBorrar.Apellidos + " ha sido borrado";

            }
            return RedirectToAction("ListaClientes");
        }
    }
}