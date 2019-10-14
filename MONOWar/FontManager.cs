using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MONOWar
{
    // Lmfao this is the 4th "manager" I have added
    class FontManager
    {
        private static FontManager PrivateInstance = null;

        public static FontManager publicInstance
        {
            get
            {
                if (PrivateInstance == null){
                    PrivateInstance = new FontManager();
                }
                return PrivateInstance;
            }
        }


        public SpriteFont menuBold;


        public void LoadContent(ContentManager content)
        {
            menuBold = content.Load<SpriteFont>("Fonts/MenuBold");
        }

    }
}
