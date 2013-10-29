using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace NotifyLibV2
{
    public class TrackersCtrlHelper : IPrgPrntTracker
    {
        private Dictionary<string, ITrackable> _trackerList = null;
        private StackPanel _mPanel = null;

        public TrackersCtrlHelper(StackPanel sp)
        {
            if (sp == null)
                throw new ArgumentNullException("sp");

            _mPanel = sp;
            _trackerList = new Dictionary<string, ITrackable>();
        }

        bool IPrgPrntTracker.TryGetTracker(string id, out ITrackable tracker)
        {
            return _trackerList.TryGetValue(id, out tracker);
        }

        List<string> IPrgPrntTracker.GetTrackerIdList()
        {
            throw new NotImplementedException();
        }

        void IPrgPrntTracker.StopTracking(string trackerId)
        {
            ITrackable tracker = null;
            if (((IPrgPrntTracker)this).TryGetTracker(trackerId, out tracker))
            {
                UserControl userCtrl = (tracker as UserControl);
                _mPanel.Children.Remove(userCtrl);
            }
            else
            {
            }
        }

        void IPrgPrntTracker.AddTracker(ITrackable tracker)
        {
            if (!_trackerList.ContainsKey(tracker.Id))
                _trackerList.Add(tracker.Id, tracker);

            if (tracker is BasicTrackerCtrl)
            {
                BasicTrackerCtrl bCtrl = (BasicTrackerCtrl)tracker;
                _mPanel.Children.Add(bCtrl);
            }
            else if (tracker is PrgTrackerCtrl)
            {
                PrgTrackerCtrl pCtrl = (PrgTrackerCtrl)tracker;
                _mPanel.Children.Add(pCtrl);
            }
            else if (tracker is TrckCtnrCtrl)
            {
                TrckCtnrCtrl tCtrl = (TrckCtnrCtrl)tracker;
                _mPanel.Children.Add(tCtrl);
            }
            else
            {
                // An unknown tracker device has been added.
            }
        }

        int IPrgPrntTracker.MaxTrackers
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        ITrackable IPrgPrntTracker.GetTracker(string trackerId)
        {
            throw new NotImplementedException();
        }
    }
}
