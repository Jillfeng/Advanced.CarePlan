using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advanced.CarePlan.Models
{
    public class CarePlanViewModel
    {
        public int CarePlanId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public DateTime ActualStartDate { get; set; }
        [Required]
        public DateTime TargetDate { get; set; }
        [Required]
        public string Reason { get; set; }
        [Required]
        public string Action { get; set; }
        public Boolean Completed { get; set; }
        public DateTime? EndDate { get; set; }
        public string OutCome { get; set; }

        public CarePlanViewModel()
        {

        }
        public CarePlanViewModel(API.Models.CarePlan carePlan)
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
