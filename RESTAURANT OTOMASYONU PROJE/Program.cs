using System;
using System.Collections.Generic;

class Restaurant
{
    private List<List<string>> tables = new List<List<string>>(new List<string>[5]);
    private Dictionary<string, string> menu = new Dictionary<string, string>
    {
        {"1", "Pizza"},
        {"2", "Hamburger"},
        {"3", "Salata"},
        {"4", "Pasta"},
        {"5", "Su"}
    };

    public void MainMenu()
    {
        while (true)
        {
            Console.WriteLine("\n******** ANAMENU ********");
            Console.WriteLine("1 - Sipariş Al");
            Console.WriteLine("2 - Hesap Al");
            Console.WriteLine("3 - Menü Düzenle");
            Console.WriteLine("4 - Çıkış");
            Console.Write("Seçiminizi yapın: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    TakeOrder();
                    break;
                case "2":
                    GetBill();
                    break;
                case "3":
                    EditMenu();
                    break;
                case "4":
                    Console.WriteLine("Çıkılıyor...");
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");
                    break;
            }
        }
    }

    private void TakeOrder()
    {
        for (int i = 0; i < tables.Count; i++)
        {
            if (tables[i] == null) // Boş masa
            {
                tables[i] = new List<string>();
                Console.Write($"{i + 1}. masa için kaç kişisiniz? ");
                int numberOfGuests = int.Parse(Console.ReadLine());

                for (int j = 0; j < numberOfGuests; j++)
                {
                    GetGuestOrder(i + 1, j + 1);
                }
                Console.WriteLine($"{i + 1}. masa siparişleri alındı.");
                break;
            }
        }
    }

    private void GetGuestOrder(int tableNumber, int guestNumber)
    {
        Console.WriteLine($"{tableNumber}. masa, {guestNumber}. müşteri için sipariş alınıyor.");
        while (true)
        {
            Console.WriteLine("\nMenü:");
            foreach (var item in menu)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            Console.Write("Seçiminizi yapın (çıkmak için 'q'): ");
            string choice = Console.ReadLine();

            if (menu.ContainsKey(choice))
            {
                tables[tableNumber - 1].Add(menu[choice]);
                Console.WriteLine($"{menu[choice]} sipariş alındı.");
            }
            else if (choice == "q")
            {
                break;
            }
            else
            {
                Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");
            }

            Console.Write("Başka bir arzunuz var mı? (Evet/Hayır): ");
            string more = Console.ReadLine().ToLower();
            if (more != "evet")
            {
                break;
            }
        }
    }

    private void GetBill()
    {
        Console.WriteLine("Hesap işlemleri henüz tanımlanmadı.");
    }

    private void EditMenu()
    {
        Console.WriteLine("Menü düzenleme işlemleri henüz tanımlanmadı.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Restaurant restaurant = new Restaurant();
        restaurant.MainMenu();
    }
}
