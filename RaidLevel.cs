using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace RAID_Calculator;

public class RaidLevel{
    protected string global_raidid { get; set; }
    protected double global_totalcapacity { get; set; }
    protected double global_unusablecapacity { get; set;}
    protected string global_raidlevel { get; set; }
    protected int global_minamountdisks{ get; set; }
    protected bool global_isfailed { get; set; } = false;
    protected List<Disk> raiddisks = new List<Disk>();
    
    // debug printing i guess
    public void getConfig(){
        System.Console.WriteLine("### This RAID Configuration: ###");
        System.Console.WriteLine("RAID Level: {0}", this.global_raidlevel);
        System.Console.WriteLine("RAID ID: {0}", this.global_raidid);
        System.Console.WriteLine("RAID Total Capacity: {0}", this.global_totalcapacity.ToString());
        System.Console.WriteLine("RAID Unusable Capacity: {0}", this.global_unusablecapacity.ToString());
        System.Console.WriteLine("RAID Min amount of disks: {0}", this.global_minamountdisks.ToString());
        System.Console.WriteLine("RAID Failure status: {0}", this.global_isfailed.ToString());
        System.Console.WriteLine("\nRAID Installed Disks: {0}", this.raiddisks.Count);
        System.Console.WriteLine("Listing all Disks:");
        
        foreach(Disk tmpdisk in this.raiddisks){
            System.Console.WriteLine(tmpdisk.getID() + " - " + tmpdisk.getCapacity().ToString() + "GB - Fail Status:" + tmpdisk.getDefect().ToString());
        }
        System.Console.WriteLine("### Done with {0} ###", this.global_raidid);
    }

    /* CLASS PUBLIC METHODS DEFINTION */
    // Init
    public RaidLevel(string level){
        this.global_raidlevel = level;
    }

    // Public Getters
    public string getRaidID(){
        return this.global_raidid;
    }
    public double getTotalCapacity(){
        return this.global_totalcapacity;
    }
    public double getUnusableCapacity(){
        return this.global_unusablecapacity;
    }
    public string getRaidLevel(){
        return this.global_raidlevel;
    }
    public bool getDefect(){
        return this.global_isfailed;
    }
    public List<Disk> getDisks(){
        return this.raiddisks;
    }

    // Public Setters
    public string setRaidID(string newid){
        this.global_raidid = newid;
        return this.global_raidid;
    }
    public string setRaidLevel(string level){
        // Function to check raid level
        return this.global_raidlevel;
    }
    public bool setDefect(bool defect){
        this.global_isfailed = defect;
        return this.global_isfailed;
    }

    // Public Method to Recalculate Capacity with given raid level
    public double[] calculateCapacity(List<Disk> diskarray, string level){
        double TotalCapacity = 0;
        double UnusableCapacity = 0;
        double[] returnarray = {TotalCapacity,UnusableCapacity}; // have to try if this works.
        return returnarray;
    }

    public void addDisk(Disk newdisk){
        try{
            this.raiddisks.Add(newdisk);
        }catch(Exception ex){
            System.Console.WriteLine("Couldn't add Disk to array. Error: " + ex);
        }
        System.Console.WriteLine("Added {0} to Raid {1}", newdisk.getID(), this.global_raidid);
    }
}
