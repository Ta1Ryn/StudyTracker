string curse = "Основы C#";
Console.WriteLine("StudyTracker\n{curse}");
string menu = "1. Добавить курс\n2. Показать мои курсы\n3. Отметить пройденную тему\n4. Записать время занятия\n5. Посмотреть прогресс\n0. Выход";
byte a = 0;
do
{
    Console.WriteLine(menu);
    Console.Write("\nВведите число: ");
    a = Convert.ToByte(Console.ReadLine());
    
}
while(a > 0);
