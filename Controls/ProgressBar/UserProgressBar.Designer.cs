namespace VPS.Controls.ProgressBar
{
    partial class UserProgressBar
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
            this.ProgressBox = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.Label = new DevComponents.DotNetBar.LabelX();
            this.Progress = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // ProgressBox
            // 
            this.ProgressBox.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.ProgressBox.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ProgressBox.ChunkColor = System.Drawing.Color.Coral;
            this.ProgressBox.ChunkColor2 = System.Drawing.Color.DarkRed;
            this.ProgressBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.ProgressBox.Location = new System.Drawing.Point(0, 0);
            this.ProgressBox.Name = "ProgressBox";
            this.ProgressBox.Size = new System.Drawing.Size(110, 20);
            this.ProgressBox.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ProgressBox.TabIndex = 0;
            this.ProgressBox.Value = 50;
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            // 
            // 
            // 
            this.Label.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Label.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label.Location = new System.Drawing.Point(0, 0);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(0, 0);
            this.Label.TabIndex = 1;
            this.Label.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // Progress
            // 
            this.Progress.AutoSize = true;
            // 
            // 
            // 
            this.Progress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Progress.Dock = System.Windows.Forms.DockStyle.Left;
            this.Progress.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Progress.Location = new System.Drawing.Point(110, 0);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(0, 0);
            this.Progress.TabIndex = 2;
            this.Progress.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // UserProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.ProgressBox);
            this.Controls.Add(this.Label);
            this.Name = "UserProgressBar";
            this.Size = new System.Drawing.Size(110, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ProgressBarX ProgressBox;
        private DevComponents.DotNetBar.LabelX Label;
        private DevComponents.DotNetBar.LabelX Progress;
    }
}
