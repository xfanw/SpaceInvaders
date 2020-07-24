using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class NullGameObjs: GameObject
    {
        public NullGameObjs()
            : base(GameObject.NAME.Null_Object)
        {

        }
        ~NullGameObjs()
        {

        }
        public override void Update()
        {
            // do nothing - its a null object
        }

    }
}
