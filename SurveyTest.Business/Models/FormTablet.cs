using SurveyTest.Business.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyTest.Business.Models
{
    public class FormTablet : ModelBase
    {
        public FormQuestion IdFormQuestion { get; set; }
        public Tablet IdTablet { get; set; }
    }
}
