﻿using System.Diagnostics;
using System.Dynamic;

namespace SpaceInvaders
{
    public class ProxyMan : Manager
    {
        // private Constructor
        private ProxyMan(int init = 2, int delta = 3) : base(init, delta)
        {

        }

        // public 
        public static void Create(int init = 2, int delta = 2)
        {
            if (pMan == null)
            {
                pMan = new ProxyMan(init, delta);
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

        public static ProxySprite Add(GameSprite.NAME name)
        {
            Debug.Assert(pMan != null);

            ProxySprite pPoxSprite = (ProxySprite)pMan.baseAdd();
            Debug.Assert(pPoxSprite != null);

            pPoxSprite.Set(name);
            return pPoxSprite;
        }

        public static void Remove(ProxySprite pProxy)
        {
            Debug.Assert(pMan != null);
            Debug.Assert(pProxy != null);

            pMan.baseRemove(pProxy);
        }

        public static void Dump()
        {
            Debug.Assert(pMan != null);
            pMan.baseDump();
        }

        public static ProxySprite Find(ProxySprite.NAME name)
        {
            DLink ptr = pMan.poActive;
            while (ptr != null)
            {
                if (((ProxySprite)ptr).GetName() == name)
                {
                    return (ProxySprite)ptr;
                }

                ptr = ptr.pNext;
            }

            return null;
        }


        override protected void derivedDump(DLink pLink)
        {
            Debug.Assert(pLink != null);
            ProxySprite pData = (ProxySprite)pLink;
            pData.Dump();
        }



        protected override DLink derivedCreate()
        {
            return new ProxySprite();
        }


        // Data: ----------
        private static ProxyMan pMan;
    }
}
