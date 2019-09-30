using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MONOWar
{
    abstract class Button : GameObject
    {
        // Where the button will be placed

        public int xpos, ypos;
        // How big the button is

        public int width, height;

        protected MouseState prevMouseState;

        public Button(Game game, int xpos, int ypos) : base(game)
        {
            this.xpos = xpos;
            this.ypos = ypos;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }
        public virtual void OnClick()
        {
        }
        // Will return true if we are hovering over the 
        public virtual bool CheckForHover()
        {
            MouseState mouse = Mouse.GetState();
            if ((mouse.X > xpos) & (mouse.X < xpos + width)
               & (mouse.Y > ypos) & (mouse.Y < ypos + height))
            {
                return true;
            }
            return false;
        }
        public virtual bool CheckForHover(MouseState mouse)
        {
            if ((mouse.X > xpos) & (mouse.X < xpos + width)
               & (mouse.Y > ypos) & (mouse.Y < ypos + height))
            {
                return true;
            }
            return false;
        }
        public virtual bool CheckForClick()
        {
            if (CheckForHover())
            {
                MouseState mouse = Mouse.GetState();
                if ((mouse.LeftButton == ButtonState.Released) & (prevMouseState.LeftButton == ButtonState.Pressed))
                {
                    return true;
                }
                else
                {
                    prevMouseState = mouse;
                    return false;
                }
            }
            return false;
        }
        public virtual bool CheckForClick(MouseState mouse)
        {
            if (CheckForHover())
            {
                if ((mouse.LeftButton == ButtonState.Released) & (prevMouseState.LeftButton == ButtonState.Pressed))
                {
                    return true;
                }
                else
                {
                    prevMouseState = mouse;
                    return false;
                }
            }
            return false;
        }
    }
    class MainMenuButton : Button
    {

        private static Texture2D testTexture;
        public MainMenuButton(Game game, int xpos, int ypos) : base(game, xpos, ypos)
        {
            // These values are hardcoded, because thats the dimensions of the actual image
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();
            spriteBatch.Draw(testTexture, new Rectangle(xpos, ypos, width, height), Color.White); // Draw it as a rectangle later, so it gets bigger when update is called
            spriteBatch.End();

        }

        public override void Initialize()
        {
            width = 75;
            height = 25;
            LoadContent();
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (CheckForClick())
            {
                OnClick();
            }

            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            if (testTexture == null)
            {
                testTexture = Game.Content.Load<Texture2D>("RedBlock");
            }
            base.LoadContent();
        }
        public override void OnClick()
        {
            System.Diagnostics.Debug.WriteLine("Button clicked");

            GameStateManager.Instance.AddScreen(new MapSelect(GraphicsDevice)); // Will load the stuff we need
            base.OnClick();

        }
    }
    class MapSelectButton : Button
    {
        Color color;
        public MapSelectButton(Game game, int xpos, int ypos) : base(game, xpos, ypos)
        {
            width = 100;
            height = 36;
            color = Color.White;
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            if (CheckForHover())
            {
                color = Color.Red;
            }
            else
            {
                color = Color.White;
            }
            if (CheckForClick())
            {
                OnClick();
            }
            base.Update(gameTime);
        }
        public override void OnClick()
        {
            if (MapSelect.SelectedMap == null)
            {
                return;
            }
            GameStateManager.Instance.AddScreen(new InGame(GraphicsDevice));
            // then transition into Ingame as well;
            // Shouldn't have to deal with repeat presses if we only add the screen once, and immediatley transition
            base.OnClick();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(FontManager.Instance.MenuBold, "Select Map", new Vector2(xpos, ypos), color);
            spriteBatch.End();
        }
    }
    class MapNameButton : Button
    {
        string Mapname;
        Color color;
        public MapNameButton(Game game, int xpos, int ypos, string mapname) : base(game, xpos, ypos)
        {
            Mapname = mapname;
            // Font size of 12 is 16 pixels high
            height = 16;
            // Just make the width the whole darker box
            width = 690;
            color = Color.White;
        }
        protected override void LoadContent()
        {
            base.LoadContent();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(FontManager.Instance.MenuBold, Mapname, new Vector2(xpos, ypos), color);
            spriteBatch.End();
        }
        public override void OnClick()
        {
            MapSelect.SelectedMap = Mapname;
            base.OnClick();
        }

        public override void Update(GameTime gameTime)
        {
            if (CheckForHover())
            {
                color = Color.Red;
            }
            else
            {
                color = Color.White;
            }
            if (CheckForClick())
            {
                OnClick();
            }
            base.Update(gameTime);
        }
    }
    class TileButton : Button
    {

        public TileButton(Game game, int xpos, int ypos) : base(game, xpos, ypos)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Do nothing. We don't want to draw this.
        }
        
    }
}
