using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mvc.RoleAuthorization.Data;
using Poly.Models;
using PolyFix.Models;

namespace PolyFix.Controllers
{
    public class UserProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<PolyFixAppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserProjectsController(ApplicationDbContext context, UserManager<PolyFixAppUser> userManager,
                RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: UserProjects
        public async Task<IActionResult> Index(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }



            var Projects = await _context.Projects
               .FirstOrDefaultAsync(m => m.ProjectId == id);

            ViewData["Projects"] = Projects;



            var applicationDbContext = _context.UserProjects.Include(u => u.Project).Include(u => u.User).Where(t => t.ProjectId == id);

            Console.Write(await applicationDbContext.ToListAsync());

            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> IndexTsk(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }



            var Tsks = await _context.Tsks
               .FirstOrDefaultAsync(m => m.TskId == id);

            ViewData["Tsks"] = Tsks;



            var applicationDbContext =  (_context.UserTasks.Include(u => u.Tsk).Include(u => u.User).Where(t => t.TskId == id));

            Console.Write(await applicationDbContext.ToListAsync());

            return View(await applicationDbContext.ToListAsync());
        }




        // GET: UserProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProject = await _context.UserProjects
                .Include(u => u.Project)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (userProject == null)
            {
                return NotFound();
            }

            return View(userProject);
        }

        // GET: UserProjects/Create
        public async Task<IActionResult> Create(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            //current project
            var Projects = await _context.Projects
               .FirstOrDefaultAsync(m => m.ProjectId == id);
            ViewData["Projects"] = Projects;



            //get all users
            //ViewData["UserId"] = _context.Users;

            //list of all users
            var AllUsers = await _context.Users.ToListAsync();

            //get user selected task IDs
            var SelectedIDs = await _context.UserProjects.Include(u => u.Project).Include(u => u.User).Where(t => t.ProjectId == id).ToListAsync();

           
            //new list
            List <Models.PolyFixAppUser> SelectedUsers = new List<Models.PolyFixAppUser>();


            foreach (var Usr in SelectedIDs)
            {
                SelectedUsers.Add(AllUsers.Where(k => k.Id == Usr.UserId).FirstOrDefault());
            }

            var NotAddedUsers = AllUsers.Except(SelectedUsers).ToList();



            ViewData["selectedUsers"] = SelectedUsers;
            ViewData["selectedUsersCOUNT"] = SelectedUsers.Count;


            ViewData["NotAddedUsers"] = NotAddedUsers;
            ViewData["NotAddedUsersCOUNT"] = NotAddedUsers.Count;

            //ViewData["UsersLength"] = _context.Users.Count();



            //var selecteds = await SelectedUs.ToListAsync();
            //ViewData["selectedUsers"] = selecteds;
            //System.Diagnostics.Debug.Write(await applicationDbContext.ToListAsync());

            //ViewData["SelectedCount"] = selecteds.Count();



            ////System.Diagnostics.Debug.WriteLine("AMen");

            return View();
        }

        public async Task<IActionResult> CreateTsk(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            //current project
            var Tsks = await _context.Tsks
               .FirstOrDefaultAsync(m => m.TskId == id);

            ViewData["Tsks"] = Tsks;



            //get all users
            //ViewData["UserId"] = _context.Users;

            //list of all users
            var AllUsers = await _context.Users.ToListAsync();

            //get user selected task IDs
            var SelectedIDs = await _context.UserTasks.Include(u => u.Tsk).Include(u => u.User).Where(t => t.TskId == id).ToListAsync();


            //new list
            List<Models.PolyFixAppUser> SelectedUsers = new List<Models.PolyFixAppUser>();


            foreach (var Usr in SelectedIDs)
            {
                SelectedUsers.Add(AllUsers.Where(k => k.Id == Usr.UserId).FirstOrDefault());
            }

            var NotAddedUsers = AllUsers.Except(SelectedUsers).ToList();



            ViewData["selectedUsers"] = SelectedUsers;
            ViewData["selectedUsersCOUNT"] = SelectedUsers.Count;


            ViewData["NotAddedUsers"] = NotAddedUsers;
            ViewData["NotAddedUsersCOUNT"] = NotAddedUsers.Count;

            return View();
        }

        // POST: UserProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]


        public async Task<IActionResult> Create(int ProjectID, string[] UserIds, string[] UserIDELS)
        {
            //get current user ID to get name of person adding
            var CurUid = _userManager.GetUserId(User);
            var CurUser = await _context.Users.Where(b => b.Id == CurUid).FirstOrDefaultAsync();

            //creating a string fo their name + username
            string FromUserName = CurUser.FirstName + " " + CurUser.LastName + "(" + CurUser.UserName + ")";


            //Getting current project to get the name
            var CurrentPro = await _context.Projects.Where(k => k.ProjectId == ProjectID).FirstOrDefaultAsync();
            
            //creating URL to link to project
            string ProURL = "/Project/TskIndex/" + ProjectID.ToString();




            


            //Getting ALL users for this projetc
            var ase = (_context.UserProjects.Include(u => u.Project).Include(u => u.User).Where(t => t.ProjectId == ProjectID));
            var ALLUserProj = await ase.ToListAsync();

            //Finding the userProjects from the IDs that must be deleted
            List<UserProject> userProjectDEL = new List<UserProject>();
            foreach (string uID in UserIDELS)
            {
                userProjectDEL.Add(ALLUserProj.Where(k => k.UserId == uID).FirstOrDefault());
            }

 
            //deleting present users           
            foreach (var item in userProjectDEL)
            {

                //Creating the notification for being DELETED

                Notification ProNotifDEL = new Notification();

                ProNotifDEL.DateCreated = DateTime.Now;

                ProNotifDEL.isRead = false;

                ProNotifDEL.NotiType = "Project-Del";

                ProNotifDEL.NotiHeader = "removed you from a project:";

                ProNotifDEL.NotiBody = CurrentPro.Name;

                ProNotifDEL.NotiMessage = CurrentPro.Description;

                //ProNotifAdd.Url = ProURL; You Cant access the url if you have been removed

                ProNotifDEL.FromUserId = CurUid;

                ProNotifDEL.FromUserName = FromUserName;


                //adding their ID to the notification (adding notification to the DB for each user)
                ProNotifDEL.ToUserId = item.UserId;
                _context.Add(ProNotifDEL);

                //deleting user
                _context.Remove(item);
                await _context.SaveChangesAsync();
            }


            //adding new users
            await _context.SaveChangesAsync();
            UserProject userProject = new UserProject();

            if (ModelState.IsValid)
            {
                if (UserIds == null)
                {
                    return NotFound();
                }

                foreach (string uID in UserIds)
                {

                    ////adding their ID to the notification (adding notification to the DB for each user)
                    
                    //_context.Add(ProNotifAdd);
                    ////_context.SaveChanges();



                    //Creating the notification for being ADDED

                    Notification ProNotifAdd = new Notification();

                    ProNotifAdd.DateCreated = DateTime.Now;

                    ProNotifAdd.isRead = false;

                    ProNotifAdd.NotiType = "Project-Add";   //differnt types of notifications so that the UI can be differnt for each

                    ProNotifAdd.NotiHeader = "added you to a project:";

                    ProNotifAdd.NotiBody = CurrentPro.Name;

                    ProNotifAdd.NotiMessage = CurrentPro.Description;

                    ProNotifAdd.Url = ProURL;

                    ProNotifAdd.FromUserId = CurUid;

                    ProNotifAdd.FromUserName = FromUserName;


                    ProNotifAdd.ToUserId = uID;

                    _context.Add(ProNotifAdd);



                    //adding user
                    UserProject NewUP = new UserProject();
                    NewUP.ProjectId = ProjectID;
                    NewUP.UserId = uID;
                    _context.Add(NewUP);
                    await _context.SaveChangesAsync();
                }



                //getting all users assigned and adding them

                var UsersAs = await _context.UserProjects.Include(u => u.Project).Include(u => u.User).Where(t => t.ProjectId == ProjectID).ToListAsync();

                String AsUsers = "";
                
                foreach(var Uss in UsersAs)
                {
                    var MyCurUss = await _context.Users.Where(k => k.Id == Uss.UserId).FirstOrDefaultAsync();

                    string MyCurUssName = MyCurUss.FirstName + " " + MyCurUss.LastName + " (" + MyCurUss.UserName + ")";

                    AsUsers = AsUsers + MyCurUssName + ",   ";
                }

                CurrentPro.UsersAssigned = AsUsers;

                _context.Update(CurrentPro);

                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "UserProjects", new { id = ProjectID }); ;
            }

  
            return NotFound();
        }

        public async Task<IActionResult> CreateTsks(int TskID, string[] UserIds, string[] UserIDELS)
        {

            //get current user ID to get name of person adding
            var CurUid = _userManager.GetUserId(User);
            var CurUser = await _context.Users.Where(b => b.Id == CurUid).FirstOrDefaultAsync();

            //creating a string fo their name + username
            string FromUserName = CurUser.FirstName + " " + CurUser.LastName + "(" + CurUser.UserName + ")";


            //Getting current task to get the name
            var CurrentPro = await _context.Tsks.Where(k => k.TskId == TskID).FirstOrDefaultAsync();

            //creating URL to link to project
            string ProURL = "Project/TskDetails/" + TskID.ToString();







            //Getting ALL users for this projetc
            var ase = (_context.UserTasks.Where(t => t.TskId == TskID));
            var ALLUserProj = await ase.ToListAsync();

            //Finding the userProjects from the IDs that must be deleted
            List<UserTask> userProjectDEL = new List<UserTask>();
            foreach (string uID in UserIDELS)
            {
                userProjectDEL.Add(ALLUserProj.Where(k => k.UserId == uID).FirstOrDefault());
            }


            //deleting present users           
            foreach (var item in userProjectDEL)
            {

                //Creating the notification for being DELETED

                Notification ProNotifDEL = new Notification();

                ProNotifDEL.DateCreated = DateTime.Now;

                ProNotifDEL.isRead = false;

                ProNotifDEL.NotiType = "Project-Del";

                ProNotifDEL.NotiHeader = "removed you from a Task:";

                ProNotifDEL.NotiBody = CurrentPro.Name;

                ProNotifDEL.NotiMessage = CurrentPro.Description;

                //ProNotifAdd.Url = ProURL; You Cant access the url if you have been removed

                ProNotifDEL.FromUserId = CurUid;

                ProNotifDEL.FromUserName = FromUserName;


                //adding their ID to the notification (adding notification to the DB for each user)
                ProNotifDEL.ToUserId = item.UserId;
                _context.Add(ProNotifDEL);

                //deleting user
                _context.Remove(item);
                await _context.SaveChangesAsync();
            }


            //adding new users
            await _context.SaveChangesAsync();
            UserProject userProject = new UserProject();

            if (ModelState.IsValid)
            {
                if (UserIds == null)
                {
                    return NotFound();
                }

                foreach (string uID in UserIds)
                {

                    ////adding their ID to the notification (adding notification to the DB for each user)

                    //_context.Add(ProNotifAdd);
                    ////_context.SaveChanges();



                    //Creating the notification for being ADDED

                    Notification ProNotifAdd = new Notification();

                    ProNotifAdd.DateCreated = DateTime.Now;

                    ProNotifAdd.isRead = false;

                    ProNotifAdd.NotiType = "Project-Add";   //differnt types of notifications so that the UI can be differnt for each

                    ProNotifAdd.NotiHeader = "added you to a task:";

                    ProNotifAdd.NotiBody = CurrentPro.Name;

                    ProNotifAdd.NotiMessage = CurrentPro.Description;

                    ProNotifAdd.Url = ProURL;

                    ProNotifAdd.FromUserId = CurUid;

                    ProNotifAdd.FromUserName = FromUserName;


                    ProNotifAdd.ToUserId = uID;

                    _context.Add(ProNotifAdd);



                    //adding user
                    UserTask NewUP = new UserTask();
                    NewUP.TskId = TskID;
                    NewUP.UserId = uID;
                    _context.Add(NewUP);
                    await _context.SaveChangesAsync();
                }


                //getting all users assigned and adding them

                var UsersAs = await _context.UserTasks.Where(t => t.TskId == TskID).ToListAsync();

                String AsUsers = "";

                foreach (var Uss in UsersAs)
                {
                    var MyCurUss = await _context.Users.Where(k => k.Id == Uss.UserId).FirstOrDefaultAsync();

                    string MyCurUssName = MyCurUss.FirstName + " " + MyCurUss.LastName + " (" + MyCurUss.UserName + ")";

                    AsUsers = AsUsers + MyCurUssName + ",   ";
                }

                CurrentPro.UsersAssigned = AsUsers;

                _context.Update(CurrentPro);

                await _context.SaveChangesAsync();


                return RedirectToAction("IndexTsk", "UserProjects", new { id = TskID }); ;
            }


            return NotFound();
        }


        //UserTask userTask = new UserTask();
        //    var ase = (_context.UserTasks.Include(u => u.Tsk).Include(u => u.User).Where(t => t.TskId == TskID));
        //    var ad = await ase.ToListAsync();
        //    //ad.Clear();
        //    foreach (var item in ad)
        //    {
        //        //    System.Diagnostics.Debug.WriteLine(item);
        //        //    _context.Remove(item);
        //        //if (item.ProjectId == ProjectID &&
        //        //item.UserId == item.UserId)
        //        //{
        //        System.Diagnostics.Debug.WriteLine("amen");
        //        System.Diagnostics.Debug.WriteLine("amen");
        //        System.Diagnostics.Debug.WriteLine("amen");
        //        System.Diagnostics.Debug.WriteLine(item.UserId);
        //        _context.Remove(item);
        //        await _context.SaveChangesAsync();

        //        //}

        //    }

        //    await _context.SaveChangesAsync();
        //    if (ModelState.IsValid)
        //    {
        //        if (UserIds == null)
        //        {
        //            return NotFound();
        //        }

        //        foreach (string uID in UserIds)
        //        {
        //            userTask.TskId = TskID;
        //            userTask.UserId = uID;
        //            _context.Add(userTask);
        //            await _context.SaveChangesAsync();
        //        }

        //        return RedirectToAction("IndexTsk", "UserProjects", new { id = TskID }); ;
        //    }
        //    //ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name", userProject.ProjectId);
        //    //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", userProject.UserId);
        //    return View(userTask);

        //}



        public async Task<IActionResult> Updated(int ProjectID, string []UserIds)
        {


            UserProject userProject = new UserProject();

            
            
            await _context.SaveChangesAsync();
            if (ModelState.IsValid)
            {
                if (UserIds == null)
                {
                    return NotFound();
                }

                foreach (string uID in UserIds)
                {
                    var ase = (_context.UserProjects.Include(u => u.Project).Include(u => u.User).Where(t => t.ProjectId == ProjectID));
                    var ad = await ase.ToListAsync();
                    foreach (var item in ad)
                    {
                        if (item.UserId == uID)
                        {
                            _context.Remove(item);
                            await _context.SaveChangesAsync();
                        }
                    }
                    userProject.ProjectId = ProjectID;
                    userProject.UserId = uID;
                    _context.Add(userProject);
                    await _context.SaveChangesAsync();
                }
                
                return RedirectToAction("Index", "UserProjects", new { id = ProjectID }); ;
            }
                //ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name", userProject.ProjectId);
                //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", userProject.UserId);
            return View(userProject);
        }

        public async Task<IActionResult> UpdatedTsks(int TskID, string[] UserIds)
        {



            UserTask userTask = new UserTask();
            



            await _context.SaveChangesAsync();
            if (ModelState.IsValid)
            {
                if (UserIds == null)
                {
                    return NotFound();
                }

                foreach (string uID in UserIds)
                {
                    var ase = (_context.UserTasks.Include(u => u.Tsk).Include(u => u.User).Where(t => t.TskId == TskID));
                    var ad = await ase.ToListAsync();
                    foreach (var item in ad)
                    {
                        if (item.UserId == uID)
                        {
                            _context.Remove(item);
                            await _context.SaveChangesAsync();
                        }
                    }
                    userTask.TskId = TskID;
                    userTask.UserId = uID;
                    _context.Add(userTask);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("IndexTsk", "UserProjects", new { id = TskID }); ;
            }
            //ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name", userProject.ProjectId);
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", userProject.UserId);
            return View(userTask);
        }


        //public async Task<IActionResult> Create([Bind("UserId,ProjectId")] UserProject userProject)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(userProject);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name", userProject.ProjectId);
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userProject.UserId);
        //    return View(userProject);
        //}


        // GET: UserProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProject = await _context.UserProjects.FindAsync(id);
            if (userProject == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name", userProject.ProjectId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userProject.UserId);
            return View(userProject);
        }

        // POST: UserProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,ProjectId")] UserProject userProject)
        {
            if (id != userProject.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserProjectExists(userProject.ProjectId))
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
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name", userProject.ProjectId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userProject.UserId);
            return View(userProject);
        }

        // GET: UserProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProject = await _context.UserProjects
                .Include(u => u.Project)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (userProject == null)
            {
                return NotFound();
            }

            return View(userProject);
        }

        // POST: UserProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userProject = await _context.UserProjects.FindAsync(id);
            _context.UserProjects.Remove(userProject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserProjectExists(int id)
        {
            return _context.UserProjects.Any(e => e.ProjectId == id);
        }
    }
}
