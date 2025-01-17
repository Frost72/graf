using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Графы
{
    public class A
    {
        private readonly Node[] _nodes;
        private readonly Func<int, int> _heuristic;

        public A(Node[] nodes, Func<int, int> heuristic)
        {
            _nodes = nodes;
            _heuristic = heuristic;
        }

        public List<int> FindPath(int startId, int goalId)
        {
            var openSet = new SortedSet<NodeScore>();
            

            var cameFrom = new Dictionary<int, int>();
            var gScore = new Dictionary<int, int>();
            var fScore = new Dictionary<int, int>();

            foreach (var node in _nodes)
            {
                gScore[node.Id] = int.MaxValue;
                fScore[node.Id] = int.MaxValue;
            }

            gScore[startId] = 0;
            fScore[startId] = _heuristic(startId);
            openSet.Add(new NodeScore(fScore[startId], startId));
            while (openSet.Count > 0)
            {
                var current = openSet.Min.Id;
                if (current == goalId)
                {
                    return ReconstructPath(cameFrom, current);
                }

                openSet.Remove(openSet.Min);

                foreach (var edge in _nodes[current].Neighbors)
                {
                    var tentativeGScore = gScore[current] + edge.Cost;

                    if (tentativeGScore < gScore[edge.To])
                    {
                        cameFrom[edge.To] = current;
                        gScore[edge.To] = tentativeGScore;
                        fScore[edge.To] = gScore[edge.To] + _heuristic(edge.To);

                        if (!openSet.Contains(new NodeScore(fScore[edge.To], edge.To)))
                        {
                            openSet.Add(new NodeScore(fScore[edge.To], edge.To));
                        }

                    }
                }
            }

            return new List<int>(); // Путь не найден
        }
        private List<int> ReconstructPath(Dictionary<int, int> cameFrom, int current)
        {
            var totalPath = new List<int> { current };
            while (cameFrom.ContainsKey(current))
            {
                current = cameFrom[current];
                totalPath.Add(current);
            }
            totalPath.Reverse();
            return totalPath;
        }
    }
    public class NodeScore : IComparable<NodeScore>
    {
        public int FScore { get; }
        public int Id { get; }

        public NodeScore(int fScore, int id)
        {
            FScore = fScore;
            Id = id;
        }

        public int CompareTo(NodeScore other)
        {
            if (FScore == other.FScore)
                return Id.CompareTo(other.Id);
            return FScore.CompareTo(other.FScore);
        }
    }

}
