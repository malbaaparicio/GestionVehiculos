﻿using GestionVehiculos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionVehiculos.WebUI.Models
{
    public class ListaDelegacionesPaginado
    {
        public IEnumerable<Delegaciones> delegaciones { get; set; }
        public PagingInfo pagingInfo { get; set; }
        public string filtro { get; set; }
        public string terminoBusqueda { get; set; }
    }
}