using SurveyTest.Business.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyTest.Business.Models
{
    public class Tablet : ModelBase
    {
        public string Name { get; set; }
        public int Type { get; set; }
    }
}
