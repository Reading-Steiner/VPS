namespace VPS.Controls.CustomControls
{
    partial class CustomState
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
            this.DisplayColor = new DevComponents.DotNetBar.LabelX();
            this.DisplayText = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // DisplayColor
            // 
            this.DisplayColor.BackColor = System.Drawing.Color.Lime;
            // 
            // 
            // 
            this.DisplayColor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DisplayColor.Location = new System.Drawing.Point(3, 6);
            this.DisplayColor.Name = "DisplayColor";
            this.DisplayColor.Size = new System.Drawing.Size(26, 12);
            this.DisplayColor.TabIndex = 0;
            // 
            // DisplayText
            // 
            this.DisplayText.AutoSize = true;
            // 
            // 
            // 
            this.DisplayText.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DisplayText.Location = new System.Drawing.Point(35, 3);
            this.DisplayText.Name = "DisplayText";
            this.DisplayText.Size = new System.Drawing.Size(31, 18);
            this.DisplayText.TabIndex = 1;
            this.DisplayText.Text = "就绪";
            // 
            // CustomState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.DisplayText);
            this.Controls.Add(this.DisplayColor);
            this.Name = "CustomState";
            this.Size = new System.Drawing.Size(69, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX DisplayColor;
        private DevComponents.DotNetBar.LabelX DisplayText;
    }
}
