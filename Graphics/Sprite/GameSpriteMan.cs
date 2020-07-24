using System.Diagnostics;
using System.Dynamic;

namespace SpaceInvaders
{
    public class GameSpriteMan : Manager
    {
        // private Constructor
        private GameSpriteMan(int init = 2, int delta = 3) : base(init, delta)
        {
        }

        // public 
        public static void Create(int init = 2, int delta = 2)
        {
            if (pMan == null)
            {
                pMan = new GameSpriteMan(init, delta);
            }

        }

        public static void Destroy()
        {

            Debug.Assert(pMan != null);

            // Do something clever here
            // track peak number of active nodes
            pMan.baseDestroy();
            // invalidate the singleton

            pMan = null;
        }

        public static GameSprite Add(GameSprite.NAME name, Image.NAME pImgName, int x, int y, int w, int h)
        {
            Debug.Assert(pMan != null);

            GameSprite pSprite = (GameSprite)pMan.baseAdd();
            Debug.Assert(pSprite != null);

            Image pImg = ImageMan.Find(pImgName);
            Debug.Assert(pImg != null);

            pSprite.SetSprite(name, pImg, x, y, w, h);
            return pSprite;
        }

        public static void Remove(GameSprite pSprite)
        {
            Debug.Assert(pMan != null);
            Debug.Assert(pSprite != null);

            pMan.baseRemove(pSprite);
            pSprite.Wash();
        }

        public static void Dump()
        {
            Debug.Assert(pMan != null);
            pMan.baseDump();
        }

        public static GameSprite Find(GameSprite.NAME name)
        {
            DLink ptr = pMan.poActive;
            while (ptr != null)
            {
                if (((GameSprite)ptr).GetName() == name)
                {
                    return (GameSprite)ptr;
                }

                ptr = ptr.pNext;
            }

            return null;
        }



        override protected void derivedDump(DLink pLink)
        {
            Debug.Assert(pLink != null);
            GameSprite pData = (GameSprite)pLink;
            pData.Dump();
        }



        protected override DLink derivedCreate()
        {
            return new GameSprite();
        }


        // Data: ----------
        private static GameSpriteMan pMan;

    }
}
