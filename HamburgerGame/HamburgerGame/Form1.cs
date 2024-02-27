using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HamburgerGame {
    public partial class HamburgerGAME : Form {
        public HamburgerGAME() {
            InitializeComponent();

            KeyDown += Form1_KeyDown;
        }
        //左右キーでお皿の移動
        private void Form1_KeyDown(object vSender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Left) {
                MoveLeft();
            } else if (e.KeyCode == Keys.Right) {
                MoveRight();
            }
        }
        void MoveLeft() {
            // Plateの現在位置を取得
            Point wPt = Plate.Location;
            // 移動量を10ピクセルに設定して左に移動
            wPt.X -= 10;
            // 移動後の位置がフォームの境界内であるかをチェックし、境界内であれば更新
            if (wPt.X >= 0) {
                Plate.Location = wPt;
            }
        }
        void MoveRight() {
            // Plateの現在位置を取得
            Point wPt = Plate.Location;
            // 移動量を10ピクセルに設定して右に移動
            wPt.X += 10;
            // 移動後の位置がフォームの境界内であるかをチェックし、境界内であれば更新
            if (wPt.X + Plate.Width <= Area_Play.Width) {
                Plate.Location = wPt;
            }
        }
    }
}
