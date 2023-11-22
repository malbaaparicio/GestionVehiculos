using GestionVehiculos.Domain;
using GestionVehiculos.Domain.Abstract;
using GestionVehiculos.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
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
            ListaClientesPaginado listaClientesPaginado = new ListaClientesPaginado()
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

            return View(listaClientesPaginado);
        }
    }
}