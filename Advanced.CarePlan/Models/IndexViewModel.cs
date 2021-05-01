using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advanced.CarePlan.Models
{
    public class IndexViewModel
    {
        public List<CarePlanDetails> CarePlans { get; set; }
        public IndexViewModel(IEnumerable<API.Models.CarePlan> carePlans)
        {
            CarePlans = new List<CarePlanDetails>();
            foreach(var carePlan in carePlans)
            {
                CarePlans.Add(new CarePlanDetails(carePlan));
            }
        }
        public class CarePlanDetails
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

            public CarePlanDetails(API.Models.CarePlan carePlan)
            {
                CarePlanId = carePlan.CarePlanId;
                Title = carePlan.Title;
                PatientName = carePlan.PatientName;
                UserName = carePlan.UserName;
                ActualStartDate = carePlan.ActualStartDate;
                TargetDate = carePlan.TargetDate;
                Reason = carePlan.Reason;
                Action = carePlan.Action;
                Completed = carePlan.Completed;
                EndDate = carePlan.EndDate;
                OutCome = carePlan.OutCome;
            }
        }
    }
}
