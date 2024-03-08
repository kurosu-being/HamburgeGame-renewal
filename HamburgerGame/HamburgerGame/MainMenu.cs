﻿using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace HamburgerGame {
    public partial class MainMenu : Form {
        /// <summary>
        /// MainMenuFormクラスのコンストラクタ
        /// </summary>
        public MainMenu() {
            InitializeComponent();
        }
        /// <summary>
        /// ラベルがクリックされたときのイベントハンドラ
        /// </summary>
        /// <param name="vSender">イベントの発生源</param>
        /// <param name="e">イベント データを格納している EventArgs</param>
        private void Label_Click(object vSender, EventArgs e) {
            // ゲーム画面のインスタンスを作成
            var wForm1 = new HamburgerGAME();
            // ゲーム画面を表示
            wForm1.Show();

            // 入店時の効果音を追加する
            var wPlayer = new SoundPlayer(Properties.Resources.instore);
            wPlayer.Play();

            // メイン画面を非表示にする
            this.Hide();
        }
        /// <summary>
        /// MainMenuFormがロードされたときのイベントハンドラ
        /// </summary>
        /// <param name="vSender">イベントの発生源</param>
        /// <param name="e">イベント データを格納している EventArgs</param>
        private void MainMenu_Load(object vSender, EventArgs e) {
            // ラベルがピクチャーボックスの子コントロールになるように設定  
            this.pictureBox1.Controls.Add(this.Label);
            // ラベルを透明色に設定  
            this.Label.BackColor = Color.Transparent;

            // ラベルがピクチャーボックスの中央に来るように設定
            this.Label.Top = (this.pictureBox1.Height - this.Label.Height);
            this.Label.Left = (this.pictureBox1.Width - this.Label.Width) / 2;
        }
    }
}
