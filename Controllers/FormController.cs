using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvc.RoleAuthorization.Data;
using Newtonsoft.Json.Linq;
using PolyFix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolyFix.Controllers
{
    public class FormController : Controller

    {
        private static int TaskID ;

        private static int ProID;

        private static int FormID = 1;


        private readonly ApplicationDbContext _dbContext;
        public string SurveyResults { get; set; }
        public FormController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: SurveyController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SurveyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SurveyController/Create
        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Result(int Tskid, int idPr)
        {



            //var SR = _dbContext.CompletedSurveys.Where(s => s.TaskId == Tskid).Include(t => t.ProjectId == idPr).Include(u => u.FormId == FormID).FirstOrDefault();

            var SR = _dbContext.CompletedSurveys.Where(s => s.TaskId == Tskid).Where(t => t.ProjectId == idPr).Where(u => u.FormId == FormID).FirstOrDefault();

            //var SR = _dbContext.CompletedSurveys
            //.Where(s => s.Id == sId).FirstOrDefault(); ;

            //var sId = 2;

            //var SR = _dbContext.CompletedSurveys
            //.Where(s => s.Id == sId).FirstOrDefault(); ;




            //SurveyResults = SR.SurveyResult;

            //var sv = JObject.Parse(SurveyResults);

            return View(SR);
        }



        public ActionResult Form(int Tskid, int idPr)
        {
            TaskID = Tskid;
            ProID = idPr;

            //ViewBag["TaskID"] = Tskid;
            //ViewBag["ProID"] = idPr;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FormFill(string data)
        {

            _dbContext.CompletedSurveys.Add(new CompletedSurvey
            {
                
                SurveyResult = data,
                TaskId = TaskID,
                ProjectId = ProID,
                FormId = FormID
                //UserId = userId
            });
            // }
            await _dbContext.SaveChangesAsync();

            var SR = _dbContext.Tsks.Where(s => s.TskId == TaskID).Where(t => t.ProjectId == ProID).FirstOrDefault();

            return new OkResult();
           
        }


    }



    public class Form2Controller : Controller

    {
        private static int TaskID;

        private static int ProID;

        private static int FormID = 2;


        private readonly ApplicationDbContext _dbContext;
        public string SurveyResults { get; set; }
        public Form2Controller(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: SurveyController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SurveyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SurveyController/Create
        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Result(int Tskid, int idPr)
        {



            //var SR = _dbContext.CompletedSurveys.Where(s => s.TaskId == Tskid).Include(t => t.ProjectId == idPr).Include(u => u.FormId == FormID).FirstOrDefault();

            var SR = _dbContext.CompletedSurveys.Where(s => s.TaskId == Tskid).Where(t => t.ProjectId == idPr).Where(u => u.FormId == FormID).FirstOrDefault();


            if (SR == null)
            {
                return NotFound();
            }


            //var SR = _dbContext.CompletedSurveys
            //.Where(s => s.Id == sId).FirstOrDefault(); ;

            //var sId = 2;

            //var SR = _dbContext.CompletedSurveys
            //.Where(s => s.Id == sId).FirstOrDefault(); ;




            //SurveyResults = SR.SurveyResult;

            //var sv = JObject.Parse(SurveyResults);

            return View(SR);
        }



        public ActionResult Form(int Tskid, int idPr)
        {
            TaskID = Tskid;
            ProID = idPr;

            

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FormFill(string data)
        {
            var SR = _dbContext.CompletedSurveys.Where(s => s.TaskId == TaskID).Where(t => t.ProjectId == ProID).Where(u => u.FormId == FormID).FirstOrDefault();

            if (SR == null)
            {
                _dbContext.CompletedSurveys.Add(new CompletedSurvey
                {

                    SurveyResult = data,
                    TaskId = TaskID,
                    ProjectId = ProID,
                    FormId = FormID
                    //UserId = userId
                });
            }
            else
            {
                SR.SurveyResult = data;
                _dbContext.Update(SR);
            }

            // }
            await _dbContext.SaveChangesAsync();

            return new OkResult();
        }





    }


    public class Form3Controller : Controller

    {
        private static int TaskID;

        private static int ProID;

        private static int FormID = 3;


        private readonly ApplicationDbContext _dbContext;
        public string SurveyResults { get; set; }
        public Form3Controller(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: SurveyController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SurveyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SurveyController/Create
        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Result(int Tskid, int idPr)
        {



            //var SR = _dbContext.CompletedSurveys.Where(s => s.TaskId == Tskid).Include(t => t.ProjectId == idPr).Include(u => u.FormId == FormID).FirstOrDefault();

            var SR = _dbContext.CompletedSurveys.Where(s => s.TaskId == Tskid).Where(t => t.ProjectId == idPr).Where(u => u.FormId == FormID).FirstOrDefault();

            //var SR = _dbContext.CompletedSurveys
            //.Where(s => s.Id == sId).FirstOrDefault(); ;

            //var sId = 2;

            //var SR = _dbContext.CompletedSurveys
            //.Where(s => s.Id == sId).FirstOrDefault(); ;




            //SurveyResults = SR.SurveyResult;

            //var sv = JObject.Parse(SurveyResults);

            return View(SR);
        }



        public ActionResult Form(int Tskid, int idPr)
        {
            TaskID = Tskid;
            ProID = idPr;


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FormFill(string data)
        {

            _dbContext.CompletedSurveys.Add(new CompletedSurvey
            {

                SurveyResult = data,
                TaskId = TaskID,
                ProjectId = ProID,
                FormId = FormID
                //UserId = userId
            });
            // }
            await _dbContext.SaveChangesAsync();

            return new OkResult();
        }





    }

}
