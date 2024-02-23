using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace RAID_Calculator;

public class DiskConfiguration{
    private List<Disk> RaidDiskIDs = new List<Disk>();
    private string RaidLevel = "JBOD";
    private double RaidHealth = 100.00;

    protected double RaidUsableCapacity;

    protected double RaidTotalCapacity;

    protected double RaidMiscCapacity;

    public List<Disk> getRaidDiskIDs(){
        foreach (Disk disk in this.RaidDiskIDs){
            System.Console.WriteLine("disk: {0}, capacity: {1}GB",disk.getDiskID(), disk.getCapacity());
        }
        return this.RaidDiskIDs;
    }

    public string getRaidLevel(){
        System.Console.WriteLine(this.RaidLevel);
        return this.RaidLevel;
    }

    public double getRaidHealth(){
        System.Console.WriteLine("{0}%", this.RaidHealth);
        return this.RaidHealth;
    }

    public void setDiskID(int index, string id){
        // see if index exists in List<Disk> RaidDiskIDs
        if(index < this.RaidDiskIDs.Count){
            
        }
        // replace or append to the List<Disk> RaidDiskIDs List at index
        // cout if the action succeeded 
    }

    public void setRaidLevel(string level){
        // call the DiskConfigurations RAID Level Check function with the String level var
        // If the function returns true then apply to the raid level var and update RaidHealth
        this.RaidLevel = level;
    }

    public void setRaidHealth(double health){
        this.RaidHealth = health;
        System.Console.WriteLine("{0}%",this.getRaidHealth());
    }

    public void ResetRaidHealth(){
        // Call this function after updating the raid level.
        // fetch all disks in current state
        // use some logic to evaluate the overall health of the raid using the individual information stored in each disk's health variable
        // set RaidHealth
        // call getRaidHealth()
    }

    public void addRaidDisk(double capacity){
        System.Console.WriteLine("Received call to add new disk with size: {0} of type: {1}" ,capacity ,capacity.GetType());
        Disk temp = new Disk();
        temp.setCapacity(capacity);
        temp.setID("DISK" + (this.getRaidDiskIDs().Count+1).ToString());
        // Health is set automatically. We assume the Disk is okay after being sold.
        try{
            //System.Console.WriteLine("Trying to add disk {0} to Array", temp.getDiskID());
            RaidDiskIDs.Add(temp);
        }catch(Exception ex){
            System.Console.WriteLine("Error adding the disk to the array:");
            System.Console.WriteLine(ex.Message);
        }finally{
            // call this.applyRaidConfig()
            this.applyRaidConfig(this.RaidLevel);
        }
    }

    public void applyRaidConfig(string level){
        int count = RaidDiskIDs.Count;
        double tempsize = 0.00;
        // The default fallback if the check fails is a plain jbod
        switch(level){
            case "JBOD":
                //System.Console.WriteLine("Applaying JBOD Configuration to your Disk array.");
                
                //System.Console.WriteLine("Disks in the Array: {0}", count);
                foreach(Disk tmpdisk in RaidDiskIDs){
                    //System.Console.WriteLine("disk capacity to add: {0}" ,tmpdisk.getCapacity());
                    tempsize = tempsize + tmpdisk.getCapacity();
                    
                    //System.Console.WriteLine("Total Size now: {0}", tempsize);
                    if(tmpdisk.getDiskHealth() == true){
                        this.setRaidHealth(100.00); 
                    }
                }
                this.RaidTotalCapacity = tempsize;
                System.Console.WriteLine("JBOD Capacity: {0}GB",this.RaidTotalCapacity);  
            break;

            case "0":
                System.Console.WriteLine("Applying RAID 0 Configuration to disk array.");

                //System.Console.WriteLine("Disks in the Array: {0}", count);
                foreach(Disk tmpdisk in RaidDiskIDs){
                    tempsize += tmpdisk.getCapacity();

                    if(tmpdisk.getDiskHealth() == true){
                        this.setRaidHealth(0); // Striping Raid 0 means that the whole array will fail in case of an disk error.
                        System.Console.WriteLine("RAID 0 Failure on 1 drive fail: " + Math.Pow(1-(1-(100/100)), count)*100 + "%"); // formula to calculate RAIDs Failure probability
                    }
                }
                this.RaidTotalCapacity = tempsize;
                System.Console.WriteLine("RAID 0 Capacity: {0}GB", this.RaidTotalCapacity);
            break;
        }
        //System.Console.WriteLine(this.getRaidLevel());
    }
}
