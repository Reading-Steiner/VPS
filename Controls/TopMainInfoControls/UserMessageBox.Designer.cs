﻿namespace VPS.Controls.TopMainInfoControls
{
    partial class UserMessageBox
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
            this.Info = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            // 
            // 
            // 
            this.Info.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Info.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Info.Location = new System.Drawing.Point(0, 0);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(0, 0);
            this.Info.TabIndex = 0;
            // 
            // UserMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.Info);
            this.Name = "UserMessageBox";
            this.Size = new System.Drawing.Size(50, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX Info;
    }
}
