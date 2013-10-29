using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotifyLibV2
{
    public interface ITrackable
    {
        /// <summary>
        /// The descriptior text
        /// </summary>
        string Description
        {
            get;
            set;
        }

        bool HasErrors
        {
            get;
            set;
        }

        /// <summary>
        /// The randomized id of the tracker to be used for later tracking.
        /// </summary>
        string Id
        {
            get;
        }

        bool IsCompleted
        {
            get;
        }

        /// <summary>
        /// Updates the description text and changes the flag status on whether or not it's an error.
        /// </summary>
        /// <param name="description">The description to set the text to.</param>
        /// <param name="hasErrors">Whether or notnn to flag the tracker as containing errors.</param>
        void UpdateTracker(string description, bool hasErrors);
    }
}
