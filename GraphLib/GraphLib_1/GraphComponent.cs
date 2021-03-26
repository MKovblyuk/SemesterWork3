using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Reflection;

namespace GraphLib
{

    public partial class GraphComponent : UserControl
    {
        public GraphComponent()
        {
            InitializeComponent();
        }

        public GraphComponent(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }


        private void btnAddVertex_MouseClick(object sender, MouseEventArgs e) => AddVertex();
        private void btnRemoveVertex_Click(object sender, EventArgs e) => RemoveVertex();
        private void btnAddEdge_Click(object sender, EventArgs e) => AddEdge();
        private void btnRemoveEdge_Click(object sender, EventArgs e) => RemoveEdge();

        private void dgvGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (graphView == GraphView.AdjacencyMatrix)
            {
                RemoveColumnAt(e.Row.Index);
                if (dgvGrid.Rows.Count == 0) e.Cancel = true;
            }

            OnVertexRemoved(new VertexChangedEventArgs { Index = e.Row.Index });
        }

        private void dgvGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            OnCellValueChanged(e);
        }
    }
}


/// <summary>
/// 
/// Transofrmation Data From Grid To GraphClass
/// 
/// </summary>
namespace GraphLib
{
    public partial class GraphComponent : UserControl
    {
        /// <summary>
        /// Set data into graph
        /// </summary>
        /// <returns></returns>
        public Graph ToGraph()
        {
            if (!CheckGrid()) throw new Exception("Incorrect data in grid");

            if(graphView == GraphView.AdjacencyMatrix)
                return new Graph(GridToArray(), IsOriented,VertexName,EdgeName);
            else
                return new Graph(Graph.IncidenceMatrixToAdjacency((GridToArray()),IsOriented),IsOriented,VertexName,EdgeName);
        }

        /// <summary>
        /// Get data from graph
        /// </summary>
        /// <param name="graph"></param>
        public void FromGraph(Graph graph)
        {
            IsOriented = graph.IsOrientedGraph;
            int[][] matrix = graphView == GraphView.AdjacencyMatrix ? graph.AdjacencyMatrix : graph.IncidenceMatrix;

            VertexName = graph.DefaultVertexName ?? VertexName;
            EdgeName = graph.DefaultEdgeName ?? EdgeName;

            RemoveAllVertices();
            if (graphView == GraphView.AdjacencyMatrix)
            {
                for (int i = 0; i < matrix.Length; i++)
                    AddVertex();
            }
            else
            {
                RemoveAllEdges();
                for (int i = 0; i < matrix.Length; i++)
                    AddVertex();
                for (int i = 0; i < matrix[0].Length - 1; i++)
                    AddEdge();
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    dgvGrid.Rows[i].Cells[j].Value = matrix[i][j];
                }
            }
        }

        public int[][] GridToArray()
        {
            int[][] array = new int[dgvGrid.Rows.Count][];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new int[dgvGrid.Columns.Count];
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = Convert.ToInt32(dgvGrid[j, i].Value);
                }
            }

            return array;
        }


        public bool CheckGrid()
        {
            for(int i = 0;i < dgvGrid.RowCount; i++)
            {
                int result;
                for (int j = 0; j < dgvGrid.ColumnCount; j++)
                {
                    if (!Int32.TryParse(dgvGrid[j, i].Value?.ToString(), out result))
                        return false;
                    if(graphView == GraphView.AdjacencyMatrix && result < 0)
                        return false;

                }
            }
            return true;
        }

    }
}


/// <summary>
/// 
/// Changing Count of GraphComponent Grid's Rows and Columns
/// 
/// </summary>
namespace GraphLib
{
    public partial class GraphComponent : UserControl
    {
        // vertices count in graph
        private int startVerticesCount = 0;
        // edges count in graph with incidental matrix view
        private int startEdgesCount = 0;

        /// <summary>
        /// Start vertices count in graph
        /// </summary>
        [DefaultValue(0)]
        [Description("Start vertices count in graph")]
        public int StartVerticesCount
        {
            get { return startVerticesCount; }
            set
            {
                if (value >= 0)
                {
                    if (graphView == GraphView.IncidenceMatrix && startEdgesCount == 0 && value > 0) startEdgesCount = 1;
                    RemoveAllVertices();
                    rowNameIndex = 0;
                    columnNameIndex = 0;

                    for (int i = 0; i < value; i++)
                        AddVertex();

                    startVerticesCount = value;
                }
                else throw new ArgumentOutOfRangeException("Argument must be greater than zero.");
            }
        }


        /// <summary>
        /// Start edges count in graph with incidental matrix view
        /// </summary>
        [DefaultValue(0)]
        [Description("Start edges count in graph")]
        public int StartEdgesCount
        {
            get { return startEdgesCount; }
            set
            {
                if (graphView == GraphView.IncidenceMatrix)
                {
                    if (value >= 0)
                    {
                        RemoveAllEdges();
                        rowNameIndex = 0;
                        columnNameIndex = 0;

                        for (int i = 0; i < value; i++)
                            AddEdge();


                        StartVerticesCount = value == 0  ? 0 : Math.Max(1,StartVerticesCount);
                        startEdgesCount = value;
                    }
                    else throw new ArgumentOutOfRangeException("Argument must be greater than zero.");
                }
            }
        }

        // indexes for different rows and columns names
        private int rowNameIndex = 0;
        private int columnNameIndex = 0;


        [DefaultValue(false)]
        public bool IsOriented { get; set; } = false;
        
        /// <summary>
        /// Default vertex name
        /// </summary>
        [DefaultValue("V")]
        [Description("Default vertex name.")]
        public string VertexName { get; set; } = "V";

        /// <summary>
        /// Default edge name
        /// </summary>
        [DefaultValue("E")]
        [Description("Default edge name.")]
        public string EdgeName { get; set; } = "E";



        // Adding and deleting vertex and edge methods
        public void AddVertex()
        {
            if (graphView == GraphView.AdjacencyMatrix)
            {
                AddColumn(VertexName);
                AddRow(VertexName);
            }
            else if (dgvGrid.Columns.Count == 0) AddEdge();
            else AddRow(VertexName);

            OnVertexAdded(new VertexChangedEventArgs { Index = dgvGrid.Rows.Count - 1 });
        }

        public void RemoveVertex()
        {
            if (dgvGrid.Rows.Count > 0) RemoveVertexAt(dgvGrid.Rows.Count - 1);
        }

        public void RemoveVertexAt(int index)
        {
            RemoveRowAt(index);
            if (graphView == GraphView.AdjacencyMatrix) RemoveColumnAt(index);
            OnVertexRemoved(new VertexChangedEventArgs { Index = index });
        }

        public void AddEdge()
        {
            if (graphView == GraphView.IncidenceMatrix)
            {
                AddColumn(EdgeName);
                if (dgvGrid.Rows.Count == 0) AddVertex();
                OnEdgeAdded(new EdgeChangedEventArgs { Index = dgvGrid.Columns.Count - 1 });
            }
        }

        public void RemoveEdge()
        {
            if (dgvGrid.Columns.Count > 0) RemoveEdgeAt(dgvGrid.Columns.Count - 1);
        }

        public void RemoveEdgeAt(int index)
        {
            if (graphView == GraphView.IncidenceMatrix)
            {
                RemoveColumnAt(index);
                OnEdgeRemoved(new EdgeChangedEventArgs { Index = index });
            }
        }

        private void RemoveAllEdges()
        {
            while (dgvGrid.Columns.Count > 0)
            {
                RemoveEdge();
            }
        }

        private void RemoveAllVertices()
        {
            while (dgvGrid.Rows.Count > 0)
            {
                RemoveVertex();
            }
        }



        // Adding and deleting row and column methods
        private void AddRow(string rowName)
        {
            dgvGrid.Rows.Add();
            dgvGrid.Rows[dgvGrid.RowCount - 1].HeaderCell.Value = rowName + rowNameIndex;
            rowNameIndex++;
        }
        private void AddColumn(string columnName)
        {
            dgvGrid.Columns.Add("Column" + columnNameIndex, columnName + columnNameIndex);
            columnNameIndex++;
        }

        private void RemoveRow()
        {
            if(dgvGrid.Rows.Count > 0) RemoveRowAt(dgvGrid.Rows.Count - 1);
        }

        private void RemoveColumn()
        {
            if (dgvGrid.Columns.Count > 0) RemoveColumnAt(dgvGrid.Columns.Count - 1);            
        }

        private void RemoveColumnAt(int index) => dgvGrid.Columns.RemoveAt(index);
        private void RemoveRowAt(int index) => dgvGrid.Rows.RemoveAt(index);

        
    }
}



/// <summary>
/// 
/// Changing GrpahComponent View
/// 
/// </summary>
namespace GraphLib
{
    public partial class GraphComponent : UserControl
    {
        private GraphView graphView = GraphView.AdjacencyMatrix;
        public GraphView GraphView
        {
            get { return graphView; }
            set
            {
                graphView = value;
                ChangeView();
                OnGraphViewChanged(new GraphViewChangedEventArgs { CurrentGraphView = graphView });
            }
        }

        private bool activeEditingButtons = true;
        public bool ActiveEditingButtons
        {
            get { return activeEditingButtons; }
            set
            {
                activeEditingButtons = value;
                ActiveVertexButtons(value);
                if (graphView == GraphView.IncidenceMatrix) ActiveEdgeButtons(value);
                else ActiveEdgeButtons(false);
            }

        }

        public void ActiveVertexButtons(bool value)
        {
            btnAddVertex.Visible = value;
            btnRemoveVertex.Visible = value;
            btnAddVertex.Enabled = value;
            btnRemoveVertex.Enabled = value;
        }

        public void ActiveEdgeButtons(bool value)
        {
            btnAddEdge.Visible = value;
            btnRemoveEdge.Visible = value;
            btnAddEdge.Enabled = value;
            btnRemoveEdge.Enabled = value;
        }

        public void ChangeView()
        {
            // deleting old grid
            dgvGrid.Dispose();

            // creating new grid
            dgvGrid = new DataGridView();
            dgvGrid.Name = "dgvGrid";
            dgvGrid.RowHeadersWidth = 70;
            dgvGrid.Dock = DockStyle.Fill;
            dgvGrid.AllowUserToAddRows = false;
            dgvGrid.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvGrid_UserDeletingRow);

            // some properties from navigation panel
            dgvGrid.AllowUserToResizeColumns = allowUserToResizeColumns;
            dgvGrid.AllowUserToResizeRows = allowUserToResizeRows;
            dgvGrid.BackgroundColor = backgroundColor;
            dgvGrid.GridColor = gridColor;
            dgvGrid.BorderStyle = gridBorderStyle;
            dgvGrid.ReadOnly = readOnlyGrid;

            // buttons status
            ActiveEditingButtons = true;

            // settin default value of indexes
            rowNameIndex = 0;
            columnNameIndex = 0;

            // setting default count of vertices and edges
            StartEdgesCount = 0;
            StartVerticesCount = 0;

            IsOriented = false;

            // adding in controls collection
            this.Controls.Add(dgvGrid);

        }
    }
}

/// <summary>
/// 
/// Changing some dgvGrid properties
/// 
/// </summary>
namespace GraphLib
{
    public partial class GraphComponent : UserControl
    {
        private bool allowUserToResizeColumns = false;
        public bool AllowUserToResizeColumns
        {
            get { return allowUserToResizeColumns; }
            set
            {
                dgvGrid.AllowUserToResizeColumns = value;
                allowUserToResizeColumns = value;
            }
        }

        private bool allowUserToResizeRows = false;
        public bool AllowUserToResizeRows
        {
            get { return allowUserToResizeRows; }
            set 
            {
                dgvGrid.AllowUserToResizeRows = value;
                allowUserToResizeRows = value;
            }
        }

        private Color gridColor = SystemColors.ControlDarkDark;
        public Color GridColor
        {
            get { return dgvGrid.GridColor; }
            set 
            {
                gridColor = value;
                dgvGrid.GridColor = value; 
            }
        }

        private Color backgroundColor = SystemColors.AppWorkspace;
        public Color BackgroundColor
        {
            get { return dgvGrid.BackgroundColor; }
            set 
            {
                backgroundColor = value;
                dgvGrid.BackgroundColor = value;
            }
        }

        private BorderStyle gridBorderStyle = BorderStyle.FixedSingle;
        public BorderStyle GirdBorderStyle
        {
            get { return gridBorderStyle; }
            set
            {
                gridBorderStyle = value;
                dgvGrid.BorderStyle = value;
            }
        }

        private bool readOnlyGrid = false;
        public bool ReadOnlyGrid
        {
            get { return readOnlyGrid; }
            set
            {
                readOnlyGrid = value;
                dgvGrid.ReadOnly = value;
            }
        }

    }
}

namespace GraphLib
{
    public enum GraphView
    {
        IncidenceMatrix, AdjacencyMatrix
    }

}



/// <summary>
/// 
/// Declaring Event for GraphComponent
/// 
/// </summary>
namespace GraphLib
{
    public partial class GraphComponent : UserControl
    {
        public event EventHandler<VertexChangedEventArgs> VertexRemoved;
        protected virtual void OnVertexRemoved(VertexChangedEventArgs e) => VertexRemoved?.Invoke(this, e);

        public event EventHandler<VertexChangedEventArgs> VertexAdded;
        protected virtual void OnVertexAdded(VertexChangedEventArgs e) => VertexAdded?.Invoke(this, e);

        public event EventHandler<EdgeChangedEventArgs> EdgeRemoved;
        protected virtual void OnEdgeRemoved(EdgeChangedEventArgs e) => EdgeRemoved?.Invoke(this, e);

        public event EventHandler<EdgeChangedEventArgs> EdgeAdded;
        protected virtual void OnEdgeAdded(EdgeChangedEventArgs e) => EdgeAdded?.Invoke(this, e);

        public event EventHandler<GraphViewChangedEventArgs> GraphViewChanged;
        protected virtual void OnGraphViewChanged(GraphViewChangedEventArgs e) => GraphViewChanged?.Invoke(this, e);

        public event EventHandler<EventArgs> CellValueChanged;
        protected virtual void OnCellValueChanged(EventArgs e) => CellValueChanged?.Invoke(this, e);
    }

    public class VertexChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Index of changed vertex
        /// </summary>
        public int Index { get; set; }
    }

    public class EdgeChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Index of changed edge
        /// </summary>
        public int Index { get; set; }
    }

    public class GraphViewChangedEventArgs : EventArgs
    {
        public GraphView CurrentGraphView { get; set; }
    }


}
