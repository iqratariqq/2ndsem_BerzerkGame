using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace gamePacOop.GameGL
{
    class Game
    {
        public static GameGrid grid;
        public static Berzerk berzerk;

        public static List<Bullet> bulletsToRemove = new List<Bullet>();
        public static List<Enemy> ghosts = new List<Enemy>();
        public static List<EnemyBullet> enemyBullets = new List<EnemyBullet>();


        public static GameObject getBlankGameObject()
        {
            GameObject blankGameObject = new GameObject(GameObjectType.NONE, null);
            return blankGameObject;
        }


        public static Image getGameObjectImage(char displayCharacter)
        {
            Image img = null;
            if (displayCharacter == '|' || displayCharacter == '%')
            {
                img = gamePacOop.Properties.Resources.wal;
            }

            if (displayCharacter == '#')
            {
                img = gamePacOop.Properties.Resources.verticalWall;
            }

            if (displayCharacter == 'P' || displayCharacter == 'p')
            {
                img = gamePacOop.Properties.Resources.player;
            }
            if (displayCharacter == 'H' || displayCharacter == 'h')
            {
                img = gamePacOop.Properties.Resources.horiEnemy;
            }
            if (displayCharacter == 'V' || displayCharacter == 'v')
            {
                img = gamePacOop.Properties.Resources.verticalEnemy;
            }

            if (displayCharacter == 'S' || displayCharacter == 's')
            {
                img = gamePacOop.Properties.Resources.pl;
            }

            if (displayCharacter == 'R' || displayCharacter == 'r')
            {
                img = gamePacOop.Properties.Resources.enemy3;
            }
           
            if (displayCharacter == 'F' || displayCharacter == 'f')
            {
                img = gamePacOop.Properties.Resources.fire;
            }


            return img;
        }
    }
}
