﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Interfaces.Repository
{
    public interface IClienteRepository
    {
        Cliente addCliente(Cliente cliente);
    }
}
