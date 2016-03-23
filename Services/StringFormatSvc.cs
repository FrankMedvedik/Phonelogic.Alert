using System;

namespace PhoneLogic.Alert.Services
{
    public static class StringFormatSvc
    {

        public static string DurationFormatted(string duration)
        {
            int n;
            if (int.TryParse(duration, out n))
                return string.Format("{0:00}:{1:00}:{2:00}", n/3600, (n/60)%60, n%60);
            return duration;
        }

        public static  string DurationFormatted(int duration)
        {
                return string.Format("{0:00}:{1:00}:{2:00}", duration / 3600, (duration / 60) % 60, duration % 60);
        }
        public static string JobFormatted(string jobNumber)
        {
            return (String.IsNullOrWhiteSpace(jobNumber)) ? jobNumber : jobNumber.Substring(0, 4) + "-" + jobNumber.Substring(4, 4) ;
        }
        public static string JobAndTaskFormatted(string jobNumber)
        {
            return (String.IsNullOrWhiteSpace(jobNumber)) ? jobNumber : jobNumber.Substring(0, 4) + "-" + jobNumber.Substring(4);
        }

        public static string PhoneNumberFormatted(string phoneNumber)
        {
                string retval;
                double n;
                if(double.TryParse(phoneNumber, out n))
                    retval = (String.IsNullOrWhiteSpace(phoneNumber)) ? phoneNumber : String.Format("{0:(###)###-####}", double.Parse(phoneNumber));
                else
                    retval = phoneNumber;
              return retval;
        }
        public static int TaskFromJobNumber(string JobNumber)
        {
            
            int n;
            if (!int.TryParse(JobNumber.Substring(8, 1), out n))
                return 0;
            return n;
        }
    }

}
