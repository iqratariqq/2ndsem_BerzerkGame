using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace gamePacOop.GameGL
{
    class RandomEnemy : Enemy
    {

        int randomDelay;
        int random;

        public RandomEnemy(Form1 form, int lives, Berzerk berzerk, Image image, GameCell startCell) : base(form, lives,berzerk, GameObjectType.ENEMY, image)
        {
            this.CurrentCell = startCell;
            this.berzerk = berzerk;
        }

        public override GameCell move()
        {
            manageDirections();
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction);
            GameObject previousObject = nextCell.CurrentGameObject;
            this.CurrentCell = nextCell;

            if (previousObject.GameObjectType == GameObjectType.PLAYER)
            {
                berzerk.decreaseHealth();
            }


            if (currentCell != nextCell)
            {
                currentCell.setGameObject(previousObject);
                

            }
            return nextCell;
        }

        public void manageDirections()
        {
            if (randomDelay % 5 == 0)
            {
                Random r = new Random();
                random = r.Next(4);
            }

            if (random == 0)
            {
                direction = GameDirection.Right;
            }
            else if (random == 1)
            {
                direction = GameDirection.Left;
            }
            else if (random == 2)
            {
                direction = GameDirection.Up;
            }
            else if (random == 3)
            {
                direction = GameDirection.Down;
            }
            randomDelay++;

        }
    }
}
