using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace gamePacOop.GameGL
{
    class Berzerk : GameObject
    {
        private int lives;
        ProgressBar deathBar;
        Form1 form;
        int score = 0;
        public Berzerk(Form1 form,int score, int lives, Image image, GameCell startCell) : base(GameObjectType.PLAYER, image)
        {
            this.lives = lives;
            this.score = score;
            this.CurrentCell = startCell;
            this.form = form;
            deathBar = new ProgressBar();

            deathBar = new ProgressBar();
            deathBar.Size = new Size(30, 7);
            deathBar.Location = new Point(8, 10);
            deathBar.ForeColor = Color.Green;
            deathBar.BackColor = Color.Black;
            deathBar.Style = ProgressBarStyle.Continuous;
            form.Controls.Add(deathBar);
        }

        public int Lives { get => lives; set => lives = value; }

        public int getLives()
        {
            return lives;
        }

        public void increaseHealth()
        {
            lives += 5;
            if (lives > 100)
                lives = 100;
            setBarValue();
        }

        public void decreaseHealth()
        {
            lives -= 5;
            if (lives < 0)
                lives = 0;
            setBarValue();
        }


        public void IncreaseScore()
        {

            score = score + 1;
        }
        public int getScore()
        {
            return score;
        }

        public GameCell move(GameDirection direction)
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction);
            this.CurrentCell = nextCell;
            if (currentCell != nextCell)
            {
                currentCell.setGameObject(Game.getBlankGameObject());

            }
            setBarPosition();
            return nextCell;
        }

        public ProgressBar getBar()
        {
            return deathBar;
        }

        public void setBarValue()
        {
            deathBar.Value = lives;
        }

            public void setBarPosition()
            {
                // Place the progress bar above the player's head
                int barHeight = 7; // Adjust this value to set the height of the progress bar
                deathBar.Top = this.CurrentCell.X * 40 - barHeight;
                deathBar.Left = this.CurrentCell.Y * 40;
            }

        public void generateBullet()
        {
            PlayerBullet b = new PlayerBullet();
            Image bullet = GameGL.Game.getGameObjectImage('f');
            GameCell startBullet = new GameCell();
                GameCell next = this.CurrentCell.nextWallCell(GameDirection.Right);
                if (next.CurrentGameObject.GameObjectType == GameObjectType.NONE)
                {
                    startBullet = this.CurrentCell.nextCell(GameDirection.Right);
                    b = new PlayerBullet(this,Game.ghosts, GameDirection.Right, bullet, startBullet);
                    b.setIsActive(true);
                    Game.bulletsToRemove.Add(b);
                }
        }

    }
}