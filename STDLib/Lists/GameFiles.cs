using ChaseLabs.Games.SWF.STDLib.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChaseLabs.Games.SWF.STDLib.Lists
{
    public class GameFiles : List<GameFile>
    {
        private static GameFiles _singleton;
        public static GameFiles Singleton
        {
            get
            {
                if (_singleton == null) _singleton = new GameFiles();
                return _singleton;
            }
        }

        private GameFiles()
        {

        }

    }
}
