using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace gamePacOop.GameGL
{
    class PlayerBullet:Bullet
    {
        GameDirection direction;
        private List<Enemy> enemies;
        Berzerk berzerk;
        public PlayerBullet(Berzerk berzerk, List<Enemy> enemies, GameDirection direction, Image image, GameCell startCell) : base(GameObjectType.PLAYER_BULLET, image)
        {
            this.direction = direction;
            this.CurrentCell = startCell;
            this.enemies = enemies;
            this.berzerk = berzerk;
        }
        public PlayerBullet()
        {
        }

        //bullet movement...
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
                    if (nextObject.GameObjectType == GameObjectType.ENEMY)
                    {
                        foreach (Enemy enemy in enemies)
                        {
                            GameCell next = enemy.CurrentCell.nextWallCell(enemy.getDirection());
                            GameObject obj = next.CurrentGameObject;

                            if (obj.GameObjectType == GameObjectType.BULLET)
                            {
                                  enemy.decreaseHealth();
                                berzerk.IncreaseScore();
                                
                            }
                        }
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
