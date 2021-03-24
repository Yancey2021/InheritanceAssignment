using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGunsExample
{
    class Program
    {
        private static readonly Random _random = new Random();

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to PA 2021 Hunting!");
            Console.WriteLine("-----------------");
            Console.WriteLine("Choose your rifle:");
            Console.WriteLine("1. Vanguard Synthetic");
            Console.WriteLine("2. Vanguard MeatEater");
            string riflePicked = Console.ReadLine();
            UOM caliberOnRifle = new UOM();
            int gunCapacity = 0;
            if (riflePicked == "1")
            {
                VanguardSynthetic vs1 = new VanguardSynthetic();
                vs1.myUOM = setRandomCaliber();
                caliberOnRifle = vs1.myUOM;
                Console.WriteLine("Rifle caliber: " + vs1.myUOM.Caliber);
                vs1.capacity = 3; // PA state law
                gunCapacity = vs1.capacity;
            } else if (riflePicked == "2")
            {
                VanguardMeatEater vme1 = new VanguardMeatEater();
                vme1.myUOM = setRandomCaliber();
                caliberOnRifle = vme1.myUOM;
                Console.WriteLine("Rifle caliber: " + vme1.myUOM.Caliber);

                vme1.capacity = 3; // PA state law
                gunCapacity = vme1.capacity;
            }


            double shotsFired = 0;
            double targetsHit = 0;
            double targetsKilled = 0;
            while (shotsFired < gunCapacity)
            {
            Console.WriteLine("Legal game spotted!");
                GameTarget gt = new GameTarget();
                gt = getNewRandomGameTarget();

                Console.WriteLine("It is broadside and is unalert. Take a shot now? (y/n)");

                     string response = Console.ReadLine();

                        if (response == "y")
                        {
                    Console.WriteLine("Target's caliber is: " + gt.targetUOM.Caliber);

                    shotsFired++;
                            if (gt.targetUOM.Caliber == caliberOnRifle.Caliber )
                    {
                        Console.WriteLine("Nice shot!");
                        targetsHit++;
                        targetsKilled++;

                    } else
                    {
                        // we shot at it, but wasn't right caliber

                        if ((gt.targetUOM.CaliberGroup == Group.Long) && (caliberOnRifle.CaliberGroup == Group.Short))
                        {
                            // get nothing, shot is fired
                            Console.WriteLine("You missed! Target ran off");
                        }
                        if ((gt.targetUOM.CaliberGroup == Group.Short) && (caliberOnRifle.CaliberGroup == Group.Long))
                        {
                            Console.WriteLine("Bad shot! Target was not fatally wounded");
                            targetsHit++;

                        }

                    }
                        } else if (response == "n") {
                    continue;
                        } else
                        {
                    continue;
                }

            }
            Console.WriteLine("The hunt is over. Let's see how you did:");
            //TODO: Play with score

            Console.WriteLine("Your Score: " + ((targetsKilled + (targetsHit*.25))  / gunCapacity));
            Console.ReadLine();
        
        }
        public static GameTarget getNewRandomGameTarget()
        {
            GameTarget newRandomGameTarget = new GameTarget();
            newRandomGameTarget.targetUOM = setRandomCaliber();
            return newRandomGameTarget;

        }
        public static UOM setRandomCaliber()
        {
            UOM newUOM = new UOM();
            string[] caliber = new string[5];
            caliber[0] = "22-250 Rem.";
            caliber[1] = "243 Win.";
            caliber[2] = "308 Win.";
            caliber[3] = "300 Win. Mag";
            caliber[4] = "7mm Rem. Mag";

            int randomN = RandomNumber(0, 4);
            newUOM.Caliber = caliber[randomN];

            switch (randomN) {
                case 0:
                    newUOM.CaliberGroup = Group.Short;
                    break;
                case 1:
                    newUOM.CaliberGroup = Group.Medium;
                    break;
                case 2:
                    newUOM.CaliberGroup = Group.Long;
                    break;
                case 3:
                    newUOM.CaliberGroup = Group.Long;
                    break;
                case 4:
                    newUOM.CaliberGroup = Group.Long;
                    break;
            }

            return newUOM;
        }
        public static int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
