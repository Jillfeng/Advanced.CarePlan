using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advanced.CarePlan.API.Models
{
    public class CarePlan
    {
        public int CarePlanId { get; set; }
        public string Title { get; set; }
        public string PatientName { get; set; }
        public string UserName { get; set; }
        public DateTime ActualStartDate { get; set; }
        public DateTime TargetDate { get; set; }
        public string Reason { get; set; }
        public string Action { get; set; }
        public Boolean Completed { get; set; }
        public DateTime? EndDate { get; set; }
        public string OutCome { get; set; }
    }
}
