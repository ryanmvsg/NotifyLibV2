using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifyLibV2
{
    public class TrackerIsAlreadyCompletedException : Exception
    {
        public TrackerIsAlreadyCompletedException(string id)
            : base(string.Format("Tracker with id of: {0} is already completed.", id))
        {
        }

        public TrackerIsAlreadyCompletedException(string id, Exception innerEx)
            : base(string.Format("Tracker with id of: {0} is already completed.", id), innerEx)
        {
        }
    }
}
