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
    [MetadataType(typeof(GoodMetadata))]
    public partial class Good
    {
        [Bind(Exclude = "Id")]
        public class GoodMetadata
        {
            [ScaffoldColumn(false)]
            public int Id { get; set; }

            [DisplayName("Name")]
            [Required(ErrorMessage = "This field is required")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public string Name { get; set; }

            [DisplayName("Date of Income")]
            [DisplayFormat(DataFormatString = "{MM/dd/yyyy}", ApplyFormatInEditMode = true)]
            public System.DateTime DateIncome { get; set; }

            [DisplayName("Price")]
            [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
            [Required(ErrorMessage = "This field is required")]
            [Range(0.01, float.MaxValue, ErrorMessage = "Price must be greater than 0.01")]
            public string Price { get; set; }

            [DisplayName("Description")]
            public string Description { get; set; }
        }
    }
}
