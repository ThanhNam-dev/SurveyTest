using SurveyTest.Business.Models.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyTest.Business.Models
{
    public class FormRequest : ModelBase
    {
        public Forms IdForm { get; set; }
        [AllowNull]
        public Guid IdUser { get; set; }
    }
}
