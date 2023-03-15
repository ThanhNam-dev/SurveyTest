using SurveyTest.Business.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyTest.Business.Models
{
    public class Forms : ModelBase
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public bool Status { get; set; }
        public AppUsers IdUser { get; set; }
        public bool Publish { get; set; }
    }
}
