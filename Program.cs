using System;

namespace SphereVolumeCalculator
{
    // Батьківський клас "Геометрична фігура"
    class GeometricShape
    {
        // Віртуальний метод для введення даних
        public virtual void SetData()
        {
            Console.WriteLine("Батьківський клас: SetData");
        }

        // Віртуальний метод для обчислення об’єму
        public virtual double CalculateVolume()
        {
            Console.WriteLine("Батьківський клас: CalculateVolume");
            return 0;
        }

        // Метод для відображення результату
        public virtual void DisplayVolume()
        {
            Console.WriteLine("Об’єм: " + CalculateVolume());
        }
    }

    // Похідний клас "Куля"
    class Sphere : GeometricShape
    {
        private double radius;

        // Перевантажений метод для введення даних
        public override void SetData()
        {
            Console.Write("Введіть радіус кулі: ");
            radius = double.Parse(Console.ReadLine());
        }

        // Перевантажений метод для обчислення об’єму кулі
        public override double CalculateVolume()
        {
            return (4.0 / 3) * Math.PI * Math.Pow(radius, 3);
        }

        // Перевантажений метод для відображення результату
        public override void DisplayVolume()
        {
            Console.WriteLine($"Об’єм кулі з радіусом {radius} дорівнює: {CalculateVolume():F2}");
        }
    }

    // Основний клас для запуску програми
    class Program
    {
        static void Main(string[] args)
        {
            // Динамічне створення об’єкта
            GeometricShape shape;

            Console.WriteLine("Обчислення об’єму геометричної фігури.");
            Console.WriteLine("Виберіть тип фігури: 1 - Куля");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                shape = new Sphere();
            }
            else
            {
                Console.WriteLine("Невірний вибір.");
                return;
            }

            // Використання віртуальних методів
            shape.SetData();
            shape.DisplayVolume();
        }
    }
}
