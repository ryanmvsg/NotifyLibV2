using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NotifyLibV2
{
    /// <summary>
    /// Interaction logic for TrckCtnrCtrl.xaml
    /// </summary>
    public partial class TrckCtnrCtrl : UserControl, IGrpPrgTracker
    {
        Dictionary<string, ITrackable> _mTrackableList = null;
        private ITrackable _mTracker = null;
        private bool _mCompleted = false;

        public TrckCtnrCtrl()
            : this(null)
        {
            InitializeComponent();
            _mTrackableList = new Dictionary<string, ITrackable>();
        }

        public TrckCtnrCtrl(ITrackableCtrl tracker)
        {
            InitializeComponent();

            if (tracker == null)
                throw new ArgumentNullException("tracker");

            _mTracker = tracker;
            this.xMainGrid.Children.Add(tracker.TrackableCtrl);
        }

        int IGrpPrgTracker.TrackerCount
        {
            get
            {
                return _mTrackableList.Count;
            }
        }

        List<ITrackable> IGrpPrgTracker.GetChildTrackers()
        {
            return _mTrackableList.Values.ToList();
        }

        void IGrpPrgTracker.AddChildTracker(ITrackableCtrl tracker)
        {
            _mTrackableList.Add(tracker.Id, tracker);
        }

        string ITrackable.Description
        {
            get
            {
                return (string)this.GetValue(DescProperty);
            }
            set
            {
                this.SetValue(DescProperty, value);
            }
        }

        bool ITrackable.HasErrors
        {
            get
            {
                return _mTracker.HasErrors;
            }
            set
            {
                _mTracker.HasErrors = true;
            }
        }

        string ITrackable.Id
        {
            get { return _mTracker.Id; }
        }

        void ITrackable.UpdateTracker(string description, bool hasErrors)
        {
            _mTracker.UpdateTracker(description, hasErrors);
        }

        double IGrpPrgTracker.GetCompletionTotal()
        {
            double retVal = 0.0;
            foreach (IProgressTracker tracker in _mTrackableList.Values.OfType<IProgressTracker>())
            {
                retVal += tracker.ProgressVal;
            }
            return retVal;
        }

        ITrackable IGrpPrgTracker.ParentTracker
        {
            get { return _mTracker; }
        }

        bool ITrackable.IsCompleted
        {
            get { return _mCompleted; }
        }

        public static readonly DependencyProperty DescProperty = DependencyProperty.Register("Description", typeof(string), typeof(TrckCtnrCtrl));
        public static readonly DependencyProperty HasErrorsProperty = DependencyProperty.Register("HasErrors", typeof(bool), typeof(TrckCtnrCtrl));
    }
}
