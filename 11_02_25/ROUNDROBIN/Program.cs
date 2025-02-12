using System;

class ProcessNode
{
    public int PID { get; set; }      // Process ID
    public int BurstTime { get; set; } // Burst Time
    public int Priority { get; set; }  // Priority
    public ProcessNode Next { get; set; } // Pointer to next process

    public ProcessNode(int pid, int burstTime, int priority)
    {
        PID = pid;
        BurstTime = burstTime;
        Priority = priority;
        Next = null;
    }
}

class CircularLinkedList
{
    public ProcessNode Head { get; set; } // Head of the circular linked list

    public CircularLinkedList()
    {
        Head = null;
    }

    // Add a new process at the end of the circular linked list
    public void AddProcess(int pid, int burstTime, int priority)
    {
        ProcessNode newNode = new ProcessNode(pid, burstTime, priority);

        if (Head == null)
        {
            Head = newNode;
            newNode.Next = Head;
        }
        else
        {
            ProcessNode current = Head;
            while (current.Next != Head)
            {
                current = current.Next;
            }
            current.Next = newNode;
            newNode.Next = Head;
        }
    }

    // Remove a process by its Process ID
    public void RemoveProcess(int pid)
    {
        if (Head == null) return;

        ProcessNode current = Head;
        ProcessNode previous = null;

        // If the process to remove is the head
        if (Head.PID == pid)
        {
            if (Head.Next == Head)
            {
                Head = null;
            }
            else
            {
                // Find the last node to link it to the new head
                while (current.Next != Head)
                {
                    current = current.Next;
                }
                current.Next = Head.Next;
                Head = Head.Next;
            }
            return;
        }

        // Traverse the list to find the process with the given PID
        do
        {
            previous = current;
            current = current.Next;
            if (current.PID == pid)
            {
                previous.Next = current.Next;
                return;
            }
        } while (current != Head);
    }

    // Display the list of processes in the circular queue
    public void DisplayList()
    {
        if (Head == null)
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        ProcessNode current = Head;
        do
        {
            Console.WriteLine($"PID: {current.PID}, Burst Time: {current.BurstTime}, Priority: {current.Priority}");
            current = current.Next;
        } while (current != Head);
    }
}

class RoundRobinScheduler
{
    public CircularLinkedList ProcessList;
    public int TimeQuantum;

    public RoundRobinScheduler(int timeQuantum)
    {
        ProcessList = new CircularLinkedList();
        TimeQuantum = timeQuantum;
    }

    // Simulate the Round Robin scheduling algorithm
    public void RunScheduler()
    {
        if (ProcessList.Head == null)
        {
            Console.WriteLine("No processes in the list.");
            return;
        }

        int totalWaitingTime = 0;
        int totalTurnaroundTime = 0;
        int numProcesses = 0;
        ProcessNode current = ProcessList.Head;

        // First, calculate the number of processes
        do
        {
            numProcesses++;
            current = current.Next;
        } while (current != ProcessList.Head);

        int[] waitingTime = new int[numProcesses];
        int[] turnaroundTime = new int[numProcesses];
        int i = 0;

        // Simulate round robin
        while (ProcessList.Head != null)
        {
            current = ProcessList.Head;

            do
            {
                if (current.BurstTime > TimeQuantum)
                {
                    current.BurstTime -= TimeQuantum;
                    ProcessList.Head = ProcessList.Head.Next; // Move to the next process
                    current = current.Next;
                }
                else
                {
                    // Process has finished its execution
                    int finishTime = current.BurstTime; // The remaining burst time
                    totalTurnaroundTime += finishTime;
                    totalWaitingTime += finishTime - current.BurstTime;
                    ProcessList.RemoveProcess(current.PID);  // Remove the process from the queue
                }
            } while (ProcessList.Head != null);
        }
    }

    // Calculate and display average waiting and turnaround times
    public void CalculateAndDisplayAvgTimes()
    {
        int numProcesses = 0;
        ProcessNode current = ProcessList.Head;
        while (current != null)
        {
            numProcesses++;
            current = current.Next;
        }

        if (numProcesses > 0)
        {
            double avgWaitingTime = (double)totalWaitingTime / numProcesses;
            double avgTurnaroundTime = (double)totalTurnaroundTime / numProcesses;

            Console.WriteLine($"Average Waiting Time: {avgWaitingTime}");
            Console.WriteLine($"Average Turnaround Time: {avgTurnaroundTime}");
        }
        else
        {
            Console.WriteLine("No processes to calculate average times.");
        }
    }
}

class Program
{
    static void Main()
    {
        RoundRobinScheduler scheduler = new RoundRobinScheduler(4); // Set time quantum to 4

        // Add processes to the circular linked list
        scheduler.ProcessList.AddProcess(1, 5, 1);
        scheduler.ProcessList.AddProcess(2, 8, 2);
        scheduler.ProcessList.AddProcess(3, 6, 3);
        scheduler.ProcessList.AddProcess(4, 3, 4);

        // Display the list of processes
        Console.WriteLine("List of Processes:");
        scheduler.ProcessList.DisplayList();

        // Run the Round Robin Scheduling
        scheduler.RunScheduler();

        // Calculate and display average waiting and turnaround times
        scheduler.CalculateAndDisplayAvgTimes();
    }
}
