using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVehiculos.Domain.Abstract
{
    public interface IDelegaciones
    {
        IEnumerable<Delegaciones> GetDelegaciones { get; }
        void SaveDelegacion(Delegaciones delegacion);
        void CrearDelegacion(Delegaciones delegacion);
        Delegaciones BorrarDelegacion(Delegaciones delegacion);
    }
}
