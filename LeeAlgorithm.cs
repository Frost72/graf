using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Графы
{
    public class LeeAlgorithm
    {
        private  readonly int[] dx = { -1, 1, 0, 0 }; // Сдвиги по строкам
        private  readonly int[] dy = { 0, 0, -1, 1 }; // Сдвиги по столбцам

        // Метод для поиска кратчайшего пути
        public  List<(int, int)> FindPath(int[,] maze, (int, int) start, (int, int) end)
        {
            int rows = maze.GetLength(0);
            int cols = maze.GetLength(1);
            int[,] distances = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    distances[i, j] = -1;
                }
            } // Инициализация непосещённых ячеек

            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue(start);
            distances[start.Item1, start.Item2] = 0;

            // Шаг 1–5: Поиск пути
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                int x = current.Item1;
                int y = current.Item2;

                for (int i = 0; i < 4; i++)
                {
                    int nx = x + dx[i];
                    int ny = y + dy[i];

                    if (nx >= 0 && nx < rows && ny >= 0 && ny < cols &&
                        maze[nx, ny] == 0 && distances[nx, ny] == -1)
                    {
                        distances[nx, ny] = distances[x, y] + 1;
                        queue.Enqueue((nx, ny));
                    }
                }
            }

            // Если конец не был достигнут
            if (distances[end.Item1, end.Item2] == -1)
                return null;

            // Поиск кратчайшего пути (обратный проход)
            List<(int, int)> path = new List<(int, int)>();
            var currentPos = end;
            path.Add(currentPos);

            while (currentPos != start)
            {
                int x = currentPos.Item1;
                int y = currentPos.Item2;

                for (int i = 0; i < 4; i++)
                {
                    int nx = x + dx[i];
                    int ny = y + dy[i];

                    if (nx >= 0 && nx < rows && ny >= 0 && ny < cols &&
                        distances[nx, ny] == distances[x, y] - 1)
                    {
                        currentPos = (nx, ny);
                        path.Add(currentPos);
                        break;
                    }
                }
            }

            path.Reverse(); // Путь найден в обратном порядке
            return path;
        }
    }
}
