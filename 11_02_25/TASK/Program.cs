using System;

public class Task
{
    public int TaskID;
    public string TaskName;
    public int Priority;
    public DateTime DueDate;
    public Task Next;

    public Task(int taskID, string taskName, int priority, DateTime dueDate)
    {
        TaskID = taskID;
        TaskName = taskName;
        Priority = priority;
        DueDate = dueDate;
        Next = null;
    }
}

public class TaskScheduler
{
    private Task head;

    public TaskScheduler()
    {
        head = null;
    }

    // Add a task at the beginning
    public void AddAtBeginning(int taskID, string taskName, int priority, DateTime dueDate)
    {
        Task newTask = new Task(taskID, taskName, priority, dueDate);
        if (head == null)
        {
            head = newTask;
            newTask.Next = head; // Circular link
        }
        else
        {
            Task temp = head;
            while (temp.Next != head) // Find the last task
            {
                temp = temp.Next;
            }
            temp.Next = newTask;
            newTask.Next = head;
            head = newTask; // New task becomes the head
        }
    }

    // Add a task at the end
    public void AddAtEnd(int taskID, string taskName, int priority, DateTime dueDate)
    {
        Task newTask = new Task(taskID, taskName, priority, dueDate);
        if (head == null)
        {
            head = newTask;
            newTask.Next = head; // Circular link
        }
        else
        {
            Task temp = head;
            while (temp.Next != head) // Traverse until the last task
            {
                temp = temp.Next;
            }
            temp.Next = newTask;
            newTask.Next = head;
        }
    }

    // Add a task at a specific position
    public void AddAtPosition(int position, int taskID, string taskName, int priority, DateTime dueDate)
    {
        Task newTask = new Task(taskID, taskName, priority, dueDate);

        if (position == 0)
        {
            AddAtBeginning(taskID, taskName, priority, dueDate);
            return;
        }

        Task temp = head;
        int count = 0;
        while (temp != null && count < position - 1)
        {
            temp = temp.Next;
            count++;
            if (temp == head) break; // Break if we circled back to the head
        }

        if (temp == null || temp.Next == head)
        {
            Console.WriteLine("Position out of range!");
            return;
        }

        newTask.Next = temp.Next;
        temp.Next = newTask;
    }

    // Remove a task by Task ID
    public void RemoveByTaskID(int taskID)
    {
        if (head == null)
        {
            Console.WriteLine("No tasks to remove.");
            return;
        }

        Task temp = head;
        Task prev = null;

        do
        {
            if (temp.TaskID == taskID)
            {
                if (prev == null) // Head node
                {
                    if (temp.Next == head) // Only one node
                    {
                        head = null;
                    }
                    else
                    {
                        prev = head;
                        while (prev.Next != head) prev = prev.Next;
                        head = temp.Next;
                        prev.Next = head;
                    }
                }
                else
                {
                    prev.Next = temp.Next;
                }
                Console.WriteLine($"Task ID {taskID} removed.");
                return;
            }
            prev = temp;
            temp = temp.Next;
        } while (temp != head);

        Console.WriteLine("Task not found!");
    }

    // View the current task and move to the next task
    public void ViewAndMoveNext()
    {
        if (head == null)
        {
            Console.WriteLine("No tasks in the scheduler.");
            return;
        }

        Task temp = head;
        do
        {
            Console.WriteLine($"Task ID: {temp.TaskID}, Name: {temp.TaskName}, Priority: {temp.Priority}, Due Date: {temp.DueDate.ToShortDateString()}");
            temp = temp.Next;
        } while (temp != head); // Loop around to the head node

        Console.WriteLine("End of tasks.");
    }

    // Display all tasks starting from the head node
    public void DisplayAllTasks()
    {
        if (head == null)
        {
            Console.WriteLine("No tasks to display.");
            return;
        }

        Task temp = head;
        do
        {
            Console.WriteLine($"Task ID: {temp.TaskID}, Name: {temp.TaskName}, Priority: {temp.Priority}, Due Date: {temp.DueDate.ToShortDateString()}");
            temp = temp.Next;
        } while (temp != head); // Loop around to the head node
    }

    // Search for a task by Priority
    public void SearchByPriority(int priority)
    {
        if (head == null)
        {
            Console.WriteLine("No tasks to search.");
            return;
        }

        Task temp = head;
        bool found = false;

        do
        {
            if (temp.Priority == priority)
            {
                Console.WriteLine($"Found Task: ID: {temp.TaskID}, Name: {temp.TaskName}, Due Date: {temp.DueDate.ToShortDateString()}");
                found = true;
            }
            temp = temp.Next;
        } while (temp != head);

        if (!found)
        {
            Console.WriteLine("No tasks found with the given priority.");
        }
    }
}

public class Program
{
    public static void Main()
    {
        TaskScheduler scheduler = new TaskScheduler();

        // Add tasks to the scheduler
        scheduler.AddAtBeginning(1, "Task 1", 3, DateTime.Now.AddDays(1));
        scheduler.AddAtEnd(2, "Task 2", 1, DateTime.Now.AddDays(2));
        scheduler.AddAtPosition(1, 3, "Task 3", 2, DateTime.Now.AddDays(3));

        // Display all tasks
        Console.WriteLine("All Tasks:");
        scheduler.DisplayAllTasks();

        // View tasks and move to the next
        Console.WriteLine("\nViewing Tasks and Moving to the Next:");
        scheduler.ViewAndMoveNext();

        // Search for tasks by Priority
        Console.WriteLine("\nSearching for tasks with priority 2:");
        scheduler.SearchByPriority(2);

        // Remove a task by Task ID
        Console.WriteLine("\nRemoving task with ID 2:");
        scheduler.RemoveByTaskID(2);

        // Display tasks after removal
        Console.WriteLine("\nAll Tasks After Removal:");
        scheduler.DisplayAllTasks();
    }
}
