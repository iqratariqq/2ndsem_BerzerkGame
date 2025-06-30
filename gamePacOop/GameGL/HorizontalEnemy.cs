using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace gamePacOop.GameGL
{
    class HorizontalGhost : Enemy
    {
        GameDirection direction;
        public HorizontalGhost(Form1 form, int lives, Berzerk berzerk, GameDirection direction, Image image, GameCell startCell) : base(form,lives,berzerk,GameObjectType.ENEMY, image)
        {
            this.direction = direction;
            this.CurrentCell = startCell;
            this.berzerk = berzerk;
        }

        public override GameCell move()
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction);
            GameObject previousObject = nextCell.CurrentGameObject;
            this.CurrentCell = nextCell;

            if (currentCell == nextCell)
            {
                if (previousObject.GameObjectType == GameObjectType.PLAYER)
                {
                    berzerk.decreaseHealth();
                }
                manageDirections();
                currentCell.setGameObject(currentCell.CurrentGameObject);
               
            }

            if (currentCell != nextCell)
            {
                currentCell.setGameObject(previousObject);
                

            }
            else
            {
               
            }
            return nextCell;
        }

        public void manageDirections()
        {
            if (direction == GameDirection.Left)
            {
                direction = GameDirection.Right;
            }
            else if (direction == GameDirection.Right)
            {
                direction = GameDirection.Left;
            }
        }

    }
}
