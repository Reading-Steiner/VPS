﻿namespace VPS.Controls
{
    partial class ComboDataList
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
            this.ShowLabel = new System.Windows.Forms.Panel();
            this.DisplayLabel = new System.Windows.Forms.Label();
            this.ShowLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShowLabel
            // 
            this.ShowLabel.AutoScroll = true;
            this.ShowLabel.Controls.Add(this.DisplayLabel);
            this.ShowLabel.Location = new System.Drawing.Point(0, 0);
            this.ShowLabel.Name = "ShowLabel";
            this.ShowLabel.Size = new System.Drawing.Size(150, 150);
            this.ShowLabel.TabIndex = 0;
            // 
            // DisplayLabel
            // 
            this.DisplayLabel.Location = new System.Drawing.Point(-2, 0);
            this.DisplayLabel.Name = "DisplayLabel";
            this.DisplayLabel.Size = new System.Drawing.Size(152, 150);
            this.DisplayLabel.TabIndex = 0;
            // 
            // ComboDataList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ShowLabel);
            this.Name = "ComboDataList";
            this.ShowLabel.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Panel ShowLabel;
        private System.Windows.Forms.Label DisplayLabel;
    }
}
