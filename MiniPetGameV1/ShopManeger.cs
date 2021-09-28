using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MiniPetGameV1
{
    class ShopManeger
    {
       public List<Item> ItemList;

      public List<Item> Iteam()
        {
            Item Weapon1 = new Item();
            Weapon1.ItemId = 1;
            Weapon1.Price = 250;
            Weapon1.Type = "Weapon";
            Weapon1.Damage = 20;
            Weapon1.Name = "Bronz Kılıç";

            Item Weapon2 = new Item();
            Weapon2.ItemId = 2;
            Weapon2.Price = 400;
            Weapon2.Type = "Weapon";
            Weapon2.Damage = 40;
            Weapon2.Name = "Gümüş Kılıç";

            

            
          

            ItemList = new List<Item>() { Weapon1, Weapon2};
            return ItemList;
        }

        public void ShowIteam(int Coin)
        {
            Iteam();
            Console.WriteLine("---> Dükkana Hoş geldin <----\n");
            Console.WriteLine("Paranız: "+ Coin);
            Console.WriteLine("Ekipmanlar:");

            foreach (var Item in ItemList)
            {
                Console.WriteLine(Item.ItemId + "." + " " + Item.Name + " " +"Fiyatı: "+ Item.Price);
            }
            Console.WriteLine("\n");
        }
        public void purchaseItem(Pet p1)
        {
            Iteam();
            Console.Write("Almak isteğiniz ürünü girin : ");
            byte GetItem =Convert.ToByte( Console.ReadLine());
            var GetPrice = from s in ItemList where s.ItemId == GetItem select s.Price;
            if (p1.Coin>=GetPrice.FirstOrDefault() && ItemList.Count() > GetItem )
            {
                p1.inventory.Add(ItemList[GetItem - 1]);
                p1.Coin -= GetPrice.FirstOrDefault();
                Console.WriteLine("Paranız: " + p1.Coin);
                Console.WriteLine("Satın alma işlem gerçekleşmiştir");
            }
            else
            {
                Console.WriteLine("Almak istediğiniz Ürün numarasının doğru girdinize ya da paranıza dikkat edin..");
            }
        }
    }
}
