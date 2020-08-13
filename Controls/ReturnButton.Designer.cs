namespace MissionPlanner.Controls
{
    partial class ReturnButton
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
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(45, 7);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(68, 30);
            this.OK.TabIndex = 0;
            this.OK.Text = "确定";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(177, 7);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(68, 30);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // ReturnButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Name = "ReturnButton";
            this.Size = new System.Drawing.Size(294, 44);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
    }
}
