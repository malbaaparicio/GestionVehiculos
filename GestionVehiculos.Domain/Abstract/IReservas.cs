using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVehiculos.Domain.Abstract
{
    public interface IReservas
    {
        IEnumerable<Reservas> GetReservas { get; }
        void SaveReserva(Reservas reserva);
        void CrearReserva(Reservas reserva);
        Reservas BorrarReserva(Reservas reserva);
    }
}
