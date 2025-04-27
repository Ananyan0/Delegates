namespace Extension_Filter;

class Student
{
    public int Age { get; set; }

    public Student(int age)
    {
        Age = age;
    }
}

static class Extension
{
    public static List<T> Filter<T>(this List<T> list, Func<T, bool> isOkay)
    {
        List<T> newList = new List<T>();
        for(int i = 0; i < list.Count; i++)
        {
            if(isOkay(list[i]))
            {
                newList.Add(list[i]);
            }
        }
        return newList;
    }
}


class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>(){
            new Student(10),
            new Student(22),
            new Student(31),
            new Student(4),
            new Student(0),
        };

        List<Student> newList = students.Filter(a => a.Age > 20);

        foreach(Student student in newList)
        {
            System.Console.Write(student.Age + " ");
        }
    }
}