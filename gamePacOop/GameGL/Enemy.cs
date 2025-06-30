using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace gamePacOop.GameGL
{
    abstract class Enemy : GameObject
    {
        protected ProgressBar enemyBar = new ProgressBar();
        protected int health;
        Form1 form;
        bool isActive;
      protected  Berzerk berzerk;
        protected GameDirection direction;
        protected int bulletDelay = 1;
        public Enemy(Form1 form, int health, Berzerk berzerk, GameObjectType gameObjectType, Image image) : base(GameObjectType.ENEMY, image)
        {
            this.health = health;
            this.form = form;
           this.berzerk = berzerk;
            enemyBar = new ProgressBar();
            enemyBar.Size = new Size(30, 7);
            enemyBar.ForeColor = Color.Red;
            enemyBar.BackColor = Color.Black;
            enemyBar.Style = ProgressBarStyle.Continuous;
            isActive = true;
            form.Controls.Add(enemyBar);
        }

        public abstract GameCell move();
        public int getHealth()
        {
            return health;
        }


        public void setIsActive(bool set)
        {
            this.isActive = set;
        }
        public bool getIsActive()
        {
            return isActive;
        }

        public void decreaseHealth()
        {
            health = health - 50;
            setBarValue();

        }
        public ProgressBar getBar()
        {
            return enemyBar;
        }

        public void setBarValue()
        {
            enemyBar.Value = health;
        }

        public void setBarPosition()
        {
            int barHight = 7;
            enemyBar.Top = this.CurrentCell.X * 40-barHight;
            enemyBar.Left = this.CurrentCell.Y * 40;
        }

        //enemy bullets generat
        public void generateBullet()
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextWallCell(direction);


            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.NONE)
            {
                if (berzerk.CurrentCell.X == this.CurrentCell.X)
                {

                    if (bulletDelay % 2 == 0)
                    {
                        EnemyBullet b = new EnemyBullet();
                        Image bullet = GameGL.Game.getGameObjectImage('f');
                        GameCell startBullet = new GameCell();
                        startBullet = this.CurrentCell.nextCell(GameDirection.Left);
                        b = new EnemyBullet(berzerk, GameDirection.Left, bullet, startBullet);
                        b.setIsActive(true);
                        Game.bulletsToRemove.Add(b);
                    }
                    bulletDelay++;
                }
                else
                {
                    bulletDelay = 1;
                }
            }


        }

        public GameDirection getDirection()
        {
            return direction;
        }


    }
}
