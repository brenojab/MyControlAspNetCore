using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyControlAspNetCore.Models
{
  public class BaseClass
  {
    [Key]
    public Guid Guid { get; set; }
    public DateTime DataCriacao { get; set; }
    public string UsuarioCriador { get; set; }
    public DateTime DataAlteracao { get; set; }
    public string UsuarioAlterador { get; set; }
  }
}
