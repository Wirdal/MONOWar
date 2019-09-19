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
        private static FontManager instance = null;

        public static FontManager Instance
        {
            get
            {
                if (instance == null){
                    instance = new FontManager();
                }
                return instance;
            }
        }


        public SpriteFont MenuBold;


        public void LoadContent(ContentManager content)
        {
            MenuBold = content.Load<SpriteFont>("Fonts/MenuBold");
        }

    }
}
