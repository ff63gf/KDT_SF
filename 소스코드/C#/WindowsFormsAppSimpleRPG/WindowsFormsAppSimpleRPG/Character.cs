using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG_Game
{
    internal class PlayerControl
    {
        public PlayerControl() { }
    }

    internal class Character
    {
        // 1024byte
        protected int hp;
        protected int power;
        public const int target_id = 112;

        public Character(int hp, int power)
        {
            this.hp = hp;
            this.power = power;
        }

        public int Attack()
        {
            return this.power;
        }

        public void Damaged(int damage)
        {
            this.hp -= damage;

            if (this.hp < 0) { this.hp = 0; }
        }
    }

    internal class Player : Character
    {
        PlayerControl playerControl;

        public Player(int hp, int power) : base(hp, power) { }

        public void ButtonInput() { }
        public void Talk() { }

        public void LevelUp(int hp) 
        { 
            this.hp = hp; 
        }

        public void LevelUp(int hp, int power)
        {
            this.hp = hp;
            this.power = power;
        }
    }

    internal class NPC : Character
    {
        string name;

        public NPC(int hp, int power) : base(hp, power) { }

        public void Script() { }
    }
}
