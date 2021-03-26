
namespace GraphLib
{
    partial class GraphComponent
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvGrid = new System.Windows.Forms.DataGridView();
            this.btnAddVertex = new System.Windows.Forms.Button();
            this.btnRemoveVertex = new System.Windows.Forms.Button();
            this.btnAddEdge = new System.Windows.Forms.Button();
            this.btnRemoveEdge = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGrid
            // 
            this.dgvGrid.AllowUserToAddRows = false;
            this.dgvGrid.AllowUserToDeleteRows = false;
            this.dgvGrid.AllowUserToResizeColumns = false;
            this.dgvGrid.AllowUserToResizeRows = false;
            this.dgvGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrid.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvGrid.Location = new System.Drawing.Point(0, 0);
            this.dgvGrid.Name = "dgvGrid";
            this.dgvGrid.RowHeadersWidth = 70;
            this.dgvGrid.Size = new System.Drawing.Size(300, 250);
            this.dgvGrid.TabIndex = 0;
            this.dgvGrid.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvGrid_UserDeletingRow);
            // 
            // btnAddVertex
            // 
            this.btnAddVertex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddVertex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddVertex.Location = new System.Drawing.Point(3, 217);
            this.btnAddVertex.Name = "btnAddVertex";
            this.btnAddVertex.Size = new System.Drawing.Size(30, 30);
            this.btnAddVertex.TabIndex = 1;
            this.btnAddVertex.Text = "+";
            this.btnAddVertex.UseVisualStyleBackColor = true;
            this.btnAddVertex.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnAddVertex_MouseClick);
            // 
            // btnRemoveVertex
            // 
            this.btnRemoveVertex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveVertex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRemoveVertex.Location = new System.Drawing.Point(3, 181);
            this.btnRemoveVertex.Name = "btnRemoveVertex";
            this.btnRemoveVertex.Size = new System.Drawing.Size(30, 30);
            this.btnRemoveVertex.TabIndex = 2;
            this.btnRemoveVertex.Text = "-";
            this.btnRemoveVertex.UseVisualStyleBackColor = true;
            this.btnRemoveVertex.Click += new System.EventHandler(this.btnRemoveVertex_Click);
            // 
            // btnAddEdge
            // 
            this.btnAddEdge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddEdge.Enabled = false;
            this.btnAddEdge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddEdge.Location = new System.Drawing.Point(267, 3);
            this.btnAddEdge.Name = "btnAddEdge";
            this.btnAddEdge.Size = new System.Drawing.Size(30, 30);
            this.btnAddEdge.TabIndex = 3;
            this.btnAddEdge.Text = "+";
            this.btnAddEdge.UseVisualStyleBackColor = true;
            this.btnAddEdge.Visible = false;
            this.btnAddEdge.Click += new System.EventHandler(this.btnAddEdge_Click);
            // 
            // btnRemoveEdge
            // 
            this.btnRemoveEdge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveEdge.Enabled = false;
            this.btnRemoveEdge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRemoveEdge.Location = new System.Drawing.Point(231, 3);
            this.btnRemoveEdge.Name = "btnRemoveEdge";
            this.btnRemoveEdge.Size = new System.Drawing.Size(30, 30);
            this.btnRemoveEdge.TabIndex = 4;
            this.btnRemoveEdge.Text = "-";
            this.btnRemoveEdge.UseVisualStyleBackColor = true;
            this.btnRemoveEdge.Visible = false;
            this.btnRemoveEdge.Click += new System.EventHandler(this.btnRemoveEdge_Click);
            // 
            // GraphComponent
            // 
            this.Controls.Add(this.btnAddEdge);
            this.Controls.Add(this.btnRemoveEdge);
            this.Controls.Add(this.btnRemoveVertex);
            this.Controls.Add(this.btnAddVertex);
            this.Controls.Add(this.dgvGrid);
            this.Name = "GraphComponent";
            this.Size = new System.Drawing.Size(300, 250);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRemoveVertex;
        private System.Windows.Forms.Button btnAddVertex;
        private System.Windows.Forms.DataGridView dgvGrid;
        private System.Windows.Forms.Button btnAddEdge;
        private System.Windows.Forms.Button btnRemoveEdge;
    }
}
