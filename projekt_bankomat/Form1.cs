using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading;


namespace projekt_bankomat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        //globalne
        #region globalne
        private int proba = 3;
        public int licznik = 0;
        private int check = 0;
        private int IDkarty;
        int kwota;
        int charywpl = 0;

        private string PIN;
        private string numerkart;
        private string word;
        
        private char[] numery = new char[100];
       
        //buttony
        Button button_one = new Button();
        Button button_two = new Button();
        Button button_three = new Button();
        Button button_four = new Button();
        Button button_five = new Button();
        Button button_six = new Button();
        Button button_seven = new Button();
        Button button_eight = new Button();
        Button button_nine = new Button();
        Button cancel = new Button();
        Button undo = new Button();
        Button accept = new Button();
        Button exit = new Button();
        Button option_one = new Button();
        Button option_two = new Button();
        Button option_three = new Button();
        Button option_four = new Button();
        Button Card = new Button();
        Button sto_button = new Button();
        Button dwiescie_button = new Button();
        Button piecdziesiat_button = new Button();
        Button powrot = new Button();
        Button TAK = new Button();
        Button NIE = new Button();

        //labele
        Label main = new Label();
        Label option_ones = new Label();
        Label option_twos = new Label();
        Label option_threes = new Label();
        Label option_fours = new Label();
        Label answer = new Label();
        //karty
        List<Karta> karty = new List<Karta>();
        Karta karta1 = new Karta("1234","123456789",1200);
        Karta karta2 = new Karta("9876", "987654321", 120);
        Karta karta3 = new Karta("9999", "192837465", 10000);
        Karta karta4 = new Karta("3331", "188888765", 1000);
        //textbox
        TextBox numerkarty = new TextBox();
        //MessageBox
        //klasy
        //klasy
        Strategia_opcji OpcjadoWyboru = new Strategia_opcji();
        Wyloguj wyloguj = new Wyloguj();
        Wyplata wyplata = new Wyplata();
        Stankonta stankonta = new Stankonta();
        Sto stowka_klasa = new Sto();
        Piecdziesiat piecdziesiatka_klasa = new Piecdziesiat();
        Dwiescie dwiestowki_klasa = new Dwiescie();
        Wyborpienidzy wybor = new Wyborpienidzy();
        Drukuje drukuje = new Drukuje();
        Drukuje niedrukuje = new AdapterDrukuje();
        //picturebox
        PictureBox picture = new PictureBox();
        static string workingDirectory = Environment.CurrentDirectory;
        static string startupPath = Directory.GetParent(workingDirectory).Parent.FullName;
        Image img = Image.FromFile(startupPath + "\\moneyy1.gif");
        PictureBox picturech = new PictureBox();
        Image imgag = Image.FromFile(startupPath+"\\giphy.gif");
        #endregion
        //
        private void Form1_Main(object sender, EventArgs e)
        {

            check = 0;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            //this.Size = new Size(1300, 1000);
            this.Location = new Point(10, 10);
            this.MaximizeBox = false;

            #region karty
            karty.Add(karta1);
            karty.Add(karta2);
            karty.Add(karta3);
            karty.Add(karta4);
            #endregion

            //labels
            #region labels
            main.Text = "Witamy w Banku!\nWłóż kartę";
            main.Location = new Point(500, 150);
            main.Size = new Size(200, 100);
            main.Font = new Font("Microsoft Sans Serif", 12);
            main.BackColor = Color.Silver;

            //buttony na 920, 150
            //option_ones.Text = "";
            option_ones.Location = new Point(740, 150);
            option_ones.Size = new Size(150, 50);
            option_ones.Font = new Font("Microsoft Sans Serif", 12);
            option_ones.BackColor = Color.Silver;

            //option_twos.Text = "Witamy w Banku!\nWłóż kartę";
            option_twos.Location = new Point(740, 220);
            option_twos.Size = new Size(150, 50);
            option_twos.Font = new Font("Microsoft Sans Serif", 12);
            option_twos.BackColor = Color.Silver;

            // main.Text = "Witamy w Banku!\nWłóż kartę";
            option_threes.Location = new Point(740, 290);
            option_threes.Size = new Size(150, 50);
            option_threes.Font = new Font("Microsoft Sans Serif", 12);
            option_threes.BackColor = Color.Silver;

            //option_fours.Text = "Witamy w Banku!\nWłóż kartę";
            option_fours.Location = new Point(740, 360);
            option_fours.Size = new Size(150, 50);
            option_fours.Font = new Font("Microsoft Sans Serif", 12);
            option_fours.BackColor = Color.Silver;

            option_ones.Text = "Wypłata";
            option_twos.Text = "Sprawdz konto";
            option_threes.Text = "Przelej na cele charytatywne";
            option_fours.Text = "Wyloguj";

            answer.Location = new Point(500, 300);
            answer.Size = new Size(200, 50);
            answer.Font = new Font("Microsoft Sans Serif", 10);
            answer.BackColor = Color.LightSlateGray;

            #endregion
            //addbuttoms
            #region buttons

            button_one.Location = new Point(20, 100);
            button_one.Text = "1";
            button_one.Size = new Size(100, 100);
            button_one.Font = new Font("Microsoft Sans Serif", 10);
            button_one.BackColor = Color.CadetBlue;
            button_one.Click += new EventHandler(pressButton1);
            button_one.Enabled = false;

            button_two.Text = "2";
            button_two.Location = new Point(120, 100);
            button_two.Size = new Size(100, 100);
            button_two.Font = new Font("Microsoft Sans Serif", 10);
            button_two.BackColor = Color.CadetBlue;
            button_two.Click += new EventHandler(pressButton2);
            button_two.Enabled = false;

            button_three.Text = "3";
            button_three.Location = new Point(220, 100);
            button_three.Size = new Size(100, 100);
            button_three.Font = new Font("Microsoft Sans Serif", 10);
            button_three.BackColor = Color.CadetBlue;
            button_three.Click += new EventHandler(pressButton3);
            button_three.Enabled = false;


            button_four.Text = "4";
            button_four.Location = new Point(20, 200);
            button_four.Size = new Size(100, 100);
            button_four.Font = new Font("Microsoft Sans Serif", 10);
            button_four.BackColor = Color.CadetBlue;
            button_four.Click += new EventHandler(pressButton4);
            button_four.Enabled = false;

            button_five.Text = "5";
            button_five.Location = new Point(120, 200);
            button_five.Size = new Size(100, 100);
            button_five.Font = new Font("Microsoft Sans Serif", 10);
            button_five.BackColor = Color.CadetBlue;
            button_five.Click += new EventHandler(pressButton5);
            button_five.Enabled = false;


            button_six.Text = "6";
            button_six.Location = new Point(220, 200);
            button_six.Size = new Size(100, 100);
            button_six.Font = new Font("Microsoft Sans Serif", 10);
            button_six.BackColor = Color.CadetBlue;
            button_six.Click += new EventHandler(pressButton6);
            button_six.Enabled = false;


            button_seven.Text = "7";
            button_seven.Location = new Point(20, 300);
            button_seven.Size = new Size(100, 100);
            button_seven.Font = new Font("Microsoft Sans Serif", 10);
            button_seven.BackColor = Color.CadetBlue;
            button_seven.Click += new EventHandler(pressButton7);
            button_seven.Enabled = false;


            button_eight.Text = "8";
            button_eight.Location = new Point(120, 300);
            button_eight.Size = new Size(100, 100);
            button_eight.Font = new Font("Microsoft Sans Serif", 10);
            button_eight.BackColor = Color.CadetBlue;
            button_eight.Click += new EventHandler(pressButton8);
            button_eight.Enabled = false;


            button_nine.Text = "9";
            button_nine.Location = new Point(220, 300);
            button_nine.Size = new Size(100, 100);
            button_nine.Font = new Font("Microsoft Sans Serif", 10);
            button_nine.BackColor = Color.CadetBlue;
            button_nine.Click += new EventHandler(pressButton9);
            button_nine.Enabled = false;

            cancel.Text = "Usuń";
            cancel.Location = new Point(20, 400);
            cancel.Size = new Size(300, 100);
            cancel.Font = new Font("Microsoft Sans Serif", 20);
            cancel.BackColor = Color.DarkKhaki;
            cancel.Enabled = false;
            cancel.Click += new EventHandler(Cancel);

            accept.Text = "Akceptuj";
            accept.Location = new Point(20, 500);
            accept.Size = new Size(300, 100);
            accept.Font = new Font("Microsoft Sans Serif", 20);
            accept.BackColor = Color.DarkKhaki;
            accept.Click += new EventHandler(Accept);
            accept.Enabled = false;

            undo.Text = "Cofnij";
            undo.Location = new Point(20, 600);
            undo.Size = new Size(300, 100);
            undo.Font = new Font("Microsoft Sans Serif", 20);
            undo.BackColor = Color.DarkKhaki;
            undo.Enabled = false;
            undo.Click += new EventHandler(Undoo);

            option_one.Text = "";
            option_one.Location = new Point(920, 150);
            option_one.BackColor = Color.PeachPuff;
            // exit.Click += new EventHandler(endprogram);
            option_one.Size = new Size(100, 50);
            option_one.Enabled = false;

            option_two.Text = "";
            option_two.Location = new Point(920, 220);
            option_two.BackColor = Color.PeachPuff;
            // exit.Click += new EventHandler(endprogram);
            option_two.Size = new Size(100, 50);
            option_two.Enabled = false;

            option_three.Text = "";
            option_three.Location = new Point(920, 290);
            option_three.BackColor = Color.PeachPuff;
            // exit.Click += new EventHandler(endprogram);
            option_three.Size = new Size(100, 50);
            option_three.Enabled = false;


            option_four.Text = "";
            option_four.Location = new Point(920, 360);
            option_four.BackColor = Color.PeachPuff;
            // exit.Click += new EventHandler(endprogram);
            option_four.Size = new Size(100, 50);
            option_four.Enabled = false;


            Card.Text = "OK";
            Card.Location = new Point(1200, 230);
            //Card.BackColor = Color.Honeydew;
            Card.Size = new Size(100, 50);
            string tekcik = numerkarty.Text;
            Card.Click += new EventHandler(CreditCard);

            sto_button.Text = "100";
            sto_button.Location = new Point(500, 385);
            sto_button.BackColor = Color.YellowGreen;
            sto_button.Click += new EventHandler(stowka);
            sto_button.Size = new Size(50, 25);
            sto_button.Enabled = false;

            dwiescie_button.Text = "200";
            dwiescie_button.Location = new Point(500, 410);
            dwiescie_button.BackColor = Color.YellowGreen;
            dwiescie_button.Click += new EventHandler(dwiestowki);
            // exit.Click += new EventHandler(endprogram);
            dwiescie_button.Size = new Size(50, 25);
            dwiescie_button.Enabled = false;

            piecdziesiat_button.Text = "50";
            piecdziesiat_button.Location = new Point(500, 360);
            piecdziesiat_button.BackColor = Color.YellowGreen;
            piecdziesiat_button.Click += new EventHandler(piecdziesiat);
            // exit.Click += new EventHandler(endprogram);
            piecdziesiat_button.Size = new Size(50, 25);
            piecdziesiat_button.Enabled = false;

            powrot.Text = "<-";
            powrot.Location = new Point(500, 435);
            powrot.BackColor = Color.YellowGreen;
            powrot.Click += new EventHandler(Powrot);
            powrot.Size = new Size(50, 25);
            powrot.Enabled = false;

            TAK.Text = "TAK";
            TAK.Location = new Point(570, 380);
            TAK.BackColor = Color.OrangeRed;
            // exit.Click += new EventHandler(endprogram);
            TAK.Size = new Size(50, 50);
            TAK.Enabled = false;

            NIE.Text = "NIE";
            NIE.Location = new Point(630, 380);
            NIE.BackColor = Color.OrangeRed;
            // exit.Click += new EventHandler(endprogram);
            NIE.Size = new Size(50, 50);
            NIE.Enabled = false;


            exit.Text = "X";
            exit.Location = new Point(1485, 0);
            exit.BackColor = Color.Red;
            exit.Click += new EventHandler(endprogram);
            exit.Size = new Size(50, 50);



            #endregion //textbox
            //textbox
            #region textbox
            numerkarty.Location = new Point(1150, 200);
            numerkarty.Size = new Size(200, 100);
            numerkarty.BackColor = Color.MintCream;
            numerkarty.Enabled = true;
            //numerkarty.Text = "Tu wpisz numer karty";
            //numerkarty.Text.Contains("Tu wpisz numer karty");// = "Tu wpisz numer karty";
            numerkarty.MaxLength = 9;
            #endregion
            //picture
            // Image img = Image.FromFile("moneyy1.gif");
            // picture.Image = img;
            picture.Image = img;
            //picture.ImageLocation = "C:\\Users\\Marzis\\Desktop\\projekt_bankomat\\moneyy1.jpeg";
            //picture.FindForm
            
            picture.Size = new Size (200,200);
            picture.Location = new Point(500, 500);
           // Thread.Sleep(2000);
            picture.Visible = false;

            picturech.Image = imgag;
            picturech.Size = new Size(500, 500);
            picturech.Location = new Point(1000, 500);
            picturech.Visible = false;


            //controls
            #region controls
            Controls.Add(button_one);
            Controls.Add(button_two);
            Controls.Add(button_three);
            Controls.Add(button_four);
            Controls.Add(button_five);
            Controls.Add(button_six);
            Controls.Add(button_seven);
            Controls.Add(button_eight);
            Controls.Add(button_nine);
            Controls.Add(exit);
            Controls.Add(cancel);
            Controls.Add(accept);
            Controls.Add(undo);
            Controls.Add(option_one);
            Controls.Add(option_two);
            Controls.Add(option_three);
            Controls.Add(option_four);
            Controls.Add(main);
            Controls.Add(option_ones);
            Controls.Add(option_twos);
            Controls.Add(option_threes);
            Controls.Add(option_fours);
            Controls.Add(answer);
            Controls.Add(numerkarty);
            Controls.Add(Card);
            Controls.Add(sto_button);
            Controls.Add(dwiescie_button);
            Controls.Add(powrot);
            Controls.Add(piecdziesiat_button);
            Controls.Add(TAK);
            Controls.Add(NIE);
            Controls.Add(picture);
            Controls.Add(picturech);
           // Controls.Add(messages);
            #endregion

        }

      

        //
        private void CreditCard(object sender, EventArgs e)
        {
            proba = 3;
            answer.Text = "";
            main.Text = "Witamy w Banku!\nWłóż kartę.";
            numerkarty.Enabled = true;
           // Card.Text = "OK";
            check = 0;
            bool tojestpuste = false;
            numerkart = numerkarty.Text;
            if (numerkart == "")
            {
                tojestpuste = true;
            }
                
            for (int i = 0; i < 4; i++)
            {
                if (karty[i].Czydobrynumerkarty(numerkart) == true)
                {//wprowadzamy PIN
                   if(karty[i].Czykartazablokowana()==true)//do sprawdzenia!
                    {
                       check = 1;
                       main.Text = "Twoja karta zablokowana.\nOdblokuj ją w banku.";
                       numerkarty.Text = "";
                       Card.Text = "OK";
                       break;
                    }
                    //MessageBox.Show(karty[i].Wyswietlnumer());
                    IDkarty = i;
                    check = 1;
                  //  Card.Text = numerkart;
                    main.Text = "Dobry numer karty.\nPodaj PIN";
                    button_one.Enabled = true;
                    button_two.Enabled = true;
                    button_three.Enabled = true;
                    button_four.Enabled = true;
                    button_five.Enabled = true;
                    button_six.Enabled = true;
                    button_seven.Enabled = true;
                    button_eight.Enabled = true;
                    button_nine.Enabled = true;
                    cancel.Enabled = true;
                    accept.Enabled = true;
                    undo.Enabled = true;
                   // Card.Text = numerkart;
                    Card.Enabled = false;
                    numerkarty.Text = "";
                    numerkarty.Enabled = false;
                }
                
            }
            if (check == 0 && tojestpuste==false)
            {
                main.Text = "Zły numer karty.Podaj jeszcze raz karte";
                numerkarty.Text = "";
            }
           
        }


        //
        private void pressButton1(object sender, EventArgs e)
        {
            if (licznik == 0)
            {
                word = "*";
                answer.Text = "*";

            }
            if (licznik == 1)
            {
                answer.Text = "**";

            }
            if (licznik == 2)
            {

                answer.Text = "***";

            }
            if (licznik == 3)
            {


                answer.Text = "****";
            }

            if (licznik == 4)
            {
                answer.Text = "****";

            }


            if (licznik > 4)
            {
                //EventHandler (Accept());
            }

            //numery[0] = '1';
            numery[licznik] = '1';

            licznik++;
        }

        private void pressButton2(object sender, EventArgs e)
        {
            if (licznik == 0)
            {


                word = "*";
                answer.Text = "*";

            }
            if (licznik == 1)
            {


                answer.Text = "**";

            }
            if (licznik == 2)
            {

                answer.Text = "***";

            }
            if (licznik == 3)
            {


                answer.Text = "****";
            }

            if (licznik == 4)
            {
                answer.Text = "****";


            }
            numery[licznik] = '2';

            if (licznik > 4)
            {
                answer.Text = "NIE WPISUJ WIECEJ OMG";
            }
            licznik++;
        }

        private void pressButton3(object sender, EventArgs e)
        {
            if (licznik > 4)
            {
                answer.Text = "NIE WPISUJ WIECEJ OMG";
            }
            if (licznik == 0)
            {


                word = "*";
                answer.Text = "*";

            }
            if (licznik == 1)
            {


                answer.Text = "**";

            }
            if (licznik == 2)
            {

                answer.Text = "***";

            }
            if (licznik == 3)
            {


                answer.Text = "****";
            }

            if (licznik == 4)
            {
                answer.Text = "****";


            }
            numery[licznik] = '3';

            licznik++;
        }

        private void pressButton4(object sender, EventArgs e)
        {

            if (licznik > 4)
            {
                answer.Text = "NIE WPISUJ WIECEJ OMG";
            }
            if (licznik == 0)
            {


                word = "*";
                answer.Text = "*";

            }
            if (licznik == 1)
            {


                answer.Text = "**";

            }
            if (licznik == 2)
            {

                answer.Text = "***";

            }
            if (licznik == 3)
            {


                answer.Text = "****";
            }

            if (licznik == 4)
            {
                answer.Text = "****";


            }
            numery[licznik] = '4';

            licznik++;
        }

        private void pressButton5(object sender, EventArgs e)
        {

            if (licznik > 4)
            {
                answer.Text = "NIE WPISUJ WIECEJ OMG";
            }
            if (licznik == 0)
            {


                word = "*";
                answer.Text = "*";

            }
            if (licznik == 1)
            {


                answer.Text = "**";

            }
            if (licznik == 2)
            {

                answer.Text = "***";

            }
            if (licznik == 3)
            {

                answer.Text = "****";
            }

            if (licznik == 4)
            {
                answer.Text = "****";


            }
            numery[licznik] = '5';

            licznik++;
        }

        private void pressButton6(object sender, EventArgs e)
        {

            if (licznik > 4)
            {
                answer.Text = "NIE WPISUJ WIECEJ OMG";
            }
            if (licznik == 0)
            {


                word = "*";
                answer.Text = "*";

            }
            if (licznik == 1)
            {


                answer.Text = "**";

            }
            if (licznik == 2)
            {

                answer.Text = "***";

            }
            if (licznik == 3)
            {


                answer.Text = "****";
            }

            if (licznik == 4)
            {
                answer.Text = "****";


            }
            numery[licznik] = '6';

            licznik++;
        }

        private void pressButton7(object sender, EventArgs e)
        {

            if (licznik > 4)
            {
                answer.Text = "NIE WPISUJ WIECEJ OMG";
            }
            if (licznik == 0)
            {


                word = "*";
                answer.Text = "*";

            }
            if (licznik == 1)
            {


                answer.Text = "**";

            }
            if (licznik == 2)
            {

                answer.Text = "***";

            }
            if (licznik == 3)
            {


                answer.Text = "****";
            }

            if (licznik == 4)
            {
                answer.Text = "****";


            }
            numery[licznik] = '7';

            licznik++;
        }

        private void pressButton8(object sender, EventArgs e)
        {

            if (licznik > 4)
            {
                answer.Text = "NIE WPISUJ WIECEJ OMG";
            }
            if (licznik == 0)
            {


                word = "*";
                answer.Text = "*";

            }
            if (licznik == 1)
            {


                answer.Text = "**";

            }
            if (licznik == 2)
            {

                answer.Text = "***";

            }
            if (licznik == 3)
            {


                answer.Text = "****";
            }

            if (licznik == 4)
            {
                answer.Text = "****";


            }
            numery[licznik] = '8';

            licznik++;
        }

        private void pressButton9(object sender, EventArgs e)
        {

            if (licznik > 4)
            {
                answer.Text = "NIE WPISUJ WIECEJ OMG";
            }

            if (licznik == 0)
            {


                word = "*";
                answer.Text = "*";

            }
            if (licznik == 1)
            {


                answer.Text = "**";

            }
            if (licznik == 2)
            {

                answer.Text = "***";

            }
            if (licznik == 3)
            {


                answer.Text = "****";
            }

            if (licznik == 4)
            {
                answer.Text = "****";


            }
            numery[licznik] = '9';

            licznik++;
        }

        private void Accept(object sender, EventArgs e)
        {
            //MessageBox.Show(proba.ToString(), licznik.ToString());
            Card.Text = numerkart;
            licznik = 0;
            PIN = "";
            for (int i = 3; i > -1; i--)
            {
                PIN = numery[i].ToString() + PIN;
            }

                main.Text = PIN;
                bool a = karty[IDkarty].CzydobrynumerPinu(PIN);
                if (a == true)

                {
                    answer.Text = "";
                main.Text = "Wprowadzono poprawny PIN.\nProszę podać co chce Pan/Pani zrobić.";
                option_ones.Text = "Wypłata";
                option_twos.Text = "Sprawdz konto";
                option_threes.Text = "Przelej na cele charytatywne";
                option_fours.Text = "Wyloguj";
                option_one.Enabled = true;
                option_two.Enabled = true;
                option_three.Enabled = true;
                option_four.Enabled = true;
                option_one.Click += new EventHandler(Wyplata);
                option_two.Click += new EventHandler(Sprawdz_konto);
                option_three.Click += new EventHandler(Przelej);
                option_four.Click += new EventHandler(Wyloguj);
                button_one.Enabled = false;
                button_two.Enabled = false;
                button_three.Enabled = false;
                button_four.Enabled = false;
                button_five.Enabled = false;
                button_six.Enabled = false;
                button_seven.Enabled = false;
                button_eight.Enabled = false;
                button_nine.Enabled = false;
                cancel.Enabled = false;
                accept.Enabled = false;
                undo.Enabled = false;
                proba = 3;
                }

            
                else
                {
                    main.Text = "NIEPOPRAWNY PIN";
                    licznik = 0;
                    check = 0;
                    proba--;

                }

                if (proba == 0)
                {
                main.Text = "Twoja karta została zablokowana.\nOdbloku ją w banku";
                karty[IDkarty].Kartazablokowana();
                Card.Text = "OK";
                Card.Enabled = true;
                numerkarty.Enabled = true;
                numerkarty.Text = "";
                button_one.Enabled = false;
                button_two.Enabled = false;
                button_three.Enabled = false;
                button_four.Enabled = false;
                button_five.Enabled = false;
                button_six.Enabled = false;
                button_seven.Enabled = false;
                button_eight.Enabled = false;
                button_nine.Enabled = false;
                cancel.Enabled = false;
                accept.Enabled = false;
                undo.Enabled = false;


            }
            answer.Text = "";
            
        }

        private void Undoo(object sender, EventArgs e)
        {
            licznik--;
            numery[3] = '0';
            if (licznik == 0)
                answer.Text = "";
            if (licznik == 1)
                answer.Text = "*";
            if (licznik == 2)
                answer.Text = "**";
            if (licznik == 3)
                answer.Text = "***";
            if (licznik == 4)
                answer.Text = "****";

        }

        private void Cancel(object sender, EventArgs e)
        {
            numery[3] = '0';
            licznik = 0;
            answer.Text = "";
        }


        ///
        private void Przelej(object sender, EventArgs e)
        {
            charywpl = 2;
            Menupieniedzy();
            main.Text = "Ile chcesz przekazac\nna cele charytatywne?";
            //piecdziesiat_button.Click += new EventHandler(piecdziesiat_ch);
            //dwiescie_button.Click += new EventHandler(dwiestowki_ch);
            //sto_button.Click += new EventHandler(stowka_ch);
            //powrot.Click += new EventHandler(Powrot);
        }

      

        private void Sprawdz_konto(object sender, EventArgs e)
        {
            string tekst = OpcjadoWyboru.Jakaopcja(stankonta);
            main.Text = tekst + ' ' + karty[IDkarty].pieniadzenakoncie().ToString();
        }

        private void Wyloguj(object sender, EventArgs e)
        {
            licznik = 0;
            string tekst = OpcjadoWyboru.Jakaopcja(wyloguj);
            main.Text = tekst;

            option_one.Enabled = false;
            option_two.Enabled = false;
            option_three.Enabled = false;
            option_four.Enabled = false;

            Card.Enabled = true;
            Card.Text = "Kliknij by wyjąć kartę!";
            Card.Click += new EventHandler(Wyjmijkarte);

            //main.Text = "Aby wyjąć karte\nWcisnij 
        }

        private void Wyplata(object sender, EventArgs e)
        {
            charywpl = 1;
            Menupieniedzy();
            ////piecdziesiat_button.Click += new EventHandler(piecdziesiat);
            //dwiescie_button.Click += new EventHandler(dwiestowki);
            //sto_button.Click += new EventHandler(stowka);
            //powrot.Click += new EventHandler(Powrot);

        }


        ///
        private void Powrot(object sender, EventArgs e)
        {
           /// MessageBox.Show(karty[IDkarty].pieniadzenakoncie().ToString());
            Card.Text = numerkart;
            Card.Enabled = false;
            option_ones.Text = "Wypłata";
            option_twos.Text = "Sprawdz konto";
            option_threes.Text = "Przelej na cele charytatywne";
            option_fours.Text = "Wyloguj";
            option_one.Enabled = true;
            option_two.Enabled = true;
            option_three.Enabled = true;
            option_four.Enabled = true;
            sto_button.Enabled = false;
            dwiescie_button.Enabled = false;
            piecdziesiat_button.Enabled = false;
            powrot.Enabled = false;
            picture.Visible = false;
            picturech.Visible = false;
            //picture.
                

            option_one.Click += new EventHandler(Wyplata);
            option_two.Click += new EventHandler(Sprawdz_konto);
            option_three.Click += new EventHandler(Przelej);
            option_four.Click += new EventHandler(Wyloguj);
        }

        private void stowka(object sender, EventArgs e)
        {

            Pieniadzenieaktywne();
            int kwotanakoncie = karty[IDkarty].pieniadzenakoncie();
            main.Text = wybor.Pieniadztekst(stowka_klasa, kwotanakoncie);
            if(wybor.PieniadzeCzySaNaKoncie(stowka_klasa,kwotanakoncie)==true)
            {
                karty[IDkarty].wybraniepieniedzy(100);
                if(charywpl==1)
                {
                     Potwierdzenie();
                    main.Text = "Czy wydrukować potwierdzenie?";
                    kwota = 100; 
                }
                else
                {
                    
                    main.Text = "Dziekuje";
                    CeleCharytatywne();
                }
                      
            }
            
            
              

        }

        private void dwiestowki(object sender, EventArgs e)
        {
            Pieniadzenieaktywne();
            int kwotanakoncie = karty[IDkarty].pieniadzenakoncie();
            main.Text = wybor.Pieniadztekst(dwiestowki_klasa, kwotanakoncie);
            if (wybor.PieniadzeCzySaNaKoncie(dwiestowki_klasa, kwotanakoncie) == true)
            {
                karty[IDkarty].wybraniepieniedzy(200);
                if (charywpl == 1)
                {
                    Potwierdzenie();
                    main.Text = "Czy wydrukować potwierdzenie?";
                    kwota = 200;
                }
                else
                {
                    
                    main.Text = "Dziekuje";
                    CeleCharytatywne();
                }
            }
           
        }

        private void piecdziesiat(object sender, EventArgs e)
        {
            Pieniadzenieaktywne();
            int kwotanakoncie = karty[IDkarty].pieniadzenakoncie();
            main.Text = wybor.Pieniadztekst(piecdziesiatka_klasa, kwotanakoncie);
            if (wybor.PieniadzeCzySaNaKoncie(piecdziesiatka_klasa, kwotanakoncie) == true)
            {
             
              karty[IDkarty].wybraniepieniedzy(50);
                if (charywpl == 1)
                {
                    Potwierdzenie();
                    main.Text = "Czy wydrukować potwierdzenie?";
                    kwota = 50;
                }
                else
                {
                    main.Text = "Dziekuje";
                    CeleCharytatywne();
                }

            }
            
        }

        // 
       
        private void Wyjmijkarte(object sender, EventArgs e)
        {
            //main.Text = "Witamy w Banku!\nWłóż kartę.";
            Card.Text = "OK";
            numerkarty.Enabled = true;
            //Card.Click += new EventHandler(CreditCard);
            //Card.Text = "OK";
        }

        ///
        private void NIEE(object sender, EventArgs e)
        {
            main.Text = niedrukuje.Operacja(kwota);//"Nie drukuje";
            TAK.Enabled = false;
            NIE.Enabled = false;
            sto_button.Enabled = false;
            dwiescie_button.Enabled = false;
            piecdziesiat_button.Enabled = false;
            powrot.Enabled = true;
            picture.Visible = true;
            // Thread.Sleep(2000);
            //picture.Visible = false;
            

        }

        private void TAKK(object sender, EventArgs e)
        {
            
            main.Text = drukuje.Operacja(kwota);//"drukuje";
            TAK.Enabled = false;
            NIE.Enabled = false;
            sto_button.Enabled = false;
            dwiescie_button.Enabled = false;
            piecdziesiat_button.Enabled = false;
            powrot.Enabled = true;
            picture.Visible = true;
           

        }
        //
        private void endprogram(object sender, EventArgs e)
    {
        System.Windows.Forms.Application.Exit();
    }

        //
        private void Menupieniedzy()
        {
            // main.Text = "Czy wydrukowac potwierdzenie?";
            sto_button.Enabled = true;
            dwiescie_button.Enabled = true;
            piecdziesiat_button.Enabled = true;
            powrot.Enabled = true;

            option_one.Enabled = false;
            option_two.Enabled = false;
            option_three.Enabled = false;
            option_four.Enabled = false;
        }//niezrobione eszcze - wydruki i inne
        private void Potwierdzenie()
        {
            TAK.Enabled = true;
            NIE.Enabled = true;

            sto_button.Enabled = false;
            dwiescie_button.Enabled = false;
            piecdziesiat_button.Enabled = false;
            powrot.Enabled = false;

            option_one.Enabled = false;
            option_two.Enabled = false;
            option_three.Enabled = false;
            option_four.Enabled = false;

            TAK.Click += new EventHandler(TAKK);
            NIE.Click += new EventHandler(NIEE);
        }
        private void Pieniadzenieaktywne()
        {
            sto_button.Enabled = false;
            dwiescie_button.Enabled = false;
            piecdziesiat_button.Enabled = false;
            powrot.Enabled = true;

            TAK.Enabled = false;
            NIE.Enabled = false;

        }

        private void CeleCharytatywne()
        {
            picturech.Visible = true;
        }

       
    }
}

