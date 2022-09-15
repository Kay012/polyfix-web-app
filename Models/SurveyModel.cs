using Poly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolyFix.Models
{
    public class SurveyModel
    {

    }

    public class CompletedSurvey
    {
        public int id { get; set; }

        public int TaskId { get; set; }

        public int ProjectId { get; set; }

        public int FormId { get; set; }

        public string SurveyResult { get; set; }

        //public PolyFixAppUser User { get; set; }

        //public string UserId { get; set; }
    }
}
