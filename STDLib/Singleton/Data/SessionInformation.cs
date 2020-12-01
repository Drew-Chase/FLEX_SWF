using System;
using System.Collections.Generic;
using System.Text;

namespace ChaseLabs.Games.SWF.STDLib.Singleton.Data
{
    public class SessionInformation
    {
        static SessionInformation _singleton;
        public static SessionInformation Singleton
        {
            get
            {
                if (_singleton == null) _singleton = new SessionInformation();
                return _singleton;
            }
        }

        private SessionInformation() { }

        public bool IsSignedIn { get { return true; } set { } }

    }
}
