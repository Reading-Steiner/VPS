namespace VPS.Controls
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
            this.components = new System.ComponentModel.Container();
            this.OK = new CCWin.SkinControl.SkinButton();
            this.Cancel = new CCWin.SkinControl.SkinButton();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.BackColor = System.Drawing.Color.Transparent;
            this.OK.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.OK.BorderColor = System.Drawing.Color.Transparent;
            this.OK.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.DownBack = null;
            this.OK.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(180)))));
            this.OK.ForeColorSuit = true;
            this.OK.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.OK.InnerBorderColor = System.Drawing.Color.Transparent;
            this.OK.IsDrawGlass = false;
            this.OK.Location = new System.Drawing.Point(45, 7);
            this.OK.MouseBack = null;
            this.OK.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.OK.Name = "OK";
            this.OK.NormlBack = null;
            this.OK.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.OK.Size = new System.Drawing.Size(68, 30);
            this.OK.TabIndex = 0;
            this.OK.Text = "确定";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.BackColor = System.Drawing.Color.Transparent;
            this.Cancel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.Cancel.BorderColor = System.Drawing.Color.Transparent;
            this.Cancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.DownBack = null;
            this.Cancel.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(180)))));
            this.Cancel.InnerBorderColor = System.Drawing.Color.Transparent;
            this.Cancel.IsDrawGlass = false;
            this.Cancel.Location = new System.Drawing.Point(177, 7);
            this.Cancel.MouseBack = null;
            this.Cancel.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.Cancel.Name = "Cancel";
            this.Cancel.NormlBack = null;
            this.Cancel.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.Cancel.Size = new System.Drawing.Size(68, 30);
            this.Cancel.TabIndex = 1;
            this.Cancel.TabStop = false;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // ReturnButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.DoubleBuffered = true;
            this.Name = "ReturnButton";
            this.Size = new System.Drawing.Size(294, 44);
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinButton OK;
        private CCWin.SkinControl.SkinButton Cancel;
    }
}
