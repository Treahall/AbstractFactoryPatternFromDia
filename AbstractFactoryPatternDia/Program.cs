using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPatternDia
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneTypeChecker PhoneChecker = new PhoneTypeChecker(Manufacturers.HTC);
            Console.WriteLine("The following are the phones by HTC:");
            PhoneChecker.CheckProducts();
            Console.WriteLine();

            PhoneChecker = new PhoneTypeChecker(Manufacturers.NOKIA);
            Console.WriteLine("The following are the phones by Nokia:");
            PhoneChecker.CheckProducts();
            Console.WriteLine();

            PhoneChecker = new PhoneTypeChecker(Manufacturers.SAMSUNG);
            Console.WriteLine("The following are the phones by Samsung:");
            PhoneChecker.CheckProducts();

            Console.ReadKey();

        }

    }

    class PhoneTypeChecker
    {
        IPhoneFactory Factory;
        Manufacturers Manu;

        public PhoneTypeChecker(Manufacturers m)
        {
            Manu = m;
        }

        public void CheckProducts()
        {
            if (Manu == Manufacturers.HTC)
            {
                Factory = new HTCFactory();
                Console.WriteLine($"The dumb phone for HTC is the {Factory.GetDumb().GetName()}");
                Console.WriteLine($"The smart phone for HTC is the {Factory.GetSmart().GetName()}");
            }

            if (Manu == Manufacturers.NOKIA)
            {
                Factory = new NokiaFactory();
                Console.WriteLine($"The dumb phone for Nokia is the {Factory.GetDumb().GetName()}");
                Console.WriteLine($"The smart phone for Nokia is the {Factory.GetSmart().GetName()}");
            }

            if (Manu == Manufacturers.SAMSUNG)
            {
                Factory = new SamsungFactory();
                Console.WriteLine($"The dumb phone for Samsung is the {Factory.GetDumb().GetName()}");
                Console.WriteLine($"The smart phone for Samsung is the {Factory.GetSmart().GetName()}");
            }
        }
    }

    enum Manufacturers
    {
        SAMSUNG, HTC, NOKIA
    }

    interface IPhoneFactory
    {
        ISmart GetSmart();
        IDumb GetDumb();
    }

    class SamsungFactory : IPhoneFactory
    {
        public IDumb GetDumb()
        {
            return new Genie();
        }

        public ISmart GetSmart()
        {
            return new GalaxyS2();
        }
    }
    class HTCFactory : IPhoneFactory
    {
        public IDumb GetDumb()
        {
            return new Primo();
        }

        public ISmart GetSmart()
        {
            return new Lumia();
        }
    }
    class NokiaFactory : IPhoneFactory
    {
        public IDumb GetDumb()
        {
            return new Asha();
        }

        public ISmart GetSmart()
        {
            return new Titan();
        }
    }


    interface ISmart
    {
        string GetName();
    }

    class Lumia : ISmart
    {
        public string GetName()
        {
            return "Lumia";
        }
    }

    class GalaxyS2 : ISmart
    {
        public string GetName()
        {
            return "GalaxyS2";
        }
    }

    class Titan : ISmart
    {
        public string GetName()
        {
            return "Titan";
        }
    }

    interface IDumb
    {
        string GetName();
    }

    class Asha : IDumb
    {
        public string GetName()
        {
            return "Asha";
        }
    }

    class Genie : IDumb
    {
        public string GetName()
        {
            return "Genie";
        }
    }

    class Primo : IDumb
    {
        public string GetName()
        {
            return "Primo";
        }
    }
}
