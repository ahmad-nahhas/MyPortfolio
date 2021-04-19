using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Shared.Entities;
using MyPortfolio.Shared.UnitOfWorks.Interfaces;
using MyPortfolio.Web.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.Web.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IUnitOfWork<Project> _uow;
        private readonly IWebHostEnvironment _hosting;

        public ProjectsController(IUnitOfWork<Project> uow, IWebHostEnvironment hosting)
        {
            _uow = uow;
            _hosting = hosting;
        }

        // GET: Projects
        public async Task<IActionResult> Index() => View(await _uow.Repository.Get());

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            try
            {
                if (id == null) return NotFound();

                var project = await _uow.Repository.Get(id);

                if (project == null) return NotFound();

                return View(project);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: Projects/Create
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                string imagePath = await SaveImage(model);
                await _uow.Repository.Add(new Project { Id = Guid.NewGuid(), Name = model.Name, Description = model.Description, ImagePath = string.IsNullOrWhiteSpace(imagePath) ? string.Empty : imagePath, Link = model.Link });
                await _uow.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            try
            {
                if (id == null) return NotFound();

                var project = await _uow.Repository.Get(id);

                if (project == null) return NotFound();

                return View(new ProjectViewModel { Id = project.Id, Name = project.Name, Description = project.Description, ImagePath = project.ImagePath, Link = project.Link });
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProjectViewModel model)
        {
            try
            {
                if (id != model.Id) return NotFound();

                if (!ModelState.IsValid) return View(model);

                string imagePath = await SaveImage(model);
                await _uow.Repository.Update(new Project { Id = id, Name = model.Name, Description = model.Description, ImagePath = string.IsNullOrWhiteSpace(imagePath) ? string.IsNullOrWhiteSpace(model.ImagePath) ? string.Empty : model.ImagePath : imagePath, Link = model.Link });
                await _uow.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                if (!await ProjectExists(model.Id)) return NotFound();

                return View();
            }
        }

        private async Task<string> SaveImage(ProjectViewModel model)
        {
            try
            {
                if (model.Image == null) return null;

                string imagePath = model.Image.FileName;
                string path = Path.Combine(_hosting.WebRootPath, "assets", "img", "portfolio", imagePath);
                await model.Image.CopyToAsync(new FileStream(path, FileMode.Create));

                return imagePath;
            }
            catch
            {
                return null;
            }
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            try
            {
                if (id == null) return NotFound();

                var project = await _uow.Repository.Get(id);

                if (project == null) return NotFound();

                return View(project);
            }
            catch
            {
                return NotFound();
            }
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _uow.Repository.Delete(id);
                await _uow.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private async Task<bool> ProjectExists(Guid id)
        {
            try
            {
                return (await _uow.Repository.Get()).Any(e => e.Id == id);
            }
            catch
            {
                return false;
            }
        }
    }
}