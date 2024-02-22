using System;

namespace RAID_Calculator{
    class Program{
        static void Main(string[] args){
            double capacity1 = 2000.00;
            double capacity2 = 4000.00;
            
            DiskConfiguration diskConfiguration = new DiskConfiguration();

            System.Console.WriteLine("Creating a Disk~");
            diskConfiguration.addRaidDisk(capacity1);

            System.Console.WriteLine("Creating another Disk~");
            diskConfiguration.addRaidDisk(capacity2);

            System.Console.WriteLine("Creating another Disk~");
            diskConfiguration.addRaidDisk(2500.00);

            System.Console.WriteLine("Getting The Raid Disks~");
            diskConfiguration.getRaidDiskIDs();
            System.Console.WriteLine("Raid Health Status: {0}", diskConfiguration.getRaidHealth());
            System.Console.WriteLine("Raid Level: {0}", diskConfiguration.getRaidLevel());
        }
    }
}
