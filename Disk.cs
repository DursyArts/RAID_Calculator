using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace RAID_Calculator;

public class Disk {
    /* CLASS PRIVATE VARIABLES DEFINITION */
    private double capacity;
    private string ID = "TEMPDISK";
    private bool isDefect = false;

    private double write_speed;
    private double read_speed;
    private List<Disk> child_disks = new List<Disk>();
    
    /* CLASS PUBLIC METHODS DEFINTION */
    // Init
    public Disk(){
        capacity = 2000.00;
        ID = "TMPDISK" +  new Random().Next(0, 10000);
        write_speed = 100;
        read_speed = 200;
    }
    // Public Getters
    public double getCapacity(){
        return this.capacity;
    }
    public string getID(){
        return this.ID;
    }
    public bool getDefect(){
        return this.isDefect;
    }
    public double getWriteSpeed(){
        return this.write_speed;
    }
    public double getReadSpeed(){
        return this.read_speed;
    }
    public List<Disk> getChildDisks(){
        return this.child_disks;
    }

    // Public Setters
    public double setCapacity(double amount){
        this.capacity = amount;
        return this.capacity;
    }
    public string setID(string new_id){
        this.ID = new_id;
        return this.ID;
    }
    public bool setDefect(bool defect){
        this.isDefect = defect;
        return this.isDefect;
    }
    public double setWriteSpeed(double writespeed){
        this.write_speed = writespeed;
        return this.write_speed;
    }
    public double setReadSpeed(double readspeed){
        this.read_speed = readspeed;
        return this.read_speed;
    }
    // Add a Disk to the List
    public void addDisk(Disk newdisk){
        this.child_disks.Add(newdisk);
    }
}
