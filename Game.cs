using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpaceInvaders : Azul.Game
    {
        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            // Game Window Device setup
            this.SetWindowName("Sprites");
            this.SetWidthHeight(800, 600);
            this.SetClearColor(0.4f, 0.4f, 0.8f, 1.0f);
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {
            //---------------------------------------------------------------------------------------------------------
            // Setup Managers
            //---------------------------------------------------------------------------------------------------------

            TextureMan.Create(1, 1);
            ImageMan.Create(5, 2);
            GameSpriteMan.Create(4, 2);
            BoxSpriteMan.Create(3, 1);
            SpriteBatchMan.Create(3, 1);
            TimerMan.Create(3, 1);
            ProxyMan.Create(10, 1);

            //---------------------------------------------------------------------------------------------------------
            // Load the Textures
            //---------------------------------------------------------------------------------------------------------

            TextureMan.Add(Texture.NAME.Birds, "Birds.tga");
            TextureMan.Add(Texture.NAME.PacMan, "PacMan.tga");

            //---------------------------------------------------------------------------------------------------------
            // Create Images
            //---------------------------------------------------------------------------------------------------------

            // --- angry birds ---

            ImageMan.Add(Image.NAME.RedBird, Texture.NAME.Birds, 47, 41, 48, 46);
            ImageMan.Add(Image.NAME.YellowBird, Texture.NAME.Birds, 124, 34, 60, 56);
            ImageMan.Add(Image.NAME.GreenBird, Texture.NAME.Birds, 246, 135, 99, 72);
            ImageMan.Add(Image.NAME.WhiteBird, Texture.NAME.Birds, 139, 131, 84, 97);

            // --- Pacman Ghosts ---

            ImageMan.Add(Image.NAME.RedGhost, Texture.NAME.PacMan, 616, 148, 33, 33);
            ImageMan.Add(Image.NAME.PinkGhost, Texture.NAME.PacMan, 663, 148, 33, 33);
            ImageMan.Add(Image.NAME.BlueGhost, Texture.NAME.PacMan, 710, 148, 33, 33);
            ImageMan.Add(Image.NAME.OrangeGhost, Texture.NAME.PacMan, 757, 148, 33, 33);

            //---------------------------------------------------------------------------------------------------------
            // Create Sprites
            //---------------------------------------------------------------------------------------------------------

            // --- BoxSprites ---

            BoxSpriteMan.Add(BoxSprite.NAME.Box1, 550.0f, 500.0f, 50.0f, 150.0f, new Azul.Color(1.0f, 1.0f, 1.0f, 1.0f));
            BoxSpriteMan.Add(BoxSprite.NAME.Box2, 550.0f, 100.0f, 50.0f, 100.0f);

            GameSpriteMan.Add(GameSprite.NAME.RedBird, Image.NAME.RedBird, 50, 500, 100, 100);
            GameSpriteMan.Add(GameSprite.NAME.YellowBird, Image.NAME.YellowBird, 300, 400, 50, 50);
            GameSpriteMan.Add(GameSprite.NAME.GreenBird, Image.NAME.GreenBird, 400, 200, 100, 100);
            GameSpriteMan.Add(GameSprite.NAME.WhiteBird, Image.NAME.WhiteBird, 600, 200, 100, 100);

            GameSpriteMan.Add(GameSprite.NAME.RedGhost, Image.NAME.RedGhost, 100, 300, 100, 100);
            GameSpriteMan.Add(GameSprite.NAME.PinkGhost, Image.NAME.PinkGhost, 300, 300, 100, 100);
            GameSpriteMan.Add(GameSprite.NAME.BlueGhost, Image.NAME.BlueGhost, 500, 300, 100, 100);
            GameSpriteMan.Add(GameSprite.NAME.OrangeGhost, Image.NAME.OrangeGhost, 700, 300, 100, 100);

            // Create SpriteBatch
            //---------------------------------------------------------------------------------------------------------

            SpriteBatch pSB_PacMan = SpriteBatchMan.Add(SpriteBatch.NAME.PacMan);
            SpriteBatch pSB_Birds = SpriteBatchMan.Add(SpriteBatch.NAME.AngryBirds);

            //---------------------------------------------------------------------------------------------------------
            // Attach to Sprite Batch
            //---------------------------------------------------------------------------------------------------------

            pSB_PacMan.Attach(GameSprite.NAME.RedGhost);
            pSB_PacMan.Attach(GameSprite.NAME.PinkGhost);
            pSB_PacMan.Attach(GameSprite.NAME.BlueGhost);
            pSB_PacMan.Attach(GameSprite.NAME.OrangeGhost);

            pSB_Birds.Attach(GameSprite.NAME.RedBird);
            pSB_Birds.Attach(GameSprite.NAME.YellowBird);
            pSB_Birds.Attach(GameSprite.NAME.GreenBird);
            pSB_Birds.Attach(GameSprite.NAME.WhiteBird);


            //---------------------------------------------------------------------------------------------------------
            // Proxy
            //---------------------------------------------------------------------------------------------------------

            // create 10 proxies
            for (int i = 0; i < 10; i++)
            {
                ProxySprite pProxy = ProxyMan.Add(GameSprite.NAME.YellowBird);
                pProxy.x = 50.0f + 70 * i;
                pProxy.y = 100.0f;
                pSB_Birds.Attach(pProxy);
            }

        }

        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        public override void Update()
        {
            // Add your update below this line: ----------------------------

            // Fire off the timer events
            TimerMan.Update(this.GetTime());


            GameSprite pSprite;

            pSprite = GameSpriteMan.Find(GameSprite.NAME.BlueGhost);
            Debug.Assert(pSprite != null);
            pSprite.Update();

            pSprite = GameSpriteMan.Find(GameSprite.NAME.RedGhost);
            Debug.Assert(pSprite != null);
            pSprite.Update();

            pSprite = GameSpriteMan.Find(GameSprite.NAME.OrangeGhost);
            Debug.Assert(pSprite != null);
            pSprite.Update();

            pSprite = GameSpriteMan.Find(GameSprite.NAME.PinkGhost);
            Debug.Assert(pSprite != null);
            pSprite.Update();

            pSprite = GameSpriteMan.Find(GameSprite.NAME.RedBird);
            Debug.Assert(pSprite != null);
            pSprite.y += 1.0f;
            if (pSprite.y > 600.0f)
            {
                pSprite.y = 0.0f;
            }
            pSprite.Update();

            pSprite = GameSpriteMan.Find(GameSprite.NAME.YellowBird);
            Debug.Assert(pSprite != null);
            pSprite.y += 2.0f;
            if (pSprite.y > 600.0f)
            {
                pSprite.y = 0.0f;
            }
            pSprite.Update();

            pSprite = GameSpriteMan.Find(GameSprite.NAME.GreenBird);
            Debug.Assert(pSprite != null);
            pSprite.y += 0.50f;
            if (pSprite.y > 600.0f)
            {
                pSprite.y = 0.0f;
            }
            pSprite.Update();

            pSprite = GameSpriteMan.Find(GameSprite.NAME.WhiteBird);
            Debug.Assert(pSprite != null);
            pSprite.y += 3.0f;
            if (pSprite.y > 600.0f)
            {
                pSprite.y = 0.0f;
            }
            pSprite.Update();

        }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {
            // draw all objects
            SpriteBatchMan.Draw();
        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {

        }

    }
}

