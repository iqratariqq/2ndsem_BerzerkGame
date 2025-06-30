using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace gamePacOop.GameGL
{
    class VerticalEnemy : Enemy
    {
        GameDirection direction;
        public VerticalEnemy(Form1 form, int lives, Berzerk berzerk, GameDirection direction, Image image, GameCell startCell) : base(form, lives, berzerk, GameObjectType.ENEMY, image)
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
            }

            if (currentCell != nextCell)
            {
                currentCell.setGameObject(previousObject);
                
            }
            return nextCell;
        }

        public void manageDirections()
        {
            if (direction == GameDirection.Up)
            {
                direction = GameDirection.Down;
            }
            else if (direction == GameDirection.Down)
            {
                direction = GameDirection.Up;
            }
        }
    }
}
