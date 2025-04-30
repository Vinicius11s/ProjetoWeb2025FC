using Projeto2025.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    public interface ILoginModels
    {
        LoginDTO validarLogin(string email, string password);
    }
}
