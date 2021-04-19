using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GraphLib
{
    public class DepthFirstSearch
    {
        // List of visited vertices
        private HashSet<Vertex> visited;
        // Path from the starting vertex to the target vertex.
        private LinkedList<Vertex> path;
        private Vertex goal;
        // Indicates whether edge orientation should be considered
        private bool isOriented = false;

        public LinkedList<Vertex> DFS(Vertex start, Vertex goal, bool isOriented = false)
        {
            visited = new HashSet<Vertex>();
            path = new LinkedList<Vertex>();
            if(start == goal)
            {
                path.AddFirst(start);
                return path;
            }

            this.goal = goal;
            this.isOriented = isOriented;
            DFS(start);
            if (path.Count > 0)
            {
                path.AddFirst(start);
            }
            return path;
        }

        private bool DFS(Vertex vertex)
        {
            if (vertex == goal)
            {
                return true;
            }

            visited.Add(vertex);

            List<Vertex> neighbors = isOriented ? vertex.EndNeighboringVertices : vertex.NeighboringVertices;
            foreach (var neighbor in neighbors.Where(x => !visited.Contains(x)))
            {
                if (DFS(neighbor))
                {
                    path.AddFirst(neighbor);
                    return true;
                }
            }
            return false;
        }
    }
}
