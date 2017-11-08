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
  public class TipoRegistroesController : Controller
  {
    private readonly MyControlAspNetCoreContext _context;

    public TipoRegistroesController(MyControlAspNetCoreContext context)
    {
      _context = context;
    }

    // GET: TipoRegistroes
    public async Task<IActionResult> Index()
    {
      return View(await _context.TipoRegistro.ToListAsync());
    }

    // GET: TipoRegistroes/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var tipoRegistro = await _context.TipoRegistro
          .SingleOrDefaultAsync(m => m.Guid == id);
      if (tipoRegistro == null)
      {
        return NotFound();
      }

      return View(tipoRegistro);
    }

    // GET: TipoRegistroes/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: TipoRegistroes/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Descricao,Cor,Guid,DataCriacao,UsuarioCriador,DataAlteracao,UsuarioAlterador")] TipoRegistro tipoRegistro)
    {
      if (ModelState.IsValid)
      {
        tipoRegistro.Guid = Guid.NewGuid();
        _context.Add(tipoRegistro);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(tipoRegistro);
    }

    // GET: TipoRegistroes/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var tipoRegistro = await _context.TipoRegistro.SingleOrDefaultAsync(m => m.Guid == id);
      if (tipoRegistro == null)
      {
        return NotFound();
      }
      return View(tipoRegistro);
    }

    // POST: TipoRegistroes/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("Descricao,Cor,Guid,DataCriacao,UsuarioCriador,DataAlteracao,UsuarioAlterador")] TipoRegistro tipoRegistro)
    {
      if (id != tipoRegistro.Guid)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(tipoRegistro);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!TipoRegistroExists(tipoRegistro.Guid))
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
      return View(tipoRegistro);
    }

    // GET: TipoRegistroes/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var tipoRegistro = await _context.TipoRegistro
          .SingleOrDefaultAsync(m => m.Guid == id);
      if (tipoRegistro == null)
      {
        return NotFound();
      }

      return View(tipoRegistro);
    }

    // POST: TipoRegistroes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
      var tipoRegistro = await _context.TipoRegistro.SingleOrDefaultAsync(m => m.Guid == id);
      _context.TipoRegistro.Remove(tipoRegistro);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool TipoRegistroExists(Guid id)
    {
      return _context.TipoRegistro.Any(e => e.Guid == id);
    }
  }
}
