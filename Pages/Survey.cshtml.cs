using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Mvc.RoleAuthorization.Data;
using PolyFix.Models;
using Microsoft.AspNetCore.Antiforgery;

namespace PolyFix.Pages
{
    public class SurveyModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly UserManager<PolyFixAppUser> _userManager;
        


        public SurveyModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync(string data)
        {
            ////var user = await _userManager.GetUserAsync(User);
            //var userId = user.Id;

            //var surveyResult = await _dbContext.CompletedSurveys
            //.Where(s => s.UserId == userId)
            //.FirstOrDefaultAsync();
            //if (surveyResult != null)
            //{
            //    surveyResult.SurveyResult = data;
            //}
            //else
            //{
                _dbContext.CompletedSurveys.Add(new CompletedSurvey
                {
                    SurveyResult = data,
                    //UserId = userId
                });
           // }
            await _dbContext.SaveChangesAsync();

            return new OkResult();
        }
    }
}

