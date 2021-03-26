using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// 
/// Constructors and properties
/// 
/// </summary>
namespace GraphLib
{
    public partial class Graph
    {

        public bool IsOrientedGraph { get; private set; }

        private List<Vertex> vertices = new List<Vertex>();

        public readonly string DefaultVertexName;
        public readonly string DefaultEdgeName;

        public Graph() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adjacencyMatrix"></param>
        /// <param name="isOrientedGraph"></param>
        /// <param name="vertexName">Default vertex name</param>
        /// <param name="edgeName">Default edge name</param>
        public Graph(int[][] adjacencyMatrix, bool isOrientedGraph, string vertexName, string edgeName) : 
            this(AdjacencyMatrixToVerticesList(adjacencyMatrix, isOrientedGraph, vertexName, edgeName),isOrientedGraph) 
        {
            DefaultEdgeName = edgeName;
            DefaultVertexName = vertexName;
        }

        public Graph(List<Vertex> vertices, bool isOrientedGraph)
        {
            if (vertices == null) throw new NullReferenceException("Vertices can not be null");
            this.vertices = vertices;
            IsOrientedGraph = isOrientedGraph;

            if(vertices.Count > 0)
            {
                List<Edge> tmpEdges = vertices[0].Edges;
                foreach (Vertex vertex in vertices)
                {
                    tmpEdges = tmpEdges.Union(vertex.Edges, new EdgeReferenceEqualityComparer()).ToList();
                }
                EdgesCount = tmpEdges.Count;
            }
        }

        public bool IsVerticesEmpty => VerticesCount == 0;
        public bool IsEdgesEmpty => EdgesCount == 0;
        public int VerticesCount => vertices.Count;
        public int EdgesCount { get; private set; } = 0;
        public List<Vertex> Vertices => vertices;

        public Vertex this[int vertexIndex]
        {
            get { return vertices[vertexIndex]; }
            set { vertices[vertexIndex] = value; }
        }


        public bool IsMultiGraph => vertices.Any(v1 => vertices.Any(v2 => v1 != v2 && v1.IncidentalEdges(v2).Count > 1));

        /// <summary>
        /// If this graph is not oriented, it returns a value that indicates whether it is connected
        /// </summary>
        public bool IsConnectedGraph => IsOrientedGraph ? false : isConnectedGraph();

        /// <summary>
        /// If this graph is oriented, it returns a value that indicates whether it is connected.
        /// An oriented graph is said to be strongly connected if it has a (oriented) path from any vertex to any other
        /// </summary>
        public bool IsStrongConectedGraph => IsOrientedGraph == false ? false : isConnectedGraph();


        /// <summary>
        /// If this graph is oriented, it returns a value that indicates whether it is unilaterally connected.
        /// An oriented graph is called unilaterally connected if for any two of its vertices 
        /// u and v there is at least one of the routes from v to u or from u to v.
        /// </summary>
        public bool IsUnilaterallyConnectedGraph
        {
            get
            {
                for (int i = 0; i < vertices.Count; i++)
                {
                    for (int j = 0; j < vertices.Count; j++)
                        if (!PathExist(vertices[i], vertices[j]) && !PathExist(vertices[j], vertices[i]))
                        {
                            return false;
                        }
                }

                return true;
            }
        }


        /// <summary>
        /// An oriented graph is called weakly connected if there is a connected unoriented graph 
        /// obtained from it by replacing the oriented edges with non-oriented ones.
        /// </summary>
        public bool IsWeaklyConnectedGraph
        {
            get
            {
                if (IsOrientedGraph == false) throw new Exception("Current graph is non oriented");

                IsOrientedGraph = false;
                bool isWeaklyConnected = isConnectedGraph();
                IsOrientedGraph = true;

                return isWeaklyConnected;
            }
        }

        public bool IsFullGraph
        {
            get
            {
                for (int i = 0; i < VerticesCount; i++)
                    if (VertexDegree(i) != VerticesCount - 1) return false;

                return true;
            }
        }

        public int[][] AdjacencyMatrix => VerticesListToAdjacencyMatrix(vertices, IsOrientedGraph);
        public int[][] IncidenceMatrix => AdjacencyMatrixToIncidence(VerticesListToAdjacencyMatrix(vertices, IsOrientedGraph), IsOrientedGraph);
        public bool IsZeroGraph => EdgesCount == 0;
        public bool IsEmptyGraph => VerticesCount == 0;
        public bool IsRegularGraph => vertices.All(v => v.VertexDegree == this[0].VertexDegree);
        public bool IsHamiltonsGraph => IsRegularGraph && (this[0].VertexDegree * 2 + 1) == EdgesCount;
    }
}





/// <summary>
/// 
/// Methods
/// 
/// </summary>
namespace GraphLib
{
    public partial class Graph
    {
        public bool ContainsVertex(Vertex vertex) => vertices.Contains(vertex);
        public bool ContainsEdge(Edge edge) => vertices.Any(v => v.Edges.Contains(edge));
        public Vertex FindVertex(Vertex vertex) => vertices.Find(v => v.Equals(vertex));
        public Vertex FindVertex(int vertexIndex) => this[vertexIndex];
        public Edge FindEdge(Edge edge) => FindVertex(edge.StartVertex).FindEdge(edge);

        public bool AddVertex(Vertex vertex)
        {
            if (vertex == null || vertices.Contains(vertex)) return false;
            vertices.Add(vertex);
            return true;
        }
        public void AddVertexRange(IEnumerable<Vertex> vertices) => this.vertices.AddRange(vertices);
        public bool RemoveVertex(Vertex vertex) => vertices.Remove(vertex);

        public bool AddEdge(Edge edge)
        {
            if (vertices.Contains(edge.StartVertex) && vertices.Contains(edge.EndVertex))
            {
                edge.StartVertex.AddEdge(edge.EndVertex, IsOrientedGraph, edge.Weight);
                EdgesCount++;
                return true;
            }
            return false;
        }
        public void AddEdgeRange(IEnumerable<Edge> edges)
        {
            foreach (Edge edge in edges)
                AddEdge(edge);
        }

        public bool RemoveEdge(Edge edge)
        {
            if (vertices.Contains(edge.StartVertex) && vertices.Contains(edge.EndVertex))
            {
                edge.StartVertex.RemoveEdge(edge.EndVertex, IsOrientedGraph, edge.Weight);
                EdgesCount--;
                return true;
            }
            return false;
        }

        public void ClearEdges() => vertices.ForEach(v => v.Edges.Clear());
        public void ClearVertices() => vertices.Clear();

        public List<Vertex> FindShortestPath(Vertex startVertex, Vertex endVertex) =>
            (new Dijkstra(this)).FindShortestPath(startVertex, endVertex);

        public List<Vertex> FindShortestPath(int startVertexIndex, int endVertexIndex) =>
            FindShortestPath(this[startVertexIndex], this[endVertexIndex]);

        public List<Edge> FindShortestPathByEdges(int startVertexIndex, int endVertexIndex) =>
            FindShortestPathByEdges(this[startVertexIndex], this[endVertexIndex]);

        public List<Edge> FindShortestPathByEdges(Vertex startVertex, Vertex endVertex)
        {
            List<Vertex> verticesPath = FindShortestPath(startVertex, endVertex);
            List<Edge> edgesPath = new List<Edge>();

            for (int i = 0; i < verticesPath.Count - 1; i++)
            {
                edgesPath.Add(verticesPath[i].IncidentalEdges(verticesPath[i + 1])
                    .Aggregate((e1, e2) => e1.Weight < e2.Weight ? e1 : e2));
            }

            return edgesPath;
        }

        public int WeightShortestPath(Vertex startVertex, Vertex endVertex) =>
            FindShortestPathByEdges(startVertex, endVertex).Sum(e => e.Weight);

        public int WeightShortestPath(int startVertexIndex, int endVertexIndex) =>
            WeightShortestPath(this[startVertexIndex], this[endVertexIndex]);

        public List<Vertex> DepthFirstSearch(Vertex startVertex, Vertex goalVertex) =>
            (new DepthFirstSearch()).DFS(startVertex, goalVertex, IsOrientedGraph).ToList();

        public List<Vertex> DepthFirstSearch(int startVertexIndex, int goalVertexIndex) =>
            this.DepthFirstSearch(this[startVertexIndex], this[goalVertexIndex]);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="startVertex"></param>
        /// <param name="goalVertex"></param>
        /// <returns>Return boolean value which show that exist route between startVertex and goalVertex</returns>
        public bool PathExist(Vertex startVertex, Vertex goalVertex)
        {
            List<Vertex> path = DepthFirstSearch(startVertex, goalVertex);
            return path == null ? false : path.Count > 0;
        }

        /// <summary>
        /// Iincidental edges for vertex1 and vertex2
        /// </summary>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        /// <returns>Returns list of incidental edges for vertex1 and vertex2</returns>
        public List<Edge> IncidentalEdges(Vertex vertex1, Vertex vertex2) => vertex1.IncidentalEdges(vertex2);

        public int VertexDegree(int vertexIndex) => vertices[vertexIndex].VertexDegree;
        public List<Vertex> IsolatedVertices() => vertices.Where(v => v.VertexDegree == 0).ToList();

        private bool isConnectedGraph()
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                for (int j = 0; j < vertices.Count; j++)
                    if (!PathExist(vertices[i], vertices[j]))
                    {
                        Console.WriteLine("path dont exist");
                        Console.WriteLine(vertices[i]);
                        Console.WriteLine(vertices[j]);
                        return false;
                    }
            }

            return true;
        }

        public List<Vertex> Eccentricity(Vertex vertex) => Eccentricity(vertices.IndexOf(vertex));

        public List<Vertex> Eccentricity(int vertexIndex)
        {
            if (IsOrientedGraph)
            {
                if (IsWeaklyConnectedGraph == false) throw new Exception("Graph must be connected.");
            }
            else if (IsConnectedGraph == false) throw new Exception("Graph must be connected.");

            List<Vertex> resultList = new List<Vertex>();
            int resultListWeight = 0;

            for (int i = 0; i < vertices.Count; i++)
            {
                if (i == vertexIndex) continue;

                int tmpWeight = WeightShortestPath(vertexIndex, i);
                if (tmpWeight > resultListWeight)
                {
                    resultListWeight = tmpWeight;
                    resultList = FindShortestPath(vertexIndex, i);
                }
            }

            return resultList;
        }
    }
}



/// <summary>
/// 
/// Static methods
/// 
/// </summary>
namespace GraphLib
{
    public partial class Graph
    {
        /// <summary>
        /// Checks whether the input matrix is symmetrical
        /// </summary>
        /// <param name="matrix">Input matrix</param>
        /// <returns></returns>
        public static bool IsSymmetricalMatrix(int[][] matrix)
        {
            // In order not to check the same elements several times
            int checkedItemInCurrentRow = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = checkedItemInCurrentRow; j < matrix.Length; j++)
                {
                    if (matrix[i][j] != matrix[j][i]) return false;
                }
                checkedItemInCurrentRow++;
            }

            return true;
        }

        /// <summary>
        /// Checks whether the input matrix is adjacency
        /// </summary>
        /// <param name="matrix">Input matrix</param>
        /// <param name="isOrientedGraph"></param>
        /// <returns></returns>
        public static bool IsAdjacencyMatrix(int[][] matrix, bool isOrientedGraph)
        {
            foreach (int[] row in matrix)
            {
                if (matrix.Length != row.Length) return false;
                foreach (int item in row)
                    if (item < 0) return false;
            }

            if (!isOrientedGraph) return IsSymmetricalMatrix(matrix);

            return true;
        }




        /// <summary>
        /// Checks whether the input matrix is incidence
        /// </summary>
        /// <param name="matrix">Input matrix</param>
        /// <param name="isOriented"></param>
        /// <returns></returns>
        public static bool IsIncidenceMatrix(int[][] matrix, bool isOriented)
        {

            for (int j = 0; j < matrix[0].Length; j++)
            {
                int columnSum = 0;
                int zeroCount = 0;
                for (int i = 0; i < matrix.Length; i++)
                {
                    columnSum += matrix[i][j];
                    if (matrix[i][j] == 0) zeroCount++;
                }

                if (isOriented && columnSum != 0) return false;
                if (!isOriented && columnSum != 2) return false;
                if (zeroCount != matrix.Length - 2) return false;
            }


            return true;
        }


        /// <summary>
        /// Convert adjacency matrix to incidence matrix
        /// </summary>
        /// <param name="adjacency">Adjacency matrix</param>
        /// <param name="isOriented"></param>
        /// <returns>Incidence matrix</returns>
        public static int[][] AdjacencyMatrixToIncidence(int[][] adjacency, bool isOriented)
        {
            if (!IsAdjacencyMatrix(adjacency, isOriented)) throw new ArgumentException("Incorrect adjacency matrix.");
            return isOriented ? OrientedAdjacencyMatrixToIncidence(adjacency) : NonOrientedAdjacencyMatrixToIncidence(adjacency);
        }

        private static int[][] OrientedAdjacencyMatrixToIncidence(int[][] adjacency)
        {
            // calculating edges count
            int edgesCount = 0;
            for (int i = 0; i < adjacency.Length; i++)
            {
                for (int j = 0; j < adjacency.Length; j++)
                {
                    edgesCount += adjacency[i][j];
                }
            }

            // memory allocation
            int[][] incidence = new int[adjacency.Length][];
            for (int i = 0; i < adjacency.Length; i++)
            {
                incidence[i] = new int[edgesCount];
            }

            // calculating incidence matrix
            int e = 0;
            for (int i = 0; i < adjacency.Length; i++)
            {
                for (int j = 0; j < adjacency.Length; j++)
                {
                    if (j == i) continue;
                    int tmpValue = adjacency[i][j];
                    while (tmpValue > 0)
                    {
                        incidence[i][e] = -1;
                        incidence[j][e] = 1;
                        tmpValue--;
                        e++;
                    }
                }
            }


            return incidence;
        }

        private static int[][] NonOrientedAdjacencyMatrixToIncidence(int[][] adjacency)
        {
            // calculating edges count
            int edgesCount = 0;
            for (int i = 0; i < adjacency.Length; i++)
            {
                for (int j = i + 1; j < adjacency.Length; j++)
                {
                    edgesCount += adjacency[i][j];
                }
            }

            // memory allocation
            int[][] incidence = new int[adjacency.Length][];
            for (int i = 0; i < adjacency.Length; i++)
            {
                incidence[i] = new int[edgesCount];
            }

            // calculating incidence matrix
            int e = 0;
            for (int i = 0; i < adjacency.Length; i++)
            {
                for (int j = i + 1; j < adjacency.Length; j++)
                {
                    if (j == i) continue;
                    int tmpValue = adjacency[i][j];
                    while (tmpValue > 0)
                    {
                        incidence[i][e] = 1;
                        incidence[j][e] = 1;
                        tmpValue--;
                        e++;
                    }
                }
            }

            return incidence;
        }


        /// <summary>
        /// Convert incidence matrix to adjacency matrix
        /// </summary>
        /// <param name="incidence">Incidence matrix</param>
        /// <param name="isOriented"></param>
        /// <returns>Adjacency matrix<</returns>
        public static int[][] IncidenceMatrixToAdjacency(int[][] incidence, bool isOriented)
        {
            if (!IsIncidenceMatrix(incidence, isOriented)) throw new ArgumentException("Incorrect incidence matrix.");
            return isOriented ? OrientedIncidenceMatrixToAdjacency(incidence) : NonOrientedIncidenceMatrixToAdjacency(incidence);
        }

        private static int[][] OrientedIncidenceMatrixToAdjacency(int[][] incidence)
        {
            int[][] adjacency = new int[incidence.Length][];

            // memory allocation
            for (int i = 0; i < incidence.Length; i++)
            {
                adjacency[i] = new int[incidence.Length];
            }

            // calculating adjacency matrix
            for (int j = 0; j < incidence[0].Length; j++)
            {
                int firstVertexIndex = 0;
                int secondVertexIndex = 0;
                int findsCount = 0;
                for (int i = 0; i < incidence.Length && findsCount < 2; i++)
                {
                    if (incidence[i][j] == -1)
                    {
                        firstVertexIndex = i;
                        findsCount++;
                    }
                    else if (incidence[i][j] == 1)
                    {
                        secondVertexIndex = i;
                        findsCount++;
                    }
                }

                adjacency[firstVertexIndex][secondVertexIndex] += 1;
            }

            return adjacency;
        }

        private static int[][] NonOrientedIncidenceMatrixToAdjacency(int[][] incidence)
        {
            int[][] adjacency = new int[incidence.Length][];

            // memory allocation
            for (int i = 0; i < incidence.Length; i++)
            {
                adjacency[i] = new int[incidence.Length];
            }

            // calculating adjacency matrix
            for (int j = 0; j < incidence[0].Length; j++)
            {
                int firstVertexIndex = 0;
                int secondVertexIndex = 0;
                int findsCount = 0;

                for (int i = 0; i < incidence.Length && findsCount < 2; i++)
                {
                    if (incidence[i][j] == 1)
                    {
                        if (findsCount == 0)
                            firstVertexIndex = i;
                        else
                            secondVertexIndex = i;

                        findsCount++;
                    }
                }

                adjacency[firstVertexIndex][secondVertexIndex] += 1;
                adjacency[secondVertexIndex][firstVertexIndex] += 1;
            }

            return adjacency;
        }



        /// <summary>
        /// Convert adjacency matrix to vertices list
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="isOrientedGraph"></param>
        /// <param name="vertexName">Default vertex name</param>
        /// <param name="edgeName">Default edge name</param>
        /// <returns>Vertices list</returns>
        public static List<Vertex> AdjacencyMatrixToVerticesList(int[][] matrix, bool isOrientedGraph, string vertexName, string edgeName)
        {
            if (!IsAdjacencyMatrix(matrix, isOrientedGraph)) throw new ArgumentException("Incorrect matrix argument");
            List<Vertex> vertices = new List<Vertex>(matrix.Length);
            for (int i = 0; i < matrix.Length; i++)
            {
                vertices.Add(new Vertex() { Name = vertexName + i });
            }

            int edgeNameIndex = 0;
            if (isOrientedGraph)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix.Length; j++)
                    {
                        for (int k = 0; k < matrix[i][j]; k++)
                            vertices[i].AddEdge(vertices[j], isOrientedGraph,0,edgeName + edgeNameIndex++);
                    }
                }
            }
            else
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        for (int k = 0; k < matrix[i][j]; k++)
                            vertices[i].AddEdge(vertices[j], isOrientedGraph,0,edgeName + edgeNameIndex++);
                    }
                }
            }

            return vertices;
        }

        /// <summary>
        /// Convert vertices list to adjacency matrix
        /// </summary>
        /// <param name="vertices"></param>
        /// <param name="isOrientedGraph"></param>
        /// <returns>Adjacency matrix</returns>
        public static int[][] VerticesListToAdjacencyMatrix(List<Vertex> vertices, bool isOrientedGraph)
        {
            int[][] matrix = new int[vertices.Count][];
            for (int i = 0; i < vertices.Count; i++)
            {
                matrix[i] = new int[vertices.Count];
            }


            if (isOrientedGraph)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix.Length; j++)
                    {
                        matrix[i][j] = vertices[i].EdgesFromThisVertex.Where(e => e.EndVertex == vertices[j]).Count();
                    }
                }
            }
            else
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix.Length; j++)
                    {
                        matrix[i][j] = i == j ?
                            vertices[i].Edges.Where(e => e.EndVertex == vertices[j] && e.StartVertex == vertices[j]).Count() :
                            vertices[i].Edges.Where(e => e.StartVertex == vertices[j] || e.EndVertex == vertices[j]).Count();
                    }
                }
            }



            return matrix;
        }
    }
}






/// <summary>
/// 
/// Not ready methods and properties
/// 
/// </summary>
namespace GraphLib
{
    public partial class Graph
    {
        public List<Vertex> GraphDiameter
        {
            get
            {
                List<Vertex> diameter = new List<Vertex>();

                foreach (Vertex v in vertices)
                {
                    List<Vertex> eccentricity = Eccentricity(v);
                    // need compare weight but not count
                    if (diameter.Count < eccentricity.Count)
                    {
                        diameter = eccentricity;
                    }
                }

                return diameter;
            }
        }

        public bool IsChain(object arguments)
        {
            return false;
        }

        public bool IsIsomorphicTo(Graph graph) => false;

        public bool IsCycle(object arguments)
        {
            return false;
        }

        public bool IsSimpleChain()
        {
            return false;
        }

        public bool IsSimpleCycle()
        {
            return false;
        }

        public int GraphRadius()
        {
            return 0;
        }

        public bool IsPeripherialNode()
        {
            return false;
        }

        public object GraphCenter()
        {
            return null;
        }

        public object Bridges()
        {
            return null;
        }
        public bool IsSimpleGraph => IsOrientedGraph == false && !IsPseudoGraph && !IsMultiGraph;
        public bool IsPseudoGraph => false;

        public bool IsTree()
        {
            return false;
        }
    }
}