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
    /// Interaction logic for PrgTrackerCtrl.xaml
    /// </summary>
    public partial class PrgTrackerCtrl : UserControl, IProgressTracker, ITrackableCtrl
    {
        private string _trackerId = null;

        public PrgTrackerCtrl()
        {
            InitializeComponent();
            _trackerId = "{" + Guid.NewGuid().ToString() + "}";
        }

        double IProgressTracker.ProgressVal
        {
            get
            {
                return (double)this.GetValue(ProgressValProperty);
            }
        }

        void IProgressTracker.UpdateTracker(double prgVal, string description, bool hasErrors)
        {
            this.SetValue(ProgressValProperty, prgVal);
            this.Description = description;
            this.TrackableDevice.HasErrors = hasErrors;
        }

        string ITrackable.Description
        {
            get
            {
                return (string)this.GetValue(DescriptionProperty);
            }
            set
            {
                this.SetValue(DescriptionProperty, value);
            }
        }

        bool ITrackable.HasErrors
        {
            get
            {
                return (bool)this.GetValue(HasErrorsProperty);
            }
            set
            {
                this.SetValue(HasErrorsProperty, value);
            }
        }

        string ITrackable.Id
        {
            get { return _trackerId; }
        }

        void ITrackable.UpdateTracker(string description, bool hasErrors)
        {
            this.TrackableDevice.UpdateTracker(this.TrackableDevice.ProgressVal, description, hasErrors);
        }

        public string Id
        {
            get { return ((ITrackable)this).Id; }
        }

        public string Description
        {
            get { return ((ITrackable)this).Description; }
            set { ((ITrackable)this).Description = value; }
        }

        public string OwnerId
        {
            get;
            set;
        }

        bool ITrackable.IsCompleted
        {
            get { return (((IProgressTracker)this).ProgressVal == 100.0); }
        }

        /// <summary>
        /// Returns this object as it's trackable device.
        /// </summary>
        public IProgressTracker TrackableDevice
        {
            get { return ((IProgressTracker)this); }
        }

        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(PrgTrackerCtrl));
        public static readonly DependencyProperty HasErrorsProperty = DependencyProperty.Register("HasErrors", typeof(bool), typeof(PrgTrackerCtrl));
        public static readonly DependencyProperty ProgressValProperty = DependencyProperty.Register("ProgressVal", typeof(double), typeof(PrgTrackerCtrl));

        UserControl ITrackableCtrl.TrackableCtrl
        {
            get { return this; }
        }
    }
}
