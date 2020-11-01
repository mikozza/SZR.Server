using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SZR
{
    public static class PrioritizationManager
    {

        public static List<PrioritySetting> GetPrioritySetting()
        {

            List<PrioritySetting> settings = new List<PrioritySetting>();
            settings.Add(
                new PrioritySetting
                {
                    MonthFrom = 1,
                    DayFrom = 2,
                    MonthTo = 2,
                    DayTo = 1,
                    BusinessCategory = 10,
                    Priority = 5,
                    PriorityNote = "People need to get fit after new years eve and christmats"
                }) ;

            return settings;
        }

        //public static List<Discount> OrderByPriority(List<Discount> discounts)
        //{
        //    List<PrioritySetting> settings = GetPrioritySetting();
        //    foreach (var discount in discounts)
        //    {
        //        foreach (var setting in settings)
        //        {
        //            if (DateTime.Now.Month >= setting.MonthFrom &&
        //                DateTime.Now.Month <= setting.MonthTo &&


        //                )
        //            {

        //            }
        //        }
        //    }


        //    return discounts.OrderBy(d => d.Priority).ToList();
        //}


        public class PrioritySetting
        {
            public int MonthFrom { get; set; }

            public int DayFrom { get; set; }

            public int MonthTo { get; set; }

            public int DayTo{ get; set; }

            public int BusinessCategory { get; set; }

            public int Priority { get; set; }

            public string PriorityNote { get; set; }
        }
    }
}
