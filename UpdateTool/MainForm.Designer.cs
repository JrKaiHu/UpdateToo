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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDes = new System.Windows.Forms.TextBox();
            this.btnBrowseDes = new System.Windows.Forms.Button();
            this.lblDesVer = new System.Windows.Forms.Label();
            this.lblDesLastTime = new System.Windows.Forms.Label();
            this.lblSrcLastTime = new System.Windows.Forms.Label();
            this.lblSrcVer = new System.Windows.Forms.Label();
            this.btnBrowseSrc = new System.Windows.Forms.Button();
            this.txtSrc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "舊版本(更新目標位置):";
            // 
            // txtDes
            // 
            this.txtDes.Location = new System.Drawing.Point(13, 54);
            this.txtDes.Name = "txtDes";
            this.txtDes.Size = new System.Drawing.Size(446, 26);
            this.txtDes.TabIndex = 1;
            // 
            // btnBrowseDes
            // 
            this.btnBrowseDes.Location = new System.Drawing.Point(473, 42);
            this.btnBrowseDes.Name = "btnBrowseDes";
            this.btnBrowseDes.Size = new System.Drawing.Size(99, 38);
            this.btnBrowseDes.TabIndex = 2;
            this.btnBrowseDes.Text = "選擇路徑";
            this.btnBrowseDes.UseVisualStyleBackColor = true;
            this.btnBrowseDes.Click += new System.EventHandler(this.OnButtonClicked);
            // 
            // lblDesVer
            // 
            this.lblDesVer.AutoSize = true;
            this.lblDesVer.Location = new System.Drawing.Point(13, 96);
            this.lblDesVer.Name = "lblDesVer";
            this.lblDesVer.Size = new System.Drawing.Size(99, 19);
            this.lblDesVer.TabIndex = 6;
            this.lblDesVer.Text = "程式版本 :";
            // 
            // lblDesLastTime
            // 
            this.lblDesLastTime.AutoSize = true;
            this.lblDesLastTime.Location = new System.Drawing.Point(13, 131);
            this.lblDesLastTime.Name = "lblDesLastTime";
            this.lblDesLastTime.Size = new System.Drawing.Size(135, 19);
            this.lblDesLastTime.TabIndex = 8;
            this.lblDesLastTime.Text = "最後修改時間 :";
            // 
            // lblSrcLastTime
            // 
            this.lblSrcLastTime.AutoSize = true;
            this.lblSrcLastTime.Location = new System.Drawing.Point(13, 312);
            this.lblSrcLastTime.Name = "lblSrcLastTime";
            this.lblSrcLastTime.Size = new System.Drawing.Size(135, 19);
            this.lblSrcLastTime.TabIndex = 13;
            this.lblSrcLastTime.Text = "最後修改時間 :";
            // 
            // lblSrcVer
            // 
            this.lblSrcVer.AutoSize = true;
            this.lblSrcVer.Location = new System.Drawing.Point(13, 277);
            this.lblSrcVer.Name = "lblSrcVer";
            this.lblSrcVer.Size = new System.Drawing.Size(99, 19);
            this.lblSrcVer.TabIndex = 12;
            this.lblSrcVer.Text = "程式版本 :";
            // 
            // btnBrowseSrc
            // 
            this.btnBrowseSrc.Location = new System.Drawing.Point(473, 223);
            this.btnBrowseSrc.Name = "btnBrowseSrc";
            this.btnBrowseSrc.Size = new System.Drawing.Size(99, 38);
            this.btnBrowseSrc.TabIndex = 11;
            this.btnBrowseSrc.Text = "選擇路徑";
            this.btnBrowseSrc.UseVisualStyleBackColor = true;
            this.btnBrowseSrc.Click += new System.EventHandler(this.OnButtonClicked);
            // 
            // txtSrc
            // 
            this.txtSrc.Location = new System.Drawing.Point(13, 235);
            this.txtSrc.Name = "txtSrc";
            this.txtSrc.Size = new System.Drawing.Size(446, 26);
            this.txtSrc.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "新版本(更新來源位置):";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(243, 358);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(99, 38);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.OnUpdateClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 408);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblSrcLastTime);
            this.Controls.Add(this.lblSrcVer);
            this.Controls.Add(this.btnBrowseSrc);
            this.Controls.Add(this.txtSrc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDesLastTime);
            this.Controls.Add(this.lblDesVer);
            this.Controls.Add(this.btnBrowseDes);
            this.Controls.Add(this.txtDes);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "UpdateTool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDes;
        private System.Windows.Forms.Button btnBrowseDes;
        private System.Windows.Forms.Label lblDesVer;
        private System.Windows.Forms.Label lblDesLastTime;
        private System.Windows.Forms.Label lblSrcLastTime;
        private System.Windows.Forms.Label lblSrcVer;
        private System.Windows.Forms.Button btnBrowseSrc;
        private System.Windows.Forms.TextBox txtSrc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdate;
    }
}

