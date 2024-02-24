using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace RAID_Calculator{
    class Program{
        static double TbToGb(double input_Tb){
            return input_Tb*1024;
        }

        static Disk diskCreate(double capacity, int counter, double writespeed, double readspeed){
            Disk temporary = new Disk(capacity, "DISK-"+counter, writespeed, readspeed);
            return temporary;
        }

        static void Main(string[] args){
            List<Disk> disks = new List<Disk>();
            
            bool escape = false;
            while(escape == false){
                int input;
                System.Console.WriteLine("Which action do you want to perform?");
                System.Console.WriteLine("1. Create a new Disk");
                System.Console.WriteLine("2. Create a new Raid Array");
                System.Console.WriteLine("3. Disk Configuration");
                
                do{
                    System.Console.Write("Enter the number >");
                }while(!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > 4);

                switch(input){
                    case 1:
                        System.Console.WriteLine("How would you like to create the disk?");
                        System.Console.WriteLine("1. use predefined value");
                        System.Console.WriteLine("2. use own values");
                        System.Console.Write("Enter the number >");
                        int diskinput = Convert.ToInt32(System.Console.ReadLine());
                        if(diskinput == 1){
                            disks.Add(diskCreate(2000, disks.Count+1,100,100));
                        }else if(diskinput == 2){
                            System.Console.WriteLine("test");
                            System.Console.Write("Enter Capacity in GB:\t");
                            double tmpcapacity = Convert.ToDouble(System.Console.ReadLine());
                            System.Console.Write("Enter Write Speed in MBps:\t");
                            double tmpwrite = Convert.ToDouble(System.Console.ReadLine());
                            System.Console.Write("Enter Read Speed in MBps:\t");
                            double tmpread = Convert.ToDouble(System.Console.ReadLine());
                            int counter = disks.Count+1;
                            disks.Add(diskCreate(tmpcapacity, counter, tmpwrite, tmpread));
                        }
                    break;
                    case 2:
                    break;
                    case 3:
                        if(disks.Count == 0){
                            System.Console.WriteLine("You havent created any disks yet. Create a disk first.");
                        }else{
                            foreach(Disk tmp in disks){
                            System.Console.WriteLine(tmp.getID());
                            }
                        }
                    break;
                }
            }

            //System.Console.WriteLine(disks[0].getCapacity()); example of how to use the functions
        }
    }
}
