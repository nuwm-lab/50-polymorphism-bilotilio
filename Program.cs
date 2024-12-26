using System;

namespace LabWork
{
    // Батьківський клас "Вектор"
    class Vector
    {
        protected int[] elements; // Масив для збереження елементів вектора
        protected int size; // Розмір вектора

        public Vector(int size)
        {
            this.size = size;
            elements = new int[size];
        }

        // Віртуальний метод для задання елементів
        public virtual void SetElements()
        {
            Console.WriteLine("Введіть елементи вектора:");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Елемент {i + 1}: ");
                elements[i] = int.Parse(Console.ReadLine());
            }
        }

        // Віртуальний метод для виведення елементів
        public virtual void Display()
        {
            Console.WriteLine("Елементи вектора:");
            for (int i = 0; i < size; i++)
            {
                Console.Write(elements[i] + " ");
            }
            Console.WriteLine();
        }

        // Віртуальний метод для пошуку максимального елемента
        public virtual int FindMax()
        {
            int max = elements[0];
            for (int i = 1; i < size; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }
            return max;
        }
    }

    // Похідний клас "Матриця"
    class Matrix : Vector
    {
        private int[,] matrixElements; // Масив для збереження елементів матриці
        private int rows; // Кількість рядків
        private int cols; // Кількість стовпців

        public Matrix(int rows, int cols) : base(rows * cols)
        {
            this.rows = rows;
            this.cols = cols;
            matrixElements = new int[rows, cols];
        }

        // Перевантажений метод для задання елементів матриці
        public override void SetElements()
        {
            Console.WriteLine("Введіть елементи матриці:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Елемент ({i + 1}, {j + 1}): ");
                    matrixElements[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        // Перевантажений метод для виведення матриці
        public override void Display()
        {
            Console.WriteLine("Елементи матриці:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrixElements[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        // Перевантажений метод для пошуку максимального елемента матриці
        public override int FindMax()
        {
            int max = matrixElements[0, 0];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrixElements[i, j] > max)
                    {
                        max = matrixElements[i, j];
                    }
                }
            }
            return max;
        }
    }

    // Основний клас для запуску програми
    class Program
    {
        static void Main(string[] args)
        {
            // Змінна для динамічного створення об'єкта
            Vector vectorOrMatrix;

            // Задаємо тип об'єкта на основі вибору користувача
            Console.WriteLine("Виберіть тип об'єкта: 1 - Вектор, 2 - Матриця");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                // Динамічно створюємо об'єкт класу Vector
                Console.Write("Введіть розмір вектора: ");
                int size = int.Parse(Console.ReadLine());
                vectorOrMatrix = new Vector(size);
            }
            else if (choice == 2)
            {
                // Динамічно створюємо об'єкт класу Matrix
                Console.Write("Введіть кількість рядків матриці: ");
                int rows = int.Parse(Console.ReadLine());
                Console.Write("Введіть кількість стовпців матриці: ");
                int cols = int.Parse(Console.ReadLine());
                vectorOrMatrix = new Matrix(rows, cols);
            }
            else
            {
                Console.WriteLine("Невірний вибір.");
                return;
            }

            // Викликаємо віртуальні методи
            vectorOrMatrix.SetElements();
            vectorOrMatrix.Display();
            Console.WriteLine($"Максимальний елемент: {vectorOrMatrix.FindMax()}");
        }
    }
}
