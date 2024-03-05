using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerGame {
      public class FoodInfo {
        /// <summary>
        /// 具材の名前
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 具材の画像
        /// </summary>
        public Image Image { get; set; }
        /// <summary>
        /// 具材の情報のコンストラクタ
        /// </summary>
        /// <param name="vName"></param>
        /// <param name="vImage"></param>
        public FoodInfo(string vName, Image vImage) {
            this.Name = vName;
            this.Image = vImage;            
        }

        /// <summary>
        /// 具材の画像と名前を管理するオブジェクトのリスト
        /// </summary>
        public static readonly List<FoodInfo> FFoodInfoList = new List<FoodInfo> {
            new FoodInfo("bun_top", Properties.Resources.bun_top),
            new FoodInfo("cheese", Properties.Resources.cheese),
            new FoodInfo("patty", Properties.Resources.patty),
            new FoodInfo("lettuce", Properties.Resources.lettuce),
            new FoodInfo("tomato", Properties.Resources.tomato)
        };
    }
}
