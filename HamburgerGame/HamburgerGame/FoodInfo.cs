using System.Drawing;

namespace HamburgerGame {
    /// <summary>
    /// 具材の持つ情報（属性）を表すクラス
    /// </summary>
    public class FoodInfo {
        /// <summary>
        /// 具材の名前
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// 具材の画像
        /// </summary>
        public Image Image { get; }

        /// <summary>
        /// 具材の情報のコンストラクタ
        /// </summary>
        /// <param name="vName">具材の名前</param>
        /// <param name="vImage">具材のImage画像</param>
        public FoodInfo(string vName, Image vImage) {
            this.Name = vName;
            this.Image = vImage;
        }
    }
}
