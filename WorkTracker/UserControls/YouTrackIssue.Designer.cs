namespace WorkTracker.UserControls
{
    partial class YouTrackIssue
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IssueHeader = new System.Windows.Forms.Label();
            this.IssueDescription = new System.Windows.Forms.Label();
            this.IssueCustomFieldsView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // IssueHeader
            // 
            this.IssueHeader.AutoSize = true;
            this.IssueHeader.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IssueHeader.Location = new System.Drawing.Point(3, 0);
            this.IssueHeader.Name = "IssueHeader";
            this.IssueHeader.Size = new System.Drawing.Size(103, 21);
            this.IssueHeader.TabIndex = 0;
            this.IssueHeader.Text = "IssueHeader";
            this.IssueHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // IssueDescription
            // 
            this.IssueDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IssueDescription.AutoSize = true;
            this.IssueDescription.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.IssueDescription.Location = new System.Drawing.Point(4, 24);
            this.IssueDescription.MinimumSize = new System.Drawing.Size(170, 20);
            this.IssueDescription.Name = "IssueDescription";
            this.IssueDescription.Size = new System.Drawing.Size(170, 20);
            this.IssueDescription.TabIndex = 1;
            this.IssueDescription.Text = "IssueDescription";
            this.IssueDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IssueCustomFieldsView
            // 
            this.IssueCustomFieldsView.BackColor = System.Drawing.Color.Snow;
            this.IssueCustomFieldsView.GridLines = true;
            this.IssueCustomFieldsView.Location = new System.Drawing.Point(7, 48);
            this.IssueCustomFieldsView.Name = "IssueCustomFieldsView";
            this.IssueCustomFieldsView.Size = new System.Drawing.Size(167, 149);
            this.IssueCustomFieldsView.TabIndex = 2;
            this.IssueCustomFieldsView.UseCompatibleStateImageBehavior = false;
            // 
            // YouTrackIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.IssueCustomFieldsView);
            this.Controls.Add(this.IssueDescription);
            this.Controls.Add(this.IssueHeader);
            this.Name = "YouTrackIssue";
            this.Size = new System.Drawing.Size(180, 200);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IssueHeader;
        private System.Windows.Forms.Label IssueDescription;
        private System.Windows.Forms.ListView IssueCustomFieldsView;
    }
}
