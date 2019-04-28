using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
namespace FlightSimulator.ViewModels
{
    class MainViewVM
    {
        public CommandServer cs;
        public InfoServer isr;
        #region Singleton
        private static MainViewVM m_Instance = null;
        public static MainViewVM Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new MainViewVM();
                }
                return m_Instance;
            }
        }
        #endregion
        public void startServerVM()
        {
            cs = CommandServer.Instance;
            isr = InfoServer.Instance;
            isr.Connect();
            cs.Start();
            FlightBoardViewModel fbvm = FlightBoardViewModel.Instance;
            fbvm.initFlightBoard();
        }
    }

}