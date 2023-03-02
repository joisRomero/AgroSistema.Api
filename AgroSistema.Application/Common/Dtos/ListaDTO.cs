﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Dtos
{
    public class ListaDTO<T>
    {
        public ListaDTO()
        {
            List = new List<T>();
        }
        public IEnumerable<T> List { get; set; }
    }
}
