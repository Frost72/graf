using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Графы
{
    public class Node
    {
        public int Id { get; }
        public List<Edge> Neighbors { get; }
        public Point Position { get; }

        public Node(int id, Point position)
        {
            Id = id;
            Position = position;
            Neighbors = new List<Edge>();
        }

        public void AddNeighbor(int to, int cost)
        {
            Neighbors.Add(new Edge(to, cost));
        }
    }
}
