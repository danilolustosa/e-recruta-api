﻿using erecruta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erecruta.Interface
{
    public interface INivelRepository
    {
        List<Nivel> ListarByOportunidade(int OportunidadeId);
    }
}
