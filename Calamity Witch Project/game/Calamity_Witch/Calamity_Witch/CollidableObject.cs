using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Calamity_Witch
{
    // Sceenary objects on the map which are loaded with the extral tool
    class CollidableObject
    {
        // Fields
        private Texture2D objectTexture;
        private Rectangle objectRectangle;

        // Properties
        public int XLocation
        {
            get { return objectRectangle.X; }
            set { objectRectangle.X = value; }
        }

        public Texture2D ObjectTexture
        {
            get { return objectTexture; }
            set { objectTexture = value; }
        }

        public Rectangle ObjectRectangle
        {
            get { return objectRectangle; }
        }

        public int YLocation
        {
            get { return objectRectangle.Y; }
            set { objectRectangle.Y = value; }
        }

        // Constructor
        public CollidableObject(Texture2D objectTexture, Rectangle objectRectangle)
        {
            this.objectTexture = objectTexture;
            this.objectRectangle = objectRectangle;
        }

        // Override draw method
        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(
            objectTexture,
            objectRectangle,
            Color.White);
        }
    }
}
