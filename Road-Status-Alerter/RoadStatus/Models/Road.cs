using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RoadStatus.Models
{
    public class Road
    {
        public string Id { get; set; }

        [Display(Name = "Road Name")]
        public string DisplayName { get; set; }

        [Display(Name = "Road Status")]
        public string StatusSeverity { get; set; }

        [Display(Name = "Road Status Description")]
        public string StatusSeverityDescription { get; set; }
    }
}
