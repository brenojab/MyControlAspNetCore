using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyControlAspNetCore.Models
{
  public class Usuario : IdentityUser
  {
    public string Nome { get; set; }
    public string Senha { get; set; }
    public bool Admin { get; set; }
  }
}
