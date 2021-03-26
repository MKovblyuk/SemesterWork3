
namespace TestForm
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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnIsMultiGraph = new System.Windows.Forms.Button();
            this.btnIsConnectedGraph = new System.Windows.Forms.Button();
            this.btnIsEmptyGraph = new System.Windows.Forms.Button();
            this.ShowIncidenceMatrix = new System.Windows.Forms.Button();
            this.btnIsFullGraph = new System.Windows.Forms.Button();
            this.btnIsZeroGraph = new System.Windows.Forms.Button();
            this.btnIsRegularGraph = new System.Windows.Forms.Button();
            this.btnIsHamiltonsGraph = new System.Windows.Forms.Button();
            this.btnShowAdjacencyMatrix = new System.Windows.Forms.Button();
            this.btnCreateGraphObject = new System.Windows.Forms.Button();
            this.btnToIncidenceView = new System.Windows.Forms.Button();
            this.btnToAdjacencyView = new System.Windows.Forms.Button();
            this.graphComponent1 = new GraphLib.GraphComponent(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIsMultiGraph
            // 
            this.btnIsMultiGraph.Location = new System.Drawing.Point(11, 266);
            this.btnIsMultiGraph.Name = "btnIsMultiGraph";
            this.btnIsMultiGraph.Size = new System.Drawing.Size(198, 32);
            this.btnIsMultiGraph.TabIndex = 0;
            this.btnIsMultiGraph.Text = "IsMultiGraph";
            this.btnIsMultiGraph.UseVisualStyleBackColor = true;
            this.btnIsMultiGraph.Click += new System.EventHandler(this.btnIsMultiGraph_Click);
            // 
            // btnIsConnectedGraph
            // 
            this.btnIsConnectedGraph.Location = new System.Drawing.Point(227, 266);
            this.btnIsConnectedGraph.Name = "btnIsConnectedGraph";
            this.btnIsConnectedGraph.Size = new System.Drawing.Size(198, 32);
            this.btnIsConnectedGraph.TabIndex = 1;
            this.btnIsConnectedGraph.Text = "IsConnectedGraph";
            this.btnIsConnectedGraph.UseVisualStyleBackColor = true;
            this.btnIsConnectedGraph.Click += new System.EventHandler(this.btnIsConnectedGraph_Click);
            // 
            // btnIsEmptyGraph
            // 
            this.btnIsEmptyGraph.Location = new System.Drawing.Point(442, 266);
            this.btnIsEmptyGraph.Name = "btnIsEmptyGraph";
            this.btnIsEmptyGraph.Size = new System.Drawing.Size(198, 32);
            this.btnIsEmptyGraph.TabIndex = 2;
            this.btnIsEmptyGraph.Text = "IsEmptyGraph";
            this.btnIsEmptyGraph.UseVisualStyleBackColor = true;
            this.btnIsEmptyGraph.Click += new System.EventHandler(this.btnIsEmptyGraph_Click);
            // 
            // ShowIncidenceMatrix
            // 
            this.ShowIncidenceMatrix.Location = new System.Drawing.Point(657, 266);
            this.ShowIncidenceMatrix.Name = "ShowIncidenceMatrix";
            this.ShowIncidenceMatrix.Size = new System.Drawing.Size(198, 32);
            this.ShowIncidenceMatrix.TabIndex = 3;
            this.ShowIncidenceMatrix.Text = "ShowIncidenceMatrix";
            this.ShowIncidenceMatrix.UseVisualStyleBackColor = true;
            this.ShowIncidenceMatrix.Click += new System.EventHandler(this.ShowIncidenceMatrix_Click);
            // 
            // btnIsFullGraph
            // 
            this.btnIsFullGraph.Location = new System.Drawing.Point(11, 315);
            this.btnIsFullGraph.Name = "btnIsFullGraph";
            this.btnIsFullGraph.Size = new System.Drawing.Size(198, 32);
            this.btnIsFullGraph.TabIndex = 4;
            this.btnIsFullGraph.Text = "IsFullGraph";
            this.btnIsFullGraph.UseVisualStyleBackColor = true;
            this.btnIsFullGraph.Click += new System.EventHandler(this.btnIsFullGraph_Click);
            // 
            // btnIsZeroGraph
            // 
            this.btnIsZeroGraph.Location = new System.Drawing.Point(227, 315);
            this.btnIsZeroGraph.Name = "btnIsZeroGraph";
            this.btnIsZeroGraph.Size = new System.Drawing.Size(198, 32);
            this.btnIsZeroGraph.TabIndex = 5;
            this.btnIsZeroGraph.Text = "IsZeroGraph";
            this.btnIsZeroGraph.UseVisualStyleBackColor = true;
            this.btnIsZeroGraph.Click += new System.EventHandler(this.btnIsZeroGraph_Click);
            // 
            // btnIsRegularGraph
            // 
            this.btnIsRegularGraph.Location = new System.Drawing.Point(442, 315);
            this.btnIsRegularGraph.Name = "btnIsRegularGraph";
            this.btnIsRegularGraph.Size = new System.Drawing.Size(198, 32);
            this.btnIsRegularGraph.TabIndex = 6;
            this.btnIsRegularGraph.Text = "IsRegularGraph";
            this.btnIsRegularGraph.UseVisualStyleBackColor = true;
            this.btnIsRegularGraph.Click += new System.EventHandler(this.btnIsRegularGraph_Click);
            // 
            // btnIsHamiltonsGraph
            // 
            this.btnIsHamiltonsGraph.Location = new System.Drawing.Point(657, 315);
            this.btnIsHamiltonsGraph.Name = "btnIsHamiltonsGraph";
            this.btnIsHamiltonsGraph.Size = new System.Drawing.Size(198, 32);
            this.btnIsHamiltonsGraph.TabIndex = 7;
            this.btnIsHamiltonsGraph.Text = "IsHamiltonsGraph";
            this.btnIsHamiltonsGraph.UseVisualStyleBackColor = true;
            this.btnIsHamiltonsGraph.Click += new System.EventHandler(this.btnIsHamiltonsGraph_Click);
            // 
            // btnShowAdjacencyMatrix
            // 
            this.btnShowAdjacencyMatrix.Location = new System.Drawing.Point(657, 220);
            this.btnShowAdjacencyMatrix.Name = "btnShowAdjacencyMatrix";
            this.btnShowAdjacencyMatrix.Size = new System.Drawing.Size(198, 29);
            this.btnShowAdjacencyMatrix.TabIndex = 8;
            this.btnShowAdjacencyMatrix.Text = "ShowAdjacencyMatrix";
            this.btnShowAdjacencyMatrix.UseVisualStyleBackColor = true;
            this.btnShowAdjacencyMatrix.Click += new System.EventHandler(this.btnShowAdjacencyMatrix_Click);
            // 
            // btnCreateGraphObject
            // 
            this.btnCreateGraphObject.Location = new System.Drawing.Point(657, 12);
            this.btnCreateGraphObject.Name = "btnCreateGraphObject";
            this.btnCreateGraphObject.Size = new System.Drawing.Size(198, 76);
            this.btnCreateGraphObject.TabIndex = 9;
            this.btnCreateGraphObject.Text = "CreateGraphObject";
            this.btnCreateGraphObject.UseVisualStyleBackColor = true;
            this.btnCreateGraphObject.Click += new System.EventHandler(this.btnCreateGraphObject_Click);
            // 
            // btnToIncidenceView
            // 
            this.btnToIncidenceView.Location = new System.Drawing.Point(657, 109);
            this.btnToIncidenceView.Name = "btnToIncidenceView";
            this.btnToIncidenceView.Size = new System.Drawing.Size(198, 46);
            this.btnToIncidenceView.TabIndex = 11;
            this.btnToIncidenceView.Text = "TOINCIDENCE VIEW";
            this.btnToIncidenceView.UseVisualStyleBackColor = true;
            this.btnToIncidenceView.Click += new System.EventHandler(this.btnToIncidenceView_Click);
            // 
            // btnToAdjacencyView
            // 
            this.btnToAdjacencyView.Location = new System.Drawing.Point(657, 161);
            this.btnToAdjacencyView.Name = "btnToAdjacencyView";
            this.btnToAdjacencyView.Size = new System.Drawing.Size(198, 46);
            this.btnToAdjacencyView.TabIndex = 12;
            this.btnToAdjacencyView.Text = "TOADJACENCYVIEW";
            this.btnToAdjacencyView.UseVisualStyleBackColor = true;
            this.btnToAdjacencyView.Click += new System.EventHandler(this.btnToAdjacencyView_Click);
            // 
            // graphComponent1
            // 
            this.graphComponent1.ActiveEditingButtons = true;
            this.graphComponent1.AllowUserToResizeColumns = false;
            this.graphComponent1.AllowUserToResizeRows = false;
            this.graphComponent1.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.graphComponent1.GirdBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphComponent1.GraphView = GraphLib.GraphView.AdjacencyMatrix;
            this.graphComponent1.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.graphComponent1.Location = new System.Drawing.Point(12, 10);
            this.graphComponent1.Name = "graphComponent1";
            this.graphComponent1.ReadOnlyGrid = false;
            this.graphComponent1.Size = new System.Drawing.Size(438, 250);
            this.graphComponent1.TabIndex = 13;
            // 
            // Form1
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(867, 364);
            this.Controls.Add(this.graphComponent1);
            this.Controls.Add(this.btnToAdjacencyView);
            this.Controls.Add(this.btnToIncidenceView);
            this.Controls.Add(this.btnCreateGraphObject);
            this.Controls.Add(this.btnShowAdjacencyMatrix);
            this.Controls.Add(this.btnIsHamiltonsGraph);
            this.Controls.Add(this.btnIsRegularGraph);
            this.Controls.Add(this.btnIsZeroGraph);
            this.Controls.Add(this.btnIsFullGraph);
            this.Controls.Add(this.ShowIncidenceMatrix);
            this.Controls.Add(this.btnIsEmptyGraph);
            this.Controls.Add(this.btnIsConnectedGraph);
            this.Controls.Add(this.btnIsMultiGraph);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button btnIsMultiGraph;
        private System.Windows.Forms.Button btnIsConnectedGraph;
        private System.Windows.Forms.Button btnIsEmptyGraph;
        private System.Windows.Forms.Button ShowIncidenceMatrix;
        private System.Windows.Forms.Button btnIsFullGraph;
        private System.Windows.Forms.Button btnIsZeroGraph;
        private System.Windows.Forms.Button btnIsRegularGraph;
        private System.Windows.Forms.Button btnIsHamiltonsGraph;
        private System.Windows.Forms.Button btnShowAdjacencyMatrix;
        private System.Windows.Forms.Button btnCreateGraphObject;
        private System.Windows.Forms.Button btnToIncidenceView;
        private System.Windows.Forms.Button btnToAdjacencyView;
        private GraphLib.GraphComponent graphComponent1;
    }
}

