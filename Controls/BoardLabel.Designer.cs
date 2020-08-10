namespace MissionPlanner.Controls
{
    partial class BoardLabel
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
            this.DisplayText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DisplayText
            // 
            this.DisplayText.AutoSize = true;
            this.DisplayText.BackColor = System.Drawing.Color.Transparent;
            this.DisplayText.Location = new System.Drawing.Point(24, 6);
            this.DisplayText.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.DisplayText.Name = "DisplayText";
            this.DisplayText.Size = new System.Drawing.Size(49, 19);
            this.DisplayText.TabIndex = 0;
            this.DisplayText.Text = "Text";
            // 
            // BoardLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.DisplayText);
            this.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "BoardLabel";
            this.Size = new System.Drawing.Size(96, 31);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DisplayText;

    }
}
