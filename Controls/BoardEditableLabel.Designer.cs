namespace VPS.Controls
{
    partial class BoardEditableLabel
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
            this.EditBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DisplayText
            // 
            this.DisplayText.AutoSize = true;
            this.DisplayText.BackColor = System.Drawing.Color.Transparent;
            this.DisplayText.Location = new System.Drawing.Point(15, 10);
            this.DisplayText.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.DisplayText.Name = "DisplayText";
            this.DisplayText.Size = new System.Drawing.Size(0, 12);
            this.DisplayText.TabIndex = 1;
            // 
            // EditBox
            // 
            this.EditBox.Location = new System.Drawing.Point(8, 10);
            this.EditBox.Name = "EditBox";
            this.EditBox.Size = new System.Drawing.Size(65, 21);
            this.EditBox.TabIndex = 2;
            this.EditBox.Visible = false;
            // 
            // BoardEditableLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EditBox);
            this.Controls.Add(this.DisplayText);
            this.Name = "BoardEditableLabel";
            this.Size = new System.Drawing.Size(76, 39);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DisplayText;
        private System.Windows.Forms.TextBox EditBox;
    }
}
