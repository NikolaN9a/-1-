using System.Collections;

namespace домашна_работа_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Console.InputEncoding = System.Text.Encoding.UTF8;

            // 1. Регистрация
            ArrayList v = new ArrayList { "Anna", "Ivan", "Maria", "Georgi", "Peter", "Elena", "Nikolay" };
            v.AddRange(new[] { "Dimitar", "Ivo", "Sofia" });
            v.Insert(3, "Stefan");
            Console.Write("1. Регистрация", v);

            // 2. Проблем на входа
            v.Remove("Ivan");
            if (v.Count > 2) v.RemoveAt(2);
            if (v.Contains("Maria")) Console.WriteLine("Maria е в списъка.");
            else Console.WriteLine("Maria не е в списъка.");
            Console.WriteLine("Брой посетители: " + v.Count);
            Console.Write("2. След напускане", v);

            // 3. VIP посетители
            v.InsertRange(0, new[] { "VIP_Victor", "VIP_Diana" });
            if (v.Contains("Georgi")) v[v.IndexOf("Georgi")] = "VIP_Georgi";
            Console.WriteLine("Peter е на индекс: " + v.IndexOf("Peter"));
            Console.Write("3. VIP", v);

            // 4. Техническа повреда (отзад напред, за да не се разместват индексите)
            for (int i = v.Count - 1; i >= 0; i--)
                if (v[i] is string n && (n.Length < 4 || n[0] == 'A')) v.RemoveAt(i);
            Console.Write("4. След повредата", v);

            // 5. Ново подреждане
            v.Sort();
            v.Reverse();
            if (v.Count > 1)
            {
                var t = v[0];
                v[0] = v[v.Count - 1];
                v[v.Count - 1] = t;
            }

            Console.WriteLine("5. Ново подреждане", v); 

            // 6. Проверка преди затваряне
            if (v.Count > 5) Console.WriteLine("Паркът беше пълен днес!");
            else if (v.Count >= 1) Console.WriteLine("Днес беше спокоен ден!");
            else Console.WriteLine("Паркът беше празен!");
            if (v.Count > 0) Console.WriteLine("Първи: " + v[0] + ", последен: " + v[v.Count - 1]);

            // 7. Бонус
            Console.Write("\nВъведете име за добавяне: ");
            string name = (Console.ReadLine() ?? "").Trim();
            if (name == "") Console.WriteLine("Не е въведено име.");
            else if (v.Contains(name)) Console.WriteLine(name + " вече е регистриран.");
            else { v.Add(name); Console.WriteLine(name + " е добавен."); }

            Console.Write("Въведете име за изтриване: ");
            name = (Console.ReadLine() ?? "").Trim();
            if (v.Contains(name)) { v.Remove(name); Console.WriteLine(name + " е изтрит."); }
            else Console.WriteLine("Няма такъв посетител.");

            Console.Write("Краен списък", v);
        }
    }
}
