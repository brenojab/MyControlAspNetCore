using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyControlAspNetCore.Models;

namespace MyControlAspNetCore.Controllers
{
  public class RegistroesController : Controller
  {
    private readonly MyControlAspNetCoreContext _context;

    public RegistroesController(MyControlAspNetCoreContext context)
    {
      _context = context;
    }

    // GET: Registroes
    public async Task<IActionResult> Index()
    {
      return View(await _context.Registro.ToListAsync());
    }

    // GET: Registroes/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var registro = await _context.Registro
          .SingleOrDefaultAsync(m => m.Guid == id);
      if (registro == null)
      {
        return NotFound();
      }

      return View(registro);
    }

    // GET: Registroes/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Registroes/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Valor,Descricao,Debito,Guid,DataCriacao,UsuarioCriador,DataAlteracao,UsuarioAlterador")] Registro registro)
    {
      if (ModelState.IsValid)
      {
        registro.Guid = Guid.NewGuid();
        _context.Add(registro);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(registro);
    }

    // GET: Registroes/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var registro = await _context.Registro.SingleOrDefaultAsync(m => m.Guid == id);
      if (registro == null)
      {
        return NotFound();
      }
      return View(registro);
    }

    // POST: Registroes/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("Valor,Descricao,Debito,Guid,DataCriacao,UsuarioCriador,DataAlteracao,UsuarioAlterador")] Registro registro)
    {
      if (id != registro.Guid)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(registro);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!RegistroExists(registro.Guid))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }
      return View(registro);
    }

    // GET: Registroes/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var registro = await _context.Registro
          .SingleOrDefaultAsync(m => m.Guid == id);
      if (registro == null)
      {
        return NotFound();
      }

      return View(registro);
    }

    // POST: Registroes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
      var registro = await _context.Registro.SingleOrDefaultAsync(m => m.Guid == id);
      _context.Registro.Remove(registro);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool RegistroExists(Guid id)
    {
      return _context.Registro.Any(e => e.Guid == id);
    }
  }
}
