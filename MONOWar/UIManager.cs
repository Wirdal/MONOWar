using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MONOWar
{
    class UIManager
    {
        private static UIManager PrivateInstance = null;

        public static UIManager publicInstance
        {
            get
            {
                if (PrivateInstance == null)
                {
                    PrivateInstance = new UIManager();
                }
                return PrivateInstance;
            }
        }
        public void DrawUI(SpriteBatch spriteBatch)
        {
            // Draw that UI baby
        }
        public void Update(GameTime gameTime)
        {

        }

    }
}
