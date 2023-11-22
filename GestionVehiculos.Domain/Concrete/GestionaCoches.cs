using GestionVehiculos.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVehiculos.Domain.Concrete {
    public class GestionaCoches : ICoches {
        VehiculosEntities context = new VehiculosEntities();

        public IEnumerable<Coches> GetCoches { get => context.Coches; }

        public Coches BorrarCoche(Coches coche) {
            Coches dbCoche = context.Coches.Where(z => z.Cocheid == coche.Cocheid).FirstOrDefault();
            if(dbCoche != null) {
                context.Coches.Remove(dbCoche);
                context.SaveChanges();
            }
            return dbCoche;
           
        }

        public void CrearCoche(Coches coche) {
            Coches dbCoche = new Coches();
            dbCoche.Marca = coche.Marca.Trim();
            dbCoche.Modelo = coche.Modelo.Trim();
            dbCoche.Matricula = coche.Matricula.Trim();
            context.Coches.Add(dbCoche);
            context.SaveChanges();
        }

        public void SaveCoche(Coches coche) {
            Coches dbCoche = context.Coches.Where(z => z.Cocheid == coche.Cocheid).FirstOrDefault();
            dbCoche.Marca = coche.Marca.Trim();
            dbCoche.Modelo = coche.Modelo.Trim();
            dbCoche.Matricula = coche.Matricula.Trim();
            context.SaveChanges();
        }
    }
}
