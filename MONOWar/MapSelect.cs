using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MONOWar
{
    class MapSelect : GameState
    {
        Texture2D backdrop;
        public static string SelectedMap = null;

        List<string> maps = new List<string>();
        List<Button> buttons = new List<Button>();

        Texture2D MapButtonTexture;
        Texture2D SelectButtonTexture;
        public MapSelect(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Draw each button, after the overlay, obviously
            spriteBatch.Begin();
            spriteBatch.Draw(backdrop, new Rectangle(0, 0, graphicsDevice.PresentationParameters.BackBufferWidth, graphicsDevice.PresentationParameters.BackBufferHeight), Color.White);
            spriteBatch.End();
            foreach (Button button in buttons)
            {
                button.Draw(spriteBatch);
            }
        }

        public override void Initialize()
        {
            // Read all the maps from the Maps folder, and put them into a list
            string[] Maps = Directory.GetFiles("../../../../Maps/");
            foreach (string map in Maps){
                string tempmap;

                tempmap = map.Substring(17, map.Length - 21);
                maps.Add(tempmap);
                System.Diagnostics.Debug.WriteLine(tempmap);
            }
            // To figure out where to place them on the Y axis
            int i = 0;
            foreach (string map in maps)
            {
                Button newbutton = new MapNameButton(GameStateManager.Instance.GameInstance, 52, 30 * i + 30, map);
                buttons.Add(newbutton);
                i++;
            }
            // Create the select button
            buttons.Add(new MapSelectButton(GameStateManager.Instance.GameInstance, 655, 415));

        }

        public override void LoadContent(ContentManager content)
        {
            backdrop = content.Load<Texture2D>("Backdrops/MapSelect");
            // Load the start button texture
        }

        public override void UnloadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Button button in buttons)
            {
                button.Update(gameTime);
            }
            // Find out if the button is being highlighted
        }
    }
}
