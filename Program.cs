namespace Odev1
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Console.WriteLine("Kaç öğrenci kaydetmek istiyorsunuz?");
                    int ogrenciSayisi = int.Parse(Console.ReadLine());

                    string[,] ogrenci = new string[ogrenciSayisi, 6]; 

                    for (int i = 0; i < ogrenciSayisi; i++)
                    {
                        Console.WriteLine($"Öğrenci {i + 1}");
                        ogrenci[i, 0] = GecerliOgrenciNumarasi();
                        Console.Write("İsim: ");
                        ogrenci[i, 1] = Console.ReadLine();
                        Console.Write("Soyisim: ");
                        ogrenci[i, 2] = Console.ReadLine();
                        ogrenci[i, 3] = GecerliNot("Vize").ToString();
                        ogrenci[i, 4] = GecerliNot("Final").ToString();
                        double ortalama = (double.Parse(ogrenci[i, 3]) * 0.4) + (double.Parse(ogrenci[i, 4]) * 0.6);
                        ogrenci[i, 5] = HarfNotuBelirle(ortalama);
                    }

                    SonuclariYazdir(ogrenci, ogrenciSayisi);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata: {ex.Message}");
                }
            }

            static string GecerliOgrenciNumarasi()
            {
                string numara;
                while (true)
                {
                    Console.Write("Öğrenci Numarası (11 haneli): ");
                    numara = Console.ReadLine();
                    if (numara.Length == 11 && long.TryParse(numara, out _))
                    {
                        return numara;
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz öğrenci numarası. Lütfen 11 haneli bir sayı girin.");
                    }
                }
            }

            static double GecerliNot(string sinavAdi)
            {
                double not;
                while (true)
                {
                    Console.Write($"{sinavAdi} Notu (0-100): ");
                    if (double.TryParse(Console.ReadLine(), out not) && not >= 0 && not <= 100)
                    {
                        return not;
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz not girişi. Lütfen 0-100 arasında bir değer girin.");
                    }
                }
            }

            static string HarfNotuBelirle(double ortalama)
            {
                if (ortalama >= 85) return "AA";
                if (ortalama >= 75) return "BA";
                if (ortalama >= 60) return "BB";
                if (ortalama >= 50) return "CB";
                if (ortalama >= 40) return "CC";
                if (ortalama >= 30) return "DC";
                if (ortalama >= 20) return "DD";
                if (ortalama >= 10) return "FD";
                return "FF";
            }
      
            static void SonuclariYazdir(string[,] ogrenciler, int ogrenciSayisi)
            {
                Console.WriteLine("\nÖğrenci Listesi:");
                Console.WriteLine("No\t\tİsim\t\tSoyisim\t\tVize\tFinal\tHarf Notu");

                double toplamOrtalama = 0;
                double enYuksekNot = double.MinValue;
                double enDusukNot = double.MaxValue;

                for (int i = 0; i < ogrenciSayisi; i++)
                {
                    double vize = double.Parse(ogrenciler[i, 3]);
                    double final = double.Parse(ogrenciler[i, 4]);
                    double ortalama = (vize * 0.4) + (final * 0.6);
                    toplamOrtalama += ortalama;

                    if (ortalama > enYuksekNot) enYuksekNot = ortalama;
                    if (ortalama < enDusukNot) enDusukNot = ortalama;

                    Console.WriteLine($"{ogrenciler[i, 0]}\t{ogrenciler[i, 1]}\t{ogrenciler[i, 2]}\t{ogrenciler[i, 3]}\t{ogrenciler[i, 4]}\t{ogrenciler[i, 5]}");
                }

                double sinifOrtalamasi = toplamOrtalama / ogrenciSayisi;
                Console.WriteLine($"\nSınıf Ortalaması: {sinifOrtalamasi:F2}");
                Console.WriteLine($"En Yüksek Not: {enYuksekNot:F2}");
                Console.WriteLine($"En Düşük Not: {enDusukNot:F2}");
            }
        }
    }


   
