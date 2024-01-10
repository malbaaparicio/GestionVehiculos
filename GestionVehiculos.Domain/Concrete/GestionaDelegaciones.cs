using GestionVehiculos.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVehiculos.Domain.Concrete
{
    public class GestionaDelegaciones : IDelegaciones
    {
        VehiculosEntities context = new VehiculosEntities();
        public IEnumerable<Delegaciones> GetDelegaciones { get => context.Delegaciones; }

        public Delegaciones BorrarDelegacion(Delegaciones delegacion)
        {
            Delegaciones dbDelegacion = context.Delegaciones.Where(z => z.Delegacionid == delegacion.Delegacionid).FirstOrDefault();
            if(dbDelegacion != null)
            {
                context.Delegaciones.Remove(dbDelegacion);
                context.SaveChanges();
            }
            return dbDelegacion;
        }

        public void CrearDelegacion(Delegaciones delegacion)
        {
            Delegaciones dbDelegacion = new Delegaciones();
            dbDelegacion.Nombre = delegacion.Nombre.Trim();
            dbDelegacion.Direccion = delegacion.Direccion.Trim();
            dbDelegacion.Telefono = delegacion.Telefono.Trim();
            dbDelegacion.Localidad = delegacion.Localidad.Trim();
            dbDelegacion.Email = delegacion.Email.Trim();
            context.Delegaciones.Add(dbDelegacion);
            context.SaveChanges();

        }

        public void SaveDelegacion(Delegaciones delegacion)
        {
            Delegaciones dbDelegacion = context.Delegaciones.Where(z => z.Delegacionid == delegacion.Delegacionid).FirstOrDefault();
            dbDelegacion.Nombre = delegacion.Nombre.Trim();
            dbDelegacion.Direccion = delegacion.Direccion.Trim();
            dbDelegacion.Telefono = delegacion.Telefono.Trim();
            dbDelegacion.Localidad = delegacion.Localidad.Trim();
            dbDelegacion.Email = delegacion.Email.Trim();           
            context.SaveChanges();
        }
    }
}
