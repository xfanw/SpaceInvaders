using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class GameObject
    {
        public enum NAME
        {
           RedBird,
           YellowBird,
           GreenBird,
           WhiteBird,
           
           RedGhost,
           PinkGhost,
           BlueGhost,
           OrangeGhost,
           MsPacMan,
           PowerUpGhost,
           Prezel,
           
           Null_Object,
           Uninitialized
        }

        protected GameObject(GameObject.NAME gameName)
        {
            this.name = gameName;
            this.x = 0.0f;
            this.y = 0.0f;
            this.pProxySprite = null;
        }

        protected GameObject(GameObject.NAME gameName, GameSprite.NAME spriteName)
        {
            this.name = gameName;
            this.x = 0.0f;
            this.y = 0.0f;
            this.pProxySprite = new ProxySprite(spriteName);
        }

        ~GameObject()
        {

        }

        public virtual void Update()
        {
            Debug.Assert(this.pProxySprite != null);
            this.pProxySprite.x = this.x;
            this.pProxySprite.y = this.y;
        }

        public void Dump()
        {
            // Data:
            Debug.WriteLine("\t\t\t       name: {0} ({1})", this.name, this.GetHashCode());

            if (this.pProxySprite != null)
            {
                Debug.WriteLine("\t\t   pProxySprite: {0}", this.pProxySprite.GetName());
                //Debug.WriteLine("\t\t    pRealSprite: {0}", this.pProxySprite.p.GetName());
            }
            else
            {
                Debug.WriteLine("\t\t   pProxySprite: null");
                Debug.WriteLine("\t\t    pRealSprite: null");
            }
            Debug.WriteLine("\t\t\t      (x,y): {0}, {1}", this.x, this.y);

        }

        public GameObject.NAME GetName()
        {
            return this.name;
        }
        // Data: ---------------
        private GameObject.NAME name;

        public float x;
        public float y;
        public ProxySprite pProxySprite;

    }
}
