using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hw_25._10._24.Data;
using hw_25._10._24.Models;

namespace hw_25._10._24.Controllers
{
    public class WorkersController : Controller
    {
        private readonly hw_25_10_24Context _context;
        private readonly IFileService _fileService;

        public WorkersController(hw_25_10_24Context context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        // GET: Workers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Worker.ToListAsync());
        }

        // GET: Workers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = await _context.Worker
                .FirstOrDefaultAsync(m => m.Id == id);
            if (worker == null)
            {
                return NotFound();
            }

            return View(worker);
        }

        // GET: Workers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Workers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Worker worker, IFormFile file)
        {
            // (ModelState.ErrorCount == 1 && file is null) checks if only file field failed Validation
            if (ModelState.IsValid || (ModelState.ErrorCount == 1 && file is null))
            {
                // Saving file only in case it was sent
                if (file is not null)
                    worker.PicturePath = await _fileService.SaveFile(file);

                _context.Add(worker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(worker);
        }

        // GET: Workers/EditPicture/5
        public async Task<IActionResult> EditPicture(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = await _context.Worker.FindAsync(id);
            if (worker == null)
            {
                return NotFound();
            }
            return View(worker);
        }

        [HttpPost]
        public async Task<IActionResult> EditPicture(int id, IFormFile file)
        {
            var worker = await _context.Worker.FindAsync(id);

            if (worker is null)
            {
                return NotFound();
            }

            try
            {
                // Deleting old picture
                if (worker.PicturePath is not null)
                {
                    await _fileService.DeleteFile(worker.PicturePath);
                }

                // If there is a new file
                if (ModelState.IsValid)
                {
                    worker.PicturePath = await _fileService.SaveFile(file);
                }
                else
                {
                    worker.PicturePath = null;
                }

                _context.Update(worker);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkerExists(worker.Id))
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

        // GET: Workers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = await _context.Worker.FindAsync(id);
            if (worker == null)
            {
                return NotFound();
            }
            return View(worker);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Worker worker)
        {
            if (id != worker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(worker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkerExists(worker.Id))
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
            return View(worker);
        }

        // GET: Workers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = await _context.Worker
                .FirstOrDefaultAsync(m => m.Id == id);
            if (worker == null)
            {
                return NotFound();
            }

            return View(worker);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var worker = await _context.Worker.FindAsync(id);
            if (worker != null)
            {
                // Deleting file in case worker had one
                if (worker.PicturePath is not null)
                {
                    await _fileService.DeleteFile(worker.PicturePath);
                }

                _context.Worker.Remove(worker);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkerExists(int id)
        {
            return _context.Worker.Any(e => e.Id == id);
        }
    }
}
