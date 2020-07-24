using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteNode : DLink
    {

        public SpriteNode()
            : base()
        {
            this.pSpriteBase = null;
        }

        public void Set(GameSprite.NAME name)
        {
            // Go find it
            this.pSpriteBase = GameSpriteMan.Find(name);
            Debug.Assert(this.pSpriteBase != null);
        }

        public void Set(BoxSprite.NAME name)
        {
            // Go find it
            this.pSpriteBase = BoxSpriteMan.Find(name);
            Debug.Assert(this.pSpriteBase != null);
        }

        public void Set(ProxySprite pProxy)
        {
            this.pSpriteBase = pProxy;

            Debug.Assert(this.pSpriteBase != null);
        }

        public void Wash()
        {
            this.pSpriteBase = null;
        }

        // Data: ----------------------------------------------
        public SpriteBase pSpriteBase;
    }
}

// End of File
