namespace MissionPlanner.Controls
{
    partial class BoardDecUpBox
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
            this.EditBox = new System.Windows.Forms.TextBox();
            this.DisplayText = new System.Windows.Forms.Label();
            this.Up = new System.Windows.Forms.Label();
            this.Down = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EditBox
            // 
            this.EditBox.Location = new System.Drawing.Point(18, 11);
            this.EditBox.Name = "EditBox";
            this.EditBox.Size = new System.Drawing.Size(100, 21);
            this.EditBox.TabIndex = 7;
            this.EditBox.Visible = false;
            // 
            // DisplayText
            // 
            this.DisplayText.BackColor = System.Drawing.Color.Transparent;
            this.DisplayText.Location = new System.Drawing.Point(11, 11);
            this.DisplayText.Name = "DisplayText";
            this.DisplayText.Size = new System.Drawing.Size(107, 12);
            this.DisplayText.TabIndex = 6;
            this.DisplayText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Up
            // 
            this.Up.BackColor = System.Drawing.Color.Transparent;
            this.Up.Location = new System.Drawing.Point(124, 10);
            this.Up.Name = "Up";
            this.Up.Size = new System.Drawing.Size(23, 12);
            this.Up.TabIndex = 5;
            this.Up.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Down
            // 
            this.Down.BackColor = System.Drawing.Color.Transparent;
            this.Down.Location = new System.Drawing.Point(124, 25);
            this.Down.Name = "Down";
            this.Down.Size = new System.Drawing.Size(23, 12);
            this.Down.TabIndex = 8;
            this.Down.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BoardDecUpBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Down);
            this.Controls.Add(this.EditBox);
            this.Controls.Add(this.DisplayText);
            this.Controls.Add(this.Up);
            this.Name = "BoardDecUpBox";
            this.Size = new System.Drawing.Size(159, 47);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox EditBox;
        private System.Windows.Forms.Label DisplayText;
        private System.Windows.Forms.Label Up;
        private System.Windows.Forms.Label Down;
    }
}
