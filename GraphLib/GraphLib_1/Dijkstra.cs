using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLib
{
    class Dijkstra
    {
        private Graph graph;

        private List<GraphVertexInfo> infos;



        public Dijkstra(Graph graph)
        {
            this.graph = graph;
        }

        /// <summary>
        /// Initialization of information
        /// </summary>
        void InitInfo()
        {
            infos = new List<GraphVertexInfo>();
            foreach (var v in graph.Vertices)
            {
                infos.Add(new GraphVertexInfo(v));
            }
        }

        /// <summary>
        /// Getting information about the vertex of the graph
        /// </summary>
        /// <param name="v">Vertex</param>
        /// <returns>Information about vertex</returns>
        GraphVertexInfo GetVertexInfo(Vertex v)
        {
            foreach (var i in infos)
            {
                if (i.Vertex.Equals(v))
                {
                    return i;
                }
            }

            return null;
        }

        /// <summary>
        /// Finding an unvisited vertex with a minimum sum value
        /// </summary>
        /// <returns>Information about vertex</returns>
        public GraphVertexInfo FindUnvisitedVertexWithMinSum()
        {
            var minValue = int.MaxValue;
            GraphVertexInfo minVertexInfo = null;
            foreach (var i in infos)
            {
                if (i.IsUnvisited && i.EdgesWeightSum < minValue)
                {
                    minVertexInfo = i;
                    minValue = i.EdgesWeightSum;
                }
            }

            return minVertexInfo;
        }



        /// <summary>
        /// Finding the shortest path along the vertices
        /// </summary>
        /// <param name="startVertex">Starting vertex</param>
        /// <param name="finishVertex">Ending vertex</param>
        /// <returns>Shortest path</returns>
        public List<Vertex> FindShortestPath(Vertex startVertex, Vertex endVertex)
        {
            InitInfo();
            GraphVertexInfo first = GetVertexInfo(startVertex);
            first.EdgesWeightSum = 0;
            while (true)
            {
                var current = FindUnvisitedVertexWithMinSum();
                if (current == null)
                {
                    break;
                }

                SetSumToNextVertex(current);
            }

            return GetPath(startVertex, endVertex);
        }


        /// <summary>
        /// Calculating the sum of the edge weights for the next vertex
        /// </summary>
        /// <param name="info">Information about the current vertex</param>
        void SetSumToNextVertex(GraphVertexInfo info)
        {
            info.IsUnvisited = false;
            foreach (var e in info.Vertex.Edges)
            {
                GraphVertexInfo nextInfo;
                if (graph.IsOrientedGraph) 
                {
                    nextInfo = GetVertexInfo(e.EndVertex);
                }
                else
                {
                    nextInfo = info.Vertex == e.StartVertex ? GetVertexInfo(e.EndVertex) : GetVertexInfo(e.StartVertex);
                }

                var sum = info.EdgesWeightSum + e.Weight;
                if (sum < nextInfo.EdgesWeightSum)
                {
                    nextInfo.EdgesWeightSum = sum;
                    nextInfo.PreviousVertex = info.Vertex;
                }
            }
        }

        /// <summary>
        /// Path formation
        /// </summary>
        /// <param name="startVertex">Starting vertex</param>
        /// <param name="endVertex">Ending vertex</param>
        /// <returns>Path</returns>
        List<Vertex> GetPath(Vertex startVertex,Vertex endVertex)
        {
            List<Vertex> path = new List<Vertex>();
            path.Add(endVertex);


            while (startVertex != endVertex)
            {
                endVertex = GetVertexInfo(endVertex).PreviousVertex;
                path.Add(endVertex);
                if (endVertex == null) return new List<Vertex>();
            }
            path.Reverse();

            return path;
        }
    }
}
