using System.Drawing;

namespace VPS.Controls
{
    partial class BoardComboBox
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
            this.Button = new System.Windows.Forms.Label();
            this.DisplayText = new System.Windows.Forms.Label();
            this.EditBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Button
            // 
            this.Button.BackColor = System.Drawing.Color.Transparent;
            this.Button.Location = new System.Drawing.Point(118, 6);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(23, 24);
            this.Button.TabIndex = 2;
            this.Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DisplayText
            // 
            this.DisplayText.BackColor = System.Drawing.Color.Transparent;
            this.DisplayText.Location = new System.Drawing.Point(5, 6);
            this.DisplayText.Name = "DisplayText";
            this.DisplayText.Size = new System.Drawing.Size(107, 24);
            this.DisplayText.TabIndex = 3;
            this.DisplayText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EditBox
            // 
            this.EditBox.Location = new System.Drawing.Point(12, 6);
            this.EditBox.Name = "EditBox";
            this.EditBox.Size = new System.Drawing.Size(100, 21);
            this.EditBox.TabIndex = 4;
            this.EditBox.Visible = false;
            // 
            // BoardComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EditBox);
            this.Controls.Add(this.DisplayText);
            this.Controls.Add(this.Button);
            this.Name = "BoardComboBox";
            this.Size = new System.Drawing.Size(150, 37);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Button;
        private System.Windows.Forms.Label DisplayText;
        private System.Windows.Forms.ToolStripControlHost comboViewHost;
        private System.Windows.Forms.ToolStripDropDown dropDown;
        private VPS.Controls.ComboDataList dataSourceList;
        private System.Windows.Forms.TextBox EditBox;
    }
}
