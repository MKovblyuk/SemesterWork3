using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphLib;

namespace TestGraphComponentDLL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnIsConnectedGraph_Click(object sender, EventArgs e)
        {
            MessageBox.Show(graphComponent1.ToGraph().IsConnectedGraph.ToString());
        }

        private void btnIsEmptyGraph_Click(object sender, EventArgs e)
        {
            MessageBox.Show(graphComponent1.ToGraph().IsEdgesEmpty.ToString());
        }

        private void btnIsZeroGraph_Click(object sender, EventArgs e)
        {
            MessageBox.Show(graphComponent1.ToGraph().IsZeroGraph.ToString());
        }

        private void btnIsRegularGraph_Click(object sender, EventArgs e)
        {
            MessageBox.Show(graphComponent1.ToGraph().IsRegularGraph.ToString());
        }

        private void btnIsStrongConectedGraph_Click(object sender, EventArgs e)
        {
            MessageBox.Show(graphComponent1.ToGraph().IsStrongConectedGraph.ToString());
        }


        private void btnAdjacencyMatrixView_Click(object sender, EventArgs e)
        {
            graphComponent1.GraphView = GraphView.AdjacencyMatrix;
        }

        private void btnIncidenceMatrixView_Click(object sender, EventArgs e)
        {
            graphComponent1.GraphView = GraphView.IncidenceMatrix;
        }

        private void btnInitiGraph_Click(object sender, EventArgs e)
        {
            int[][] matrix =
            {
                new int[]{0, 1, 0, 0, 0, 0, 1, 1, 0, 0 },
                new int[]{1, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new int[]{0, 1, 0, 0, 0, 0, 0, 0, 0, 1 },
                new int[]{0, 0, 0, 0, 1, 0, 0, 0, 0, 1 },
                new int[]{0, 0, 0, 1, 0, 0, 0, 0, 1, 0 },
                new int[]{0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                new int[]{1, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                new int[]{1, 1, 0, 0, 0, 0, 0, 0, 1, 0 },
                new int[]{0, 0, 0, 0, 1, 1, 1, 1, 0, 1 },
                new int[]{0, 0, 1, 1, 0, 0, 0, 0, 1, 0 }
                };

            string vertexName = "vertex";
            string edgeName = "edge";
            Graph graph = new Graph(matrix, false, vertexName, edgeName);
            graphComponent1.FromGraph(graph);
            
        }

        private void btnFindShortestPath_Click(object sender, EventArgs e)
        {
            //Graph graph = graphComponent1.ToGraph();

            //// initialization weight values  /////////////////

            //graph[0].IncidentalEdges(graph[1]).First().Weight = 2;
            //graph[0].IncidentalEdges(graph[7]).First().Weight = 3;
            //graph[0].IncidentalEdges(graph[6]).First().Weight = 4;
            //graph[1].IncidentalEdges(graph[7]).First().Weight = 1;
            //graph[1].IncidentalEdges(graph[2]).First().Weight = 7;
            //graph[2].IncidentalEdges(graph[9]).First().Weight = 4;
            //graph[3].IncidentalEdges(graph[9]).First().Weight = 15;
            //graph[3].IncidentalEdges(graph[4]).First().Weight = 13;
            //graph[4].IncidentalEdges(graph[8]).First().Weight = 3;
            //graph[5].IncidentalEdges(graph[8]).First().Weight = 1;
            //graph[6].IncidentalEdges(graph[8]).First().Weight = 7;
            //graph[7].IncidentalEdges(graph[8]).First().Weight = 18;
            //graph[8].IncidentalEdges(graph[9]).First().Weight = 12;

            
            //List<Vertex> path = graph.FindShortestPath(7, 3);
            
            //StringBuilder sb = new StringBuilder();
            //foreach(Vertex v in path)
            //{
            //    sb.Append(v.Name).Append("\n");
            //}

            //MessageBox.Show(sb.ToString());

            TestOrientedGraphShortestPath();

        }

        private void TestOrientedGraphShortestPath()
        {
            int[][] matrix = 
            {
                new int[] { 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
                new int[] { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 1, 0, 1, 1, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 } 
            };

            string vertexName = "vertex";
            string edgeName = "edge";
            Graph graph = new Graph(matrix, true, vertexName, edgeName);
            graphComponent1.FromGraph(graph);

            List<Vertex> path = graph.FindShortestPath(7, 3);

            StringBuilder sb = new StringBuilder();
            foreach (Vertex v in path)
            {
                sb.Append(v.Name).Append("\n");
            }

            MessageBox.Show(sb.ToString());
        }
    }
}
