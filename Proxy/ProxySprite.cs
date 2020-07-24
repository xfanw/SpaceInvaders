using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    //---------------------------------------------------------------------------------------------------------
    // Design Notes:
    //---------------------------------------------------------------------------------------------------------

    abstract public class ProxySprite_Base : SpriteBase
    {

    }
    public class ProxySprite : ProxySprite_Base
    {
        //---------------------------------------------------------------------------------------------------------
        // Enum
        //---------------------------------------------------------------------------------------------------------
        public enum NAME
        {
            Pro_Proxy,
            Uninitialized
        }

        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------

        // Create a single sprite and all dynamic objects ONCE and ONLY ONCE (OOO- tm)
        public ProxySprite()
            : base()
        {
            this.name = ProxySprite.NAME.Uninitialized;

            this.x = 0.0f;
            this.y = 0.0f;

            this.pSprite = null;
        }

        ~ProxySprite()
        {

        }

        //---------------------------------------------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------------------------------------------

        public ProxySprite(GameSprite.NAME name)
        {
            this.name = ProxySprite.NAME.Pro_Proxy;

            this.x = 0.0f;
            this.y = 0.0f;

            this.pSprite = GameSpriteMan.Find(name);
            Debug.Assert(this.pSprite != null);
        }

        public void Set(GameSprite.NAME name)
        {
            this.name = ProxySprite.NAME.Pro_Proxy;

            this.x = 0.0f;
            this.y = 0.0f;

            this.pSprite = GameSpriteMan.Find(name);
            Debug.Assert(this.pSprite != null);
        }

        public override void Update()
        {

        }

        public void Wash()
        {
            this.x = 0.0f;
            this.y = 0.0f;
            this.name = NAME.Uninitialized;
            this.pSprite = null;
            // Wash - clear the entire hierarchy
            base.Clear();            
        }



        public override void Render()
        {
            Debug.Assert(this.pSprite != null);

            this.pSprite.SetXY(this.x, this.y);

            // update and draw real sprite 
            // Seems redundant - Real Sprite might be stale
            this.pSprite.Update();
            this.pSprite.Render();
        }

        public void SetName(NAME inName)
        {
            this.name = inName;
        }
        public NAME GetName()
        {
            return this.name;
        }
        public void Dump()
        {
            //
        }

        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------

        private ProxySprite.NAME name;
        public  float x;
        public float y;
        private GameSprite pSprite;
    }
}
