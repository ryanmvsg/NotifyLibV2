using System;

namespace NotifyLibV2
{
    public delegate void StopTrackerEventHandler(object sender, string trackerId, string ownerId);
    public delegate void UpdateTrackerEventHandler(object sender, ITrackable tracker, string ownerId);
}