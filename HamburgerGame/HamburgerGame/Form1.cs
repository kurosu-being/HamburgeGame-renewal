﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HamburgerGame {
    public partial class HamburgerGAME : Form {
        private GameLogic FGameLogic;


        public HamburgerGAME() {
            InitializeComponent();
            InitializeGame();

        }
        private void InitializeGame() {
            FGameLogic = new GameLogic(Area_Play);
            FGameLogic.AreaPlay_Load(null);
        }

        private void pictureBox1_Click(object sender, EventArgs e) {

        }

        private void HamburgerGAME_Load_1(object sender, EventArgs e) {           
        }
    }
}