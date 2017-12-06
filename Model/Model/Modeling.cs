using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Modeling
{
	public int PROCESSORS_COUNT;
    public int PROCESS_GENERATORS_COUNT = 1;
    public int INTERRUPT_GENERATORS_COUNT = 1;
    public int MAX_QUEUE_SIZE;
    public int MAX_INT_QUEUE_SIZE;
    public int QUANTUM;
    Random rand = new Random();
    //Processor processors[PROCESSORS_COUNT];
    //ProcessGenerator pGens[PROCESS_GENERATORS_COUNT];
    //InterruptGenerator iGens[INTERRUPT_GENERATORS_COUNT];
    Processor[] processors=new Processor[100];
    ProcessGenerator[] pGens=new ProcessGenerator[100];
    InterruptGenerator[] iGens=new InterruptGenerator[100];
    //std::random_device rd;  //Will be used to obtain a seed for the random number engine
    //std::mt19937 gen; //Standard mersenne_twister_engine seeded with rd()
    //std::uniform_real_distribution<> dis;

    public Modeling(int pc, double pgc, double igc, int mqs, int miqs, int q, double procInt, double procIntInt)
    {
        
        this.PROCESSORS_COUNT = pc;
        //this->PROCESS_GENERATORS_COUNT = pgc;
        ProcessGenerator.intensity = pgc;
        //this->INTERRUPT_GENERATORS_COUNT = igc;
        InterruptGenerator.intensity = igc;
        this.MAX_QUEUE_SIZE = mqs;
        this.MAX_INT_QUEUE_SIZE = miqs;
        this.QUANTUM = q;
        Processor.intensity = procInt;
        Processor.intIntensity = procIntInt;
        for (int i = 0; i < PROCESSORS_COUNT; ++i)
        {
            //processors[i].releaseTime = (-processors[i].intensity*log(this->dis(gen)));
            //this->timesOfEnds.push(processors[i].releaseTime);			
        }

        for (int i = 0; i < PROCESS_GENERATORS_COUNT; ++i)
        {
            pGens[i].releaseTime = (-ProcessGenerator.intensity * Math.Log(this.rand.NextDouble()));
            this.timesOfEnds.Add(pGens[i].releaseTime);
        }

        for (int i = 0; i < INTERRUPT_GENERATORS_COUNT; ++i)
        {
            iGens[i].releaseTime = (-InterruptGenerator.intensity * Math.Log(this.rand.NextDouble()));
            this.timesOfEnds.Add(iGens[i].releaseTime);
        }
    }
    public int countOfProcessLost = 0;
    public int countOfProcessSuccess = 0;
    public int countOfProcessRequests = 0;
    //double sumOfProcessWaiting = 0;
    //double sumOfProcessWork = 0;
    public int countOfIntLost = 0;
    public int countOfIntSuccess = 0;
    public int countOfIntRequests = 0;
    //double sumOfIntWaiting = 0;
    //double sumOfIntWork = 0;
    List<double> processWaitings=new List<double>();
    List<double> processWorks = new List<double>();
    List<double> intWaitings = new List<double>();
    List<double> intWorks = new List<double>();

    SortedSet<double> timesOfEnds = new SortedSet<double>();
    SortedSet<Process> procQueue = new SortedSet<Process>();
    SortedSet<Interrupt> intQueue = new SortedSet<Interrupt>();
   double getExpectedValue(List<double> vec)
    {
        if (vec.Count() == 0)
            return 0;
        double sum = 0;
        foreach(double item in vec)
        {
            sum += item;
        }
        return sum;            
    }
    double getStandartDeviation(List<double> vec, double expectedValue)
    {
        if (vec.Count()==0)
            return -1;
        if (expectedValue == -1)
            expectedValue = this.getExpectedValue(vec);
        double sum = 0;
        foreach (double o in vec)
        {
            sum+= (o - expectedValue) * (o - expectedValue);
        }          
        return Math.Sqrt(sum / vec.Count());
    }

}

void loop(long double globalTime);
void checkProcessGenerator(long double globalTime, int number);
void checkIntGenerator(long double globalTime, int number);
void checkProcessorProcess(long double globalTime, int number);
void checkProcessorInt(long double globalTime, int number);

}

