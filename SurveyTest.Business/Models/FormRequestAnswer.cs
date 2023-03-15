using SurveyTest.Business.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyTest.Business.Models
{
    public class FormRequestAnswer : ModelBase
    {
        public FormRequest IdFormRequest { get; set; }
        public FormAnswer IdFormAnswer { get; set; }
    }
}
