using System;
using System.ComponentModel;

namespace Library
{
    
    public class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        #region implémentation de INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}