using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace RAID_Calculator;

public class DiskConfiguration{
    private Dictionary<string, List<Disk>> arrays = new Dictionary<string, List<Disk>>();

    /* CLASS PUBLIC METHODS DEFINTION */
    // Public Getters

    public Dictionary<string, List<Disk>> getArrays(){
        return this.arrays;
    }

    public Dictionary<string, List<Disk>> getArray(string arrayid){
        Dictionary<string, List<Disk>> oneArray = new Dictionary<string, List<Disk>>();
        oneArray.Add(arrayid, this.arrays[arrayid]);
        return oneArray;
    }

    // Public Setters
    public void addArray(string arrayID, List<Disk>arrayDisks){
        arrays.TryAdd(arrayID, arrayDisks);
    }
}
