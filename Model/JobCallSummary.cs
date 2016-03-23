
using System.ComponentModel.DataAnnotations;

namespace Phonelogic.Alert.Model
{
    public class JobCallSummary 
    {

        [Display(Name = "Job")]
        public string jobFormatted
        {
            get
            {
                return JobNumber.Substring(0, 4) + "-" + JobNumber.Substring(4, 4);
            }
        }
        public string JobNumber {get; set;}
        [Display(Name = "Hung up")]
        public int Abandoned {get; set;}
        [Display(Name = "Callbacks")]
        public int Callback {get; set;}
        [Display(Name = "InQueue")]
        public int InQueue {get; set;}
        [Display(Name = "In")]
        public int InboundCalls { get; set; }
        [Display(Name = "Left Message ")]
        public int LeftMessage { get; set; }
        [Display(Name = "No Answer")]
        public int NoAgents { get; set; }
        [Display(Name = "Out")]
        public int OutboundCall { get; set; }
        [Display(Name = "Placed")]
        public int PlacedCall { get; set; }
        [Display(Name = "TollFreeNumber")]
        public string TollFreeNumber {get; set;}
        }
    }
