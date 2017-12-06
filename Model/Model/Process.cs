using System;

public class Process
{
    public int id;
    public double waitBegin = -1;
    public double sumOfWaiting = 0;
    public double workBegin = -1;
    public double sumOfWork = 0;
    public double necessaryTime = -1;
    public double priority = -1;
    public static int curId;
    public Process(double wB)
    {
        this.id = curId;
        ++curId;
        this.waitBegin = wB;
    }
    ~Process() { }
}

