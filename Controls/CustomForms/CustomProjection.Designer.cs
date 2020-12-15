namespace VPS.Controls.CustomForms
{
    partial class CustomProjection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomProjection));
            this.projectionSelectControl = new DotSpatial.Projections.Forms.ProjectionSelectControl();
            this.SuspendLayout();
            // 
            // projectionSelectControl
            // 
            resources.ApplyResources(this.projectionSelectControl, "projectionSelectControl");
            this.projectionSelectControl.Name = "projectionSelectControl";
            this.projectionSelectControl.SelectedCoordinateSystem = null;
            // 
            // CustomProjection
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.projectionSelectControl);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Name = "CustomProjection";
            this.ResumeLayout(false);

        }

        #endregion

        private DotSpatial.Projections.Forms.ProjectionSelectControl projectionSelectControl;
    }
}