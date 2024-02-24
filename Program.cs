using System;
using System.Collections.Generic;

namespace RAID_Calculator{
    class Program{
        static double TbToGb(double input_Tb){
            return input_Tb*1024;
        }
        static void Main(string[] args){
            RaidLevel newArray = new RaidLevel("0");
            Disk newDisk1 = new Disk();
            Disk newDisk2 = new Disk();
            Disk newDisk3 = new Disk();
            System.Console.WriteLine(newDisk1.getID());
            System.Console.WriteLine(newDisk2.getID());
            System.Console.WriteLine(newDisk3.getID());
            newArray.addDisk(newDisk1);
            newArray.addDisk(newDisk2);
            newArray.addDisk(newDisk3);

            DiskConfiguration config = new DiskConfiguration();
            config.addArray("array1",newArray.getDisks());
            
            Dictionary<string, List<Disk>> TotalArrays = new Dictionary<string, List<Disk>>();
            TotalArrays = config.getArray("array1");

            System.Console.WriteLine(TotalArrays.Count);
        }
    }
}
