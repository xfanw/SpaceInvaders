﻿using System.Diagnostics;

namespace SpaceInvaders
{
    public class ImageHolder : SLink
    {
        public ImageHolder(Image image)
            : base()
        {
            this.pImage = image;
        }

        // Data: ---------------
        public Image pImage;
    }
}
