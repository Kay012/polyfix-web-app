using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mvc.RoleAuthorization.Data;
using Poly.Models;
using PolyFix.Models;

namespace Mvc.RoleAuthorization.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;
  

        private readonly UserManager<PolyFixAppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ProjectController(ApplicationDbContext context, UserManager<PolyFixAppUser> userManager,
                RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Project
        public async Task<IActionResult> Index()
        {
            var id = _userManager.GetUserId(User);

            //find assigned ids
            var Userproj = await _context.UserProjects.Where(s => s.UserId == id).ToListAsync();

            
            //create projetct list
            List<Project> Projects = new List<Project>() ;


            //find projects for assigned ids and add to projects list
            foreach (var proj in Userproj)
            {
                Projects.Add(await _context.Projects.Where(j => j.ProjectId == proj.ProjectId).FirstOrDefaultAsync());
            }

            //find user created projects
            var CreatePro = await _context.Projects.Where(y => y.UserCreated == Guid.Parse(id)).ToListAsync();

            //add user created projects with their assigned projects
            var result = Projects.Union(CreatePro).OrderBy(x => x.Name).ToList();



            return View(result);
        }


        public async Task<IActionResult> TskIndex(int? id)

        {

            List<Tsk> EMPT = new List<Tsk>();

            ViewData["MyOverDueTsks"] = EMPT;
            ViewData["MyCompTsk"] = EMPT;
            ViewData["MyTsks"] = EMPT;
            var CurDate = DateTime.Now;
            ViewData["DateNow"] = DateTime.Now;


            var Uid = _userManager.GetUserId(User);

            List<Tsk> FnTasks = new List<Tsk>();


            //get ALL tasks
            var ALLTsk = await _context.Tsks.Where(t=> t.ProjectId == id).ToListAsync();



            //get ALL current users tasks from ids
            var UserTsk = await _context.UserTasks.Where(s => s.UserId == Uid).ToListAsync();

            foreach (var Usr in UserTsk)
            {
                FnTasks.Add(ALLTsk.Where(k => k?.TskId == Usr.TskId).FirstOrDefault());
            }

            if (FnTasks.Count > 0)
            {

                //find user created projects
                //var CreateTsk = await _context.Tsks.Where(y => y.UserCreated == Guid.Parse(Uid)).ToListAsync();
                var CreateTsk = ALLTsk.Where(j => j.UserCreated == Guid.Parse(Uid)).ToList();

                //joining them to current projects without creating duplicates
                if(CreateTsk.Count > 0)
                {
                    var TMP = FnTasks.Union(CreateTsk).OrderBy(x => x.Name).ToList();
                    FnTasks = TMP;
                }
                


                //get current user  overdue tasks
                List<Tsk> MyOverDueTsk = new List<Tsk>();
                CurDate = DateTime.Now;
                List<Tsk> Overs = new List<Tsk>();
                Overs.AddRange(FnTasks.Where(k => k?.DateDue < CurDate).Where(l => l?.isComplete == false));

                if(Overs.Count > 0)
                {
                    MyOverDueTsk.AddRange(FnTasks.Where(k => k?.DateDue < CurDate).Where(l => l.isComplete == false));
                }

               



                //get current users complete tasks
                List<Tsk> MyCompTsk = new List<Tsk>();

                List<Tsk> Comp = new List<Tsk>();
                Comp.AddRange(FnTasks.Where(l => l?.isComplete == true));
                if (Comp.Count > 0)
                {
                    MyCompTsk.AddRange(FnTasks.Where(l => l?.isComplete == true));
                }



                //get users in progress tasks by removing the complete and overdue tasks from all the users tasks
                var Templist = FnTasks.Except(MyOverDueTsk).ToList();
                var MyCurTasks = Templist.Except(MyCompTsk).ToList();


                ViewData["MyOverDueTsks"] = MyOverDueTsk;
                ViewData["MyCompTsk"] = MyCompTsk;
                ViewData["MyTsks"] = MyCurTasks;

            }

            


            //repeateing the same process but for ALL projects not only user assigned

            //overdue
            List<Tsk> ALLOverDueTsk = new List<Tsk>();
            ALLOverDueTsk.AddRange(ALLTsk.Where(k => k?.DateDue < CurDate).Where(l => l.isComplete == false));


            //get current ALL complete tasks
            List<Tsk> ALLCompTsk = new List<Tsk>();
            ALLCompTsk.AddRange(ALLTsk.Where(l => l?.isComplete == true));



            //get ALL in progress tasks
            var ALLTemplist = ALLTsk.Except(ALLOverDueTsk).ToList();
            var ALLCurTasks = ALLTemplist.Except(ALLCompTsk).ToList();

            
            ViewData["ALLOverDueTsks"] = ALLOverDueTsk;
            ViewData["ALLCompTsk"] = ALLCompTsk;
            ViewData["ALLTsks"] = ALLCurTasks;


            // get projects name and id to display on top
            var Pro = await _context.Projects.Where(s => s.ProjectId == id).FirstOrDefaultAsync();
            ViewData["ProjectName"] = Pro.Name;
            ViewData["ProjectId"] = id;
            
            return View(ALLTsk);
        }
        // GET: Project/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Project/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,Name,Description,Location, ProjectImage")] Project project)
        {
            if (ModelState.IsValid)
            {
                
                

                var Uid = _userManager.GetUserId(User);

                var CurUser = await _context.Users.Where(k => k.Id == Uid).FirstOrDefaultAsync();

                string FromUserName = CurUser.FirstName + " " + CurUser.LastName + "(" + CurUser.UserName + ")";

                project.UserCreatedName = FromUserName;

                project.UserCreated = Guid.Parse(Uid);

                project.isArchived = false;

                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Project/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Project/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,Name,Description,Location, ProjectImage")] Project project)
        {
            if (id != project.ProjectId)
            {
                return NotFound();
            }

            


            if (ModelState.IsValid)
            {
                var Curproject = await _context.Projects.FindAsync(id);

                Curproject.Name = project.Name;
                Curproject.Description = project.Description;
                Curproject.Location = project.Location;

                try
                {
                    _context.Update(Curproject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(Curproject.ProjectId))
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

        // GET: Project/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ProjectId == id);
        }



        // GET: Tsk/Details/5
        public async Task<IActionResult> TskDetails(int? id)
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


        [HttpPost, ActionName("TskDetails")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TskDetails(int id, int idPr, IFormCollection formFields)
        {

            string comm = formFields["Comment"];
            //var tsk =  _context.Tsks.Where(s => s.TskId == id).Where(t => t.ProjectId == idPr).FirstOrDefault();

            var tsk = await _context.Tsks.FindAsync(id);
       

            //var tsk = await _context.Tsks
            //    .Include(t => t.ProjectId)
            //    .FirstOrDefaultAsync(m => m.TskId == id);

            tsk.isComplete = true;
            tsk.Comment = comm;


            //tsk.Comment = Com;

            _context.Update(tsk);
            
            await _context.SaveChangesAsync();


            return RedirectToAction("TskIndex", new { id = tsk.ProjectId });
        }



        public async Task<IActionResult> TskComp(int? id)
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
        public async Task<IActionResult> TskCreate(int? id)
        {

            var Pro = _context.Projects.Where(s => s.ProjectId == id);
            ViewData["ProjectId"] = new SelectList(Pro, "ProjectId", "Name");

            var ProId = await _context.Projects.Where(s => s.ProjectId == id).FirstOrDefaultAsync();
            ViewData["ProId"] = id;
            return View();
        }

        // POST: Tsk/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TskCreate([Bind("TskId,Name,Description,DateDue,Form1,Form2,Form3,ProjectId")] Tsk tsk)
        {

            tsk.isComplete = false;

            var Uid = _userManager.GetUserId(User);

 

            var CurUser = await _context.Users.Where(k => k.Id == Uid).FirstOrDefaultAsync();

            string FromUserName = CurUser.FirstName + " " + CurUser.LastName + "(" + CurUser.UserName + ")";

            tsk.UserCreatedName = FromUserName;

            tsk.UserCreated = Guid.Parse(Uid);

            if (ModelState.IsValid)
            {


                _context.Add(tsk);
                await _context.SaveChangesAsync();
                return RedirectToAction("TskIndex", new { id = tsk.ProjectId });
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name", tsk.ProjectId);
            return View(tsk);
        }

        // GET: Tsk/Edit/5
        public async Task<IActionResult> TskEdit(int? id)
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
        public async Task<IActionResult> TskEdit(int id, [Bind("TskId,Name,Description,DateDue,Form1,Form2,Form3,ProjectId,isComplete")] Tsk tsk)
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
                return RedirectToAction("TskIndex", new {id = tsk.ProjectId });
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name", tsk.ProjectId);
            return View(tsk);
        }

        // GET: Tsk/Delete/5
        public async Task<IActionResult> TskDelete(int? id)
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
        [HttpPost, ActionName("TskDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var tsk = await _context.Tsks.FindAsync(id);
            _context.Tsks.Remove(tsk);
            await _context.SaveChangesAsync();
            return RedirectToAction("TskIndex", new { id = tsk.ProjectId });
        }

        private bool TskExists(int id)
        {
            return _context.Tsks.Any(e => e.TskId == id);
        }


        public async Task<IActionResult> ToSurvey()
        {
            return Redirect("Pages/SurveyResult");
        }

        //[HttpPost]
        //public async Task<IActionResult> TskComplete(int? id, int idPr)
        //{

        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    //var tsk = _context.Tsks.Where(s => s.TskId == id).Where(t => t.ProjectId == idPr).FirstOrDefault();

        //    var tsk = await _context.Tsks
        //        .Include(t => t.ProjectId == idPr)
        //        .FirstOrDefaultAsync(m => m.TskId == id);

        //    tsk.isComplete = true;

        //    _context.Update(tsk);

        //    return RedirectToAction("TskIndex", new { id = tsk.ProjectId });
        //}


    }
}
