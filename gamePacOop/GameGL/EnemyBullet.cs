using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace gamePacOop.GameGL
{
    class EnemyBullet : Bullet
    {
        GameDirection direction;
        Berzerk player;

        public EnemyBullet(Berzerk player,GameDirection direction, Image image, GameCell startCell) : base(GameObjectType.ENEMY_BULLET, image)
        {
            this.player = player;
            this.direction = direction;
            this.CurrentCell = startCell;
        }
        public EnemyBullet() { }

        public override GameCell move()
        {
            if (getIsActive() == true)
            {
                GameCell currentCell = this.CurrentCell;
                GameCell nextCell = currentCell.nextCell(direction);
                GameCell nextCell2 = currentCell.nextWallCell(direction);

                this.CurrentCell = nextCell;
                GameObject previousObject = nextCell.CurrentGameObject;
                GameObject nextObject = nextCell2.CurrentGameObject;


                if (currentCell != nextCell)
                {
                    currentCell.setGameObject(Game.getBlankGameObject());

                }
                else if (currentCell == nextCell)
                {
                    if (nextObject.GameObjectType == GameObjectType.PLAYER)
                    {
                        player.decreaseHealth();

                    }

                    currentCell.setGameObject(Game.getBlankGameObject());

                    this.setIsActive(false);

                }
                return nextCell;
            }

            return null;
        }

    }
}

