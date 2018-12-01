using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InferensiLogika
{
    public partial class Form1 : Form
    {
        double mfBrightness_Gelap, mfBrightness_Redup, mfBrightness_CukupTerang, mfBrightness_Terang,

            mfContrast_Rendah, mfContrast_Sedang, mfContrast_Tinggi,

            mfKedipMataJarang,  mfKedipMataNormal, mfKedipMataSering,

            convertTbBrightness, convertTbContrast,

            kedipMataBatas1 = 0, kedipMataBatas2, kedipMataBatas3, 
            kedipMataBatas4, kedipMataBatas5, kedipMataBatas6 = 15,

            rule1jarang, rule2Normal, rule3Sering,
            
            integralWilayah1, integralWilayah2, integralWilayah3, integralWilayah4, integralWilayah5,

            luasWilayah1, luasWilayah2, luasWilayah3, luasWilayah4, luasWilayah5,

            z;


        private void btnCheck_Click(object sender, EventArgs e)
        {
            //Cek Brightness
            cekBrightnessGelap();
            cekBrightnessRedup();
            cekBrightnessCukupTerang();
            cekBrightnessTerang();
            //Cek Contrast
            cekContrastRendah();
            cekContrastSedang();
            cekContrastTinggi();
            //Cek Rule
            rule();
            //Menghitung batas dan integralnya
            hitungBatasdanIntegral();
            //Menghitung nilai Z
            hitungNilaiZ();
            //Cek Z pada consequent
            cekZKedipMataJarang();
            cekZKedipMataNormal();
            cekZKedipMataSering();
            //mencetak
            cetak();
        }

        public Form1()
        {
            InitializeComponent();
        }

        public void cekBrightnessGelap()
        {
            convertTbBrightness = Convert.ToDouble(tbBrightness.Text);

            if (convertTbBrightness < 0 || convertTbBrightness > 25)
            {
                mfBrightness_Gelap = 0;
            }
            else if (convertTbBrightness <= 20)
            {
                mfBrightness_Gelap = 1;
            }
            else if ( convertTbBrightness > 20 && convertTbBrightness <= 25)
            {
                mfBrightness_Gelap = (25 - convertTbBrightness) / 5;
            }
        }

        public void cekBrightnessRedup()
        {
            convertTbBrightness = Convert.ToDouble(tbBrightness.Text);

            if (convertTbBrightness < 20 || convertTbBrightness > 55)
            {
                mfBrightness_Redup = 0;
            } 
            else if(convertTbBrightness >= 20 && convertTbBrightness < 25)
            {
                mfBrightness_Redup = (convertTbBrightness - 20) / 5;
            }else if (convertTbBrightness >= 25 &&  convertTbBrightness <= 50)
            {
                mfBrightness_Redup = 1;
            }else if (convertTbBrightness > 50 && convertTbBrightness <= 55)
            {
                mfBrightness_Redup = (55 - convertTbBrightness) / 5;
            }
        }

        public void cekBrightnessCukupTerang()
        {
            convertTbBrightness = Convert.ToDouble(tbBrightness.Text);

            if (convertTbBrightness < 50 || convertTbBrightness > 80)
            {
                mfBrightness_Terang = 0;
            }
            else if(convertTbBrightness >= 50 && convertTbBrightness < 55)
            {
                mfBrightness_CukupTerang = (convertTbBrightness - 50) / 5;
            }else if (convertTbBrightness >= 55 &&  convertTbBrightness <= 75)
            {
                mfBrightness_CukupTerang = 1;
            }else if (convertTbBrightness > 75 && convertTbBrightness <= 80)
            {
                mfBrightness_CukupTerang = (80 - convertTbBrightness) / 5;
            }
        }

        public void cekBrightnessTerang()
        {
            convertTbBrightness = Convert.ToDouble(tbBrightness.Text);

            if (convertTbBrightness < 75 || convertTbBrightness > 100)
            {
                mfBrightness_Terang = 0;
            }
            else if (convertTbBrightness >= 75 && convertTbBrightness < 80)
            {
                mfBrightness_Terang = (convertTbBrightness - 75) / 5;
            }
            else if (convertTbBrightness >= 80 && convertTbBrightness <= 100)
            {
                mfBrightness_Terang = 1;
            }
        }

        public void cekContrastRendah()
        {
            convertTbContrast = Convert.ToDouble(tbContrast.Text);

            if (convertTbBrightness < 0 || convertTbBrightness > 50)
            {
                mfContrast_Rendah = 0;
            }
            else if (convertTbContrast <= 30)
            {
                mfContrast_Rendah = 1;
            }
            else if (convertTbContrast > 30 && convertTbContrast <= 50)
            {
                mfContrast_Rendah = (50 - convertTbContrast) / 20;
            }
        }

        public void cekContrastSedang()
        {
            convertTbContrast = Convert.ToDouble(tbContrast.Text);

            if (convertTbContrast < 30 || convertTbContrast >50)
            {
                mfContrast_Sedang = 0;
            } 
            else if(convertTbContrast >= 30 && convertTbContrast < 50)
            {
                mfContrast_Sedang = (convertTbContrast - 30) / 20; 
            }else if (convertTbContrast == 50)
            {
                mfContrast_Sedang = 1;
            }else if (convertTbContrast > 50 && convertTbContrast <= 70)
            {
                mfContrast_Sedang = (70 - convertTbContrast) / 20;
            }
        }

        public void cekContrastTinggi()
        {
            convertTbContrast = Convert.ToDouble(tbContrast.Text);

            if (convertTbContrast < 50 || convertTbContrast > 100)
            {
                mfContrast_Tinggi = 0;
            } 
            else if(convertTbContrast >= 50 && convertTbContrast <70)
            {
                mfContrast_Tinggi = (convertTbContrast - 50) / 20;
            }else if (convertTbContrast >= 70 && convertTbContrast <= 100)
            {
                mfContrast_Tinggi = 1;
            }
        }
        
        public void rule()
        {
            rule1jarang = Math.Max((Math.Min(mfBrightness_Gelap, mfContrast_Rendah)), Math.Min(mfBrightness_Gelap,mfContrast_Sedang));
            rule1jarang = Math.Max(rule1jarang, Math.Min(mfBrightness_Gelap, mfContrast_Tinggi));

            rule2Normal = Math.Max(Math.Min(mfBrightness_Redup, mfContrast_Rendah), Math.Min(mfBrightness_Redup, mfContrast_Sedang));
            rule2Normal = Math.Max(rule2Normal, Math.Min(mfBrightness_Redup, mfContrast_Tinggi));
            rule2Normal = Math.Max(rule2Normal, Math.Min(mfBrightness_CukupTerang, mfContrast_Sedang));
            rule2Normal = Math.Max(rule2Normal, Math.Min(mfBrightness_CukupTerang, mfContrast_Rendah));
            rule2Normal = Math.Max(rule2Normal, Math.Min(mfBrightness_CukupTerang, mfContrast_Tinggi));

            rule3Sering = Math.Max(Math.Min(mfBrightness_Terang, mfContrast_Rendah), Math.Min(mfBrightness_Terang, mfContrast_Sedang));
            rule3Sering = Math.Max(rule3Sering, Math.Min(mfBrightness_Terang, mfContrast_Tinggi));
        }

        public void hitungBatasdanIntegral()
        {
            if (rule1jarang > rule2Normal)
            {
                kedipMataBatas2 = ((-3) * rule1jarang) + 7;
                kedipMataBatas3 = ((-3) * rule2Normal) + 7;

                integralWilayah1 = Math.Abs(((rule1jarang / 2 * Math.Pow(kedipMataBatas2, 2)) - (rule1jarang / 2 * Math.Pow(kedipMataBatas1, 2))));
                integralWilayah2 = Math.Abs(-((((2 * Math.Pow(kedipMataBatas3, 3)) - (21 * Math.Pow(kedipMataBatas3, 2))) / (18)) -
                                   (((2 * Math.Pow(kedipMataBatas2, 3)) - (21 * Math.Pow(kedipMataBatas2, 2))) / (18))));

                luasWilayah1 = rule1jarang * (kedipMataBatas2 - kedipMataBatas1);
                luasWilayah2 = (rule1jarang + rule2Normal) * (kedipMataBatas3 - kedipMataBatas2);
            }
            if (rule1jarang < rule2Normal)
            {
                kedipMataBatas2 = ((3) * rule1jarang) + 4;
                kedipMataBatas3 = ((3) * rule2Normal) + 4;

                integralWilayah1 = Math.Abs(((rule1jarang / 2 * Math.Pow(kedipMataBatas2, 2)) - (rule1jarang / 2 * Math.Pow(kedipMataBatas1, 2))));
                integralWilayah2 = Math.Abs(((((Math.Pow(kedipMataBatas3, 3)) - (6 * Math.Pow(kedipMataBatas3, 2))) / 9) -
                                   (((Math.Pow(kedipMataBatas2, 3)) - (6 * Math.Pow(kedipMataBatas2, 2))) / 9)));

                luasWilayah1 = rule1jarang * (kedipMataBatas2 - kedipMataBatas1);
                luasWilayah2 = (rule1jarang + rule2Normal) * (kedipMataBatas3 - kedipMataBatas2);
            }
            if(rule1jarang == 0)
            {
                kedipMataBatas2 = 0;
            }
            else
            {
                kedipMataBatas3 = 0;
            }
            if (rule2Normal > rule3Sering)
            {
                kedipMataBatas4 = ((-3) * rule2Normal) + 10;
                kedipMataBatas5 = ((-3) * rule3Sering) + 10;

                integralWilayah3 = Math.Abs(((rule2Normal / 2 * Math.Pow(kedipMataBatas4, 2)) - (rule2Normal / 2 * Math.Pow(kedipMataBatas3, 2))));
                integralWilayah4 = Math.Abs((((Math.Pow(kedipMataBatas5, 3) - (15 * Math.Pow(kedipMataBatas5, 2))) / 9) -
                                   ((Math.Pow(kedipMataBatas4, 3) - (15 * Math.Pow(kedipMataBatas4, 2))) / 9)));
                integralWilayah5 = Math.Abs(((rule3Sering / 2 * Math.Pow(kedipMataBatas6, 2)) - (rule3Sering / 2 * Math.Pow(kedipMataBatas5, 2))));

                luasWilayah3 = rule2Normal * (kedipMataBatas4 - kedipMataBatas3);
                luasWilayah4 = (rule1jarang + rule2Normal) * (kedipMataBatas5 - kedipMataBatas4);
                luasWilayah5 = rule3Sering * (kedipMataBatas6 - kedipMataBatas5);
            }
            if (rule2Normal < rule3Sering)
            {
                kedipMataBatas4 = (3 * rule2Normal) + 7;
                kedipMataBatas5 = (3 * rule3Sering) + 7;

                integralWilayah3 = Math.Abs(((rule2Normal / 2 * Math.Pow(kedipMataBatas4, 2)) - (rule2Normal / 2 * Math.Pow(kedipMataBatas3, 2))));
                integralWilayah4 = Math.Abs(((((2 * Math.Pow(kedipMataBatas5, 3)) - (21 * Math.Pow(kedipMataBatas5, 2))) / (18)) -
                                   (((2 * Math.Pow(kedipMataBatas4, 3)) - (21 * Math.Pow(kedipMataBatas4, 2))) / (18))));
                integralWilayah5 = Math.Abs(((rule2Normal / 2 * Math.Pow(kedipMataBatas6, 2)) - (rule2Normal / 2 * Math.Pow(kedipMataBatas5, 2))));

                luasWilayah3 = rule2Normal * (kedipMataBatas4 - kedipMataBatas3);
                luasWilayah4 = (rule1jarang + rule2Normal) * (kedipMataBatas5 - kedipMataBatas4);
                luasWilayah5 = rule3Sering * (kedipMataBatas6 - kedipMataBatas5);
            }
            if (rule2Normal == 0)
            {
                kedipMataBatas4 = 0;
            }
            else
            {
                kedipMataBatas5 = 0;
            }
        }

        public void hitungNilaiZ()
        {
            z = (integralWilayah1 + integralWilayah2 + integralWilayah3 + integralWilayah4 + integralWilayah5) / (luasWilayah1 + luasWilayah2 + luasWilayah3 + luasWilayah4 + luasWilayah5);
        }

        public void cekZKedipMataJarang()
        {
            if (z < 0 || z > 7 )
            {
                mfKedipMataJarang = 0;
            }else if (z <= 4)
            {
                mfKedipMataJarang = 1;
                lbPrediction.Text = "Mata Anda Akan Berkedip Jarang " + '\n' +
                                    "dengan kemungkinan " + mfKedipMataJarang;
            }
            else if (z > 4 && z <= 7)
            {
                mfKedipMataJarang = (7 - z) / 3;
                lbPrediction.Text = "Mata Anda Akan Berkedip Jarang " + '\n' +
                                    "dengan kemungkinan " + mfKedipMataJarang;
            }
        }

        public void cekZKedipMataNormal()
        {
            if (z < 4 || z > 11)
            {
                mfKedipMataNormal = 0;
            }else if (z >= 4 && z < 7)
            {
                mfKedipMataNormal = (z - 4) / 3;
                lbPrediction.Text = "Mata Anda Akan Berkedip Normal " + '\n' +
                                    "dengan kemungkinan " + mfKedipMataNormal;
            }
            else if (z == 7)
            {
                mfKedipMataNormal = 1;
                lbPrediction.Text = "Mata Anda Akan Berkedip Normal " + '\n' +
                                    "dengan kemungkinan " + mfKedipMataNormal;
            }
            else if (z > 7 && z <= 10)
            {
                mfKedipMataNormal = (10 - z) / 3;
                lbPrediction.Text = "Mata Anda Akan Berkedip Jarang " + '\n' +
                                    "dengan kemungkinan " + mfKedipMataNormal;
            }
        }

        public void cekZKedipMataSering()
        {
            if (z < 7 || z > 15)
            {
                mfKedipMataSering = 0;
            }else if (z >= 7 && z < 10)
            {
                mfKedipMataSering = (z - z) / 3;
                lbPrediction.Text = "Mata Anda Akan Berkedip Sering " + '\n' +
                                    "dengan kemungkinan " + mfKedipMataSering;
            }
            else if (z >= 10 && z <= 15)
            {
                mfKedipMataSering = 1;
                lbPrediction.Text = "Mata Anda Akan Berkedip Sering " + '\n' +
                                    "dengan kemungkinan " + mfKedipMataSering;
            }
        }

        public void cetak()
        {
            tbJarang.Text = Convert.ToString(rule1jarang);
            tbNormal.Text = Convert.ToString(rule2Normal);
            tbSering.Text= Convert.ToString(rule3Sering);

            tbBatas1.Text = Convert.ToString(kedipMataBatas2);
            tbBatas2.Text = Convert.ToString(kedipMataBatas3);
            tbBatas3.Text = Convert.ToString(kedipMataBatas4);
            tbBatas4.Text = Convert.ToString(kedipMataBatas5);

            tbIntegralWilayah1.Text = Convert.ToString(integralWilayah1);
            tbIntegralWilayah2.Text = Convert.ToString(integralWilayah2);
            tbIntegralWilayah3.Text = Convert.ToString(integralWilayah3);
            tbIntegralWilayah4.Text = Convert.ToString(integralWilayah4);
            tbIntegralWilayah5.Text = Convert.ToString(integralWilayah5);

            tbLuasWilayah1.Text = Convert.ToString(luasWilayah1);
            tbLuasWilayah2.Text = Convert.ToString(luasWilayah2);
            tbLuasWilayah3.Text = Convert.ToString(luasWilayah3);
            tbLuasWilayah4.Text = Convert.ToString(luasWilayah4);
            tbLuasWilayah5.Text = Convert.ToString(luasWilayah5);

            tbNilaiZ.Text = Convert.ToString(z);
        }
    }
}
