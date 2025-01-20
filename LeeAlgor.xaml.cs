using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Графы
{
    /// <summary>
    /// Логика взаимодействия для LeeAlgor.xaml
    /// </summary>
    public partial class LeeAlgor : Window
    {
        private LeeAlgorithm path;
        private int[,] maze = {
            { 0, 0, 0, 1, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 1, 0, 0, 0 },
            { 0, 0, 0, 1, 1 },
            { 1, 1, 0, 0, 0 }
        };

        private readonly int cellSize = 50;
        public LeeAlgor()
        {
            InitializeComponent();
            //InitializeGraph();
            DrawMaze();
        }

        private void DrawMaze()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Rectangle rect = new Rectangle
                    {
                        Width = cellSize,
                        Height = cellSize,
                        Fill = maze[i, j] == 1 ? Brushes.Black : Brushes.White,
                        Stroke = Brushes.Gray
                    };
                    Canvas.SetLeft(rect, j * cellSize);
                    Canvas.SetTop(rect, i * cellSize);
                    GraphCanvas.Children.Add(rect);
                }
            }
        }
        private void FindPath_Click(object sender, RoutedEventArgs e)
        {
            var start = (0, 0);
            var end = (4, 4);
            var leeAlgoritm = new LeeAlgorithm();
            
            var path = leeAlgoritm.FindPath(maze, start, end);

            if (path != null)
            {
                foreach (var point in path)
                {
                    DrawPath(point);
                }
            }
            else
            {
                MessageBox.Show("Путь не найден.");
            }
        }
        private void DrawPath((int x, int y) point)
        {
            Rectangle rect = new Rectangle
            {
                Width = cellSize,
                Height = cellSize,
                Fill = Brushes.Red
            };
            Canvas.SetLeft(rect, point.y * cellSize);
            Canvas.SetTop(rect, point.x * cellSize);
            GraphCanvas.Children.Add(rect);
        }


    }
}
