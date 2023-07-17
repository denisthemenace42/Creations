Console.WriteLine("Good Morning, Denis!");
Console.WriteLine("Are you ready for the challenges prepared for you today?");
Console.WriteLine("Please input what you would like to accomplish today, separated by commas: ");

List<string> targets = Console.ReadLine().Split(",").ToList();

Console.WriteLine("***********************************************************************");
Console.WriteLine("Interesting choices, I hope that you will be able to do all of them today!");

string message = GetValidStartingTime();
Console.WriteLine(message);

Console.WriteLine("With which task are you going to start your day?");

string taskName = string.Empty;
List<Task> achieved = new List<Task>();

while ((taskName = Console.ReadLine()) != "Im done!")
{
    Console.WriteLine("Please provide a short description for your task. What exactly are you going to do?");

    string taskDescription = Console.ReadLine();

    Task task = new Task(taskName, taskDescription);
    achieved.Add(task);

    Console.WriteLine("***********************************************************************");
    Console.WriteLine("That's the spirit, keep going! There is no doubt that you are not going to finish it! I have added it to the achieved list!");
    Console.WriteLine("If you are done with your tasks, type: Im done!");
    Console.WriteLine("What will be your next task?");
}

Console.WriteLine("***********************************************************************");
Console.WriteLine("Here are the goals for your day:");
Console.WriteLine(string.Join(", ", targets));

Console.WriteLine("***********************************************************************");
string achievementMessage = GetAchievementMessage(achieved, targets);
Console.WriteLine(achievementMessage);
Console.WriteLine("Here are the tasks that you completed today:");

foreach (var task in achieved)
{
    Console.WriteLine(task);
}

Console.WriteLine("***********************************************************************");
Console.WriteLine("And here is the final task!");
Console.WriteLine("Please write your thoughts for the day, what you learned?");
Console.WriteLine("Which are the things that you are grateful for?");

string finalMessage = Console.ReadLine();

static string GetAchievementMessage(List<Task> achievedTasks, List<string> targetTasks)
{
    if (achievedTasks.Count == targetTasks.Count && achievedTasks.All(a => targetTasks.Contains(a.Name)))
    {
        return "Great job! You finished all of your tasks today!";
    }
    else if (achievedTasks.Count >= targetTasks.Count / 2)
    {
        return "Good job! You made good progress on your tasks!";
    }
    else
    {
        return "Keep going! You'll accomplish more tomorrow!";
    }
}


static string GetValidStartingTime()
{
    bool validInput = false;
    string message = string.Empty;

    while (!validInput)
    {
        Console.Write("Could you tell me what time it is right now? (Format: HH:MM) ");
        string input = Console.ReadLine();

        try
        {
            int[] startingTime = input.Split(':').Select(int.Parse).ToArray();

            if (startingTime.Length == 2)
            {
                int hours = startingTime[0];
                int minutes = startingTime[1];

                if (hours >= 0 && hours <= 23 && minutes >= 0 && minutes <= 59)
                {
                    validInput = true;

                    Console.WriteLine("***********************************************************************");

                    if (hours <= 9)
                    {
                        message = "Awesome, you are up early today!";
                    }
                    else if (hours == 10)
                    {
                        message = "Quite late but no worries, you still have plenty of time to do everything!";
                    }
                    else if (hours == 11)
                    {
                        message = "Aim to wake up earlier, you're going to feel better. Trust me and good luck with the tasks!";
                    }
                    else
                    {
                        message = "Damn, this is really late! Try fixing your schedule!";
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter the time in the format HH:MM.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter the time in the format HH:MM.");
        }
    }

    return message;
}

public class Task
{
    public Task(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; set; }

    public string Description { get; set; }

    public override string ToString()
    {
        return $"You completed {Name} ({Description})";
    }
}





