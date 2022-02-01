using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CWMapEditor
{
    //Holds necessary information to generate a collidable object of defined size

    //Used to determine the picture to display and color to put on grid
    enum ObjectType
    {
        Tree,
        Boulder,
        Stump,
        Water,
        Fire,
        Blank
    }

    class CollidableObject
    {
        //Fields
        int size;
        Color color;
        ObjectType type;
        int[] location;

        //Constructor
        public CollidableObject(int cSize, ObjectType cType)
        {
            size = cSize;
            type = cType;

            //Determine color of displayed square on grid by type

            switch (type)
            {
                case ObjectType.Boulder:
                    color = Color.Gray;
                    break;
                case ObjectType.Tree:
                    color = Color.Green;
                    break;
                case ObjectType.Water:
                    color = Color.Blue;
                    break;
                case ObjectType.Fire:
                    color = Color.Red;
                    break;
                case ObjectType.Blank:
                    color = Color.Black;
                    break;
                case ObjectType.Stump:
                    color = Color.Brown;
                    break;
            }

        }

        //Properties
        public Color ObjectColor
        {
            get { return color; }
        }

        //Methods
        //ToString override to generate data to write to file
        public override string ToString()
        {
            //Return a single character corresponding to the type of object
            switch (type)
            {
                case ObjectType.Boulder:
                    return "b";
                case ObjectType.Tree:
                    return "t";
                case ObjectType.Water:
                    return "w";
                case ObjectType.Fire:
                    return "f";
                case ObjectType.Blank:
                    return "x";
                case ObjectType.Stump:
                    return "s";
                default:
                    return "x";
            }
        }
    }
}
