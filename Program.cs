namespace OTUS.HW5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Пример использования функции расширения GetMax
            List<string> words = new List<string> { "Отус", "Гикбрейнс", "Скиллфактори" };
            var longestWord = words.GetMax(word => word.Length);
            Console.WriteLine($"Самое длинное слово: {longestWord}");

            // Пример использования FileSearcher
            var searcher = new FileSearcher();
            searcher.FileFound += OnFileFound;

            Console.WriteLine("Старт поиска файлов...");
            searcher.Search("C:\\Users\\user\\source\\repos\\WebApplication2");

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        private static void OnFileFound(object sender, FileArgs e)
        {
            Console.WriteLine($"Файл найден: {e.FileName}");

            // Добавляем возможность отмены поиска при нахождении определённого файла (для примера файл решения)
            if (e.FileName.EndsWith(".sln"))
            {
                Console.WriteLine("Файл решения найден, отмена поиска...");
                ((FileSearcher)sender).CancelSearch();
            }
        }
    }
}
