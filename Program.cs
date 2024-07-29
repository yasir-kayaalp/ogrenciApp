namespace ögrenciApp
{
    internal class Program
    {
        static List<Ogrenci> Ogrenciler = new List<Ogrenci>();
        static int counter = Ogrenciler.Count + 1;
        static void Main(string[] args)
        {












            Uygulama();
          




        }
        static void Uygulama()
        {
            Menu();
            SecimAl();
        }
        static void SecimAl()
        {
            int counter = 0;

        Main:
            int counterA = 9 - counter;
            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine().ToUpper();
            switch (secim)
            {
                case "1":
                case "E":
                    Ekle();
                    break;
                case "2":
                case "L":
                    Listele();
                    break;
                case "3":
                case "S":
                    Sil();
                    break;
                case "X":
                case "4":
                    Console.WriteLine("Çıktınız...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Yanlış Bir Seçim Yaptınız, Tekrar Deneyin... " + counterA + " Deneme Hakkınız Kaldı");
                    counter++;
                    if (counter == 10)
                    {
                        Console.WriteLine("Çok Fazla Hatalı Giriş, Program Sonlandırılıyor...");
                        Environment.Exit(0);
                    }
                    goto Main;
                    break;
            }
            goto Main;

        }
        static void Menu()
        {
            Console.WriteLine("Öğrenci Yönetim Uygulaması");
            Console.WriteLine("1. Öğrenci Ekle (E)");
            Console.WriteLine("2. Öğrenci Listele (L)");
            Console.WriteLine("3. Öğrenci Sil (S)");
            Console.WriteLine("4. Çıkış (X)");
        }
        static void Ekle()
        {



            Ogrenci o = new Ogrenci();
            Console.WriteLine("----------Öğrenci Ekle----------");
            Console.WriteLine(counter + ". Öğrencinin: ");
            bool noVarMi;
            int no;
            do
            {
                
                Console.Write("No ");
                no = int.Parse(Console.ReadLine());
                
                noVarMi = Ogrenciler.Any(ogr => ogr.No == no);
                if (noVarMi)
                {
                    Console.WriteLine(" Bu Öğrenci Numarası Zaten Kayıtlı.. Tekrar Deneyin");
                }

            } while (noVarMi);
            o.No = no;
            Console.Write("Adı: ");
            o.Ad = ilkHarf(Console.ReadLine())/*.Substring(0,1).ToUpper().Substring(1).ToLower()*/;
            Console.Write("Soyadı: ");
            o.Soyad = ilkHarf(Console.ReadLine())/*.Substring(0, 1).ToUpper().Substring(1).ToLower()*/;
            Console.Write("Subesi: ");
            o.Sube = Console.ReadLine().ToUpper();
        Cevap:
            Console.WriteLine("Öğrenciyi Kaydetmek İstediğinize Emin misiniz? (E/H");
            string cevap = Console.ReadLine().ToUpper();
            switch (cevap)
            {
                case "E":
                    Ogrenciler.Add(o);
                    Console.WriteLine("Öğrenci Eklendi..");
                    break;
                case "H":
                    Console.WriteLine("öğrenci Eklenmedi...");
                    break;
                default:
                    Console.WriteLine("Tekrar Deneyin...");
                    goto Cevap;
                    break;
            }

            counter++;


        }
        static void Listele()
        {
            if (Ogrenciler.Count == 0)
            {
                Console.WriteLine("Gösterilecek öğrenci yok.");

            }
            else
            {
                Console.WriteLine(Hizala("Öğrenci Listesi",70));
                Console.WriteLine("-".PadRight(70, '-').PadLeft(70, '-'));
            
                Console.Write(Hizala("AD", 20));
                Console.Write(Hizala("SOYAD", 20));
                Console.Write(Hizala("ŞUBE", 20));
                Console.Write("NO");
                Console.WriteLine();
                Console.WriteLine("-".PadRight(70, '-').PadLeft(70,'-'));
                foreach (Ogrenci item in Ogrenciler)
                {
                    Console.WriteLine(Hizala(item.Ad, 20)  + Hizala(item.Soyad, 20) + Hizala(item.Sube, 20) + item.No);
                }
            }
        }
        static void Sil()
        {

            if (Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede silinecek öğrenci bulunamadı.");
                return;
            }
            else
            {
                Console.Write("Silmek istediğiniz Öğrencinin Numarasını Girin: ");
                int cevap = int.Parse(Console.ReadLine());
                Ogrenci o = null;
                foreach (var item in Ogrenciler)
                {
                    if (cevap == item.No)
                    {
                        o = item;

                    }

                }
                if (o != null)
                {
                    Console.WriteLine("Öğrencinin Adı: " + o.Ad);
                    Console.WriteLine("Öğrencinin Soyad: " + o.Soyad);
                    Console.WriteLine("Öğrencinin Subes: " + o.Sube);
                    Console.WriteLine("Öğrenciyi Silmek İstediğinize Emin misiniz? ");
                    string giris = Console.ReadLine().ToUpper();
                    if (giris == "E")
                    {
                        Ogrenciler.Remove(o);
                        Console.WriteLine("Öğrenci Silindi");
                    }
                    else
                    {
                        Console.WriteLine("Öğrenci Silinmedi");
                    }


                }
            }
        }
        static string ilkHarf(string item)
        {

            return char.ToUpper(item[0]) + item.Substring(1).ToLower();


        }
        static string Hizala(string item, int totalWidth)
        {
            int padLeft = (totalWidth - item.Length) / 2 + item.Length;
            int padRight = totalWidth;
            item = item.PadLeft(padLeft).PadRight(padRight);
            return item;
        }
        static int HizalaINT(int item, int totalWidth)
        {
            string itemString = Convert.ToString(item);
            int padLeft = (totalWidth - itemString.Length) / 2 + itemString.Length;
            int padRight = totalWidth;
            itemString = itemString.PadLeft(padLeft).PadRight(padRight);
            return Convert.ToInt32(itemString);
        }


        

    }
}

