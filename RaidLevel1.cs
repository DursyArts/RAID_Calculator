using System;

namespace RAID_Calculator;

public class RaidLevel1 : RaidLevel {
    public RaidLevel1(string level) : base(level){
        this.setRaidLevel(level);
    }
}
