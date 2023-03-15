using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyTest.Business.ViewModel
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string NameQuestion { get; set; }
        public string DescriptionQuestion { get; set; }
        public int Type { get; set; }
        public string Question { get; set; }
    }
}
