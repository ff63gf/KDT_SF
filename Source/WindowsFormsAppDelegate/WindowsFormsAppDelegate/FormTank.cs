using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppDelegate
{
    public partial class FormTank : Form
    {
        delegate void Move(int value);

        #region Runner
        delegate void Runner();

        void CallRunner(Runner runner) => runner();
        void Go() => textBox_print.Text += "달려\r\n";
        void Stop() => textBox_print.Text += "멈춰\r\n";
        #endregion

        public FormTank()
        {
            InitializeComponent();

            #region Tank
            Tank tank = new Tank();

            // 동시에 실행될 메소드들 할당
            Move move;
            move = tank.Forward;
            move += tank.Backward;
            move += tank.Rotate;

            // delegate에 할당된 메소드 제거 
            move -= tank.Rotate;

            // 등록된 모든 메소드 호출
            move(20);

            textBox_print.Text = tank.result;
            #endregion

            #region Runner          
            Runner runner = new Runner(Go);

            // delegate를 메소드의 입력 값으로 전달
            CallRunner(runner); // Go 메소드 실행

            // 인스턴스 생성과 동시에 delegate 전달
            CallRunner(new Runner(Stop)); // Stop 메소드 실행
            #endregion
        }
    }
    internal class Tank
    {
        public string result { get; set; } = string.Empty;
        public void Forward(int length) => result += $"{length}만큼 전진\r\n";
        public void Backward(int length) => result += $"{length}만큼 후진\r\n";
        public void Rotate(int angle) => result += $"{angle}만큼 회전\r\n";
    }
}
