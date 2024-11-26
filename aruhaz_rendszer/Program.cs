using System;

namespace aruhaz_rendszer
{
    internal class Program
    {
        static string[] raktarTermekek = new string[] {"kenyér", "rizs", "tészta", "paradicsom"};
        static int[] termekAr =new int[] {1000, 1500, 2000, 500};
        static int[] raktarMennyisegek =new int[] {100, 45, 35, 22};


        static List<string> kosar = new List<string>();
        static List<int> mennyisegek = new List<int>();
        static void Main(string[] args)
        {
                bool fut = true;
                while (fut == true)
                {
                    Console.WriteLine("Áruház rendszer");
                    Console.WriteLine("1. Termékek megjelenítése a raktárból");
                    Console.WriteLine("2. Termék hozzáadása a kosárhoz");
                    Console.WriteLine("3. Kosár tartalmának megjelenítése");
                    Console.WriteLine("4. Termék eltávolítása a kosárból");
                    Console.WriteLine("5. Kosár ürítése");
                    Console.WriteLine("6. Vásárlás szimuláció");
                    Console.WriteLine("7. Legdrágább termék a raktárban");
                    Console.WriteLine("8. Legolcsóbb termék a raktárban");
                    Console.WriteLine("9. Kosár statisztika");
                    Console.WriteLine("10. Raktárkészlet ellenőrzése");
                    Console.WriteLine("11. Kosár teljes értéke");
                    Console.WriteLine("12. Új termék felvétele a raktárba");
                    Console.WriteLine("13. Termékek rendezése ár szerint");
                    Console.WriteLine("14. Kilépés");
                    Console.Write("Válassz egy opciót: ");

                    int opcio = Convert.ToInt32(Console.ReadLine());

                    switch (opcio)
                    {
                        case 1:
                            termekMegjelenit();
                            break;
                        case 2:
                            termekKosarba();
                            break;
                        case 3:
                            kosarMegjelenites();
                            break;
                        case 4:
                            termekEltavolitas();
                            break;
                        case 5:
                            kosarUrites();
                            break;
                        case 6:
                            Vasarlas();
                            break;
                        case 7:
                            legdragabb();
                            break;
                        case 8:
                            legolcsobb();
                            break;
                        case 9:
                            statisztika();
                            break;
                        case 10:
                            raktarKeszlet();
                            break;
                        case 11:
                            kosarErtek();
                            break;
                        case 12:
                            Hozzaadas();
                            break;
                        case 13:
                            Rendezes();
                            break;
                        case 14:
                            Console.WriteLine("Kilépés...");
                            fut = false;
                            break;
                        default:
                            Console.WriteLine("Érvénytelen opció!");
                            break;
                    }
                }
        }

        static void termekMegjelenit()
        {
            Console.WriteLine("Termékek a raktárból:");
            for (int i = 0; i < raktarTermekek.Length; i++)
            {
                if (raktarTermekek[i] == null)
                {
                    Console.WriteLine($"- Nincs termék a {i + 1}. helyen.");
                }
                else
                {
                    Console.WriteLine($"- {raktarTermekek[i]} ({termekAr[i]}): {raktarMennyisegek[i]} db");
                }
            }
        }

        static void termekKosarba()
        {
            int mennyiseg = 0;
            Console.Write("Add meg a termék nevét: ");
            string termek = Console.ReadLine();
            if (termek == null)
            {
                Console.WriteLine("A termék neve nem lehet üres!");
                return;
            }

            for (int i = 0; i < raktarTermekek.Length; i++)
            {
                if (termek == raktarTermekek[i])
                {
                    Console.Write("Add meg a mennyiséget: ");
                    mennyiseg = Convert.ToInt32(Console.ReadLine());

                    if (mennyiseg < 0)
                    {
                        Console.WriteLine("A mennyiség nem lehet negatív!");
                        return;
                    }

                    kosar.Add(termek);
                    mennyisegek.Add(mennyiseg);
                    Console.WriteLine("Termék hozzáadva a bevásárlólistához!");
                    return;
                }
            }

            Console.WriteLine("Ez a termék nincs a termékek között.");
            return;
        }

        static void kosarMegjelenites()
        {
            Console.WriteLine("A kosarad termékei:");
            for (int i = 0; i < kosar.Count; i++)
            {
                if (kosar[i] == null)
                {
                    Console.WriteLine($"- Nincs termék a {i + 1}. helyen.");
                }
                else
                {
                    Console.WriteLine($"- {kosar[i]}: {mennyisegek[i]} db");
                }
            }
        }

        static void termekEltavolitas()
        {
            Console.Write("Add meg a törölni kívánt termék nevét: ");
            string termek = Console.ReadLine();
            while (termek == null)
            {
                Console.WriteLine("Érvénytelen.");
                return;
            }

            if (!kosar.Contains(termek))
            {
                Console.WriteLine("Ez a termék nincs a listán!");
            }
            else
            {
                int index = kosar.IndexOf(termek);
                kosar.RemoveAt(index);
                raktarMennyisegek[index] += mennyisegek[index];
                mennyisegek.RemoveAt(index);
                Console.WriteLine("Termék eltávolítva a bevásárlólistáról!");
            }
        }

        static void kosarUrites()
        {
            for (int i = 0; i < kosar.Count; i++)
            {
                kosar.RemoveAt(i);
                raktarMennyisegek[i] += mennyisegek[i];
                mennyisegek.RemoveAt(i);
            }
            Console.WriteLine("Kosár ürítve, mennyiségek visszaadva a raktárhoz.");
        }

        static void Vasarlas()
        {
            int penz = 0;
            Console.WriteLine("Bevásárlás folyamatban...");
            for (int i = 0; i < kosar.Count; i++)
            {
                string termek = kosar[i];
                int mennyiseg = mennyisegek[i];

                int index = Array.IndexOf(raktarTermekek, termek);
                if (index == -1)
                {
                    Console.WriteLine($"Nincs a raktárban: {termek}");
                    continue;
                }

                if (raktarMennyisegek[index] < mennyiseg)
                {
                    Console.WriteLine($"Nincs elég {termek} a raktárban!");
                }
                else
                {
                    raktarMennyisegek[index] -= mennyiseg;
                    penz += termekAr[index];
                    Console.WriteLine($"Sikeresen megvásárolt: {termek} ({termekAr[index]}), {mennyiseg} db.");
                }
            }

            Console.WriteLine($"A termékekért fizetett pontos összeg: {penz} ft.");
            kosar.Clear();
        }

        static void legdragabb()
        {
            int legdragabb = termekAr[0];
            int index = 0;
            for (int i = 0; i < raktarTermekek.Length; i++)
            {
                if (termekAr[i] > legdragabb)
                {
                    legdragabb = termekAr[i];
                    index = i;
                }
            }
            Console.WriteLine($"A legdrágább termék: {raktarTermekek[index]} ({termekAr[index]})");
        }

        static void legolcsobb()
        {
            int legolcsobb = termekAr[0];
            int index = 0;
            for (int i = 0; i < raktarTermekek.Length; i++)
            {
                if (termekAr[i] < legolcsobb)
                {
                    legolcsobb = termekAr[i];
                    index = i;
                }
            }
            Console.WriteLine($"A legolcsóbb termék: {raktarTermekek[index]} ({termekAr[index]})");
        }

        static void statisztika()
        {
            int ossz = 0;
            for (int i = 0; i < mennyisegek.Count; i++)
            {
                ossz += mennyisegek[i];
            }
            Console.WriteLine($"Jelenleg {ossz} darab termék van a kosárban, és ezek közül {kosar.Count()} db termék különböző.");
        }

        static void raktarKeszlet()
        {
            for (int i = 0; i < raktarTermekek.Length; i++)
            {
                if (raktarMennyisegek[i] < 5)
                {
                    Console.WriteLine($"Vigyázz, a {raktarTermekek[i]} raktárban fellelhető száma kevesebb mint 5.");
                }
            }
        }

        static void kosarErtek()
        {
            int penz = 0;
            for (int i = 0; i < kosar.Count; i++)
            {
                string termek = kosar[i];
                int mennyiseg = mennyisegek[i];

                int index = Array.IndexOf(raktarTermekek, termek);
                if (index == -1)
                {
                    continue;
                }

                else
                {
                    penz += termekAr[index];
                }
            }
            Console.WriteLine($"A kosarad értéke: {penz} ft");
        }

        static void Hozzaadas()
        {
            Console.Write("Add meg a termék nevét: ");
            string termek = Console.ReadLine();
            if (termek == null)
            {
                Console.WriteLine("A termék neve nem lehet üres!");
                return;
            }

            Console.Write("Add meg a mennyiséget: ");
            int mennyiseg = Convert.ToInt32(Console.ReadLine());

            if (mennyiseg < 0)
            {
                Console.WriteLine("A mennyiség nem lehet negatív!");
                return;
            }

            Console.Write("Add meg az árát: ");
            int ar = Convert.ToInt32(Console.ReadLine());

            if (ar < 0)
            {
                Console.WriteLine("A mennyiség nem lehet negatív!");
                return;
            }

            if (raktarTermekek.Length < 11)
            {
                raktarTermekek = raktarTermekek.Concat(new string[] {termek}).ToArray();
                raktarMennyisegek = raktarMennyisegek.Concat(new int[] { mennyiseg }).ToArray();
                termekAr = termekAr.Concat(new int[] { ar }).ToArray();
                Console.WriteLine("Termék hozzáadva a raktárhoz!");
            } else
            {
                Console.WriteLine("A raktár meg van telve.");
            }
            
        }

        static void Rendezes()
        {
            Console.WriteLine("Termékek rendezése ár szerint:");
        }
    }
}
