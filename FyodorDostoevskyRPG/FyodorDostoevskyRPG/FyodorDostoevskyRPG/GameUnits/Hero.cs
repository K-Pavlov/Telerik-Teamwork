namespace FyodorDostoevskyRPG.GameUnits
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    class Hero: Unit
    {
        private int damageMin;
        private int damageMax;
     //   public static Hero Villain = new Hero("Hero", 500, 5, 20, Vector2, Texture2D);// как подавам вертора и имиджа?
        //остава Weapon да се добави
        public Hero(string name, int health, int damageMin, int damageMax, Vector2 position, Texture2D image)
        {
            this.name = name;
            this.health = health;
            this.damageMin = damageMin;
            this.damageMin = damageMax;
            this.position = position;
            this.image = image;
            this.isAlive = true;
        }
        public void Movement()
        { 
            //??
        }

        

        public int DamageMin
        {
            get 
            { 
                return damageMin; 
            }
            set 
            { 
                damageMin = value; 
            }
        }
        public int DamageMax
        {
            get
            {
                return damageMax;
            }
            set
            {
                damageMax = value;
            }
        }
        



    }
}
