using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyControlAspNetCore.Interfaces
{
  public interface IDataServices<T>
  {
    void Update(T entidade);
  }
}
