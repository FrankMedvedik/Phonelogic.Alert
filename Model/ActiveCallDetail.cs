using System.ComponentModel.DataAnnotations;

namespace Phonelogic.Alert.Model
{
    public class ActiveCallDetail
    {
        [Display(Name = "Phone")]
        public string CallerId {get; set;}
        public string ConferenceUri {get; set;}
        public string Id {get; set;}
        public string JobNumber {get; set;}
        public string RecruiterUri {get; set;}
        [Display(Name = "Start")]
        public string TimeIn { get; set; }
        [Display(Name = "Job")]
        public string jobFormatted
        {
            get
            {
                return JobNumber.Substring(0, 4) + "-" + JobNumber.Substring(4);
            }
        }
    }
}