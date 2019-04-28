using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
using System.ComponentModel;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private InfoServer isr;
        #region Singleton
        private static FlightBoardViewModel m_Instance = null;
        public static FlightBoardViewModel Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new FlightBoardViewModel();
                }
                return m_Instance;
            }
        }
        #endregion

        public FlightBoardViewModel()
        {
        }

        public void initFlightBoard()
        {
            MainViewVM mv = MainViewVM.Instance;
            this.isr = mv.isr;
            isr.PropertyChanged += PropertyChange;
        }

        public double VM_Lon
        {
            get { return isr.Lon; }
            set { isr.Lon = value; }
        }

        public double VM_Lat
        {
            get { return isr.Lat; }
            set { isr.Lat = value; }
        }

        public void PropertyChange(object sender, PropertyChangedEventArgs p)
        {
            NotifyPropertyChanged("VM_"+p.PropertyName);
        }
    }
}