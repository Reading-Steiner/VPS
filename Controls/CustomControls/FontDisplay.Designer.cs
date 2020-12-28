namespace VPS.Controls.CustomControls
{
    partial class FontDisplay
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.DisplayName = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // DisplayName
            // 
            // 
            // 
            // 
            this.DisplayName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DisplayName.Dock = System.Windows.Forms.DockStyle.Top;
            this.DisplayName.Location = new System.Drawing.Point(0, 0);
            this.DisplayName.Name = "DisplayName";
            this.DisplayName.Size = new System.Drawing.Size(150, 22);
            this.DisplayName.TabIndex = 4;
            this.DisplayName.Text = "字体";
            this.DisplayName.Click += new System.EventHandler(this.Display_DoubleClick);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Location = new System.Drawing.Point(0, 22);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(150, 22);
            this.labelX1.TabIndex = 5;
            this.labelX1.Text = "[, , ]";
            this.labelX1.Click += new System.EventHandler(this.Display_DoubleClick);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX2.Location = new System.Drawing.Point(0, 44);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(150, 22);
            this.labelX2.TabIndex = 6;
            this.labelX2.Text = "[]";
            this.labelX2.Click += new System.EventHandler(this.Display_DoubleClick);
            // 
            // FontDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.DisplayName);
            this.Name = "FontDisplay";
            this.Size = new System.Drawing.Size(150, 66);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX DisplayName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
    }
}
