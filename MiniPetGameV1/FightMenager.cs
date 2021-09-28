using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPetGameV1
{
    class FightMenager
    {
        Pet p1;
        Item Item1;
        PetMenager pm;

        Random rEnemydamage = new Random();
        Random rDamage = new Random();

        int Heart, enemyHeart = 100, Enemydamage, Damage;
        string EnemyWeapon, Weapon; 

       
        public void BeforeEnterArea(Pet p1)
        {
            Console.Write("\n----> Savaş alanı <----\n");
            foreach (var Fight in p1.GetIteam)
            {
                 Damage=Fight.Damage;
                Enemydamage = Fight.Damage;
                Heart = p1.Heart;
                Weapon = Fight.Name;
                EnemyWeapon = Fight.Name;
                

            }
        }
        public void Fight(Pet p1)
        {
            BeforeEnterArea(p1);
            while (Heart>=0 || enemyHeart>=0)
            {
                Console.WriteLine("\n----> Düşman <----");
                Console.WriteLine("Düşmanın Canı: " + enemyHeart);
                Console.WriteLine("Düşman Silahı: " + EnemyWeapon);
                Heart -= rEnemydamage.Next(0, Enemydamage);
                Console.WriteLine("\n");
                Console.WriteLine("----> " +p1.PetName+" <----");
                Console.WriteLine("Canınız: " + Heart);
                Console.WriteLine("Silahınız: " + Weapon+"\n");
                enemyHeart -= rDamage.Next(0, Damage);
                System.Threading.Thread.Sleep(1000);
                if (rEnemydamage.Next(0,Enemydamage)>Heart || rDamage.Next(0, Damage) > Heart)
                {
                    break;
                }
            }

            if (enemyHeart>Heart)
            {
                Console.WriteLine("----> Sonuç <----");
                Console.WriteLine("Karakteriniz ölümden kurtuldu ve Düşman kazandı.\n");
                p1.Heart = Heart;
                enemyHeart = 100;
                p1.GetIteam.Clear();
            }
            else if (Heart>enemyHeart)
            {
                Console.WriteLine("----> Sonuç <----");
                Console.WriteLine("Düşmanınız kaçtı. "+p1.PetName+ " kazandı, 40 tecrübe puanı ve 60 coin kazandın. Evcil hayvanınız ağır yaralı lütfen doktara görünün");
                p1.Xp += 40;
                p1.Heart =Heart;
                p1.Coin += 60;
                p1.GetIteam.Clear();
                enemyHeart = 100;
            }
            else
            {
                p1.Xp += 20;
                p1.Heart = Heart;
                p1.GetIteam.Clear();
                enemyHeart = 100;

                Console.WriteLine("Berabere biti, 20 tecrübe puanı kazandın. Evcil hayvanınız  yaralı lütfen doktara görünün");
            }
        }
        
    }
}
