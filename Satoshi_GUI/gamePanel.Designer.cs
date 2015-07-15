﻿namespace Satoshi_GUI
{
    partial class gamePanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.outputLog = new System.Windows.Forms.RichTextBox();
            this.winStats = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.satoshi_grid1 = new Satoshi_GUI.Satoshi_grid();
            this.SuspendLayout();
            // 
            // outputLog
            // 
            this.outputLog.Location = new System.Drawing.Point(141, 47);
            this.outputLog.Name = "outputLog";
            this.outputLog.ReadOnly = true;
            this.outputLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.outputLog.Size = new System.Drawing.Size(307, 85);
            this.outputLog.TabIndex = 13;
            this.outputLog.Text = "";
            // 
            // winStats
            // 
            this.winStats.AutoSize = true;
            this.winStats.Location = new System.Drawing.Point(208, 31);
            this.winStats.Name = "winStats";
            this.winStats.Size = new System.Drawing.Size(118, 13);
            this.winStats.TabIndex = 12;
            this.winStats.Text = "0% | Wins: 0 | Losses: 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Win %:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(141, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(307, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // satoshi_grid1
            // 
            this.satoshi_grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.satoshi_grid1.Location = new System.Drawing.Point(0, 0);
            this.satoshi_grid1.Name = "satoshi_grid1";
            this.satoshi_grid1.Size = new System.Drawing.Size(132, 132);
            this.satoshi_grid1.TabIndex = 9;
            // 
            // gamePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.outputLog);
            this.Controls.Add(this.winStats);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.satoshi_grid1);
            this.Name = "gamePanel";
            this.Size = new System.Drawing.Size(457, 139);
            this.Load += new System.EventHandler(this.gamePanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox outputLog;
        private System.Windows.Forms.Label winStats;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private Satoshi_grid satoshi_grid1;
    }
}
