using SurveyTest.Business.Models.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyTest.Business.Models
{
    public class FormAnswer : ModelBase
    {
        [AllowNull]
        public Guid IdUser { get; set; }
        public FormQuestion IdFormQuestion { get; set; }
        public string Answer { get; set; }
    }
}
