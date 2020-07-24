using System;
using System.Diagnostics;


namespace SpaceInvaders
{
    public class GameSprite : SpriteBase
    {
        public enum NAME
        {
            Sprite_Squid_Open,
            Sprite_Squid_Close,
            Sprite_Octopus_Open,
            Sprite_Octopus_Close,
            Sprite_Crab_Open,
            Sprite_Crab_Close,
            
            Sprite_ShipBullet,
            Sprite_Ship,
            
            Sprite_BombT,
            Sprite_BombZigZag,
            Sprite_BombCross,
            
            Sprite_Brick,
            Sprite_BrickLeft_Top0,
            Sprite_BrickLeft_Top1,
            Sprite_BrickLeft_Bottom,
            Sprite_BrickRight_Top0,
            Sprite_BrickRight_Top1,
            Sprite_BrickRight_Bottom,
            
            Sprite_ShipDie1,
            Sprite_ShipDie2,
            Sprite_AlienDie1,
            Sprite_AlienDie2,
            Sprite_UFO,
            Sprite_UFODie,

            // test
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
            // test

            uninitialized
        }

        public GameSprite(GameSprite.NAME name, Image pImg, Azul.Rect pScr)
        {
            Debug.Assert(pImg != null);
            Debug.Assert(pScr != null);

            // Do the create and load
            this.pImg = pImg;
            this.poAzulSprite = new Azul.Sprite(pImg.GetAzulTexture(), pImg.GetRect(), pScr);

            this.name = name;

            this.x = poAzulSprite.x;
            this.y = poAzulSprite.y;
            this.sx = poAzulSprite.sx;
            this.sy = poAzulSprite.sy;
            this.angle = poAzulSprite.angle;
        }

        public void SetSprite(GameSprite.NAME name, Image pImg, int x, int y, int w, int h)
        {

            this.name = name;

            Debug.Assert(pImg != null);
            this.pImg = pImg;

            Debug.Assert(GameSprite.psTmpRect != null);
            psTmpRect.Set(x, y, w, h);

            this.poAzulSprite = new Azul.Sprite(pImg.GetAzulTexture(), pImg.GetRect(), GameSprite.psTmpRect);
            Debug.Assert(this.poAzulSprite != null);

            this.x = poAzulSprite.x;
            this.y = poAzulSprite.y;
            this.sx = poAzulSprite.sx;
            this.sy = poAzulSprite.sy;
            this.angle = poAzulSprite.angle;

        }

        //public void SwapColor(Azul.Color _pColor)
        //{
        //    Debug.Assert(_pColor != null);
        //    Debug.Assert(this.poAzulColor != null);
        //    Debug.Assert(this.poAzulSprite != null);
        //    this.poAzulColor.Set(_pColor);
        //    this.poAzulSprite.SwapColor(_pColor);
        //}

        public void SetXY(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        //public void SwapColor(float red, float green, float blue, float alpha = 1.0f)
        //{
        //    Debug.Assert(this.poAzulColor != null);
        //    Debug.Assert(this.poAzulSprite != null);
        //    this.poAzulColor.Set(red, green, blue, alpha);
        //    this.poAzulSprite.SwapColor(this.poAzulColor);
        //}

        public void SwapImage(Image pNewImage)
        {
            Debug.Assert(this.poAzulSprite != null);
            Debug.Assert(pNewImage != null);
            this.pImg = pNewImage;

            this.poAzulSprite.SwapTexture(this.pImg.GetAzulTexture());
            this.poAzulSprite.SwapTextureRect(this.pImg.GetRect());
        }
        override public void Update()
        {
            this.poAzulSprite.x = this.x;
            this.poAzulSprite.y = this.y;
            this.poAzulSprite.sx = this.sx;
            this.poAzulSprite.sy = this.sy;
            this.poAzulSprite.angle = this.angle;

            this.poAzulSprite.Update();
        }
        public void Wash()
        {
            this.name = NAME.uninitialized;

            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0.0f;

        }
        override public void Render()
        {
            this.poAzulSprite.Render();
        }
        public GameSprite() : base()
        {
            this.poAzulSprite = new Azul.Sprite();
            Debug.Assert(this.poAzulSprite != null);

            // this.Clear();
        }

        public void SetSpriteName(NAME name)
        {
            this.name = name;
        }

        public GameSprite.NAME GetName()
        {
            return this.name;
        }

        public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   {0} ({1})", this.name, this.GetHashCode());

            // Prev Node
            if (this.pPrev == null)
            {
                Debug.WriteLine("      prev: null");
            }
            else
            {
                GameSprite pTmp = (GameSprite)this.pPrev;
                Debug.WriteLine("      prev: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }

            // Next Node
            if (this.pNext == null)
            {
                Debug.WriteLine("      next: null");
            }
            else
            {
                GameSprite pTmp = (GameSprite)this.pNext;
                Debug.WriteLine("      next: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }

        }
        // Data: ----------
        public float x;
        public float y;
        private float sx;
        private float sy;
        private float angle;

        private GameSprite.NAME name;
        private Image pImg;
        private Azul.Sprite poAzulSprite;
        //private readonly Azul.Color poAzulColor;

        static private Azul.Rect psTmpRect = new Azul.Rect();
        static private Azul.Color psTmpColor = new Azul.Color(1, 1, 1);
    }
}
