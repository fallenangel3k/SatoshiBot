﻿using Satoshi_GUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Satoshi_GUI
{
    

    public partial class SettingsForm : Form
    {
        public GameSettings GameConfig { get; private set; }
        private bool settingDefaults = false;
        private bool LoadingDefaults = false;
        public SettingsForm()
        {
            GameConfig = new GameSettings();
            InitializeComponent();
            GameConfig.BombCount = 3;
        }
        public SettingsForm(DefaultSettings ds)
        {
            GameConfig = new GameSettings();
            InitializeComponent();
            LoadDefaultSettings(ds);
        }

        public SettingsForm(DefaultSettings ds, bool settingDef)
        {
            GameConfig = new GameSettings();
            InitializeComponent();
            LoadDefaultSettings(ds);
            if(settingDef)
            {
                settingDefaults = true;
                this.Text = "Default settings";
            }
        }

        private void LoadDefaultSettings(DefaultSettings ds)
        {
            GameConfig = new GameSettings();
            if (ds == null)
                return;
            LoadingDefaults = true;
            pHash.Text = ds.PlayerHash;
            numberofBets.Value = ds.BetAmmount;
            GameConfig.UseStrat = ds.UseStrat;
            GameConfig.ResetBetMultiplyer = ds.ResetBetMultiplyer;
            GameConfig.ResetBetMultiplyerDeadline = ds.ResetBetMultiplyerDeadline;

            useStratCheck.Checked = GameConfig.UseStrat;
            GameConfig.StratergySquares = ds.StratergySquares;
            if (GameConfig.UseStrat)
            {
                stratDisplay.Reset();
                foreach (int sv in GameConfig.StratergySquares)
                {
                    stratDisplay.SetSquare(sv, Brushes.Green);
                }
            }

            betCostNUD.Value = ds.BetCost;
            stopAfterWinCheck.Checked = ds.StopAfterWin;
            stopAfterLossCheck.Checked = ds.StopAfterLoss;
            showExWindow.Checked = ds.ShowExceptionWindow;
            precentOnLoss.Value = ds.PercentOnLoss;
            showGBombsCheck.Checked = ds.ShowGameBombs;
            saveLog.Checked = ds.SaveLogToFile;
            cfgTag.Text = ds.ConfigTag;
            stopAfterGamesChecked.Checked = ds.StopAfterGames;
            percentOnLossReset.Checked = ds.ResetBetMultiplyer;
            PercentOnLossResetGames.Value = ds.ResetBetMultiplyerDeadline;
            useProxy.Checked = ds.UseProxy;
            proxyBox.Text = ds.Proxy;
            metaChecked.Checked = ds.MetaSettings;

            nudDelay.Value = ds.GameDelay;

            BalanceStopCheck.Checked = ds.CheckBalance;
            if(ds.BalanceStopAbove == -1)
            {
                balanceStopOverChecked.Checked = false;
            }
            else
            {
                if(ds.BalanceStopAbove > balanceStopOver.Minimum && ds.BalanceStopAbove < balanceStopOver.Maximum)
                    balanceStopOver.Value = ds.BalanceStopAbove;
                balanceStopOverChecked.Checked = true;
            }
            if (ds.BalanceStopBelow == -1)
            {
                balanceStopUnderChecked.Checked = false;
            }
            else
            {
                if(ds.BalanceStopBelow > balanceStopUnder.Minimum && ds.BalanceStopBelow < balanceStopUnder.Maximum)
                    balanceStopUnder.Value = ds.BalanceStopBelow;
                balanceStopUnderChecked.Checked = true;
            }

            if (ds.StopAfterGamesAmmount < 1)
                stopAfterGamesNum.Value = 1;
            else
                stopAfterGamesNum.Value = ds.StopAfterGamesAmmount;
            stopAfterGamesNum.Enabled = stopAfterGamesChecked.Checked;

            switch (ds.BombCount)
            {
                case 1:
                    radioButton1.Checked = true;
                    break;
                case 3:
                    radioButton2.Checked = true;
                    break;
                case 5:
                    radioButton3.Checked = true;
                    break;
                case 24:
                    radioButton4.Checked = true;
                    break;
            }
            numberofBets.Enabled = !GameConfig.UseStrat;
            LoadingDefaults = false;
        }

        public DefaultSettings ToDefaultSettings()
        {
            DefaultSettings ds = new DefaultSettings();
            /*
            ds.BombCount = GameConfig.BombCount;
            ds.PlayerHash = GameConfig.PlayerHash;
            ds.BetAmmount = GameConfig.BetAmmount;
            ds.BetCost = GameConfig.BetCost;
            ds.PercentOnLoss = GameConfig.PercentOnLoss;
            ds.StopAfterWin = GameConfig.StopAfterWin;
            ds.StopAfterLoss = GameConfig.StopAfterLoss;
            ds.ShowExceptionWindow = GameConfig.ShowExceptionWindow;
            ds.StratergySquares = GameConfig.StratergySquares;
            ds.UseStrat = GameConfig.UseStrat;
            ds.ShowGameBombs = GameConfig.ShowGameBombs;
            ds.ConfigTag = GameConfig.ConfigTag;
            ds.SaveLogToFile = GameConfig.SaveLogToFile;
            ds.StopAfterGames = GameConfig.StopAfterGames;
            ds.StopAfterGamesAmmount = GameConfig.StopAfterGamesAmmount;
            ds.BalanceStopAbove = GameConfig.BalanceStopAbove;
            ds.BalanceStopBelow = GameConfig.BalanceStopBelow;
            ds.CheckBalance = BalanceStopCheck.Checked;
            ds.ResetBetMultiplyer = GameConfig.ResetBetMultiplyer;
            ds.ResetBetMultiplyerDeadline = GameConfig.ResetBetMultiplyerDeadline;
            ds.Proxy = GameConfig.Proxy;
            ds.UseProxy = GameConfig.UseProxy;
            ds.MetaSettings = GameConfig.MetaSettings;
            ds.GameDelay = GameConfig.GameDelay;
            */
            Type gType = typeof(GameSettings);
            foreach(PropertyInfo sProp in typeof(DefaultSettings).GetProperties())
            {
                PropertyInfo gProp = gType.GetProperty(sProp.Name);
                if(gProp != null)
                {
                    sProp.SetValue(ds, gProp.GetValue(GameConfig));
                }
            }
            return ds;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            GameConfig.BombCount = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            GameConfig.BombCount = 3;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            GameConfig.BombCount = 5;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            GameConfig.BombCount = 24;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string PlayerHash = pHash.Text;

            if (PlayerHash == string.Empty && !settingDefaults)
            {
                MessageBox.Show("Please enter a hash.");
                return;
            }

            int BetAmmount = (int)numberofBets.Value;
            if (GameConfig.UseStrat)
                BetAmmount = GameConfig.StratergySquares.Length;
            GameConfig.UseProxy = useProxy.Checked;
            GameConfig.Proxy = proxyBox.Text;
            GameConfig.PlayerHash = PlayerHash;
            GameConfig.BetAmmount = BetAmmount;
            GameConfig.BetCost = betCostNUD.Value;
            GameConfig.StopAfterWin = stopAfterWinCheck.Checked;
            GameConfig.StopAfterLoss = stopAfterLossCheck.Checked;
            GameConfig.ShowExceptionWindow = showExWindow.Checked;

            GameConfig.GameDelay = (int)nudDelay.Value;

            GameConfig.ShowGameBombs = showGBombsCheck.Checked;
            GameConfig.SaveLogToFile = saveLog.Checked;
            GameConfig.ConfigTag = cfgTag.Text;
            GameConfig.StopAfterGamesAmmount = (int)stopAfterGamesNum.Value;
            GameConfig.StopAfterGames = stopAfterGamesChecked.Checked;
            GameConfig.CheckBalance = BalanceStopCheck.Checked;
            GameConfig.BalanceStopAbove = balanceStopOverChecked.Checked ? (int)balanceStopOver.Value : -1;
            GameConfig.BalanceStopBelow = balanceStopUnderChecked.Checked ? (int)balanceStopUnder.Value : -1;
            GameConfig.MetaSettings = metaChecked.Checked;
            if (GameConfig.MetaSettings)
            {
                GameConfig.PercentOnLoss = precentOnLoss.Value;
                GameConfig.ResetBetMultiplyer = percentOnLossReset.Checked;
                GameConfig.ResetBetMultiplyerDeadline = (int)PercentOnLossResetGames.Value;
            }
            else
            {
                GameConfig.PercentOnLoss = 100;
                GameConfig.ResetBetMultiplyer = false;
                GameConfig.ResetBetMultiplyerDeadline = 2;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StratergyForm sf = new StratergyForm())
            {
                sf.ShowDialog();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (useStratCheck.Checked)
            {
                if (LoadingDefaults)
                    return;
                using (StratergyForm sf = new StratergyForm())
                {
                    if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        GameConfig.StratergySquares = sf.StratergyArray;
                        GameConfig.UseStrat = GameConfig.StratergySquares != null && GameConfig.StratergySquares.Length > 0;
                        if (GameConfig.UseStrat)
                        {
                            /*
                            for (int i = 0; i < StratergySquares.Length; i++)
                            {
                                if (StratergySquares[i] == 1)
                                {
                                    stratDisplay.SetSquare(i, Brushes.Green);
                                }
                            }*/
                            foreach (int sv in GameConfig.StratergySquares)
                            {
                                stratDisplay.SetSquare(sv, Brushes.Green);
                            }
                        }
                        else
                        {
                            useStratCheck.Checked = false;
                            stratDisplay.Reset();
                        }
                    }
                    else
                    {
                        useStratCheck.Checked = false;
                        GameConfig.UseStrat = false;
                    }
                }
            }
            else
            {
                GameConfig.UseStrat = false;
                stratDisplay.Reset();
            }
            numberofBets.Enabled = !GameConfig.UseStrat;
        }

        private void precentOnLoss_ValueChanged(object sender, EventArgs e)
        {

        }

        private void stopAfterWinCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void stopAfterGamesChecked_CheckedChanged(object sender, EventArgs e)
        {
            stopAfterGamesNum.Enabled = stopAfterGamesChecked.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            balanceStopperGroup.Enabled = BalanceStopCheck.Checked;
        }

        private void balanceStopUnderChecked_CheckedChanged(object sender, EventArgs e)
        {
            balanceStopUnder.Enabled = balanceStopUnderChecked.Checked;
        }

        private void balanceStopOverChecked_CheckedChanged(object sender, EventArgs e)
        {
            balanceStopOver.Enabled = balanceStopOverChecked.Checked;
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            proxyGroup.Enabled = useProxy.Checked;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if(proxyBox.Text == string.Empty)
            {
                MessageBox.Show("Cant check an empty proxy");
                return;
            }
            try
            {
                HttpWebRequest _request = (HttpWebRequest)WebRequest.Create("https://google.com");
                _request.Proxy = new WebProxy(proxyBox.Text);
                _request.Timeout = 5000;
                HttpWebResponse _responce = (HttpWebResponse)_request.GetResponse();
                using (var s = new StreamReader(_responce.GetResponseStream()))
                {
                    var contents = s.ReadToEnd();
                }
                MessageBox.Show("Proxy responded successfully!");
            }
            catch
            {
                MessageBox.Show("Proxy did not respond after 5 seconds");
            }
        }

        private void metaChecked_CheckedChanged(object sender, EventArgs e)
        {
            metaBox.Enabled = metaChecked.Checked;
        }

        private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                using (var str = new AdvancedStratForm())
                {
                    if (str.ShowDialog() == DialogResult.OK)
                    {
                        numberofBets.Enabled = false;
                        betCostNUD.Enabled = false;
                        useStratCheck.Checked = false;
                        useStratCheck.Enabled = false;
                    }
                }
            }
            else
            {
                numberofBets.Enabled = true;
                betCostNUD.Enabled = true;
                useStratCheck.Enabled = true;
            }
        }
    }
}
