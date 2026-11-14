using System.Runtime.InteropServices.Marshalling;

string curse = "Основы C#";
Console.WriteLine("StudyTracker\n{curse}");
string menu = "1. Добавить курс\n2. Показать мои курсы\n3. Отметить пройденную тему\n4. Записать время занятия\n5. Посмотреть прогресс\n0. Выход";
byte a = 0;
do
{
    Console.WriteLine(menu);
    Console.Write("\nВведите число: ");
    a = Convert.ToByte(Console.ReadLine());
    switch(a)
    {
        case 1:

        case 2:

        case 3:

        case 4:

        case 5:

        case 0:
        break;
    }


}
while(a > 0);
