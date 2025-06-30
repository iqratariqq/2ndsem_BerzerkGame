using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;
using gamePacOop.GameGL;

namespace gamePacOop
{
    public partial class Form1 : Form
    {
        GameGrid grid;
        Berzerk berzerk;
        PlayerBullet bullet = new PlayerBullet();
        static int totalScore = 0;
        public Form1()
        {
            InitializeComponent();
        }

        //for new form when all enemy or player die
        private bool IsGameOver()
        {
            return Game.ghosts.All(enemy => enemy.getHealth() == 0) || berzerk.getLives() <= 0;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            gameLoop.Start();//when game resart.
           grid = new GameGrid("maze.txt", 18, 36);
            Image berzerkImage = GameGL.Game.getGameObjectImage('P');
            GameCell startCell = grid.getCell(8, 10);
            berzerk = new Berzerk( this,0,100,berzerkImage, startCell);


            HorizontalGhost ghostH1;
            VerticalEnemy ghostV1;
            RandomEnemy ghostR1;
            SmartEnemy ghostS1;

            Image ghostH1Img = GameGL.Game.getGameObjectImage('H');
            GameCell startH1 = grid.getCell(16,19);
            ghostH1 = new HorizontalGhost(this, 100, berzerk, GameDirection.Left, ghostH1Img, startH1);

            Image ghostV1Img = GameGL.Game.getGameObjectImage('V');
            GameCell startV1 = grid.getCell(6, 18);
            ghostV1 = new VerticalEnemy(this, 100, berzerk, GameDirection.Up, ghostV1Img, startV1);

            Image ghostR1Img = GameGL.Game.getGameObjectImage('R');
            GameCell startR1 = grid.getCell(10, 23);
            ghostR1 = new RandomEnemy(this, 100, berzerk, ghostR1Img, startR1);

            Image ghostS1Img = GameGL.Game.getGameObjectImage('S');
            GameCell startS1 = grid.getCell(10, 23);
            ghostS1 = new SmartEnemy(this, 100, berzerk,ghostS1Img, startS1);

            Game.ghosts.Add(ghostH1);
            Game.ghosts.Add(ghostV1);
            Game.ghosts.Add(ghostR1);
            Game.ghosts.Add(ghostS1);

            printMaze(grid);
        }

        void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {

                for (int y = 0; y < grid.Cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    this.Controls.Add(cell.PictureBox);
                }

            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!IsGameOver())
            {
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    berzerk.move(GameDirection.Left);
                }
                else if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    berzerk.move(GameDirection.Right);
                }
                else if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    berzerk.move(GameDirection.Up);
                }
                else if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    berzerk.move(GameDirection.Down);
                }
                else if (Keyboard.IsKeyPressed(Key.Space))
                {
                    berzerk.generateBullet();
                }

                //progress bar of player
                berzerk.setBarPosition();
                berzerk.setBarValue();
                //score
                scorelbl.Text = "Score: " + berzerk.getScore();

                //////////////////////////
                ////ENEMY MOVEMENTS
                ///////////////////////

                foreach (Enemy enemy in Game.ghosts)
                {
                    if (enemy.getIsActive() == true)
                    {
                        enemy.move();
                        enemy.generateBullet();
                        enemy.setBarPosition();
                        enemy.setBarValue();
                    }

                    if (enemy.getHealth() == 0)
                    {
                        enemy.setIsActive(false);

                        GameObject gameObj = Game.getBlankGameObject();
                        this.Controls.Remove(enemy.getBar());
                        enemy.CurrentCell.CurrentGameObject = gameObj;
                    }
                }
                for (int x = 0; x < Game.ghosts.Count; x++)
                {
                    if (Game.ghosts[x].getIsActive() == false)
                    {
                        Game.ghosts.Remove(Game.ghosts[x]);
                    }
                }
                //player bullet
                foreach (Bullet b in Game.bulletsToRemove)
                {
                    b.move();
                }
                //enemy bullet
                foreach (Bullet b in Game.enemyBullets)
                {
                    b.move();
                }

            }
            //for game overen
            else
            {
                gameLoop.Stop();
                this.Hide();
                GameOverfrm gameOverForm = new GameOverfrm(); //gameover from open
                gameOverForm.ShowDialog();
            }
        }
    }
}
