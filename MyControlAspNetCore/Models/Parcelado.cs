using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyControlAspNetCore.Models
{
  public class Parcelado : BaseClass
  {
    public List<string> ListaRegistros { get; set; }

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
  } 
}
