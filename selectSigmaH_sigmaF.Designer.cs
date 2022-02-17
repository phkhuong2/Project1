
namespace luan_van1
{
    partial class selectSigmaH_sigmaF
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.luanVanDataSet = new luan_van1.LuanVanDataSet();
            this.tbl_6_15_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_6_15_TableAdapter = new luan_van1.LuanVanDataSetTableAdapters.tbl_6_15_TableAdapter();
            this.tableAdapterManager = new luan_van1.LuanVanDataSetTableAdapters.TableAdapterManager();
            this.tbl_6_15_DataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.luanVanDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_6_15_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_6_15_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // luanVanDataSet
            // 
            this.luanVanDataSet.DataSetName = "LuanVanDataSet";
            this.luanVanDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_6_15_BindingSource
            // 
            this.tbl_6_15_BindingSource.DataMember = "tbl_6_15_";
            this.tbl_6_15_BindingSource.DataSource = this.luanVanDataSet;
            // 
            // tbl_6_15_TableAdapter
            // 
            this.tbl_6_15_TableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.P1_3_TableAdapter = null;
            this.tableAdapterManager.tbl_6_15_TableAdapter = this.tbl_6_15_TableAdapter;
            this.tableAdapterManager.tbl_6_2_TableAdapter = null;
            this.tableAdapterManager.tbl_6_5_TableAdapter = null;
            this.tableAdapterManager.tbl_6_7_TableAdapter = null;
            this.tableAdapterManager.tbl_NhietLuyen_TableAdapter = null;
            this.tableAdapterManager.UpdateOrder = luan_van1.LuanVanDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tbl_6_15_DataGridView
            // 
            this.tbl_6_15_DataGridView.AutoGenerateColumns = false;
            this.tbl_6_15_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_6_15_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.tbl_6_15_DataGridView.DataSource = this.tbl_6_15_BindingSource;
            this.tbl_6_15_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_6_15_DataGridView.Location = new System.Drawing.Point(0, 0);
            this.tbl_6_15_DataGridView.Name = "tbl_6_15_DataGridView";
            this.tbl_6_15_DataGridView.Size = new System.Drawing.Size(643, 239);
            this.tbl_6_15_DataGridView.TabIndex = 1;
            this.tbl_6_15_DataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbl_6_15_DataGridView_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Do_Ran";
            this.dataGridViewTextBoxColumn1.HeaderText = "Do_Ran";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Dang_rang";
            this.dataGridViewTextBoxColumn2.HeaderText = "Dang_rang";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "sigma_H";
            this.dataGridViewTextBoxColumn3.HeaderText = "sigma_H";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "sigma_F";
            this.dataGridViewTextBoxColumn4.HeaderText = "sigma_F";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // selectSigmaH_sigmaF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 239);
            this.Controls.Add(this.tbl_6_15_DataGridView);
            this.Name = "selectSigmaH_sigmaF";
            this.Text = "selectSigmaH_sigmaF";
            this.Load += new System.EventHandler(this.selectSigmaH_sigmaF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.luanVanDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_6_15_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_6_15_DataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LuanVanDataSet luanVanDataSet;
        private System.Windows.Forms.BindingSource tbl_6_15_BindingSource;
        private LuanVanDataSetTableAdapters.tbl_6_15_TableAdapter tbl_6_15_TableAdapter;
        private LuanVanDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView tbl_6_15_DataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}