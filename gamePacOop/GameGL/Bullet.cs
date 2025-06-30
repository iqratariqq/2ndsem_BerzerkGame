using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace gamePacOop.GameGL
{
    abstract class Bullet : GameObject
    {
        protected bool isActive;
        public Bullet(GameObjectType gameObjectType, Image image) : base(GameObjectType.BULLET, image)
        {

        }
        public Bullet() { }

        public abstract GameCell move();
        public void setIsActive(bool set)
        {
            this.isActive = set;
        }
        public bool getIsActive()
        {
            return isActive;
        }
    }
}
