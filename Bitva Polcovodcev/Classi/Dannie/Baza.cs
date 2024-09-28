using System;
using System.Drawing;

namespace Bitva_Polcovodcev
{
    public class Baza
    {
        //Цвѣта карты
        public static Color granica = Color.FromArgb(255, 0, 0, 0);
        public static Color more = Color.FromArgb(255, 12, 74, 127);
        public static Color gori = Color.FromArgb(255, 64, 64, 64);
        public static Color pustota = Color.FromArgb(0, 0, 0, 0);

        //Цвѣта для Типовъ Территорій
        public static Color beli = Color.FromArgb(255, 255, 255, 255);

        //Цѣна захвата территорій разного Типа
        public static int cenaZahvataTerritorii = 2;
        public static int cenaZahvataPorta = 5;
        public static int cenaZahvataKreposti = 10;
        public static int cenaZahvataKrepostiSPortom = 15;

        //Ответы Игры на некоторые действія Игрока
        public static String MaloOD = "Вамъ не хватаетъ Очковъ Действiй";

        public static String[] tip =
        {
            "Нулевой Игрокъ",
            "Живой Игрокъ",
            "Искусственный Противникъ"
        };

        //Въ будущемъ этотъ классъ долженъ хранить данныя о сценаріяхъ (Возможно станетъ частью класса Карта)
        public static String[,] scenarii = 
        {
            { "Проба", "18", "9", "5", "IgrokData_Proba.json", "TerritoriiData_Proba.json" },
            { "Битва за Островъ", "40", "20", "7", "IgrokData_BitvaZaOstrov.json", "TerritoriiData_BitvaZaOstrov.json" }
        };
    }
}
