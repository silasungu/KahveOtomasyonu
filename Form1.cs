using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SılaSunguOOPmaraton
{
    public partial class Form1 : Form
    {
        public List<string> list_isimler = new List<string>();
        public List<string> list_soyisimler = new List<string>();
        public List<müs> müsteriler = new List<müs>();
        public List<string> kahveler = new List<string>();
        public List<int> kahveler_hazırlamahızı = new List<int>();
        public string isim_yeni;

        public bool kasa1_bosMu;
        public bool kasa2_bosMu;
        public bool kasa3_bosMu;    
        
        public bool kasa1calısan_bosMu;
        public bool kasa2calısan_bosMu;
        public bool kasa3calısan_bosMu;

        public bool Hakan_bosMu;
        public bool Sıla_bosMu;
        public bool Aysun_bosMu;
        public bool Melike_bosMu;
        public bool Onur_bosMu;



        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            list_isimler.Add("Ayşe");
            list_isimler.Add("Ali");
            list_isimler.Add("İsmail");
            list_isimler.Add("Hakan");
            list_isimler.Add("Furkan");
            list_isimler.Add("Zeynep");
            list_isimler.Add("Fırat");
            list_isimler.Add("Gülşen");
            list_isimler.Add("Murat");
            list_isimler.Add("Neşe");
            list_isimler.Add("Beyza");
            list_isimler.Add("Duygu");
            list_isimler.Add("Can");
            list_isimler.Add("Derya");
            list_isimler.Add("Yakup");

            list_soyisimler.Add(" ALKAN");
            list_soyisimler.Add(" YILMAZ");
            list_soyisimler.Add(" TOPÇU");
            list_soyisimler.Add(" ÖZTÜRK");
            list_soyisimler.Add(" BARAN");
            list_soyisimler.Add(" DİŞLİ");
            list_soyisimler.Add(" YILDIRIM");
            list_soyisimler.Add(" AKSOY");
            list_soyisimler.Add(" BOZKURT");
            list_soyisimler.Add(" KILIÇ");
            list_soyisimler.Add(" KOÇ");
            list_soyisimler.Add(" ÇELİK");
            list_soyisimler.Add(" ÇETİN");

            kahveler.Add("Caffé Latte");
            kahveler.Add("cappuccino");
            kahveler.Add("Latte Macchiato");
            kahveler.Add("Caffé Americano");
            kahveler.Add("Flat White");
            kahveler.Add("Chai Tea Latte");
            kahveler.Add("Iced Cappuccino");
            kahveler.Add("Frappuccino");
            kahveler.Add("Caffé Mocha");

            kahveler_hazırlamahızı.Add(1);
            kahveler_hazırlamahızı.Add(2);
            kahveler_hazırlamahızı.Add(4);
            kahveler_hazırlamahızı.Add(4);
            kahveler_hazırlamahızı.Add(2);
            kahveler_hazırlamahızı.Add(1);
            kahveler_hazırlamahızı.Add(5);
            kahveler_hazırlamahızı.Add(5);
            kahveler_hazırlamahızı.Add(2);



            kasa1_bosMu = true; 
            kasa2_bosMu = true; 
            kasa3_bosMu = true;

            kasa1calısan_bosMu = false ;
            kasa2calısan_bosMu = false;
            kasa3calısan_bosMu = false;



            Hakan_bosMu = true;
            Sıla_bosMu = true;
            Aysun_bosMu = true;
            Melike_bosMu = true;
            Onur_bosMu = true;


    }

        private void timer1_sure_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            isim_yeni = list_isimler[rnd.Next(list_isimler.Count)];
            isim_yeni += list_soyisimler[rnd.Next(list_soyisimler.Count)];

            müsteriler.Add(new müs(isim_yeni, 0, "bos",0,1));


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1_sure.Enabled = true;
            timer1_yonetim.Enabled = true;
            timer1_calısanlar.Enabled = true;

            rb_kalabalık.Enabled = false;
            rb_normal.Enabled = false;
            rb_tenha.Enabled = false;

            if (cb_kasa1.Checked)
            {
                kasa1calısan_bosMu = true;
                cb_kasa1.Enabled = false;
            }

            if (cb_kasa2.Checked)
            {
                kasa2calısan_bosMu = true;
                cb_kasa2.Enabled = false;
            }

            if (cb_kasa3.Checked)
            {
                kasa3calısan_bosMu = true;
                cb_kasa3.Enabled = false;
            }


            if (rb_tenha.Checked)
            {
                timer1_sure.Interval = 8000;
            }
            else if (rb_normal.Checked)
            {
                timer1_sure.Interval = 5000;
            }
            else if (rb_kalabalık.Checked)
            {
                timer1_sure.Interval = 3000;
            }
        }

        private void timer1_yonetim_Tick(object sender, EventArgs e)
        {
            rtb_kasa1.Text = "";
            rtb_kasa2.Text = "";
            rtb_kasa3.Text = "";
            rtb_beklenen.Text = "";

            for (int i = 0; i < müsteriler.Count; i++)
            {

                if (müsteriler[i].asama == 0) // müşteri rastgele sıraya girer aşama 0-1
                {
                    Random rnd = new Random();
                    int kasa = rnd.Next(1, 4);



                    müsteriler[i].kasano = kasa;
                    müsteriler[i].asama = 1;
                }
                else if (müsteriler[i].asama == 1) // müşteri sırası geldiyse kasaya gider aşama 1-2
                {
                    if (müsteriler[i].kasano == 1)
                    {
                        rtb_kasa1.Text += (i+1).ToString() +" "+ müsteriler[i].isim + "\n";
                    }
                    else if (müsteriler[i].kasano == 2)
                    {
                        rtb_kasa2.Text += (i + 1).ToString() + " " + müsteriler[i].isim + "\n";
                    }
                    else if (müsteriler[i].kasano == 3)
                    {
                        rtb_kasa3.Text += (i + 1).ToString() + " " + müsteriler[i].isim + "\n";
                    }



                    if (müsteriler[i].kasano == 1 && kasa1_bosMu )
                    {
                        kasa1_bosMu = false;
                        lbl_kasa1müs.Text = "Müşteri : "+ (i + 1).ToString() +" "+ müsteriler[i].isim;
                        müsteriler[i].asama = 2;

                    }
                    else if (müsteriler[i].kasano == 2 && kasa2_bosMu )
                    {
                        kasa2_bosMu = false;
                        lbl_kasa2müs.Text = "Müşteri : " + (i + 1).ToString() +" "+ müsteriler[i].isim;
                        müsteriler[i].asama = 2;


                    }
                    else if (müsteriler[i].kasano == 3 && kasa3_bosMu )
                    {
                        kasa3_bosMu = false;
                        lbl_kasa3müs.Text = "Müşteri : " + (i + 1).ToString() +" "+ müsteriler[i].isim;
                        müsteriler[i].asama = 2;

                    }








                }

                else if (müsteriler[i].asama == 2) // müşteri secimini yapar 2-3
                {
                    if (müsteriler[i].kasano == 1 && cb_kasa1.Checked)
                    {
                        

                        if (pb_kasa1.Value == 100)
                        {
                            kasa1_bosMu = true;
                            pb_kasa1.Value = 0;
                            müsteriler[i].asama = 3;

                        }

                        if (pb_kasa1.Value < 100)
                        {
                            pb_kasa1.Value += 1;
                        }

                        if(pb_kasa1.Value == 1)
                        {
                            Random rnd = new Random();
                            int rastgele = rnd.Next(1, 5);

                            if(rastgele == 1)
                            {
                                rtb_kasa1_talk.Text = " > Buyrun. Nasıl yardımcı olabilirm ? ";
                            }
                            else if(rastgele == 2)
                            {
                                rtb_kasa1_talk.Text = " > Hoşgeldiniz. Ne arzu edersiniz ? ";
                            }
                            else if (rastgele == 3)
                            {
                                rtb_kasa1_talk.Text = " > Ne içmek istersiniz ? ";

                            }
                            else if (rastgele == 4)
                            {
                                rtb_kasa1_talk.Text = " > Türkiyenin en iyi kahvecisine hoşgeldiniz. ";
                            }

                        }
                        if (pb_kasa1.Value == 20)
                        {
                            Random rnd = new Random();
                            int rastgele = rnd.Next(1, 5);

                            if (rastgele == 1)
                            {
                                rtb_kasa1_talk.Text += "\n > Merhaba , biraz düşüneyim ";
                            }
                            else if (rastgele == 2)
                            {
                                rtb_kasa1_talk.Text += "\n > Merhaba ";
                            }
                            else if (rastgele == 3)
                            {
                                rtb_kasa1_talk.Text += "\n > Ne tür kahveleriz var ? ";

                            }
                            else if (rastgele == 4)
                            {
                                rtb_kasa1_talk.Text += "\n > Menünüz nasıl ? ";
                            }

                        }
                        if (pb_kasa1.Value == 40)
                        {
                            Random rnd = new Random();
                            int rastgele = rnd.Next(1, 5);

                            if (rastgele == 1)
                            {
                                rtb_kasa1_talk.Text += "\n > Caffé Latte ve Flat White önerebilirm ";
                            }
                            else if (rastgele == 2)
                            {
                                rtb_kasa1_talk.Text += "\n > Caffé Americano bu aralar çok satılıyor ";
                            }
                            else if (rastgele == 3)
                            {
                                rtb_kasa1_talk.Text += "\n > Latte Macchiato , Caffé Mocha , Frappuccino , Chai Tea Latte ... ne ararsanız var ";

                            }
                            else if (rastgele == 4)
                            {
                                rtb_kasa1_talk.Text += "\n > Daha önce frappuccino içmiş miydiniz ? ";
                            }

                        }

                        if (pb_kasa1.Value == 60)
                        {
                            Random rnd = new Random();
                            int rastgele = rnd.Next(1, 5);

                            int rastgeleicecek = rnd.Next(1, 9);
                            müsteriler[i].secim = kahveler[rastgeleicecek];
                            müsteriler[i].hazırlamahızı = kahveler_hazırlamahızı[rastgeleicecek];


                            if (rastgele == 1)
                            {
                                rtb_kasa1_talk.Text += "\n > Ben bir tane " + müsteriler[i].secim + " alayım";
                            }
                            else if (rastgele == 2)
                            {
                                rtb_kasa1_talk.Text += "\n > " + müsteriler[i].secim + " lütfen";
                            }
                            else if (rastgele == 3)
                            {
                                rtb_kasa1_talk.Text += "\n > " + müsteriler[i].secim + " olsun";

                            }
                            else if (rastgele == 4)
                            {
                                rtb_kasa1_talk.Text += "\n > hımmm " + müsteriler[i].secim + " alabilir miyim ? ";
                            }

                        }
                        if (pb_kasa1.Value == 80)
                        {
                            Random rnd = new Random();
                            int rastgele = rnd.Next(1, 5);




                            if (rastgele == 1)
                            {
                                rtb_kasa1_talk.Text += "\n > tabi , arkadaşlar hazırlarken kenarda beklebilirsiniz.";
                            }
                            else if (rastgele == 2)
                            {
                                rtb_kasa1_talk.Text += "\n > tabi efendim.";
                            }
                            else if (rastgele == 3)
                            {
                                rtb_kasa1_talk.Text += "\n > işleminzi yapıyorum.";

                            }
                            else if (rastgele == 4)
                            {
                                rtb_kasa1_talk.Text += "\n > Hazırlanıyor. İşleminiz bitti.  ";
                            }

                        }


                    }
                    else if (müsteriler[i].kasano == 2 && cb_kasa2.Checked)
                    {

                        if (pb_kasa2.Value == 100)
                        {
                            kasa2_bosMu = true;
                            pb_kasa2.Value = 0;
                            müsteriler[i].asama = 3;
                        }

                        if (pb_kasa2.Value < 100)
                        {
                            pb_kasa2.Value += 1;
                        }

                        if (pb_kasa2.Value == 1)
                        {
                            Random rnd = new Random();
                            int rastgele = rnd.Next(1, 5);

                            if (rastgele == 1)
                            {
                                rtb_kasa2_talk.Text = " > Buyrun. Nasıl yardımcı olabilirm ? ";
                            }
                            else if (rastgele == 2)
                            {
                                rtb_kasa2_talk.Text = " > Hoşgeldiniz. Ne arzu edersiniz ? ";
                            }
                            else if (rastgele == 3)
                            {
                                rtb_kasa2_talk.Text = " > Merhaba , ne içmek istersiniz ? ";

                            }
                            else if (rastgele == 4)
                            {
                                rtb_kasa2_talk.Text = " > Türkiyenin en iyi kahvecisine hoşgeldiniz. ";
                            }

                        }

                        if (pb_kasa2.Value == 20)
                        {
                            Random rnd = new Random();
                            int rastgele = rnd.Next(1, 5);

                            if (rastgele == 1)
                            {
                                rtb_kasa2_talk.Text += "\n > Merhaba , biraz düşüneyim ";
                            }
                            else if (rastgele == 2)
                            {
                                rtb_kasa2_talk.Text += "\n > Merhaba ";
                            }
                            else if (rastgele == 3)
                            {
                                rtb_kasa2_talk.Text += "\n > Ne tür kahveleriz var ? ";

                            }
                            else if (rastgele == 4)
                            {
                                rtb_kasa2_talk.Text += "\n > Menünüz nasıl ? ";
                            }

                        }
                        if (pb_kasa2.Value == 40)
                        {
                            Random rnd = new Random();
                            int rastgele = rnd.Next(1, 5);

                            if (rastgele == 1)
                            {
                                rtb_kasa2_talk.Text += "\n > Caffé Latte ve Flat White önerebilirm ";
                            }
                            else if (rastgele == 2)
                            {
                                rtb_kasa2_talk.Text += "\n > Caffé Americano bu aralar çok satılıyor ";
                            }
                            else if (rastgele == 3)
                            {
                                rtb_kasa2_talk.Text += "\n > Latte Macchiato , Caffé Mocha , Frappuccino , Chai Tea Latte ... ne ararsanız var ";

                            }
                            else if (rastgele == 4)
                            {
                                rtb_kasa2_talk.Text += "\n > Daha önce frappuccino içmiş miydiniz ? ";
                            }

                        }
                        if (pb_kasa2.Value == 60)
                        {
                            Random rnd = new Random();
                            int rastgele = rnd.Next(1, 5);

                            int rastgeleicecek = rnd.Next(1, 9);
                            müsteriler[i].secim = kahveler[rastgeleicecek];
                            müsteriler[i].hazırlamahızı = kahveler_hazırlamahızı[rastgeleicecek];


                            if (rastgele == 1)
                            {
                                rtb_kasa2_talk.Text += "\n > Ben bir tane "+ müsteriler[i].secim + " alayım";
                            }
                            else if (rastgele == 2)
                            {
                                rtb_kasa2_talk.Text += "\n > " + müsteriler[i].secim + " lütfen";
                            }
                            else if (rastgele == 3)
                            {
                                rtb_kasa2_talk.Text += "\n > " + müsteriler[i].secim + " olsun";

                            }
                            else if (rastgele == 4)
                            {
                                rtb_kasa2_talk.Text += "\n > hımmm "+ müsteriler[i].secim + " alabilir miyim ? ";
                            }

                        }

                        if (pb_kasa2.Value == 80)
                        {
                            Random rnd = new Random();
                            int rastgele = rnd.Next(1, 5);




                            if (rastgele == 1)
                            {
                                rtb_kasa2_talk.Text += "\n > tabi , arkadaşlar hazırlarken kenarda beklebilirsiniz.";
                            }
                            else if (rastgele == 2)
                            {
                                rtb_kasa2_talk.Text += "\n > tabi efendim.";
                            }
                            else if (rastgele == 3)
                            {
                                rtb_kasa2_talk.Text += "\n > işleminzi yapıyorum.";

                            }
                            else if (rastgele == 4)
                            {
                                rtb_kasa2_talk.Text += "\n > Hazırlanıyor. İşleminiz bitti.  ";
                            }

                        }

                    }
                    else if (müsteriler[i].kasano == 3 && cb_kasa3.Checked)
                    {
                        if (pb_kasa3.Value == 100)
                        {
                            kasa3_bosMu = true;
                            pb_kasa3.Value = 0;
                            müsteriler[i].asama = 3;
                        }

                        if (pb_kasa3.Value < 100)
                        {
                            pb_kasa3.Value += 1;
                        }

                        if (pb_kasa3.Value == 1)
                        {
                            Random rnd = new Random();
                            int rastgele = rnd.Next(1, 5);

                            if (rastgele == 1)
                            {
                                rtb_kasa3_talk.Text = " > Buyrun. Nasıl yardımcı olabilirm ? ";
                            }
                            else if (rastgele == 2)
                            {
                                rtb_kasa3_talk.Text = " > Hoşgeldiniz. Ne arzu edersiniz ? ";
                            }
                            else if (rastgele == 3)
                            {
                                rtb_kasa3_talk.Text = " > Ne içmek istersiniz ? ";

                            }
                            else if (rastgele == 4)
                            {
                                rtb_kasa3_talk.Text = " > Türkiyenin en iyi kahvecisine hoşgeldiniz. ";
                            }

                        }
                        if (pb_kasa3.Value == 20)
                        {
                            Random rnd = new Random();
                            int rastgele = rnd.Next(1, 5);

                            if (rastgele == 1)
                            {
                                rtb_kasa3_talk.Text += "\n > Merhaba , biraz düşüneyim ";
                            }
                            else if (rastgele == 2)
                            {
                                rtb_kasa3_talk.Text += "\n > Merhaba ";
                            }
                            else if (rastgele == 3)
                            {
                                rtb_kasa3_talk.Text += "\n > Ne tür kahveleriz var ? ";

                            }
                            else if (rastgele == 4)
                            {
                                rtb_kasa3_talk.Text += "\n > Menünüz nasıl ? ";
                            }

                        }
                        if (pb_kasa3.Value == 40)
                        {
                            Random rnd = new Random();
                            int rastgele = rnd.Next(1, 5);

                            if (rastgele == 1)
                            {
                                rtb_kasa3_talk.Text += "\n > Caffé Latte ve Flat White önerebilirm ";
                            }
                            else if (rastgele == 2)
                            {
                                rtb_kasa3_talk.Text += "\n > Caffé Americano bu aralar çok satılıyor ";
                            }
                            else if (rastgele == 3)
                            {
                                rtb_kasa3_talk.Text += "\n > Latte Macchiato , Caffé Mocha , Frappuccino , Chai Tea Latte ... ne ararsanız var ";

                            }
                            else if (rastgele == 4)
                            {
                                rtb_kasa3_talk.Text += "\n > Daha önce frappuccino içmiş miydiniz ? ";
                            }

                        }

                        if (pb_kasa3.Value == 60)
                        {
                            Random rnd = new Random();
                            int rastgele = rnd.Next(1, 5);

                            int rastgeleicecek = rnd.Next(1, 9);
                            müsteriler[i].secim = kahveler[rastgeleicecek];
                            müsteriler[i].hazırlamahızı  = kahveler_hazırlamahızı[rastgeleicecek];


                            if (rastgele == 1)
                            {
                                rtb_kasa3_talk.Text += "\n > Ben bir tane " + müsteriler[i].secim + " alayım";
                            }
                            else if (rastgele == 2)
                            {
                                rtb_kasa3_talk.Text += "\n > " + müsteriler[i].secim + " lütfen";
                            }
                            else if (rastgele == 3)
                            {
                                rtb_kasa3_talk.Text += "\n > " + müsteriler[i].secim + " olsun";

                            }
                            else if (rastgele == 4)
                            {
                                rtb_kasa3_talk.Text += "\n > hımmm " + müsteriler[i].secim + " alabilir miyim ? ";
                            }

                        }

                        if (pb_kasa3.Value == 80)
                        {
                            Random rnd = new Random();
                            int rastgele = rnd.Next(1, 5);




                            if (rastgele == 1)
                            {
                                rtb_kasa3_talk.Text += "\n > tabi , arkadaşlar hazırlarken kenarda beklebilirsiniz.";
                            }
                            else if (rastgele == 2)
                            {
                                rtb_kasa3_talk.Text += "\n > tabi efendim.";
                            }
                            else if (rastgele == 3)
                            {
                                rtb_kasa3_talk.Text += "\n > işleminzi yapıyorum.";

                            }
                            else if (rastgele == 4)
                            {
                                rtb_kasa3_talk.Text += "\n > Hazırlanıyor. İşleminiz bitti.  ";
                            }

                        }


                    }
                }

                else if (müsteriler[i].asama == 3)
                {

                    rtb_beklenen.Text += " "+(i+1).ToString()+"- " + müsteriler[i].secim + " (" + müsteriler[i].isim + ") \n";



                }





            }
        }

        private void timer1_calısanlar_Tick(object sender, EventArgs e)
        {
     

            if (kasa1calısan_bosMu)
            {
                if (Hakan_bosMu)
                {
                    Hakan_bosMu = false;
                    lbl_kasa1durum.Text = "Hakan ilgileniyor";
                    kasa1calısan_bosMu = false;
                    c1_info.Text = "1. Kasada çalışıyor";
                }
                else if (Sıla_bosMu)
                {
                    Sıla_bosMu = false;
                    lbl_kasa1durum.Text = "Sıla ilgileniyor";
                    kasa1calısan_bosMu = false;
                    c2_info.Text = "1. Kasada çalışıyor";
                }
                else if (Aysun_bosMu)
                {
                    Aysun_bosMu = false;
                    lbl_kasa1durum.Text = "Aysun ilgileniyor";
                    kasa1calısan_bosMu = false;
                    c3_info.Text = "1. Kasada çalışıyor";
                }
                else if (Melike_bosMu)
                {
                    Melike_bosMu = false;
                    lbl_kasa1durum.Text = "Melike ilgileniyor";
                    kasa1calısan_bosMu = false;
                    c4_info.Text = "1. Kasada çalışıyor";
                }
                else if (Onur_bosMu)
                {
                    Onur_bosMu = false;
                    lbl_kasa1durum.Text = "Onur ilgileniyor";
                    kasa1calısan_bosMu = false;
                    c5_info.Text = "1. Kasada çalışıyor";
                }
            }

            else if (kasa2calısan_bosMu)
            {
                if (Hakan_bosMu)
                {
                    Hakan_bosMu = false;
                    lbl_kasa2durum.Text = "Hakan ilgileniyor";
                    kasa2calısan_bosMu = false;
                    c1_info.Text = "2. Kasada çalışıyor";
                }
                else if (Sıla_bosMu)
                {
                    Sıla_bosMu = false;
                    lbl_kasa2durum.Text = "Sıla ilgileniyor";
                    kasa2calısan_bosMu = false;
                    c2_info.Text = "2. Kasada çalışıyor";

                }
                else if (Aysun_bosMu)
                {
                    Aysun_bosMu = false;
                    lbl_kasa2durum.Text = "Aysun ilgileniyor";
                    kasa2calısan_bosMu = false;
                    c3_info.Text = "2. Kasada çalışıyor";

                }
                else if (Melike_bosMu)
                {
                    Melike_bosMu = false;
                    lbl_kasa2durum.Text = "Melike ilgileniyor";
                    kasa2calısan_bosMu = false;
                    c4_info.Text = "2. Kasada çalışıyor";

                }
                else if (Onur_bosMu)
                {
                    Onur_bosMu = false;
                    lbl_kasa2durum.Text = "Onur ilgileniyor";
                    kasa2calısan_bosMu = false;
                    c5_info.Text = "2. Kasada çalışıyor";

                }
            }

            else if (kasa3calısan_bosMu)
            {
                if (Hakan_bosMu)
                {
                    Hakan_bosMu = false;
                    lbl_kasa3durum.Text = "Hakan ilgileniyor";
                    kasa3calısan_bosMu = false;
                    c1_info.Text = "3. Kasada çalışıyor";

                }
                else if (Sıla_bosMu)
                {
                    Sıla_bosMu = false;
                    lbl_kasa3durum.Text = "Sıla ilgileniyor";
                    kasa3calısan_bosMu = false;
                    c2_info.Text = "3. Kasada çalışıyor";

                }
                else if (Aysun_bosMu)
                {
                    Aysun_bosMu = false;
                    lbl_kasa3durum.Text = "Aysun ilgileniyor";
                    kasa3calısan_bosMu = false;
                    c3_info.Text = "3. Kasada çalışıyor";

                }
                else if (Melike_bosMu)
                {
                    Melike_bosMu = false;
                    lbl_kasa3durum.Text = "Melike ilgileniyor";
                    kasa3calısan_bosMu = false;
                    c4_info.Text = "3. Kasada çalışıyor";

                }
                else if (Onur_bosMu)
                {
                    Onur_bosMu = false;
                    lbl_kasa3durum.Text = "Onur ilgileniyor";
                    kasa3calısan_bosMu = false;
                    c5_info.Text = "3. Kasada çalışıyor";


                }
            }

            for (int i = 0; i < müsteriler.Count; i++)
            {
                if (müsteriler[i].asama == 3)
                {
                    if (Hakan_bosMu)
                    {
                        müsteriler[i].asama = 4;

                        Hakan_bosMu = false;
                        
                    }                    
                    else if (Sıla_bosMu)
                    {

                        müsteriler[i].asama = 5;

                        Sıla_bosMu = false;
                    }
                  
                    else if (Aysun_bosMu)
                    {
                        müsteriler[i].asama = 6;
                        Aysun_bosMu = false;
                    }
                    
                    else if (Melike_bosMu)
                    {

                        müsteriler[i].asama = 7;

                        Melike_bosMu = false;
                    }
                    
                    else if (Onur_bosMu)
                    {

                        müsteriler[i].asama = 8;

                        Onur_bosMu = false;
                    }




                }



                else if (müsteriler[i].asama == 4)
                {
                    if (pb_c1.Value <= (100 - müsteriler[i].hazırlamahızı))
                    {
                        pb_c1.Value += müsteriler[i].hazırlamahızı;
                        c1_info.Text = "No: " + (i + 1).ToString() + " hazırlanıyor (" + (200 / müsteriler[i].hazırlamahızı).ToString() + ") sn";

                    }

                    if (pb_c1.Value == 100)
                    {
                        pb_c1.Value = 0;
                        Hakan_bosMu = true;
                        müsteriler[i].asama = 10;
                        c1_info.Text = "Bekliyor ... ";
                    }



                }

                else if (müsteriler[i].asama == 5)
                {
                    if (pb_c2.Value <= (100 - müsteriler[i].hazırlamahızı))
                    {
                        pb_c2.Value += müsteriler[i].hazırlamahızı;
                        c2_info.Text = "No: " + (i + 1).ToString() + " hazırlanıyor (" + (200 / müsteriler[i].hazırlamahızı).ToString() + ") sn";

                    }

                    if (pb_c2.Value == 100)
                    {
                        pb_c2.Value = 0;
                        Sıla_bosMu = true;
                        müsteriler[i].asama = 10;
                        c2_info.Text = "Bekliyor ... ";
                    }



                }

                else if (müsteriler[i].asama == 6)
                {
                    if (pb_c3.Value <= (100 - müsteriler[i].hazırlamahızı))
                    {
                        pb_c3.Value += müsteriler[i].hazırlamahızı;
                        c3_info.Text = "No: " + (i + 1).ToString() + " hazırlanıyor (" + (200 / müsteriler[i].hazırlamahızı).ToString() + ") sn";

                    }

                    if (pb_c3.Value == 100)
                    {
                        pb_c3.Value = 0;
                        Aysun_bosMu  = true;
                        müsteriler[i].asama = 10;
                        c3_info.Text = "Bekliyor ... ";
                    }



                }

                else if (müsteriler[i].asama == 7)
                {
                    if (pb_c4.Value <= (100 - müsteriler[i].hazırlamahızı))
                    {
                        pb_c4.Value += müsteriler[i].hazırlamahızı;
                        c4_info.Text = "No: " + (i + 1).ToString() + " hazırlanıyor (" + (200 / müsteriler[i].hazırlamahızı).ToString() + ") sn";
                    }

                    if (pb_c4.Value == 100)
                    {
                        pb_c4.Value = 0;
                        Melike_bosMu = true;
                        müsteriler[i].asama = 10;
                        c4_info.Text = "Bekliyor ... ";

                    }



                }

                else if (müsteriler[i].asama == 8)
                {
                    if (pb_c5.Value <= (100 - müsteriler[i].hazırlamahızı))
                    {
                        pb_c5.Value += müsteriler[i].hazırlamahızı;
                        c5_info.Text = "No: "+(i + 1).ToString() + " hazırlanıyor (" +(200 / müsteriler[i].hazırlamahızı).ToString() + ") sn";
                    }

                    if (pb_c5.Value == 100)
                    {
                        pb_c5.Value = 0;
                        Onur_bosMu = true;
                        müsteriler[i].asama = 10;
                        c5_info.Text = "Bekliyor ... ";

                    }



                }




            }





            }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();

        }
    }
}

public class müs
{
    public string isim;
    public int asama;
    public int kasano;
    public string secim;
    public int hazırlamahızı;

    public müs(string isim, int asama, string secim, int kasano,int hazırlamahızı)
    {
        this.secim = secim;
        this.isim = isim;
        this.asama = asama;
        this.kasano = kasano;
        this.hazırlamahızı = hazırlamahızı;
    }

  
}
