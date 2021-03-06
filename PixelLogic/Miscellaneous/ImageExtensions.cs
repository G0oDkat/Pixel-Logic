﻿namespace PixelLogic.Miscellaneous
{
    using System.Drawing;

    internal static class ImageExtensions
    {
        private const uint Black = 0xFF000000;
        private const uint Gray = 0xFF808080;

        public static bool IsWire(this Image image, int x, int y)
        {
            uint pixel = image.GetPixel(x, y);

            return pixel != Black && pixel != Gray;
        }
    }
}