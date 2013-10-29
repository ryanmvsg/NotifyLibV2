using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace NotifyLibV2
{
    public interface ITrackableCtrl : ITrackable
    {
        UserControl TrackableCtrl
        {
            get;
        }
    }
}
