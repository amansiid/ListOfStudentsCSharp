public class StudentList
{
    private List<Student> students = new List<Student>();

    public void AddStudent(string name, int age)
    {
        students.Add(new Student(name, age));
    }

    public void DeleteStudent(string name)
    {
        students.RemoveAll(s => s.Name.Split(' ')[0] == name || s.Name == name);
    }

    public void DisplayStudents()
    {
        foreach (var student in students)
        {
            Console.WriteLine("{0}'s age is {1} years old.", student.Name, student.Age);
        }
    }

    public bool IsEmpty()
    {
        return students.Count == 0;
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        StudentList studentList = new StudentList();

        string command = "";
        Console.WriteLine("Commands: ");
        Console.WriteLine("l - List students and their ages");
        Console.WriteLine("d - Delete student by name or first name if multiple students have the same first name (case-sensitive)");
        Console.WriteLine("a - Add student by name and age (separated by a space) e.g. 'a John Doe 25'");
        Console.WriteLine("q - Quit program");

        while (command != "q")
        {
            Console.WriteLine("Enter a command:");
            string[] input = Console.ReadLine().Split(' ');
            command = input[0];

            switch (command)
            {
                case "l":
                    if (studentList.IsEmpty())
                    {
                        Console.WriteLine("No students to display.");
                    }
                    else
                    {
                        studentList.DisplayStudents();
                    }
                    break;
                case "d":
                    if (input.Length > 1)
                    {
                        string name = string.Join(" ", input.Skip(1));
                        studentList.DeleteStudent(name);
                    }
                    else
                    {
                        Console.WriteLine("You need to provide a name for the 'd' command.");
                    }
                    break;
                case "a":
                    if (input.Length > 2)
                    {
                        string name = string.Join(" ", input.Skip(1).Take(input.Length - 2));
                        if (int.TryParse(input.Last(), out int age))
                        {
                            studentList.AddStudent(name, age);
                        }
                        else
                        {
                            Console.WriteLine("Invalid age. Please provide a valid number for the age.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You need to provide a name and age for the 'a' command.");
                    }
                    break;
                case "q":
                    Console.WriteLine("Quitting program...");
                    break;
                default:
                    Console.WriteLine("Invalid command. Please enter 'l', 'd', 'a', or 'q'.");
                    break;
            }
        }
    }
}