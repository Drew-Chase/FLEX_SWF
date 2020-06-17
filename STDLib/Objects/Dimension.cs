using System;
using System.Collections.Generic;
using System.Text;

namespace ChaseLabs.Games.SWF.STDLib.Objects
{
    public class Dimension
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public enum ScreenSpacePreset
        {
            None,
            TopLeft,
            MidLeft,
            BottomLeft,
            TopCenter,
            MidCenter,
            BottomCenter,
            TopRight,
            MidRight,
            BottomRight
        }

        public double ScreenSpaceX { get; private set; }
        public double ScreenSpaceY { get; private set; }

        public Dimension(ScreenSpacePreset preset = ScreenSpacePreset.None, int width = 400, int height = 300, double ssx = 0, double ssy = 0, double boundingWidth = 800, double boundingHeight = 600)
        {
            switch (preset)
            {
                case ScreenSpacePreset.None:
                    ScreenSpaceX = ssx;
                    ScreenSpaceY = ssy;
                    break;
                case ScreenSpacePreset.TopLeft:
                    ScreenSpaceX = 0;
                    ScreenSpaceY = 0;
                    break;
                case ScreenSpacePreset.MidLeft:
                    ScreenSpaceX = 0;
                    ScreenSpaceY = (boundingHeight / 2) - (height / 2);
                    break;
                case ScreenSpacePreset.BottomLeft:
                    ScreenSpaceX = 0;
                    ScreenSpaceY = boundingHeight - height;
                    break;
                case ScreenSpacePreset.TopCenter:
                    ScreenSpaceX = (boundingWidth / 2) - (width / 2);
                    ScreenSpaceY = 0;
                    break;
                case ScreenSpacePreset.MidCenter:
                    ScreenSpaceX = (boundingWidth / 2) - (width / 2);
                    ScreenSpaceY = (boundingHeight / 2) - (height / 2);
                    break;
                case ScreenSpacePreset.BottomCenter:
                    ScreenSpaceX = (boundingWidth / 2) - (width / 2);
                    ScreenSpaceY = boundingHeight - height;
                    break;
                case ScreenSpacePreset.TopRight:
                    ScreenSpaceX = boundingWidth - width;
                    ScreenSpaceY = 0;
                    break;
                case ScreenSpacePreset.MidRight:
                    ScreenSpaceX = boundingWidth - width;
                    ScreenSpaceY = (boundingHeight / 2) - (height / 2);
                    break;
                case ScreenSpacePreset.BottomRight:
                    ScreenSpaceX = boundingWidth - width;
                    ScreenSpaceY = boundingHeight - height;
                    break;
                default:
                    preset = ScreenSpacePreset.None;
                    ScreenSpaceX = ssx;
                    ScreenSpaceY = ssy;
                    break;
            }
        }

    }
}
