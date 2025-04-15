using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG_Game
{
    internal class Monster
    {
        // 1024byte
        protected int hp;
        protected int power;
        public const int target_id = 111;

        public Monster(int hp, int power)
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

        #region virtual
        public virtual void Talk()
        {
            MessageBox.Show("나는야 몬-스-터");
        }
        #endregion
    }

    internal class Orc : Monster
    {
        string name;

        public Orc(int hp, int power) : base(hp, power) { }

        public int Bash() { return this.power + 5; }

        #region override
        public override void Talk()
        {
            MessageBox.Show("나는 멋진 미남 오크");
        }
        #endregion
    }

    internal class Slime : Monster
    {
        string name;

        public Slime(int hp, int power) : base(hp, power) { }

        public int Heal() { return this.hp + 5; }

        #region override
        public override void Talk()
        {
            MessageBox.Show("(슬라임은 말을 못해요)");
        }
        #endregion
    }
}
