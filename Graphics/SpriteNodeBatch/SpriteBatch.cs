using System;
using System.Diagnostics;

namespace SpaceInvaders
{

    public class SpriteBatch : DLink
    {
        public enum NAME
        {
            PacMan,
            AngryBirds,
            Boxes,

            Uninitialized
        }

        public SpriteBatch()
            : base()
        {
            this.name = SpriteBatch.NAME.Uninitialized;
            this.pNodeMan = new SpriteNodeMan();
            Debug.Assert(this.pNodeMan != null);
        }


        public void Set(SpriteBatch.NAME name, int reserveNum = 3, int reserveGrow = 1)
        {
            this.name = name;
        }
        public SpriteNode Attach(GameSprite.NAME name)
        {
            SpriteNode pNode = this.pNodeMan.Attach(name);
            return pNode;
        }

        public SpriteNode Attach(BoxSprite.NAME name)
        {
            SpriteNode pNode = this.pNodeMan.Attach(name);
            return pNode;
        }

        public SpriteNode Attach(ProxySprite pNode)
        {
            Debug.Assert(this.pNodeMan != null);
            SpriteNode pSBNode = this.pNodeMan.Attach(pNode);
            return pSBNode;
        }
        public void Wash()
        {
        }

        public void Dump()
        {
        }

        public void SetName(SpriteBatch.NAME inName)
        {
            this.name = inName;
        }

        public SpriteBatch.NAME GetName()
        {
            return this.name;
        }

        public SpriteNodeMan GetSpriteNodeMan()
        {
            return this.pNodeMan;
        }

        // Data -------------------------------
        public SpriteBatch.NAME name;
        private readonly SpriteNodeMan pNodeMan;

    }
}

// End of File
