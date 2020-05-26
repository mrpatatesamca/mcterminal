﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mCTerminal
{
    public partial class eksikdosyaForm : Form
    {
        static string programyolu = System.AppDomain.CurrentDomain.BaseDirectory;

        public eksikdosyaForm()
        {
            InitializeComponent();
        }

        private void eksikdosyaForm_Load(object sender, EventArgs e)
        {
            dosyabilgiTextBox2.Text = "";
        }

        private void tamamButon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void eksikdosyaindirButon_Click(object sender, EventArgs e)
        {
            //yeni sürümü varsa güncelleme aracının yeni sürümünü başlat.
            try
            {
                if (File.Exists("mCTerminal-updater2.exe"))
                {
                    Process.Start(programyolu + @"\mCTerminal-updater2.exe");
                    File.Delete("mCTerminal-updater.exe");
                }
                else
                {
                    Process.Start(programyolu + @"\mCTerminal-updater.exe");
                }
                this.Close();
            }
            catch
            {
                MessageBox.Show("Güncelleme aracı başlatılamadı! Lütfen dosyaların konumunu kontrol edin.", "Program başlatılamadı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            //----------Gerekli dosyaları kontrol et----------------------
            if (File.Exists("AForge.dll"))
            {
                dosyabilgiTextBox2.AppendText("TAMAM" + Environment.NewLine);
            }
            else
            {
                dosyabilgiTextBox2.AppendText("EKSİK" + Environment.NewLine);
            }
            //----------
            if (File.Exists("AForge.Video.DirectShow.dll"))
            {
                dosyabilgiTextBox2.AppendText("TAMAM" + Environment.NewLine);
            }
            else
            {
                dosyabilgiTextBox2.AppendText("EKSİK" + Environment.NewLine);
            }
            //----------
            if (File.Exists("AForge.Video.dll"))
            {
                dosyabilgiTextBox2.AppendText("TAMAM" + Environment.NewLine);
            }
            else
            {
                dosyabilgiTextBox2.AppendText("EKSİK" + Environment.NewLine);
            }
            //----------
            if (File.Exists("GMap.NET.Core.dll"))
            {
                dosyabilgiTextBox2.AppendText("TAMAM" + Environment.NewLine);
            }
            else
            {
                dosyabilgiTextBox2.AppendText("EKSİK" + Environment.NewLine);
            }
            //----------
            if (File.Exists("GMap.NET.WindowsForms.dll"))
            {
                dosyabilgiTextBox2.AppendText("TAMAM" + Environment.NewLine);
            }
            else
            {
                dosyabilgiTextBox2.AppendText("EKSİK" + Environment.NewLine);
            }
            //----------
            if (File.Exists("DotNetZip.dll"))
            {
                dosyabilgiTextBox2.AppendText("TAMAM" + Environment.NewLine);
            }
            else
            {
                dosyabilgiTextBox2.AppendText("EKSİK" + Environment.NewLine);
            }
            //----------
            if (File.Exists("mCTerminal-updater.exe") || File.Exists("mCTerminal-updater2.exe"))
            {
                dosyabilgiTextBox2.AppendText("TAMAM" + Environment.NewLine);
            }
            else
            {
                dosyabilgiTextBox2.AppendText("EKSİK" + Environment.NewLine);
            }
            //----------
            if (Directory.Exists("logs"))
            {
                dosyabilgiTextBox2.AppendText("TAMAM" + Environment.NewLine);
            }
            else
            {
                dosyabilgiTextBox2.AppendText("EKSİK" + Environment.NewLine);
            }
            //------------
            if (File.Exists(programyolu + @"\res\settings.xml"))
            {
                dosyabilgiTextBox2.AppendText("TAMAM" + Environment.NewLine);
            }
            else
            {
                dosyabilgiTextBox2.AppendText("EKSİK" + Environment.NewLine);
            }
            //-----------Gerekli dosyaları kontrol et sonu---------------

            if (dosyabilgiTextBox2.Text.Contains("EKSİK"))
            {
                durumLabel.Text = "Eksik dosyalar tespit edildi!";
                durumLabel.ForeColor = Color.Red;
                MessageBox.Show("Dikkat! Eksik dosyalar tespit edildi! Programın ve programın özelliklerinin düzgün çalışabilmesi için bu dosyalara gerek vardır, \"Eksik Dosyaları İndir\" butonuna basarak bu dosyaları indirebilirsiniz! (mCTerminal Güncelleyici Programına yönlendirileceksiniz, program için güncelleme var ise güncellemeyi yaparak eksik dosyaları indirebilirsiniz eğer güncelleme yok ise \"İndirmeye Zorla\" butonuna basarak indirmeye başlayabilirsiniz!)", "Eksik dosyalar bulundu!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                durumLabel.Text = "Bütün dosyalar program dizininde bulunuyor!";
                durumLabel.ForeColor = Color.Lime;
            }
        }
    }
}
