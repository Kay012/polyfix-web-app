using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Mvc.RoleAuthorization.Data;
using Poly.Models;


namespace Poly.Controllers
{
    public class TskController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TskController(ApplicationDbContext context)
        {
            _context = context;
        }




        


        // GET: Tsk
        public async Task<IActionResult> Index(int?id)
        {

            

            var projectContext = _context.Tsks;
            //ViewData["Package"] = projectContext;
            ViewData["Package"] = new SelectList(_context.Tsks, projectContext);
            return View(await projectContext.ToListAsync());

            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var tsk = await _context.Tsks
            //    .ToListAsync();

            //if (tsk == null)
            //{

            //    return NotFound();
            //}



            //return View(tsk);

            //Project projectRef = new Project();
            //var projectContext = _context.Tsks.ToListAsync();
            //if (await projectContext != null)
            //{
            //    //ViewData["Qtd_Items"] = items.Count;
            //    ViewData["Package"] = projectContext;

            //}
            //return View(await projectContext);
            //var projectContext = _context.Tsks.FirstOrDefaultAsync(t => t.ProjectId == id);
            //return View(projectContext);
        }

        // GET: Tsk/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tsk = await _context.Tsks
                .Include(t => t.ProjectRef)
                .FirstOrDefaultAsync(m => m.TskId == id);
            if (tsk == null)
            {
                return NotFound();
            }

            return View(tsk);
        }

        // GET: Tsk/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name");
            return View();
        }

        // POST: Tsk/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TskId,Name,Description,DateDue,ProjectId")] Tsk tsk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tsk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name", tsk.ProjectId);
            return View(tsk);
        }

        // GET: Tsk/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tsk = await _context.Tsks.FindAsync(id);
            if (tsk == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name", tsk.ProjectId);
            return View(tsk);
        }

        // POST: Tsk/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TskId,Name,Description,DateDue,ProjectId")] Tsk tsk)
        {
            if (id != tsk.TskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tsk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TskExists(tsk.TskId))
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
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name", tsk.ProjectId);
            return View(tsk);
        }

        // GET: Tsk/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tsk = await _context.Tsks
                .Include(t => t.ProjectRef)
                .FirstOrDefaultAsync(m => m.TskId == id);
            if (tsk == null)
            {
                return NotFound();
            }

            return View(tsk);
        }

        // POST: Tsk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tsk = await _context.Tsks.FindAsync(id);
            _context.Tsks.Remove(tsk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TskExists(int id)
        {
            return _context.Tsks.Any(e => e.TskId == id);
        }
    }
}
