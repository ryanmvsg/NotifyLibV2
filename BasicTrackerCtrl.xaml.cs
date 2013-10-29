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
    /// Interaction logic for BasicTrackerCtrl.xaml
    /// </summary>
    public partial class BasicTrackerCtrl : UserControl, ITrackable, ITrackableCtrl
    {
        private string _trackerId = null;

        public BasicTrackerCtrl()
        {
            InitializeComponent();
            _trackerId = "{" + Guid.NewGuid().ToString() + "}";
        }

        public string Description
        {
            get { return ((ITrackable)this).Description; }
            set { ((ITrackable)this).Description = value; }
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

        public string OwnerId
        {
            get;
            set;
        }

        void ITrackable.UpdateTracker(string description, bool hasErrors)
        {
            ITrackable tracker = ((ITrackable)this);
            tracker.Description = description;
            tracker.HasErrors = hasErrors;
        }

        bool ITrackable.IsCompleted
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Returns this object as it's trackable device.
        /// </summary>
        public ITrackable TrackableDevice
        {
            get { return ((ITrackable)this); }
        }

        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(BasicTrackerCtrl));
        public static readonly DependencyProperty HasErrorsProperty = DependencyProperty.Register("HasErrors", typeof(bool), typeof(BasicTrackerCtrl));

        UserControl ITrackableCtrl.TrackableCtrl
        {
            get { return this; }
        }
    }
}
