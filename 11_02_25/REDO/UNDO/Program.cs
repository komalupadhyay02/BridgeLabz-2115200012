using System;

class TextState
{
    public string Text { get; set; }
    public TextState Prev { get; set; } // Pointer to the previous state (undo)
    public TextState Next { get; set; } // Pointer to the next state (redo)

    public TextState(string text)
    {
        Text = text;
        Prev = null;
        Next = null;
    }
}

class TextEditor
{
    private TextState currentState;
    private int historySize;
    private int historyCount;

    public TextEditor(int historySize)
    {
        this.historySize = historySize;
        historyCount = 0;
        currentState = null;
    }

    // Add a new state to the history
    public void AddState(string text)
    {
        TextState newState = new TextState(text);

        if (currentState != null)
        {
            if (currentState.Next != null)
            {
                // If we are in the middle of history, clear the redo history.
                currentState.Next = null;
            }
            newState.Prev = currentState;
            currentState.Next = newState;
        }
        currentState = newState;

        // Limit history size
        historyCount++;
        if (historyCount > historySize)
        {
            // Remove the oldest state (from the beginning of the history)
            TextState temp = currentState;
            while (temp.Prev != null && temp.Prev.Prev != null)
            {
                temp = temp.Prev;
            }
            temp.Prev = null;
            historyCount--;
        }
    }

    // Undo the last operation
    public void Undo()
    {
        if (currentState != null && currentState.Prev != null)
        {
            currentState = currentState.Prev;
            Console.WriteLine("Undo: " + currentState.Text);
        }
        else
        {
            Console.WriteLine("No more undo operations.");
        }
    }

    // Redo the last undone operation
    public void Redo()
    {
        if (currentState != null && currentState.Next != null)
        {
            currentState = currentState.Next;
            Console.WriteLine("Redo: " + currentState.Text);
        }
        else
        {
            Console.WriteLine("No more redo operations.");
        }
    }

    // Display the current state of the text
    public void DisplayCurrentState()
    {
        if (currentState != null)
        {
            Console.WriteLine("Current text: " + currentState.Text);
        }
        else
        {
            Console.WriteLine("No text available.");
        }
    }
}

class Program
{
    static void Main()
    {
        // Create a text editor with a history limit of 5 states
        TextEditor editor = new TextEditor(5);

        // Add some text states to the history
        editor.AddState("Hello");
        editor.DisplayCurrentState();

        editor.AddState("Hello, world!");
        editor.DisplayCurrentState();

        editor.AddState("Hello, world! This is a text editor.");
        editor.DisplayCurrentState();

        editor.AddState("Hello, world! This is a text editor. Undo/Redo implemented.");
        editor.DisplayCurrentState();

        editor.AddState("Hello, world! This is a text editor. Undo/Redo implemented. More changes.");
        editor.DisplayCurrentState();

        // Perform undo operations
        editor.Undo();
        editor.Undo();

        // Perform redo operations
        editor.Redo();
        editor.Redo();
        
        // Add another state, this will remove the oldest state due to history size limit
        editor.AddState("New state added after redo.");
        editor.DisplayCurrentState();

        // Perform undo operation after size limit change
        editor.Undo();
        editor.Undo();
    }
}
