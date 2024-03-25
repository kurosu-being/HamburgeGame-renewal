﻿using System;
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
            this.KeyPreview = true;
            // フォームのKeyDownイベントにイベントハンドラを関連付ける
            this.KeyDown += HamburgerGAME_KeyDown;
        }

        /// <summary>
        /// ゲームを初期化し、ゲームロジックを設定するメソッド
        /// </summary>
        private void InitializeGame() {
            FGameLogic = new GameLogic(FAreaPlay, FAreaDisplay, FPlate, this, FBunUnder);
            FGameLogic.InitializeGameScreen();
        }

        /// <summary>
        /// キー入力を受け取り、皿を移動させる
        /// </summary>
        private void HamburgerGAME_KeyDown(object sender, KeyEventArgs e) {
            FGameLogic.ProcessKeyPress(e.KeyCode, FAreaPlay.Width);
        }

        private void HamburgerGAME_FormClosing(object sender, FormClosingEventArgs e) {
            //ゲームタイマーを止め、タイマーを破棄
            FGameLogic.StopTimer();

            var wMainMenuForm = Application.OpenForms["MainMenuForm"];

            if (wMainMenuForm is MainMenuForm){
                wMainMenuForm.Show();
            } else {
                throw new Exception("メインメニューフォームが見つかりませんでした。フォーム名を確認してください。");
            }
        }
    }
}
