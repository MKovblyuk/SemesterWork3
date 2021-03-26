using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private GraphLib.Graph graph = new GraphLib.Graph();

        private void ShowMatrix(int[][] matrix)
        {
            string result = "";
            for(int i = 0;i < matrix.Length; i++)
            {
                for(int j = 0;j < matrix[i].Length; j++)
                {
                    result += matrix[i][j] + " ";
                }
                result += "\n";
            }
            MessageBox.Show(result);
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnIsMultiGraph_Click(object sender, EventArgs e)
        {
            MessageBox.Show(graph.IsMultiGraph.ToString());
        }

        private void btnIsFullGraph_Click(object sender, EventArgs e)
        {
            MessageBox.Show(graph.IsFullGraph.ToString());
        }

        private void btnIsConnectedGraph_Click(object sender, EventArgs e)
        {
            string result = "";
            result += "Is connected graph: " + graph.IsConnectedGraph;
            result += "\nIs strong connected graph: " + graph.IsStrongConectedGraph;
            result += "\nIs unilaterally connected graph: " + graph.IsUnilaterallyConnectedGraph;
            result += "\nIs weak connected graph: " + graph.IsWeaklyConnectedGraph;
            MessageBox.Show(result);
        }

        private void btnIsZeroGraph_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Edges count = " + graph.EdgesCount +
                "\nVertices count = " + graph.VerticesCount);
            MessageBox.Show(graph.IsZeroGraph.ToString());
            int res = 0;
            foreach (var v in graph.Vertices)
            {
                res += v.Edges.Count;
            }
            MessageBox.Show("res = " + res.ToString());

            //ShowVerticesList();
            //EdgeEqualsTest();
            //UnionTest();
        }
        private void ShowVerticesList()
        {
            string res = "";
            foreach (var v in graph.Vertices)
                res += v + "\n";

            MessageBox.Show(res);
        }
        private void EdgeEqualsTest()
        {

            MessageBox.Show("Vertex added: " + graph.AddVertex(new GraphLib.Vertex("addv1")).ToString());
            MessageBox.Show("Vertex added: " + graph.AddVertex(new GraphLib.Vertex("addv2")).ToString());
            MessageBox.Show("Edge added: " + graph.AddEdge(new GraphLib.Edge(graph[0], graph[1], false, 10)).ToString());
            MessageBox.Show(graph.ContainsEdge(new GraphLib.Edge(graph[0], graph[1], false, 10)).ToString());
        }
        private void UnionTest()
        {
            int[] arr1 = { 1, 2, 3, 4, 5 };
            int[] arr2 = { 3, 4, 5, 6, 7 };
            arr1.Union(arr2);
            //int[] res = arr1.Union(arr2).ToArray();

            ShowArr(arr1);
        }

        private void ShowArr(int[] arr)
        {
            string res = "";
            foreach(int e in arr)
            {
                res += e + " ";
            }
            MessageBox.Show(res);
        }

        private void btnIsEmptyGraph_Click(object sender, EventArgs e)
        {
            MessageBox.Show(graph.IsEmptyGraph.ToString());
        }

        private void btnIsRegularGraph_Click(object sender, EventArgs e)
        {
            MessageBox.Show(graph.IsRegularGraph.ToString());
        }

        private void ShowIncidenceMatrix_Click(object sender, EventArgs e)
        {
            ShowMatrix(graph.IncidenceMatrix);
        }

        private void btnIsHamiltonsGraph_Click(object sender, EventArgs e)
        {
            MessageBox.Show(graph.IsHamiltonsGraph.ToString());
        }

        private void btnShowAdjacencyMatrix_Click(object sender, EventArgs e)
        {
            ShowMatrix(graph.AdjacencyMatrix);
        }

        private void btnCreateGraphObject_Click(object sender, EventArgs e)
        {
            graph = graphComponent1.ToGraph();
        }

        private void btnToIncidenceView_Click(object sender, EventArgs e)
        {
            graphComponent1.GraphView = GraphLib.GraphView.IncidenceMatrix;
        }

        private void btnToAdjacencyView_Click(object sender, EventArgs e)
        {
            graphComponent1.GraphView = GraphLib.GraphView.AdjacencyMatrix;
        }
    }
}
