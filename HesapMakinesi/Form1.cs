using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sayfa45_48_HesapMakinesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        decimal sayi1, sayi2, hafiza_deger;
        Boolean sonuclandı;
        string islem;

        private void arti_eksi_Click(object sender, EventArgs e)
        {
            if(txt_sayi_giris.Text.Length>0)
            {
                if(txt_sayi_giris.Text.Substring(0, 1) == "-")
                {
                    txt_sayi_giris.Text = txt_sayi_giris.Text.Substring(1);
                }
                else
                {
                    txt_sayi_giris.Text = "-" + txt_sayi_giris.Text.Substring(0);
                }
            }
        }

        private void btn_ondalikvirgul_Click(object sender, EventArgs e)
        {
            if(txt_sayi_giris.Text.IndexOf(",")<=0)
            {
                if(txt_sayi_giris.Text.Length == 0)
                {
                    txt_sayi_giris.Text = "0";
                }

                else
                {
                    txt_sayi_giris.Text = txt_sayi_giris.Text + ",";
                }
            }
        }

        private void btn_CE_Click(object sender, EventArgs e)
        {
            hafiza_deger = 0;
        }

        private void btn_C_Click(object sender, EventArgs e)
        {
            txt_sayi_giris.Text = "";
        }

        private void btn_gerial_Click(object sender, EventArgs e)
        {
            if(txt_sayi_giris.Text.Length>0)
            {
                txt_sayi_giris.Text = txt_sayi_giris.Text.Substring(0, txt_sayi_giris.Text.Length - 1);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if(txt_sayi_giris.Text.Length == 0)
            {
                txt_sayi_giris.Text = "0";
            }

            if((sender as Button).Name == "button1")
            {
                hafiza_deger = 0;
                sonuclandı = true;
            }
            if ((sender as Button).Name == "button2")
            {
                txt_sayi_giris.Text = hafiza_deger.ToString();
                sonuclandı = true;
            }
            if ((sender as Button).Name == "button3")
            {
                hafiza_deger = hafiza_deger + Convert.ToDecimal(txt_sayi_giris.Text);
                sonuclandı = true;
            }
            if ((sender as Button).Name == "button4")
            {
                hafiza_deger = hafiza_deger - Convert.ToDecimal(txt_sayi_giris.Text);
                sonuclandı = true;                 
            }
        }

        private void dort_islem(object sender, EventArgs e)
        {
            islem = (sender as Button).Name;
            if(txt_sayi_giris.Text.Length == 0)
            {
                txt_sayi_giris.Text = "0";
            }
            sayi1 = Convert.ToDecimal(txt_sayi_giris.Text);
            sonuclandı = true;
        }

        private void btn_esittir_Click(object sender, EventArgs e)
        {
            sayi2 = Convert.ToDecimal(txt_sayi_giris.Text);
            decimal islem_sonucu = 0;

            if (islem == "btn_topla")
            {
                islem_sonucu = sayi1 + sayi2;
            }
            if (islem == "btn_cikar")
            {
                islem_sonucu = sayi1 - sayi2;
            }
            if (islem == "btn_carp")
            {
                islem_sonucu = sayi1 * sayi2;
            }
            if (islem == "btn_bol")
            {
                islem_sonucu = sayi1 / sayi2;
            }

            sonuclandı = true;
            txt_sayi_giris.Text = islem_sonucu.ToString();
        }

        private void diger_islemler(object sender, EventArgs e)
        {
            if(txt_sayi_giris.Text.Length==0)
            {
                txt_sayi_giris.Text = "0";
            }

            decimal diger_islemler_sayi = Convert.ToDecimal(txt_sayi_giris.Text);
            decimal sonuc = 0;

            if (((sender as Button).Name == "btn_karekok") && diger_islemler_sayi > 0)
            {
                sonuc = Convert.ToDecimal(Math.Sqrt((double)diger_islemler_sayi));
            }
            if((sender as Button).Name == "btn_kare")
            {
                sonuc = diger_islemler_sayi * diger_islemler_sayi;
            }
            if((sender as Button).Name == "btn-birbolu")
            {
                sonuc = 1 / diger_islemler_sayi;
            }

            txt_sayi_giris.Text = sonuc.ToString();
            sonuclandı = true;
        }

        private void txt_sayi_giris_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Char.IsDigit(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (sonuclandı)
            {
                txt_sayi_giris.Text = (sender as Button).Text;
                sonuclandı = false;
            }
            else
            {
                txt_sayi_giris.Text = txt_sayi_giris.Text + (sender as Button).Text;
            }
        }
    }
}
