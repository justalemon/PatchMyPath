
namespace PatchMyPath
{
    partial class FormStartup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStartup));
            this.CurrentOperation = new System.Windows.Forms.Label();
            this.OperationProgress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // CurrentOperation
            // 
            this.CurrentOperation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentOperation.Location = new System.Drawing.Point(12, 9);
            this.CurrentOperation.Name = "CurrentOperation";
            this.CurrentOperation.Size = new System.Drawing.Size(279, 23);
            this.CurrentOperation.TabIndex = 0;
            this.CurrentOperation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OperationProgress
            // 
            this.OperationProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OperationProgress.Location = new System.Drawing.Point(12, 42);
            this.OperationProgress.Name = "OperationProgress";
            this.OperationProgress.Size = new System.Drawing.Size(279, 23);
            this.OperationProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.OperationProgress.TabIndex = 1;
            // 
            // FormStartup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 77);
            this.Controls.Add(this.OperationProgress);
            this.Controls.Add(this.CurrentOperation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormStartup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Shown += new System.EventHandler(this.FormStartup_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label CurrentOperation;
        private System.Windows.Forms.ProgressBar OperationProgress;
    }
}