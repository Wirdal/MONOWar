using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MONOWar
{
    class InGame : GameState
    {
        private int scrollvalue;
        private MouseState prevState;
        // Might make game states static, who knows. Might be too much work, though
        public InGame(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            graphicsDevice.Clear(Color.Aquamarine);
            scrollvalue = Mouse.GetState().ScrollWheelValue;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.Aquamarine); //  The background image placeholder
            MapManager.Instance.DrawMap(spriteBatch);
            UnitManager.Instance.DrawUnits(spriteBatch);
            // uiManager.Draw
        }

        public override void Initialize()
        {
            // Buttons will need to communicate with the map name, in the map manager
            MapManager.Instance.CreateMap(MapSelect.SelectedMap);
            // Starting a new map, so we probably should clear this thing out.
            UnitManager.Instance.ClearUnits();
            // UnitManager.Instance.CreateUnit(UnitType.Infantry, 0, 0, UnitColor.Red);
        }

        public override void LoadContent(ContentManager content)
        {
        }

        public override void UnloadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
            // Handle controls.
            HandleControls();
            //Update the map
            MapManager.Instance.Update(gameTime);
            // Update the units
            UnitManager.Instance.Update(gameTime);

        }
        private void HandleControls()
        {
            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();
            // Map camera movement;
            // Might need more
            if (keyboard.IsKeyDown(Keys.Up))
            {
                MapManager.Instance.cameraY--;
            }
            if (keyboard.IsKeyDown(Keys.Down))
            {
                MapManager.Instance.cameraY++;
            }
            if (keyboard.IsKeyDown(Keys.Right))
            {
                MapManager.Instance.cameraX++;
            }
            if (keyboard.IsKeyDown(Keys.Left))
            {
                MapManager.Instance.cameraX--;
            }
            // Click handling
            if ((mouse.LeftButton == ButtonState.Pressed) && (prevState.LeftButton == ButtonState.Released))
            {
                System.Diagnostics.Debug.WriteLine("Handling clicking");
                Tile clickedtile = MapManager.Instance.FindClickedTile(mouse);
                if(clickedtile != null)
                {
                    System.Diagnostics.Debug.WriteLine("Xpos {0} Ypos {1}", clickedtile.colplace, clickedtile.rowplace);
                }
            }
            if (mouse.ScrollWheelValue > scrollvalue)
            {
                MapManager.Instance.zoomLevel++;
            }
            else if (mouse.ScrollWheelValue < scrollvalue)
            {
                MapManager.Instance.zoomLevel--;
            }

            scrollvalue = mouse.ScrollWheelValue;
            prevState = mouse;
        }
    }
}
