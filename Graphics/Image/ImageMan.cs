using System.Diagnostics;
using System.Dynamic;

namespace SpaceInvaders
{
    public class ImageMan : Manager
    {
        // private Constructor
        private ImageMan(int init = 2, int delta = 3) : base(init, delta)
        {
            
        }

        // public 
        public static void Create(int init = 2, int delta = 2)
        {
            if (pMan == null)
            {
                pMan = new ImageMan(init, delta);
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

        public static Image Add(Image.NAME name, Texture.NAME pTexName, int x, int y, int w, int h)
        {
            Debug.Assert(pMan != null);

            Image pImage = (Image)pMan.baseAdd();
            Debug.Assert(pImage != null);


            Texture pTex = TextureMan.Find(pTexName);
            Debug.Assert(pTex != null);

            pImage.SetImage(name, pTex, x, y, w, h);
            return pImage;
        }

        public static void Remove(Image pImage)
        {
            Debug.Assert(pMan != null);
            Debug.Assert(pImage != null);

            pMan.baseRemove(pImage);
        }

        public static void Dump()
        {
            Debug.Assert(pMan != null);
            pMan.baseDump();
        }

        public static Image Find(Image.NAME name)
        {
            DLink ptr = pMan.poActive;
            while (ptr != null)
            {
                if (((Image)ptr).GetName() == name)
                {
                    return (Image)ptr;
                }

                ptr = ptr.pNext;
            }

            return null;
        }


        override protected void derivedDump(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Image pData = (Image)pLink;
            pData.Dump();
        }



        protected override DLink derivedCreate()
        {
            return new Image();
        }


        // Data: ----------
        private static ImageMan pMan;
    }
}
