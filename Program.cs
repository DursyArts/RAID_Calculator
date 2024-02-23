using System;

namespace RAID_Calculator{
    class Program{
        static double TbToGb(double input_Tb){
            return input_Tb*1024;
        }
        static void Main(string[] args){
            double capacity1 = TbToGb(2);
            double capacity2 = TbToGb(4);
            
            DiskConfiguration diskConfiguration = new DiskConfiguration();

            System.Console.WriteLine("Creating a Disk~");
            diskConfiguration.addRaidDisk(capacity1);

            System.Console.WriteLine("Creating another Disk~");
            diskConfiguration.addRaidDisk(capacity2);

            System.Console.WriteLine("Creating another Disk~");
            diskConfiguration.addRaidDisk(TbToGb(3));

            System.Console.WriteLine("Getting The Raid Disks~");
            diskConfiguration.getRaidDiskIDs();
            diskConfiguration.applyRaidConfig("0");
        }
    }
}
