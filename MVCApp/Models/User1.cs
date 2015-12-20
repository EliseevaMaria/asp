using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCApp.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
        [Bind(Exclude = "Id")]
        public class UserMetadata
        {
            [ScaffoldColumn(false)]
            public int Id { get; set; }

            [DisplayName("Login")]
            public string Login { get; set; }

            [DisplayName("Password")]
            public string Password { get; set; }

            [DisplayName("Role")]
            public int Role { get; set; }
        }
    }
}
