using System.Drawing;
using System.Windows.Forms;

namespace HamburgerGame {
    //皿クラス
    public class Plate {
        /// <summary>
        /// 皿の移動速度
        /// </summary>
        private const int C_PlateSpeed = 10;
        /// <summary>
        /// 皿のPictureBox
        /// </summary>
        public PictureBox PlatePictureBox { get; private set; }

        /// <summary>
        /// 皿のコンストラクタ
        /// </summary>
        /// <param name="vPlatePictureBox">皿のPictureBox</param>
        public Plate(PictureBox vPlatePictureBox) {
            PlatePictureBox = vPlatePictureBox;
        }

        /// <summary>
        /// 皿の移動処理のメソッド
        /// </summary>
        public void MovePlate(Keys key, int vAreaWidth) {
            // 皿の現在位置を取得
            Point wLocation = PlatePictureBox.Location;

            // 左右のキー入力に基づいて皿を移動させる
            if (key == Keys.Left) {
                wLocation.X -= C_PlateSpeed;
            } else if (key == Keys.Right) {
                wLocation.X += C_PlateSpeed;
            }

            // 移動後の位置がエリアの境界内であるかをチェックし、境界内であれば更新
            if (wLocation.X >= 0 && wLocation.X + PlatePictureBox.Width <= vAreaWidth) {
                PlatePictureBox.Location = wLocation;
            }
        }
    }
}
