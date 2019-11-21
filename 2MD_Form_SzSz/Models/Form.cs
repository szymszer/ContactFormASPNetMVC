using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _2MD_Form_SzSz
{
    public partial class Form
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }


        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "This field is required.")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DisplayName("Area Of Interest")]
        public string AreaOfInterest { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }

    public enum AOI
    {
        Accounting,
        Administration,
        Business,
        Communication,
        Economics,
        Finance,
        Management,
        Marketing,
        Mathematics,
        Other
    }
}
