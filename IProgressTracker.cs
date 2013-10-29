using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotifyLibV2
{
    public interface IProgressTracker : ITrackable
    {
        /// <summary>
        /// The current progress of the task completed.
        /// </summary>
        double ProgressVal
        {
            get;
        }
        /// <summary>
        /// Updates the tracker to a given percentage of completion with an update to text as an option.
        /// </summary>
        /// <param name="prgVal">Updates the tracker to a set amount of progress.</param>
        /// <param name="description">The description to update the tracker to.</param>
        /// <param name="hasErrors">Sets whether or not the object references an error that was intercepted that was uncorrectable.</param>
        void UpdateTracker(double prgVal, string description, bool hasErrors);
    }
}
