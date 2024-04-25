using System;
using System.Drawing;

namespace Bitva_Polcovodcev
{
    public class Dannie
    {
        //Цвѣта карты
        public Color granica = Color.FromArgb(255, 0, 0, 0);
        public Color more = Color.FromArgb(255, 12, 74, 127);
        public Color gori = Color.FromArgb(255, 64, 64, 64);
        public Color pustota = Color.FromArgb(0, 0, 0, 0);

        //Цвѣта для Типовъ Территорій
        public Color beli = Color.FromArgb(255, 255, 255, 255);

        //Цѣна захвата территорій разного Типа
        public int cenaZahvataTerritorii = 2;
        public int cenaZahvataPorta = 5;
        public int cenaZahvataKreposti = 10;
        public int cenaZahvataKrepostiSPortom = 15;

        //Ответы Игры на некоторые дейтсвія Игрока
        public String MaloOD = "Вамъ не хватаетъ Очковъ Действiй";

        public String[] tip =
        {
            "Нулевой Игрокъ",
            "Живой Игрокъ",
            "Искусственный Противникъ"
        };

        //Въ будущемъ этотъ классъ долженъ хранить данныя о сценаріяхъ (Возможно станетъ частью класса Карта)
        public string imaScenaria = "Проба";
        public int cenaZahvataKarti = 18;
    }
}
