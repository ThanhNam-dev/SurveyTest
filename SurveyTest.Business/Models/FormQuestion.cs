using SurveyTest.Business.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyTest.Business.Models
{
    public class FormQuestion : ModelBase
    {
        public string Question { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public Forms IdForm { get; set; }
    }
}
