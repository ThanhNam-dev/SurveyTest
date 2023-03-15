using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyTest.Business.Models
{
    public class AppUsers : IdentityUser<Guid>
    {
        public int IDSV { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Firstname { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Lastname { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [AllowNull]
        public string Address { get; set; }

    }


}
