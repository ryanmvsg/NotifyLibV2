using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotifyLibV2
{
    public interface IGrpPrgTracker : ITrackable
    {
        /// <summary>
        /// The total amount of currently active trackers.
        /// </summary>
        int TrackerCount
        {
            get;
        }

        /// <summary>
        /// The parent tracker in which is held above all.
        /// </summary>
        ITrackable ParentTracker
        {
            get;
        }

        /// <summary>
        /// Gets all of the currently active trackers.
        /// </summary>
        List<ITrackable> GetChildTrackers();

        void AddChildTracker(ITrackableCtrl tracker);

        /// <summary>
        /// Gets the total completion percentage of all the combined child trackers.
        /// </summary>
        double GetCompletionTotal();
    }
}
