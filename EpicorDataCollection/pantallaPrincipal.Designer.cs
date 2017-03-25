namespace EpicorDataCollection
{
    partial class pantallaPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pantallaPrincipal));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgvEpicor = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.listaNoEncontrados = new DevComponents.DotNetBar.ListBoxAdv();
            this.lblServerOrigen = new DevComponents.DotNetBar.LabelX();
            this.lblServerDestino = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEpicor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(515, 322);
            this.dataGridView1.TabIndex = 2;
            // 
            // dgvEpicor
            // 
            this.dgvEpicor.AllowUserToAddRows = false;
            this.dgvEpicor.AllowUserToDeleteRows = false;
            this.dgvEpicor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEpicor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEpicor.Location = new System.Drawing.Point(3, 32);
            this.dgvEpicor.Name = "dgvEpicor";
            this.dgvEpicor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEpicor.Size = new System.Drawing.Size(511, 322);
            this.dgvEpicor.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 89);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelX1);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.labelX2);
            this.splitContainer1.Panel2.Controls.Add(this.dgvEpicor);
            this.splitContainer1.Size = new System.Drawing.Size(1042, 357);
            this.splitContainer1.SplitterDistance = 521;
            this.splitContainer1.TabIndex = 5;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(14, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(244, 23);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "Registros del Master a actualizar";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(13, 3);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(123, 23);
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.labelX2.TabIndex = 5;
            this.labelX2.Text = "Proyectos Epicor";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(26, 12);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(127, 23);
            this.labelX3.TabIndex = 6;
            this.labelX3.Text = "Servidor Origen:";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(26, 41);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(134, 23);
            this.labelX4.TabIndex = 7;
            this.labelX4.Text = "Servidor Destino:";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.Location = new System.Drawing.Point(531, 12);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(104, 23);
            this.labelX5.TabIndex = 8;
            this.labelX5.Text = "No Encontrados:";
            // 
            // listaNoEncontrados
            // 
            this.listaNoEncontrados.AutoScroll = true;
            // 
            // 
            // 
            this.listaNoEncontrados.BackgroundStyle.Class = "ListBoxAdv";
            this.listaNoEncontrados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listaNoEncontrados.ContainerControlProcessDialogKey = true;
            this.listaNoEncontrados.DragDropSupport = true;
            this.listaNoEncontrados.Location = new System.Drawing.Point(632, 12);
            this.listaNoEncontrados.Name = "listaNoEncontrados";
            this.listaNoEncontrados.Size = new System.Drawing.Size(404, 74);
            this.listaNoEncontrados.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.listaNoEncontrados.TabIndex = 9;
            this.listaNoEncontrados.Text = "listBoxAdv1";
            // 
            // lblServerOrigen
            // 
            // 
            // 
            // 
            this.lblServerOrigen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblServerOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerOrigen.Location = new System.Drawing.Point(159, 14);
            this.lblServerOrigen.Name = "lblServerOrigen";
            this.lblServerOrigen.Size = new System.Drawing.Size(237, 23);
            this.lblServerOrigen.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.lblServerOrigen.TabIndex = 10;
            this.lblServerOrigen.Text = "_";
            // 
            // lblServerDestino
            // 
            // 
            // 
            // 
            this.lblServerDestino.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblServerDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerDestino.Location = new System.Drawing.Point(159, 43);
            this.lblServerDestino.Name = "lblServerDestino";
            this.lblServerDestino.Size = new System.Drawing.Size(237, 23);
            this.lblServerDestino.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.lblServerDestino.TabIndex = 11;
            this.lblServerDestino.Text = "_";
            // 
            // pantallaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 449);
            this.Controls.Add(this.lblServerDestino);
            this.Controls.Add(this.lblServerOrigen);
            this.Controls.Add(this.listaNoEncontrados);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "pantallaPrincipal";
            this.Text = "Sincronizador de Parcialidades";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.pantallaPrincipal_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEpicor)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dgvEpicor;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.Timer timer1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.ListBoxAdv listaNoEncontrados;
        private DevComponents.DotNetBar.LabelX lblServerOrigen;
        private DevComponents.DotNetBar.LabelX lblServerDestino;
    }
}