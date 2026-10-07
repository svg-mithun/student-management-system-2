using System;
using System.Collections.Generic;

// মেমোরিতে ডাটা রাখার জন্য List
List<Student> students = new List<Student>();

// প্রারম্ভিক কিছু টেস্ট ডাটা (Sample Data)
students.Add(new Student(101, "Khaled", 25, 78));
students.Add(new Student(102, "Rahim", 22, 65));
students.Add(new Student(103, "Karim", 24, 88));

bool isRunning = true;

while (isRunning)
{
    Console.Clear();
    Console.WriteLine("===== Student Management System =====\n");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. View All Students");
    Console.WriteLine("3. Search Student");
    Console.WriteLine("4. Update Student");
    Console.WriteLine("5. Delete Student");
    Console.WriteLine("6. Exit\n");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddStudent();
            break;
        case "2":
            ViewAllStudents();
            break;
        case "3":
            SearchStudent();
            break;
        case "4":
            UpdateStudent();
            break;
        case "5":
            DeleteStudent();
            break;
        case "6":
            isRunning = false;
            Console.WriteLine("\nExiting program. Goodbye!");
            break;
        default:
            Console.WriteLine("\nInvalid option! Press Enter to try again.");
            Console.ReadLine();
            break;
    }
}

// 1. Add Student
void AddStudent()
{
    Console.Clear();
    Console.WriteLine("--- Add New Student ---\n");

    Console.Write("Student ID: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("Invalid ID format!");
        Pause();
        return;
    }

    if (students.Exists(s => s.Id == id))
    {
        Console.WriteLine("A student with this ID already exists!");
        Pause();
        return;
    }

    Console.Write("Name: ");
    string name = Console.ReadLine();

    Console.Write("Age: ");
    int.TryParse(Console.ReadLine(), out int age);

    Console.Write("Marks: ");
    double.TryParse(Console.ReadLine(), out double marks);

    students.Add(new Student(id, name, age, marks));
    Console.WriteLine("\nStudent added successfully!");
    Pause();
}

// 2. View All Students
void ViewAllStudents()
{
    Console.Clear();
    Console.WriteLine("--- Student List ---\n");

    if (students.Count == 0)
    {
        Console.WriteLine("No students found.");
    }
    else
    {
        Console.WriteLine("{0,-8} {1,-15} {2,-8} {3,-8}", "ID", "Name", "Age", "Marks");
        Console.WriteLine("----------------------------------------");

        foreach (var student in students)
        {
            Console.WriteLine("{0,-8} {1,-15} {2,-8} {3,-8}", student.Id, student.Name, student.Age, student.Marks);
        }
    }

    Pause();
}

// 3. Search Student
void SearchStudent()
{
    Console.Clear();
    Console.WriteLine("--- Search Student ---\n");

    Console.Write("Enter Student ID: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        Student student = students.Find(s => s.Id == id);

        if (student != null)
        {
            Console.WriteLine("\nStudent Found!");
            Console.WriteLine($"Name: {student.Name}");
            Console.WriteLine($"Age: {student.Age}");
            Console.WriteLine($"Marks: {student.Marks}");
        }
        else
        {
            Console.WriteLine("\nStudent Not Found!");
        }
    }
    else
    {
        Console.WriteLine("\nInvalid ID input!");
    }

    Pause();
}

// 4. Update Student
void UpdateStudent()
{
    Console.Clear();
    Console.WriteLine("--- Update Student ---\n");

    Console.Write("Enter Student ID: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        Student student = students.Find(s => s.Id == id);

        if (student != null)
        {
            Console.Write("\nNew Name: ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                student.Name = newName;
            }

            Console.Write("New Age: ");
            if (int.TryParse(Console.ReadLine(), out int newAge))
            {
                student.Age = newAge;
            }

            Console.Write("New Marks: ");
            if (double.TryParse(Console.ReadLine(), out double newMarks))
            {
                student.Marks = newMarks;
            }

            Console.WriteLine("\nStudent updated successfully.");
        }
        else
        {
            Console.WriteLine("\nStudent Not Found!");
        }
    }
    else
    {
        Console.WriteLine("\nInvalid ID input!");
    }

    Pause();
}

// 5. Delete Student
void DeleteStudent()
{
    Console.Clear();
    Console.WriteLine("--- Delete Student ---\n");

    Console.Write("Enter Student ID: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        Student student = students.Find(s => s.Id == id);

        if (student != null)
        {
            Console.Write("\nAre you sure? (Y/N): ");
            string confirm = Console.ReadLine();

            if (confirm.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                students.Remove(student);
                Console.WriteLine("\nStudent deleted successfully.");
            }
            else
            {
                Console.WriteLine("\nDeletion canceled.");
            }
        }
        else
        {
            Console.WriteLine("\nStudent Not Found!");
        }
    }
    else
    {
        Console.WriteLine("\nInvalid ID input!");
    }

    Pause();
}

void Pause()
{
    Console.WriteLine("\nPress Enter to return to main menu...");
    Console.ReadLine();
}

// স্টুডেন্টের Class
class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public double Marks { get; set; }

    public Student(int id, string name, int age, double marks)
    {
        Id = id;
        Name = name;
        Age = age;
        Marks = marks;
    }
}
