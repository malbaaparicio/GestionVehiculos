using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVehiculos.Domain.Abstract {
    public interface ICoches {
        IEnumerable <Coches> GetCoches { get; }

        void SaveCoche(Coches coche);
        void CrearCoche(Coches coche);
        Coches BorrarCoche(Coches coche);
    }
}
