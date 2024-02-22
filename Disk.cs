using System;

namespace RAID_Calculator;

public class Disk {
    /* CLASS PRIVATE VARIABLES DEFINITION */
    private double capacity;
    private string ID = "TEMPDISK";
    private bool isDefect = false;
    
    /* CLASS PUBLIC METHODS DEFINTION */
    public double getCapacity(){
        return this.capacity;
    }

    public string getDiskID(){
        return this.ID;
    }

    public bool getDiskHealth(){
        return this.isDefect;
    }

    public void setCapacity(double amount){
        //System.Console.WriteLine("Setting Capacity of disk ID {0} to: {1}", this.ID, amount);
        this.capacity = amount;
        System.Console.WriteLine(this.getCapacity() + "GB");
    }

    public void setID(string id){
        this.ID = id;
        System.Console.WriteLine(this.getDiskID());
    }

    public void setHealth(bool defect){
        if(this.isDefect&&defect){
            System.Console.WriteLine("Disk already defect");
        }else{
            this.isDefect = true;
        }
        this.getDiskHealth();
    }
}
