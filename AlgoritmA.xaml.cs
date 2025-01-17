using System;
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
    /// Логика взаимодействия для AlgoritmA.xaml
    /// </summary>
    public partial class AlgoritmA : Window
    {
        private Node[] nodes;
        public AlgoritmA()
        {
            InitializeComponent();
            InitializeGraph();
            DrawGraph();
        }
        private void InitializeGraph()
        {
            nodes = new Node[5];
            nodes[0] = new Node(0, new Point(50, 300));
            nodes[1] = new Node(1, new Point(150, 100));
            nodes[2] = new Node(2, new Point(250, 200));
            nodes[3] = new Node(3, new Point(350, 100));
            nodes[4] = new Node(4, new Point(450, 300));

            // Добавление соседей
            nodes[0].AddNeighbor(1, 10);
            nodes[0].AddNeighbor(2, 3);
            nodes[1].AddNeighbor(2, 1);
            nodes[1].AddNeighbor(3, 2);
            nodes[2].AddNeighbor(1, 4);
            nodes[2].AddNeighbor(3, 8);
            nodes[2].AddNeighbor(4, 2);
            nodes[3].AddNeighbor(4, 7);
        }

        private void DrawGraph()
        {
            foreach (var node in nodes)
            {
                DrawNode(node);
                foreach (var edge in node.Neighbors)
                {
                    DrawEdge(node.Position, nodes[edge.To].Position);
                }
            }
        }

        private void DrawNode(Node node)
        {
            var ellipse = new Ellipse
            {
                Fill = Brushes.Blue,
                Width = 20,
                Height = 20,
                Stroke = Brushes.Black
            };

            Canvas.SetLeft(ellipse, node.Position.X - ellipse.Width / 2);
            Canvas.SetTop(ellipse, node.Position.Y - ellipse.Height / 2);
            GraphCanvas.Children.Add(ellipse);

            var textBlock = new System.Windows.Controls.TextBlock
            {
                Text = node.Id.ToString(),
                Foreground = Brushes.White,
                FontWeight = FontWeights.Bold
            };

            Canvas.SetLeft(textBlock, node.Position.X - 5);
            Canvas.SetTop(textBlock, node.Position.Y - 10);
            GraphCanvas.Children.Add(textBlock);
        }

        private void DrawEdge(Point from, Point to)
        {
            var line = new Line
            {
                Stroke = Brushes.Gray,
                X1 = from.X,
                Y1 = from.Y,
                X2 = to.X,
                Y2 = to.Y,
                StrokeThickness = 2
            };
            GraphCanvas.Children.Add(line);
        }

        private void FindPath_Click(object sender, RoutedEventArgs e)
        {
            Func<int, int> heuristic = id => id == 4 ? 0 : Math.Abs(id - 4); // Пример: расстояние до вершины 4

            var aStar = new A(nodes, heuristic);
            var path = aStar.FindPath(0, 4);

            if (path.Count > 0)
            {
                HighlightPath(path);
                MessageBox.Show("Кратчайший путь найден: " + string.Join(" -> ", path));
            }
            else
            {
                MessageBox.Show("Путь не найден.");
            }
        }

        private void HighlightPath(List<int> path)
        {
            for (int i = 0; i < path.Count - 1; i++)
            {
                var fromNode = nodes[path[i]];
                var toNode = nodes[path[i + 1]];

                var line = new Line
                {
                    Stroke = Brushes.Red,
                    X1 = fromNode.Position.X,
                    Y1 = fromNode.Position.Y,
                    X2 = toNode.Position.X,
                    Y2 = toNode.Position.Y,
                    StrokeThickness = 4
                };

                GraphCanvas.Children.Add(line);
            }
        }

    }
}
