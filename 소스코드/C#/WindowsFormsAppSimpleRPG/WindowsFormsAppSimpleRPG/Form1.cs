using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RPG_Game;

namespace WindowsFormsAppSimpleRPG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            PlaySimpleRPG();
        }

         void PlaySimpleRPG()
        {
            Character player = new Player(100, 20);
            Character npc = new NPC(50, 10);

            // 전투
            Monster monster = new Orc(60, 10);

            // 플레이어 공격
            monster.Damaged(player.Attack());

            // 몬스터 공격
            player.Damaged(monster.Attack());
            //player.Attack(ref Monster m); // 1024byte copy delay

            // 스킬 공격
            player.Damaged(((Orc)monster).Bash());

            // 몬스터 변경
            monster = new Slime(30, 5);            
        }
    }
}
