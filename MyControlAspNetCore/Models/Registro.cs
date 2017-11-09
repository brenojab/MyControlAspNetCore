using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyControlAspNetCore.Models
{
  public class Registro : BaseClass
  {
    public decimal Valor { get; set; }
    public string Descricao { get; set; }
    public bool Debito { get; set; }
    public string TipoRegistro { get; set; }
  }
}
