using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVehiculos.Domain.Abstract
{
    public interface IClientes
    {
        IEnumerable<Clientes> GetClientes { get; }
        void SaveCliente(Clientes cliente);
        void CrearCliente(Clientes cliente);
        Clientes BorrarCliente(Clientes cliente);
    }
}
