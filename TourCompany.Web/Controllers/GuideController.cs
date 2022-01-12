#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Business.Abstract;

namespace TourCompany.Web.Controllers
{
    public class GuideController : Controller
    {
        private readonly TourCompanyDbContext _context;
        private readonly IGuideService _guideService;

        public GuideController(TourCompanyDbContext context, IGuideService guideService)
        {
            _context = context;
            _guideService = guideService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_guideService.GetAll());
        }
        

        //TO DO: detay getirirken bildiği yabancı diller çekilmelidir.
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
           
            Guide guide = _guideService.GetById(id.Value);

            return (guide != null) ? View(guide) : NotFound();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guide/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuideId,Name,Surname,Gender,PhoneNumber,IsActive")] Guide guide)
        {
            if (ModelState.IsValid)
            {
                var language = _context.Languages.Find(1);
                guide.Languages.Add(language);
                _context.Add(guide);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guide);
        }

        // GET: Guide/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guide = await _context.Guides.FindAsync(id);
            if (guide == null)
            {
                return NotFound();
            }
            return View(guide);
        }

        // POST: Guide/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GuideId,Name,Surname,Gender,PhoneNumber,IsActive")] Guide guide)
        {
            if (id != guide.GuideId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guide);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuideExists(guide.GuideId))
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
            return View(guide);
        }

        // GET: Guide/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guide = await _context.Guides
                .FirstOrDefaultAsync(m => m.GuideId == id);
            if (guide == null)
            {
                return NotFound();
            }

            return View(guide);
        }

        // POST: Guide/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guide = await _context.Guides.FindAsync(id);
            _context.Guides.Remove(guide);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuideExists(int id)
        {
            return _context.Guides.Any(e => e.GuideId == id);
        }
    }
}
