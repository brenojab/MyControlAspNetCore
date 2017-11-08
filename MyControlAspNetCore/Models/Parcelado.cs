using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyControlAspNetCore.Models
{
  public class Parcelado : BaseClass
  {
    public List<Registro> ListaRegistros { get; set; }

    public int TotalParcelas
    {
      get
      {
        return ListaRegistros.Count();
      }
      set
      {
        TotalParcelas = value;
      }
    }

    public decimal ValorTotal
    {
      get
      {
        return ListaRegistros.Sum(r => r.Valor);
      }
    }
  }
}
