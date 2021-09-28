using System;

namespace MiniPetGameV1
{
    class Program
    {
        static void Main(string[] args)
        {
            PetMenager pm = new PetMenager();
            if (pm.addNewPet())
            {
                pm.pMenu();
            }
            else
            {
                Console.WriteLine("Beklenmedik bir hata oluştu,Lütfen daha sonra tekrar deneyiniz.");
            }
        }
    }
}
