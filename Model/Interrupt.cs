using System;

public class Interrupt
{    
	public int id;
    public double waitBegin = -1;
    public double sumOfWaiting = 0;
    public double workBegin = -1;
    public double sumOfWork = 0;
    public double necessaryTime = -1;
    public double priority = -1;
    public static unsigned curId;
    public Interrupt(double wB)
    {
        this->id = curId;
        ++curId;
        this->waitBegin = wB;
    }
}
