﻿namespace HamburgerGame {
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
            this.Plate = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Area_Play)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Area_Display)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Plate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // Plate
            // 
            this.Plate.Location = new System.Drawing.Point(293, 499);
            this.Plate.Name = "Plate";
            this.Plate.Size = new System.Drawing.Size(100, 40);
            this.Plate.TabIndex = 2;
            this.Plate.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(775, 452);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // HamburgerGAME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Plate);
            this.Controls.Add(this.Area_Display);
            this.Controls.Add(this.Area_Play);
            this.Name = "HamburgerGAME";
            this.Text = "ハンバーガーゲーム";
            ((System.ComponentModel.ISupportInitialize)(this.Area_Play)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Area_Display)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Plate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Area_Play;
        private System.Windows.Forms.PictureBox Area_Display;
        private System.Windows.Forms.PictureBox Plate;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

