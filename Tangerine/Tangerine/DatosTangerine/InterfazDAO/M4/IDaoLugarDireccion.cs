﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine.Entidades.M4;

namespace DatosTangerine.InterfazDAO.M4
{
    public interface IDaoLugarDireccion // : IDao<Parametro, Resultado, Resultado>
    {
         List<LugarDireccionM4> ConsultCityPlaces();

    }
}
