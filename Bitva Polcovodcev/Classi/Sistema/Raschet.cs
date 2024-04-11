using Bitva_Polcovodcev.Classi.Dannie;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bitva_Polcovodcev
{
    public class Raschet
    {
        Dannie dannie = new Dannie();

        public void SmenaIgroka(List<Igrok> listClassIgrok, ref int NomerIgroka, ref Label labelNazvanie, ref Label labelOD, ref PictureBox pictureFlag, ref PictureBox pictureBrosok, Button buttonBrosok, Button buttonHod, Panel panelInterfeis, ref Color IgrokCvet, bool boolZagruzca)
        {
            if (!boolZagruzca)
            {
                if (NomerIgroka < listClassIgrok.Count - 1) NomerIgroka++;
                else
                {
                    if (listClassIgrok[0].Tip != dannie.tip[0]) NomerIgroka = 0;
                    else NomerIgroka = 1;
                }
            }

            //Пока нѣтъ ИП его ходъ будетъ пропускатся
            while (listClassIgrok[NomerIgroka].Tip == dannie.tip[2])
            {
                if (NomerIgroka < listClassIgrok.Count - 1) NomerIgroka++;
                else
                {
                    if (listClassIgrok[0].Tip != dannie.tip[0]) NomerIgroka = 0;
                    else NomerIgroka = 1;
                }
            }

            while (!listClassIgrok[NomerIgroka].JivLi || listClassIgrok[NomerIgroka].Tip == dannie.tip[0])
            {
                if (NomerIgroka < listClassIgrok.Count - 1) NomerIgroka++;
                else
                {
                    if (listClassIgrok[0].Tip != dannie.tip[0]) NomerIgroka = 0;
                    else NomerIgroka = 1;
                }
            }

            pictureFlag.BackColor = listClassIgrok[NomerIgroka].Cvet;//Пока такъ, дальше догружать флагъ
            labelNazvanie.Text = listClassIgrok[NomerIgroka].Ima;
            labelNazvanie.Location = new Point(panelInterfeis.Width / 2 - labelNazvanie.Width / 2, pictureFlag.Height + 5);
            labelOD.Text = "ОД " + listClassIgrok[NomerIgroka].KolicestvoOD;
            labelOD.Location = new Point(panelInterfeis.Width / 2 - labelOD.Width / 2, buttonBrosok.Location.Y + buttonBrosok.Height + 5);
            pictureBrosok.Image = Properties.Resources.Niet;
            buttonBrosok.Enabled = true;
            buttonHod.Enabled = false;

            IgrokCvet = listClassIgrok[NomerIgroka].Cvet;
        }

        public void Raspredelenie_Rolei(List<Roli> listClassRoli, List<Igrok> listClassIgrok)
        {
            for (int i = 0; i < listClassIgrok.Count; i++)
            {
                //if (listClassRoli[0].Igroki.Contains(listClassIgrok[i].Nomer) && listClassRoli[4].Igroki.Contains(listClassIgrok[i].Nomer)) listClassRoli[4].Igroki.Remove(listClassIgrok[i].Nomer);

                if (listClassIgrok[i].Tip != dannie.tip[0])
                {
                    //Работа съ Гегемономъ
                    if (listClassRoli[1].Igroki.Count == 0)
                    {
                        listClassIgrok[i].Rol = listClassRoli[1].Ima;
                        listClassRoli[1].Igroki.Add(listClassIgrok[i].Nomer);
                    }
                    else if (listClassIgrok[i].CenaZahvata > listClassIgrok[listClassIgrok.FindIndex(list => int.Equals(list.Nomer, listClassRoli[1].Igroki[0]))].CenaZahvata)
                    {
                        int nomerProslogoGegemona = listClassRoli[1].Igroki[0];
                        listClassRoli[1].Igroki[0] = listClassIgrok[i].Nomer;
                        listClassRoli[2].Igroki.Remove(listClassIgrok[i].Nomer);
                        listClassIgrok[i].Rol = listClassRoli[1].Ima;

                        i = listClassIgrok.FindIndex(list => int.Equals(list.Nomer, nomerProslogoGegemona));
                        listClassIgrok[i].Rol = listClassRoli[2].Ima;
                    }

                    if (listClassIgrok[i].Rol == listClassRoli[1].Ima) continue;

                    int indexGegemona = listClassIgrok.FindIndex(list => int.Equals(list.Nomer, listClassRoli[1].Igroki[0]));

                    //Работа съ Соперникомъ
                    if (listClassIgrok[i].CenaZahvata <= listClassIgrok[indexGegemona].CenaZahvata && listClassIgrok[i].CenaZahvata >= listClassIgrok[indexGegemona].CenaZahvata - listClassIgrok[indexGegemona].CenaZahvata / 10 && !listClassRoli[2].Igroki.Contains(listClassIgrok[i].Nomer))
                    {
                        listClassIgrok[i].Rol = listClassRoli[2].Ima;
                        listClassRoli[2].Igroki.Add(listClassIgrok[i].Nomer);
                    }
                    else if (listClassIgrok[i].CenaZahvata <= listClassIgrok[indexGegemona].CenaZahvata - listClassIgrok[indexGegemona].CenaZahvata / 10 && listClassRoli[2].Igroki.Contains(listClassIgrok[i].Nomer)) listClassRoli[2].Igroki.Remove(listClassIgrok[i].Nomer);

                    //Работа съ Середнякомъ
                    if (listClassIgrok[i].CenaZahvata < listClassIgrok[indexGegemona].CenaZahvata - listClassIgrok[indexGegemona].CenaZahvata / 10 && listClassIgrok[i].CenaZahvata > listClassIgrok[indexGegemona].CenaZahvata / 10 && !listClassRoli[3].Igroki.Contains(listClassIgrok[i].Nomer))
                    {
                        listClassIgrok[i].Rol = listClassRoli[3].Ima;
                        listClassRoli[3].Igroki.Add(listClassIgrok[i].Nomer);
                    }
                    else if ((listClassIgrok[i].CenaZahvata <= listClassIgrok[indexGegemona].CenaZahvata / 10 || listClassIgrok[i].CenaZahvata >= listClassIgrok[indexGegemona].CenaZahvata - listClassIgrok[indexGegemona].CenaZahvata / 10) && listClassRoli[3].Igroki.Contains(listClassIgrok[i].Nomer)) listClassRoli[3].Igroki.Remove(listClassIgrok[i].Nomer);

                    //Работа съ Изгоемъ
                    if (listClassIgrok[i].CenaZahvata <= listClassIgrok[indexGegemona].CenaZahvata / 10 && listClassIgrok[i].CenaZahvata > 0 && !listClassRoli[4].Igroki.Contains(listClassIgrok[i].Nomer))
                    {
                        listClassIgrok[i].Rol = listClassRoli[4].Ima;
                        listClassRoli[4].Igroki.Add(listClassIgrok[i].Nomer);
                    }
                    else if ((listClassIgrok[i].CenaZahvata > listClassIgrok[indexGegemona].CenaZahvata / 10 || listClassIgrok[i].CenaZahvata < 0) && listClassRoli[4].Igroki.Contains(listClassIgrok[i].Nomer)) listClassRoli[4].Igroki.Remove(listClassIgrok[i].Nomer);
                }
                else if (!listClassRoli[0].Igroki.Contains(listClassIgrok[i].Nomer)) listClassRoli[0].Igroki.Add(listClassIgrok[i].Nomer);
            }

            Sortirovka_Spiskov_Rolei(listClassRoli, listClassIgrok);
        }

        public void Sortirovka_Spiskov_Rolei(List<Roli> listClassRoli, List<Igrok> listClassIgrok)
        {
            int nomerElementa = 0;
            if (listClassRoli[2].Igroki.Count > 1)
            {
                var sortirovkaKonkurenta = listClassRoli[2].Igroki.OrderByDescending(nomer => listClassIgrok[listClassIgrok.FindIndex(spisok => int.Equals(spisok.Nomer, nomer))].CenaZahvata);
                foreach (var i in sortirovkaKonkurenta)
                {
                    listClassRoli[2].Igroki[nomerElementa] = i;
                    nomerElementa++;
                }
            }

            nomerElementa = 0;
            if (listClassRoli[3].Igroki.Count > 1)
            {
                var sortirovkaSerednauk = listClassRoli[3].Igroki.OrderByDescending(nomer => listClassIgrok[listClassIgrok.FindIndex(spisok => int.Equals(spisok.Nomer, nomer))].CenaZahvata);
                foreach (var i in sortirovkaSerednauk)
                {
                    listClassRoli[3].Igroki[nomerElementa] = i;
                    nomerElementa++;
                }
            }

            nomerElementa = 0;
            if (listClassRoli[4].Igroki.Count > 1)
            {
                var sortirovkaIzgoi = listClassRoli[4].Igroki.OrderByDescending(nomer => listClassIgrok[listClassIgrok.FindIndex(spisok => int.Equals(spisok.Nomer, nomer))].CenaZahvata);
                foreach (var i in sortirovkaIzgoi)
                {
                    listClassRoli[4].Igroki[nomerElementa] = i;
                    nomerElementa++;
                }
            }

        }
    }
}
