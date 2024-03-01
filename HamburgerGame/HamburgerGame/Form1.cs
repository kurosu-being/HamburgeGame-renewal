using System;
using System.Drawing;
using System.Windows.Forms;

namespace HamburgerGame {
    /// <summary>
    /// ゲームプレイのクラス
    /// </summary>
    public partial class HamburgerGAME : Form {
        /// <summary>
        ///  GameLogicクラスのインスタンス
        /// </summary>
        private GameLogic FGameLogic;

        public HamburgerGAME() {
            InitializeComponent();
            InitializeGame();

            // キー入力をフォームが優先的に受け取るようにする
            KeyPreview = true; 
            // フォームのKeyDownイベントにイベントハンドラを関連付ける
            KeyDown += HamburgerGAME_KeyDown;
        }


        /// <summary>
        /// ゲームを初期化し、ゲームロジックを設定するメソッド
        /// </summary>
        private void InitializeGame() {
            FGameLogic = new GameLogic(Area_Play, Plate, listBox1);
            FGameLogic.AreaPlay_Load(null);
        }

        /// <summary>
        /// キー入力を受け取り、皿を移動させる
        /// </summary>
        private void HamburgerGAME_KeyDown(object sender, KeyEventArgs e) {
            FGameLogic.ProcessKeyPress(e.KeyCode, Area_Play.Width);
        }

        private void HamburgerGAME_Load_1(object sender, EventArgs e) {
        }
    }
}