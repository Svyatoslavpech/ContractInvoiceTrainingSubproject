using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContractInvoice.Data.Contexts;
using ContractInvoice.Model.Entities;

namespace ContractInvoice.Web.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ContractInvoiceDbContext context;

        public ProjectsController(ContractInvoiceDbContext context)
        {
            this.context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            return View(await this.context.Project.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await this.context.Project
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Column('Id',Long, primery_key=True, autoincrement=False),Business,NameProject,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,HoursWorked,DateWorked")] Project project)
        {
            if (ModelState.IsValid)
            {
                if (project.Id <= 0)
                {
                    project.CreatedDate = DateTime.Now;
                    project.CreatedBy = User.Identity.Name;
                }

                project.ModifiedDate = DateTime.Now;
                project.ModifiedBy = User.Identity.Name;

                this.context.Add(project);

                await this.context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await this.context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Business,NameProject,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,HoursWorked,DateWorked")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.context.Update(project);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
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
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await this.context.Project
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var project = await this.context.Project.FindAsync(id);
            this.context.Project.Remove(project);
            await this.context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(long id)
        {
            return this.context.Project.Any(e => e.Id == id);
        }
    }
}
