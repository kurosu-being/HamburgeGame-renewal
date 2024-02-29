using System;
using System.Drawing;
using System.Windows.Forms;

namespace HamburgerGame {
    public class Plate {
        /// <summary>
        /// 皿の移動速度
        /// </summary>
        private const int C_PlateSpeed = 10;
        /// <summary>
        /// 皿のPictureBox
        /// </summary>
        private PictureBox FPlatePictureBox;

        // コンストラクタ
        public Plate(PictureBox vPlatePictureBox) {
            FPlatePictureBox = vPlatePictureBox;
        }

        // 皿の移動処理
        public void MovePlate(Keys key, int areaWidth) {
            // 皿の現在位置を取得
            Point wLocation = FPlatePictureBox.Location;

            // 左右のキー入力に基づいて皿を移動させる
            if (key == Keys.Left) {
                wLocation.X -= C_PlateSpeed;
            } else if (key == Keys.Right) {
                wLocation.X += C_PlateSpeed;
            }

            // 移動後の位置がエリアの境界内であるかをチェックし、境界内であれば更新
            if (wLocation.X >= 0 && wLocation.X + FPlatePictureBox.Width <= areaWidth) {
                FPlatePictureBox.Location = wLocation;
            }
        }
    }
}
