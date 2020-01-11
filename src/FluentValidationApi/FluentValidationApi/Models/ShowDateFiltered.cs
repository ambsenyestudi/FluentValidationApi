using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationApi.Models
{
    public class ShowDateFiltered
    {
        public string Iso { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Show { get; set; }
    }
}
