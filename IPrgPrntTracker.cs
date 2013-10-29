using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotifyLibV2
{
    public interface IPrgPrntTracker
    {
        /// <summary>
        /// The maximum number of active trackers allowed to be in the trackers list (this includes sub trackers as well).
        /// </summary>
        int MaxTrackers
        {
            get;
        }
        /// <param name="id">The tracker id to obtain.</param>
        /// <param name="tracker">If successful, the tracker will be assigned to this variable.</param>
        bool TryGetTracker(string id, out ITrackable tracker);

        /// <summary>
        /// Gets the entire tracker id list.
        /// </summary>
        List<string> GetTrackerIdList();

        void StopTracking(string trackerId);

        void AddTracker(ITrackable tracker);

        /// <summary>
        /// Get a trackable object with the associated id.
        /// </summary>
        /// <param name="trackerId">The id of the tracker to get.</param>
        ITrackable GetTracker(string trackerId);
    }
}
