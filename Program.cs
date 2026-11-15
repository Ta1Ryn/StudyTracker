using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;

List<Course> courses = new List<Course>();
Course course = new Course();
course.Name = "Основы C#";
courses.Add(course);
string menu = "1. Добавить курс\n2. Показать мои курсы\n3. Отметить пройденную тему\n4. Записать время занятия\n5. Посмотреть прогресс\n0. Выход";
int a = 0;
do
{
    Console.WriteLine(menu);
    Console.Write("\nВведите число: ");
    a = Convert.ToInt32(Console.ReadLine());
    switch(a)
    {
        case 1:
            Console.Write("Введите название курса: ");
            course = new Course();
            course.Name = Console.ReadLine();
            courses.Add(course);
            break;
        case 2:
        foreach(Course item in courses)
            {
            Console.WriteLine($"курс {item.Name}");
            }
            break;
        case 3:

        case 4:

        case 5:

        case 0:
        break;
    }


}
while(a > 0);
class Course
{
    public string Name = "-";
    public int time_work;
}
