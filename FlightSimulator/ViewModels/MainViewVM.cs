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
            cs = new CommandServer();
            isr = new InfoServer();
            cs.Start();
            isr.Connect();
<<<<<<< HEAD
            isr.HandleClient();
=======
>>>>>>> 4bff969a3c86c2c5302e8b6dfd1dc4a8a98dd3e4
            FlightBoardViewModel fbvm = FlightBoardViewModel.Instance;
            fbvm.initFlightBoard();
        }
    }

}
