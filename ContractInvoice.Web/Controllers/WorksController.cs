using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContractInvoice.Data.Contexts;
using ContractInvoice.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Nest;
using NPOI.SS.Formula.Functions;
using Microsoft.CodeAnalysis;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ContractInvoice.Web.Controllers
{

    
    [Authorize]
    public class WorksController : Controller
    {
        public static string UserName { get; }

        private readonly ContractInvoiceDbContext context;

        public WorksController(ContractInvoiceDbContext context)
        {
            this.context = context;
        }

        // GET USER IDENTITY
        

        // GET: Works
        public async Task<IActionResult> Index()
        {
            return View(await this.context.Work.ToListAsync());
        }

        // GET: Works/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await this.context.Work
                .FirstOrDefaultAsync(m => m.Id == id);
            if (work == null)
            {
                return NotFound();
            }

            return View(work);
        }

        // GET: Works/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Works/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //Set IDENTITY_INSERT Work ON;
        //public async Task<IActionResult> Create([Bind("Id,ProjectId,CreatedDate,CreatedById,ModifiedDate,ModifiedById,HoursWorked,DateWorked")] Work work)
        public async Task<IActionResult> Create([Bind("Column('Id',Long, primery_key=True, autoincrement=False),ProjectId,CreatedDate," +
                                                        "CreatedById,ModifiedDate,ModifiedById,HoursWorked,DateWorked")] Work work)
        {

            //ContractInvoiceUser contractInvoiceUser = new();

            if (ModelState.IsValid)
            {
                this.context.Add(work);

                // Count ProjectId   **********************************************************
                
                //Определяем конкретный номер проекта кот вводим
                long[] b = new long [] { 1, 2, 3, 4, 5, 6 };
                long numberProjectId = -1;
                long K = -1; 
                for (int i = 0; i < b.Length; i++)
                    {
                        if (work.ProjectId == b[i])
                            {
                                K = b[i];
                            }
                    }
                
                numberProjectId = this.context.Work.Count(s => s.ProjectId == K);
                if (numberProjectId == 0 )
                {
                    work.CreatedById = Environment.UserName;
                    work.ModifiedById = Environment.UserName;
                }
                else if (numberProjectId > 0)
                {
                    work.ModifiedById = Environment.UserName;
                           
                    var work1 = from t in this.context.Work
                        where t.ProjectId == K
                        select t.CreatedById;

                    foreach (string s in work1)
                    {
                        work.CreatedById = s;
                    }

                    var work2 = from t in this.context.Work
                        where t.ProjectId == K
                        select t.CreatedDate;

                    foreach (DateTime s in work2)
                    {
                        work.CreatedDate = s;
                    }

                }
                //********************************************************************************

                await this.context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(work);
        }

        // GET: Works/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await this.context.Work.FindAsync(id);
            if (work == null)
            {
                return NotFound();
            }
            return View(work);
        }

        // POST: Works/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ProjectId,CreatedDate,CreatedById,ModifiedDate,ModifiedById,HoursWorked,DateWorked")] Work work)
        {
            if (id != work.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.context.Update(work);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkExists(work.Id))
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
            return View(work);
        }

        // GET: Works/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await this.context.Work
                .FirstOrDefaultAsync(m => m.Id == id);
            if (work == null)
            {
                return NotFound();
            }

            return View(work);
        }

        // POST: Works/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var work = await this.context.Work.FindAsync(id);
            this.context.Work.Remove(work);
            await this.context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkExists(long id)
        {
            return this.context.Work.Any(e => e.Id == id);
        }
    }
}
