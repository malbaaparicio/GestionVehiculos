using GestionVehiculos.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVehiculos.Domain.Concrete
{
    public class GestionaClientes : IClientes
    {
        VehiculosEntities context = new VehiculosEntities();
        public IEnumerable<Clientes> GetClientes { get => context.Clientes; }

        public Clientes BorrarCliente(Clientes cliente)
        {
            Clientes dbCliente = context.Clientes.Where(z => z.Clienteid == cliente.Clienteid).FirstOrDefault();
            if(dbCliente != null)
            {
                context.Clientes.Remove(dbCliente);
                context.SaveChanges();
            }
            return dbCliente;
        }

        public void CrearCliente(Clientes cliente)
        {
            Clientes dbCliente = new Clientes();
            dbCliente.Nombre = cliente.Nombre.Trim();
            dbCliente.Apellidos = cliente.Apellidos.Trim();
            dbCliente.NIF = cliente.NIF.Trim();
            dbCliente.Telefono = cliente.Telefono.Trim();
            dbCliente.Dirección = cliente.Dirección.Trim();
            dbCliente.Localidad = cliente.Localidad.Trim();
            dbCliente.Email = cliente.Email.Trim();
            context.Clientes.Add(dbCliente);
            context.SaveChanges();

        }

        public void SaveCliente(Clientes cliente)
        {
            Clientes dbCliente = context.Clientes.Where(z => z.Clienteid == cliente.Clienteid).FirstOrDefault();
            dbCliente.Nombre = cliente.Nombre.Trim();
            dbCliente.Apellidos = cliente.Apellidos.Trim();
            dbCliente.NIF = cliente.NIF.Trim();
            dbCliente.Telefono = cliente.Telefono.Trim();
            dbCliente.Dirección = cliente.Dirección.Trim();
            dbCliente.Localidad = cliente.Localidad.Trim();
            dbCliente.Email = cliente.Email.Trim();            
            context.SaveChanges();
        }
    }
}
