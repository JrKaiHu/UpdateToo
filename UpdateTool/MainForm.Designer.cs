namespace UpdateTool
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tvNewVer = new UpdateTool.MyTreeView();
            this.tvOldVer = new UpdateTool.MyTreeView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnBrowseSrc = new System.Windows.Forms.Button();
            this.lblSrcLastTime = new System.Windows.Forms.Label();
            this.lblSrcVer = new System.Windows.Forms.Label();
            this.txtSrc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnBrowseDes = new System.Windows.Forms.Button();
            this.lblDesLastTime = new System.Windows.Forms.Label();
            this.lblDesVer = new System.Windows.Forms.Label();
            this.txtDes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 96F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1264, 682);
            this.tableLayoutPanel4.TabIndex = 22;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.btnCompare, 0, 5);
            this.tableLayoutPanel5.Controls.Add(this.btnGenerate, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.btnUpdate, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(1088, 16);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 11;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.5F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.5F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.5F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.5F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.5F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.5F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(158, 648);
            this.tableLayoutPanel5.TabIndex = 24;
            // 
            // btnCompare
            // 
            this.btnCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCompare.Location = new System.Drawing.Point(3, 208);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(152, 68);
            this.btnCompare.TabIndex = 19;
            this.btnCompare.Text = "版本比對";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.OnCompareClicked);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenerate.Location = new System.Drawing.Point(3, 115);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(152, 68);
            this.btnGenerate.TabIndex = 18;
            this.btnGenerate.Text = "產生xml";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.OnCreateXmlClicked);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdate.Location = new System.Drawing.Point(3, 22);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(152, 68);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "更新程式";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.OnUpdateClicked);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.5F));
            this.tableLayoutPanel3.Controls.Add(this.tvNewVer, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.tvOldVer, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(15, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1055, 648);
            this.tableLayoutPanel3.TabIndex = 22;
            // 
            // tvNewVer
            // 
            this.tvNewVer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvNewVer.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvNewVer.Location = new System.Drawing.Point(535, 152);
            this.tvNewVer.Name = "tvNewVer";
            this.tvNewVer.Size = new System.Drawing.Size(517, 493);
            this.tvNewVer.TabIndex = 23;
            this.tvNewVer.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.OnAfterChecked);
            // 
            // tvOldVer
            // 
            this.tvOldVer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvOldVer.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvOldVer.Location = new System.Drawing.Point(3, 152);
            this.tvOldVer.Name = "tvOldVer";
            this.tvOldVer.Size = new System.Drawing.Size(516, 493);
            this.tvOldVer.TabIndex = 22;
            this.tvOldVer.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.OnAfterChecked);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel2.Controls.Add(this.btnBrowseSrc, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblSrcLastTime, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblSrcVer, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtSrc, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(535, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.75F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.75F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.75F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.75F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(517, 143);
            this.tableLayoutPanel2.TabIndex = 21;
            // 
            // btnBrowseSrc
            // 
            this.btnBrowseSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBrowseSrc.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseSrc.Location = new System.Drawing.Point(401, 38);
            this.btnBrowseSrc.Name = "btnBrowseSrc";
            this.btnBrowseSrc.Size = new System.Drawing.Size(113, 29);
            this.btnBrowseSrc.TabIndex = 15;
            this.btnBrowseSrc.Text = "選擇路徑";
            this.btnBrowseSrc.UseVisualStyleBackColor = true;
            this.btnBrowseSrc.Click += new System.EventHandler(this.OnButtonClicked);
            // 
            // lblSrcLastTime
            // 
            this.lblSrcLastTime.AutoSize = true;
            this.lblSrcLastTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSrcLastTime.Location = new System.Drawing.Point(3, 105);
            this.lblSrcLastTime.Name = "lblSrcLastTime";
            this.lblSrcLastTime.Size = new System.Drawing.Size(392, 35);
            this.lblSrcLastTime.TabIndex = 14;
            this.lblSrcLastTime.Text = "最後修改時間 :";
            this.lblSrcLastTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSrcVer
            // 
            this.lblSrcVer.AutoSize = true;
            this.lblSrcVer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSrcVer.Location = new System.Drawing.Point(3, 70);
            this.lblSrcVer.Name = "lblSrcVer";
            this.lblSrcVer.Size = new System.Drawing.Size(392, 35);
            this.lblSrcVer.TabIndex = 13;
            this.lblSrcVer.Text = "程式版本 :";
            this.lblSrcVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSrc
            // 
            this.txtSrc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSrc.Location = new System.Drawing.Point(3, 38);
            this.txtSrc.Name = "txtSrc";
            this.txtSrc.Size = new System.Drawing.Size(392, 31);
            this.txtSrc.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(392, 35);
            this.label2.TabIndex = 10;
            this.label2.Text = "新版本(更新來源位置):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel1.Controls.Add(this.btnBrowseDes, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDesLastTime, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblDesVer, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtDes, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(516, 143);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // btnBrowseDes
            // 
            this.btnBrowseDes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBrowseDes.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseDes.Location = new System.Drawing.Point(400, 38);
            this.btnBrowseDes.Name = "btnBrowseDes";
            this.btnBrowseDes.Size = new System.Drawing.Size(113, 29);
            this.btnBrowseDes.TabIndex = 10;
            this.btnBrowseDes.Text = "選擇路徑";
            this.btnBrowseDes.UseVisualStyleBackColor = true;
            this.btnBrowseDes.Click += new System.EventHandler(this.OnButtonClicked);
            // 
            // lblDesLastTime
            // 
            this.lblDesLastTime.AutoSize = true;
            this.lblDesLastTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDesLastTime.Location = new System.Drawing.Point(3, 105);
            this.lblDesLastTime.Name = "lblDesLastTime";
            this.lblDesLastTime.Size = new System.Drawing.Size(391, 35);
            this.lblDesLastTime.TabIndex = 9;
            this.lblDesLastTime.Text = "最後修改時間 :";
            this.lblDesLastTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDesVer
            // 
            this.lblDesVer.AutoSize = true;
            this.lblDesVer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDesVer.Location = new System.Drawing.Point(3, 70);
            this.lblDesVer.Name = "lblDesVer";
            this.lblDesVer.Size = new System.Drawing.Size(391, 35);
            this.lblDesVer.TabIndex = 7;
            this.lblDesVer.Text = "程式版本 :";
            this.lblDesVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDes
            // 
            this.txtDes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDes.Location = new System.Drawing.Point(3, 38);
            this.txtDes.Name = "txtDes";
            this.txtDes.Size = new System.Drawing.Size(391, 31);
            this.txtDes.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "舊版本(更新目標位置):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "UpdateTool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private MyTreeView tvNewVer;
        private MyTreeView tvOldVer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnBrowseSrc;
        private System.Windows.Forms.Label lblSrcLastTime;
        private System.Windows.Forms.Label lblSrcVer;
        private System.Windows.Forms.TextBox txtSrc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnBrowseDes;
        private System.Windows.Forms.Label lblDesLastTime;
        private System.Windows.Forms.Label lblDesVer;
        private System.Windows.Forms.TextBox txtDes;
        private System.Windows.Forms.Label label1;
    }
}

