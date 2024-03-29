﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using System.Text.RegularExpressions;

namespace MiniPetGameV1
{
    class PetMenager : ShopManeger
    {
        byte Selection;
        public static string backToMenu = "\n Menüye Dönülüyor";
        public List<Pet> petList;
        Pet p1;
        FightMenager fMenager;
        ShopManeger sManager;
        List<string> Menu = new List<string>();
        public PetMenager()
        {
            sManager = new ShopManeger();
            fMenager = new FightMenager();
            petList = new List<Pet>();

            Console.WriteLine("----> Evcil hayvan oyununa hoş geldiniz <----\n");
            Console.WriteLine("----> Bu Proje tamamen eğlence  amaçlı yapılmış açık kaynak bir projedir. Tur mantığı düşünülerek kodlanmıştır. her yaptığınız eylem bitişinde 1 gün geçer ve açıkır, susarsınız. <----\n");

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Menu.Add("1. Hayvanının durumuna bak.");
            Menu.Add("2. Hayvanına yemek ver.");
            Menu.Add("3. Hayvanına su ver.");
            Menu.Add("4. Dükkana git.");
            Menu.Add("5. Envantere bak");
            Menu.Add("6. Savaşa gir.");
            Menu.Add("7. Doktora git.\n");
        }
        public bool addNewPet()
        {
            p1 = new Pet();
            RestartGame:
            try
            {
                p1.inventory = new List<Item>();
                Console.Write("Hayvan oluşturmaya Hayvanına bir isim ver. (En az 2 karakter): ");
                p1.PetName = Console.ReadLine();

                if (p1.PetName.Length >= 2 && !Regex.IsMatch(p1.PetName, @"\d"))
                {
                    p1.Heart = 100;
                    p1.isHungary = 100;
                    p1.isThirsty = 100;
                    p1.Lvl = 1;
                    p1.Xp = 0;  
                    p1.TargetLvl = 100;
                    p1.Coin = 250;

                    Console.WriteLine("Evcil hayvanınız oluşturuldu, Hoş geldin" + " " + p1.PetName + "\n");
                    petList.Add(p1);
                    return true;
                }
                else
                {
                    Console.WriteLine("Hayvanınız en az 2 karakter olması gerekiyor.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Satace sayı giriniz !!!");
                Thread.Sleep(3000);
            }

            goto RestartGame;


        }

        public void pMenu()
        {
        BackToMemu:
            try
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("---> Menü <----\n");

                    foreach (var element in Menu)
                    {
                        Console.WriteLine(element);
                    }

                    Console.Write("seçim Yapın: ");
                    Selection = Convert.ToByte(Console.ReadLine());

                    switch (Selection)
                    {
                        case 1:
                            showPetStats(p1);

                            break;
                        case 2:
                            giveLunch();
                            break;
                        case 3:
                            giveWater();
                            break;
                        case 4:
                            isPurchaseItem();
                            break;
                        case 5:
                            showInventory();
                            break;
                        case 6:
                            enterArea();
                            break;
                        case 7:
                            doctor();
                            break;

                        default:
                            Console.WriteLine("Böyle bir işlem yok, 1-6 arasında sayı giriniz");
                            pMenu();
                            break;
                    }
                } while (Selection != 8);
            }
            catch (Exception)
            {
                Console.WriteLine("Satace sayı giriniz !!!");
                Thread.Sleep(3000);
            }
            goto BackToMemu;
        }

        public void showPetStats(Pet p1)
        {
            Console.WriteLine("\n");
            Console.WriteLine("----> Bilgilendirme Ekranı <----- \n");
            Console.WriteLine("Hayvanınızın Canı: " + p1.Heart);
            Console.WriteLine("Hayvanınızın Susuzluğu: " + p1.isThirsty);
            Console.WriteLine("Hayvanınızın Açlığı: " + p1.isHungary);
            Console.WriteLine("Hayvanınızın Seviyesi: " + p1.Lvl);
            Console.WriteLine("Hayvanınızın Tecrübesi: " + p1.Xp);
            Console.WriteLine("Paranız: " + p1.Coin + "\n");
            manuelTimer(p1);
            Console.WriteLine(backToMenu);
            Thread.Sleep(3000);


        }

        public void manuelTimer(Pet p1)
        {
            for (int i = 0; i < 1; i++)
            {
                p1.isHungary -= 7;
                p1.isThirsty -= 5;
                Console.WriteLine("Hayvanınızın Susuzluğu: " + p1.isThirsty);
                Console.WriteLine("Hayvanınızın Açlığı: " + p1.isHungary);
            }
        }
        public void giveLunch()
        {
            p1.isHungary = 100;
            Console.WriteLine("Hayvanınızın karnı doyduğu için çok mutlu.\n");
            p1.Xp += 20;
            isLvlUp();
            manuelTimer(p1);
            Console.WriteLine(backToMenu);
            Thread.Sleep(2000);
        }

        public void giveWater()
        {
            p1.isThirsty = 100;
            Console.WriteLine("Hayvanınızın su içtiği için çok mutlu.\n");
            p1.Xp += 20;
            isLvlUp();
            manuelTimer(p1);
            Console.WriteLine(backToMenu);
            Thread.Sleep(2000);
        }

        public void isPurchaseItem()
        {
            ShowIteam(p1.Coin);
            Console.Write("Ekipman almak ister misiniz? (E / H): ");
            var Select = Console.ReadLine();
            if (Select == "E" || Select == "e")
            {
                purchaseItem(p1);
                manuelTimer(p1);
                Console.WriteLine(backToMenu);
                Thread.Sleep(3000);

            }
            else if (Select == "H" || Select == "h")
            {
                pMenu();
                manuelTimer(p1);
                Console.WriteLine(backToMenu);
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("Böyle bir işlem yok, Dikkatli okuyun. \n");
                manuelTimer(p1);
                isPurchaseItem();
            }
        }

        public void showInventory(string text= null)
        {
            if (string.IsNullOrEmpty(text))
                text = PetMenager.backToMenu;

            if (p1.inventory.Count != 0)
            {
                Console.WriteLine("----> Envanter <----\n");
                foreach (var PInventory in p1.inventory)
                {
                    Console.WriteLine("1." + " " + PInventory.Name + " " + "Türü: " + PInventory.Type + "\n");
                }
                
                Console.WriteLine(text);
                Thread.Sleep(2500);
            }
            else
            {
                Console.WriteLine("----> Envanter <----\n");
                Console.WriteLine("Envanteriniz boş, Önce dükkandan bir eşya alınız. \n");


            }
        }
        public void enterArea()
        {
            if (p1.Heart > 50)
            {
                showInventory("Depoya bakılıyor");
                p1.GetIteam = new List<Item>();
                Console.Write("Savaşa katılmak için bir silah seçiniz: ");
                byte Select = Convert.ToByte(Console.ReadLine());
                var isWeapon = from x in ItemList where Select == x.ItemId select x.Name;
                if (p1.inventory.Count >= Select)
                {
                    p1.GetIteam.Add(p1.inventory[Select - 1]);
                    Console.WriteLine(isWeapon.FirstOrDefault() + " Silahını kuşandın savaşa hazırsın.");
                    Console.WriteLine("Savaş başlıyor..");
                    Thread.Sleep(2500);
                    fMenager.Fight(p1);
                    manuelTimer(p1);
                }
                else
                {
                    Console.WriteLine("\n Lütfen envanterde bulunan bir eşya IDsi girin. Yeniden arenaya yönlendiriliyorsunuz.");
                    enterArea();
                }
            }
            else
            {
                Console.WriteLine("Canınız çok düşük tedavi olunuz");
                Console.WriteLine(backToMenu);
                Thread.Sleep(3000);
            }

        }

        public void doctor()
        {
            Console.WriteLine("----> Doktora Hoş geldiniz <----\n");
            if (p1.Heart <= 50)
            {
                p1.Heart = 100;
                Console.WriteLine("Tedavi olmak için biraz bekleyin tedavi olunuyor..");
                System.Threading.Thread.Sleep(2500);
                Console.WriteLine("Tedavi olundu sağlıklı günler. \n");
                manuelTimer(p1);
                Console.WriteLine(backToMenu);
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("Gayet sağlıklısınız.\n");
                manuelTimer(p1);
                Console.WriteLine(backToMenu);
                Thread.Sleep(3000);
            }
        }

        public bool isLvlUp()
        {
            if (p1.Xp >= p1.TargetLvl)
            {
                p1.Lvl++;
                p1.Xp = 0;
                p1.TargetLvl += 60;
                Console.WriteLine("Hayvanınız" + " " + p1.Lvl + " " + "level oldu, hayvanınız artık daha büyük ve daha sevimli. \n");
                return true;
            }
            return false;
        }
    }
}
