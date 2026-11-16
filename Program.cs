
List<Course> courses = new List<Course>();

Course firstCourse = new Course();
firstCourse.Name = "Основы C#";
firstCourse.TotalTopics = 20;
courses.Add(firstCourse);

string menu = "1. Добавить курс\n2. Показать мои курсы\n3. Отметить пройденную тему\n4. Записать время занятия\n5. Посмотреть прогресс\n0. Выход";
int action = 0;

Console.WriteLine("StudyTracker");

do
{
    Console.WriteLine();
    Console.WriteLine(menu);
    action = ReadNumber("\nВведите число: ");

    if (action == -1)
    {
        break;
    }

    switch (action)
    {
        case 1:
        {
            Console.Write("Введите название курса: ");
            string? name = Console.ReadLine();

            if (name == null)
            {
                break;
            }

            name = name.Trim();
            if (name.Length == 0)
            {
                Console.WriteLine("Название курса должно содержать текст.");
                break;
            }

            int totalTopics = ReadNumber("Сколько тем в курсе? ");
            if (totalTopics == -1)
            {
                break;
            }

            Course newCourse = new Course();
            newCourse.Name = name;
            newCourse.TotalTopics = totalTopics;
            courses.Add(newCourse);

            Console.WriteLine($"Курс «{newCourse.Name}» добавлен.");
            break;
        }

        case 2:
            ShowCourses(courses);
            break;

        case 3:
        {
            int courseIndex = SelectCourse(courses);
            if (courseIndex == -1)
            {
                break;
            }

            Course selectedCourse = courses[courseIndex];

            if (selectedCourse.TotalTopics == 0)
            {
                Console.WriteLine("В этом курсе пока нет тем.");
            }
            else if (selectedCourse.CompletedTopics == selectedCourse.TotalTopics)
            {
                Console.WriteLine("Все темы этого курса уже пройдены.");
            }
            else
            {
                selectedCourse.CompletedTopics++;
                Console.WriteLine($"«{selectedCourse.Name}»: пройдено {selectedCourse.CompletedTopics} из {selectedCourse.TotalTopics} тем.");
            }

            break;
        }

        case 4:
        {
            int courseIndex = SelectCourse(courses);
            if (courseIndex == -1)
            {
                break;
            }

            Course selectedCourse = courses[courseIndex];
            int minutes = ReadNumber("Сколько минут занимались? ");
            if (minutes == -1)
            {
                break;
            }

            if (minutes == 0)
            {
                Console.WriteLine("Занятие должно длиться хотя бы 1 минуту.");
                break;
            }

            if (minutes > int.MaxValue - selectedCourse.time_work)
            {
                Console.WriteLine("Слишком большое количество минут.");
                break;
            }

            selectedCourse.time_work += minutes;
            Console.WriteLine($"«{selectedCourse.Name}»: всего {selectedCourse.time_work} мин.");
            break;
        }

        case 5:
        {
            int courseIndex = SelectCourse(courses);
            if (courseIndex == -1)
            {
                break;
            }

            Course selectedCourse = courses[courseIndex];
            double progress = 0;

            if (selectedCourse.TotalTopics > 0)
            {
                progress = selectedCourse.CompletedTopics * 100.0 / selectedCourse.TotalTopics;
            }

            Console.WriteLine($"Курс: {selectedCourse.Name}");
            Console.WriteLine($"Пройдено тем: {selectedCourse.CompletedTopics} из {selectedCourse.TotalTopics}");
            Console.WriteLine($"Осталось тем: {selectedCourse.TotalTopics - selectedCourse.CompletedTopics}");
            Console.WriteLine($"Прогресс: {progress:F1}%");
            Console.WriteLine($"Время занятий: {selectedCourse.time_work} мин.");
            break;
        }

        case 0:
            break;

        default:
            Console.WriteLine("Выберите пункт меню от 0 до 5.");
            break;
    }
}
while (action != 0);

Console.WriteLine("Работа завершена.");

static void ShowCourses(List<Course> courses)
{
    if (courses.Count == 0)
    {
        Console.WriteLine("Пока нет курсов.");
        return;
    }

    int number = 1;
    foreach (Course item in courses)
    {
        Console.WriteLine($"{number}. {item.Name}");
        number++;
    }
}

static int SelectCourse(List<Course> courses)
{
    ShowCourses(courses);
    if (courses.Count == 0)
    {
        return -1;
    }

    while (true)
    {
        int number = ReadNumber("Выберите номер курса (0 — вернуться в меню): ");
        if (number == -1 || number == 0)
        {
            return -1;
        }

        if (number <= courses.Count)
        {

            return number - 1;
        }

        Console.WriteLine("Такого номера курса нет. Выберите номер из списка.");
    }
}

static int ReadNumber(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        if (input == null)
        {
            return -1;
        }


        if (int.TryParse(input, out int number) && number >= 0)
        {
            return number;
        }

        Console.WriteLine("Введите целое число, которое не меньше нуля.");
    }
}

class Course
{
    public string Name = "-";
    public int TotalTopics;     // Всего тем.
    public int CompletedTopics; // Пройдено тем. 
    public int time_work;       // Сумма минут занятий.
}
