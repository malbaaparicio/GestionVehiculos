using GestionVehiculos.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVehiculos.Domain.Concrete
{
    public class GestionaReservas : IReservas
    {
        VehiculosEntities context = new VehiculosEntities();
        public IEnumerable<Reservas> GetReservas {get => context.Reservas;}

        public Reservas BorrarReserva(Reservas reserva)
        {
            Reservas dbReserva = context.Reservas.Where(z=>z.Reservarid == reserva.Reservarid).FirstOrDefault(); 
            if(dbReserva != null)
            {
                context.Reservas.Remove(dbReserva);
                context.SaveChanges();
            }
            return dbReserva;
        }

        public void CrearReserva(Reservas reserva)
        {
            Reservas dbReserva = new Reservas();
            dbReserva.FechaReserva = reserva.FechaReserva;
            dbReserva.Clienteid = reserva.Clienteid;
            dbReserva.CentroRecogidaid = reserva.CentroRecogidaid;
            dbReserva.FechaDevolucion = reserva.FechaDevolucion;
            dbReserva.CentroDevolucionid = reserva.CentroDevolucionid;
            dbReserva.Vehiculoid = reserva.Vehiculoid;
            dbReserva.Observaciones = reserva.Observaciones;
            dbReserva.DepositoLleno = reserva.DepositoLleno;
            context.Reservas.Add(dbReserva);
            context.SaveChanges();
        }

        public void SaveReserva(Reservas reserva)
        {
            Reservas dbReserva = context.Reservas.Where(z => z.Reservarid == reserva.Reservarid).FirstOrDefault();
            dbReserva.FechaReserva = reserva.FechaReserva;
            dbReserva.Clienteid = reserva.Clienteid;
            dbReserva.CentroRecogidaid = reserva.CentroRecogidaid;
            dbReserva.FechaDevolucion = reserva.FechaDevolucion;
            dbReserva.CentroDevolucionid = reserva.CentroDevolucionid;
            dbReserva.Vehiculoid = reserva.Vehiculoid;
            dbReserva.Observaciones = reserva.Observaciones;
            dbReserva.DepositoLleno = reserva.DepositoLleno;
            context.SaveChanges();
        }
    }
}
