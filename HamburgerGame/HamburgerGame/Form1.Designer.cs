namespace HamburgerGame {
    partial class HamburgerGAME {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.Area_Play = new System.Windows.Forms.PictureBox();
            this.Area_Display = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Area_Play)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Area_Display)).BeginInit();
            this.SuspendLayout();
            // 
            // Area_Play
            // 
            this.Area_Play.Location = new System.Drawing.Point(-3, 1);
            this.Area_Play.Name = "Area_Play";
            this.Area_Play.Size = new System.Drawing.Size(700, 560);
            this.Area_Play.TabIndex = 0;
            this.Area_Play.TabStop = false;
            // 
            // Area_Display
            // 
            this.Area_Display.BackColor = System.Drawing.Color.Linen;
            this.Area_Display.Location = new System.Drawing.Point(700, 1);
            this.Area_Display.Name = "Area_Display";
            this.Area_Display.Size = new System.Drawing.Size(285, 560);
            this.Area_Display.TabIndex = 1;
            this.Area_Display.TabStop = false;
            // 
            // HamburgerGAME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.Area_Display);
            this.Controls.Add(this.Area_Play);
            this.Name = "HamburgerGAME";
            this.Text = "ハンバーガーゲーム";
            ((System.ComponentModel.ISupportInitialize)(this.Area_Play)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Area_Display)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Area_Play;
        private System.Windows.Forms.PictureBox Area_Display;
    }
}

