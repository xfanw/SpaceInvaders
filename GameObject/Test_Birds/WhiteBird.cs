using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WhiteBird : GameObject
    {
        public WhiteBird(GameObject.NAME name, GameSprite.NAME spriteName, float posX, float posY)
    : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
        }

        // Data: ---------------
        ~WhiteBird()
        {

        }

        // this is just a placeholder, who knows what data will be stored here

    }
}
