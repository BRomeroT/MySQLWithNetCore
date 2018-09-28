using MySQLNetCore.Model;
using System;

namespace MySQLNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DemoDataContext();

            Console.Write("Nombre del nuevo log: ");
            var nuevoLog = new Log()
            {
                Text = Console.ReadLine()
            };
            if (!string.IsNullOrEmpty(nuevoLog.Text))
            {
                db.Logs.Add(nuevoLog);
                Console.WriteLine($"Guardando log {nuevoLog.Text}...");
                db.SaveChanges();
            }

            foreach (var log in db.Logs)
            {
                Console.WriteLine($"{log.Id} - {log.Text}");
            }
            Console.ReadLine();
        }
    }
}
