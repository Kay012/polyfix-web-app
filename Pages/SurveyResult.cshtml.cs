using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mvc.RoleAuthorization.Data;

namespace PolyFix.Pages
{
    public class SurveyResultModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public string SurveyResults { get; set; }
        public SurveyResultModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task OnGetAsync()
        {
            var sId = 2;

            //var SR = _dbContext.CompletedSurveys
            //.Where(s => s.Id == sId).FirstOrDefault(); ;


            //SurveyResults = SR.SurveyResult;
            //SurveyResult = surveyResult?.SurveyResult?? "{}";

        }
    }
}
