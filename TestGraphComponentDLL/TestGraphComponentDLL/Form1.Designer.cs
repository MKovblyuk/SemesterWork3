
namespace TestGraphComponentDLL
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnIsConnectedGraph = new System.Windows.Forms.Button();
            this.btnIsEmptyGraph = new System.Windows.Forms.Button();
            this.btnIsZeroGraph = new System.Windows.Forms.Button();
            this.btnIsRegularGraph = new System.Windows.Forms.Button();
            this.btnIsStrongConectedGraph = new System.Windows.Forms.Button();
            this.btnAdjacencyMatrixView = new System.Windows.Forms.Button();
            this.btnIncidenceMatrixView = new System.Windows.Forms.Button();
            this.graphComponent1 = new GraphLib.GraphComponent(this.components);
            this.btnInitiGraph = new System.Windows.Forms.Button();
            this.btnFindShortestPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIsConnectedGraph
            // 
            this.btnIsConnectedGraph.Location = new System.Drawing.Point(933, 21);
            this.btnIsConnectedGraph.Name = "btnIsConnectedGraph";
            this.btnIsConnectedGraph.Size = new System.Drawing.Size(222, 46);
            this.btnIsConnectedGraph.TabIndex = 1;
            this.btnIsConnectedGraph.Text = "IsConnectedGraph";
            this.btnIsConnectedGraph.UseVisualStyleBackColor = true;
            this.btnIsConnectedGraph.Click += new System.EventHandler(this.btnIsConnectedGraph_Click);
            // 
            // btnIsEmptyGraph
            // 
            this.btnIsEmptyGraph.Location = new System.Drawing.Point(933, 73);
            this.btnIsEmptyGraph.Name = "btnIsEmptyGraph";
            this.btnIsEmptyGraph.Size = new System.Drawing.Size(222, 46);
            this.btnIsEmptyGraph.TabIndex = 2;
            this.btnIsEmptyGraph.Text = "IsEmptyGraph";
            this.btnIsEmptyGraph.UseVisualStyleBackColor = true;
            this.btnIsEmptyGraph.Click += new System.EventHandler(this.btnIsEmptyGraph_Click);
            // 
            // btnIsZeroGraph
            // 
            this.btnIsZeroGraph.Location = new System.Drawing.Point(933, 125);
            this.btnIsZeroGraph.Name = "btnIsZeroGraph";
            this.btnIsZeroGraph.Size = new System.Drawing.Size(222, 46);
            this.btnIsZeroGraph.TabIndex = 3;
            this.btnIsZeroGraph.Text = "IsZeroGraph";
            this.btnIsZeroGraph.UseVisualStyleBackColor = true;
            this.btnIsZeroGraph.Click += new System.EventHandler(this.btnIsZeroGraph_Click);
            // 
            // btnIsRegularGraph
            // 
            this.btnIsRegularGraph.Location = new System.Drawing.Point(933, 177);
            this.btnIsRegularGraph.Name = "btnIsRegularGraph";
            this.btnIsRegularGraph.Size = new System.Drawing.Size(222, 46);
            this.btnIsRegularGraph.TabIndex = 4;
            this.btnIsRegularGraph.Text = "IsRegularGraph";
            this.btnIsRegularGraph.UseVisualStyleBackColor = true;
            this.btnIsRegularGraph.Click += new System.EventHandler(this.btnIsRegularGraph_Click);
            // 
            // btnIsStrongConectedGraph
            // 
            this.btnIsStrongConectedGraph.Location = new System.Drawing.Point(933, 229);
            this.btnIsStrongConectedGraph.Name = "btnIsStrongConectedGraph";
            this.btnIsStrongConectedGraph.Size = new System.Drawing.Size(222, 46);
            this.btnIsStrongConectedGraph.TabIndex = 5;
            this.btnIsStrongConectedGraph.Text = "IsStrongConectedGraph";
            this.btnIsStrongConectedGraph.UseVisualStyleBackColor = true;
            this.btnIsStrongConectedGraph.Click += new System.EventHandler(this.btnIsStrongConectedGraph_Click);
            // 
            // btnAdjacencyMatrixView
            // 
            this.btnAdjacencyMatrixView.Location = new System.Drawing.Point(933, 337);
            this.btnAdjacencyMatrixView.Name = "btnAdjacencyMatrixView";
            this.btnAdjacencyMatrixView.Size = new System.Drawing.Size(222, 46);
            this.btnAdjacencyMatrixView.TabIndex = 6;
            this.btnAdjacencyMatrixView.Text = "AdjacencyMatrixView";
            this.btnAdjacencyMatrixView.UseVisualStyleBackColor = true;
            this.btnAdjacencyMatrixView.Click += new System.EventHandler(this.btnAdjacencyMatrixView_Click);
            // 
            // btnIncidenceMatrixView
            // 
            this.btnIncidenceMatrixView.Location = new System.Drawing.Point(933, 389);
            this.btnIncidenceMatrixView.Name = "btnIncidenceMatrixView";
            this.btnIncidenceMatrixView.Size = new System.Drawing.Size(222, 46);
            this.btnIncidenceMatrixView.TabIndex = 10;
            this.btnIncidenceMatrixView.Text = "IncidenceMatrixView";
            this.btnIncidenceMatrixView.UseVisualStyleBackColor = true;
            this.btnIncidenceMatrixView.Click += new System.EventHandler(this.btnIncidenceMatrixView_Click);
            // 
            // graphComponent1
            // 
            this.graphComponent1.ActiveEditingButtons = true;
            this.graphComponent1.AllowUserToResizeColumns = false;
            this.graphComponent1.AllowUserToResizeRows = false;
            this.graphComponent1.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.graphComponent1.GirdBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphComponent1.GraphView = GraphLib.GraphView.IncidenceMatrix;
            this.graphComponent1.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.graphComponent1.Location = new System.Drawing.Point(12, 12);
            this.graphComponent1.Name = "graphComponent1";
            this.graphComponent1.ReadOnlyGrid = false;
            this.graphComponent1.Size = new System.Drawing.Size(915, 499);
            this.graphComponent1.TabIndex = 12;
            this.graphComponent1.VertexName = "a";
            // 
            // btnInitiGraph
            // 
            this.btnInitiGraph.Location = new System.Drawing.Point(933, 281);
            this.btnInitiGraph.Name = "btnInitiGraph";
            this.btnInitiGraph.Size = new System.Drawing.Size(222, 46);
            this.btnInitiGraph.TabIndex = 13;
            this.btnInitiGraph.Text = "Init Graph";
            this.btnInitiGraph.UseVisualStyleBackColor = true;
            this.btnInitiGraph.Click += new System.EventHandler(this.btnInitiGraph_Click);
            // 
            // btnFindShortestPath
            // 
            this.btnFindShortestPath.Location = new System.Drawing.Point(933, 441);
            this.btnFindShortestPath.Name = "btnFindShortestPath";
            this.btnFindShortestPath.Size = new System.Drawing.Size(222, 46);
            this.btnFindShortestPath.TabIndex = 14;
            this.btnFindShortestPath.Text = "FindShortestPath";
            this.btnFindShortestPath.UseVisualStyleBackColor = true;
            this.btnFindShortestPath.Click += new System.EventHandler(this.btnFindShortestPath_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 523);
            this.Controls.Add(this.btnFindShortestPath);
            this.Controls.Add(this.btnInitiGraph);
            this.Controls.Add(this.graphComponent1);
            this.Controls.Add(this.btnIncidenceMatrixView);
            this.Controls.Add(this.btnAdjacencyMatrixView);
            this.Controls.Add(this.btnIsStrongConectedGraph);
            this.Controls.Add(this.btnIsRegularGraph);
            this.Controls.Add(this.btnIsZeroGraph);
            this.Controls.Add(this.btnIsEmptyGraph);
            this.Controls.Add(this.btnIsConnectedGraph);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnIsConnectedGraph;
        private System.Windows.Forms.Button btnIsEmptyGraph;
        private System.Windows.Forms.Button btnIsZeroGraph;
        private System.Windows.Forms.Button btnIsRegularGraph;
        private System.Windows.Forms.Button btnIsStrongConectedGraph;
        private System.Windows.Forms.Button btnAdjacencyMatrixView;
        private System.Windows.Forms.Button btnIncidenceMatrixView;
        private GraphLib.GraphComponent graphComponent1;
        private System.Windows.Forms.Button btnInitiGraph;
        private System.Windows.Forms.Button btnFindShortestPath;
    }
}

