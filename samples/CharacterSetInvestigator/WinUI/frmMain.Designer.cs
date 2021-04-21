
namespace CharacterSetInvestigator.WinUI
{
	partial class frmMain
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.blMainHeading = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnTest = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.lblProgress = new System.Windows.Forms.Label();
			this.ddlCategory = new System.Windows.Forms.ComboBox();
			this.lblCategoryOfInterest = new System.Windows.Forms.Label();
			this.btnCopyToClipboard = new System.Windows.Forms.Button();
			this.txtResults = new System.Windows.Forms.TextBox();
			this.lblRestrictSets = new System.Windows.Forms.Label();
			this.chkRestrict = new System.Windows.Forms.CheckBox();
			this.lblToThoseContaining = new System.Windows.Forms.Label();
			this.txtSetNameMatch = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// blMainHeading
			// 
			this.blMainHeading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.blMainHeading.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.blMainHeading.Location = new System.Drawing.Point(12, 9);
			this.blMainHeading.Name = "blMainHeading";
			this.blMainHeading.Size = new System.Drawing.Size(1037, 46);
			this.blMainHeading.TabIndex = 0;
			this.blMainHeading.Text = "Character Set Investigator";
			this.blMainHeading.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(12, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(1037, 42);
			this.label2.TabIndex = 1;
			this.label2.Text = "Use this screen to investigate the categorisation of characters within predefined" +
    " Unicode character sets";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// btnTest
			// 
			this.btnTest.Location = new System.Drawing.Point(99, 201);
			this.btnTest.Name = "btnTest";
			this.btnTest.Size = new System.Drawing.Size(94, 29);
			this.btnTest.TabIndex = 2;
			this.btnTest.Text = "&Test";
			this.btnTest.UseVisualStyleBackColor = true;
			this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
			// 
			// btnExit
			// 
			this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExit.Location = new System.Drawing.Point(955, 592);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(94, 29);
			this.btnExit.TabIndex = 3;
			this.btnExit.Text = "E&xit";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// lblProgress
			// 
			this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblProgress.Location = new System.Drawing.Point(40, 233);
			this.lblProgress.Name = "lblProgress";
			this.lblProgress.Size = new System.Drawing.Size(985, 30);
			this.lblProgress.TabIndex = 4;
			this.lblProgress.Text = "Click \'Test\' to start";
			this.lblProgress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// ddlCategory
			// 
			this.ddlCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ddlCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlCategory.FormattingEnabled = true;
			this.ddlCategory.Location = new System.Drawing.Point(226, 115);
			this.ddlCategory.Name = "ddlCategory";
			this.ddlCategory.Size = new System.Drawing.Size(768, 28);
			this.ddlCategory.TabIndex = 5;
			// 
			// lblCategoryOfInterest
			// 
			this.lblCategoryOfInterest.AutoSize = true;
			this.lblCategoryOfInterest.Location = new System.Drawing.Point(58, 118);
			this.lblCategoryOfInterest.Name = "lblCategoryOfInterest";
			this.lblCategoryOfInterest.Size = new System.Drawing.Size(140, 20);
			this.lblCategoryOfInterest.TabIndex = 6;
			this.lblCategoryOfInterest.Text = "Category of Interest";
			// 
			// btnCopyToClipboard
			// 
			this.btnCopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCopyToClipboard.Location = new System.Drawing.Point(99, 543);
			this.btnCopyToClipboard.Name = "btnCopyToClipboard";
			this.btnCopyToClipboard.Size = new System.Drawing.Size(166, 29);
			this.btnCopyToClipboard.TabIndex = 7;
			this.btnCopyToClipboard.Text = "Copy to Clipboard";
			this.btnCopyToClipboard.UseVisualStyleBackColor = true;
			this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
			// 
			// txtResults
			// 
			this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtResults.Location = new System.Drawing.Point(24, 281);
			this.txtResults.Multiline = true;
			this.txtResults.Name = "txtResults";
			this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtResults.Size = new System.Drawing.Size(1009, 231);
			this.txtResults.TabIndex = 8;
			this.txtResults.Visible = false;
			// 
			// lblRestrictSets
			// 
			this.lblRestrictSets.AutoSize = true;
			this.lblRestrictSets.Location = new System.Drawing.Point(58, 148);
			this.lblRestrictSets.Name = "lblRestrictSets";
			this.lblRestrictSets.Size = new System.Drawing.Size(87, 20);
			this.lblRestrictSets.TabIndex = 9;
			this.lblRestrictSets.Text = "Restrict sets";
			// 
			// chkRestrict
			// 
			this.chkRestrict.AutoSize = true;
			this.chkRestrict.Checked = true;
			this.chkRestrict.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkRestrict.Location = new System.Drawing.Point(226, 151);
			this.chkRestrict.Name = "chkRestrict";
			this.chkRestrict.Size = new System.Drawing.Size(18, 17);
			this.chkRestrict.TabIndex = 10;
			this.chkRestrict.UseVisualStyleBackColor = true;
			// 
			// lblToThoseContaining
			// 
			this.lblToThoseContaining.AutoSize = true;
			this.lblToThoseContaining.Location = new System.Drawing.Point(250, 148);
			this.lblToThoseContaining.Name = "lblToThoseContaining";
			this.lblToThoseContaining.Size = new System.Drawing.Size(272, 20);
			this.lblToThoseContaining.TabIndex = 11;
			this.lblToThoseContaining.Text = "to those whose name contains the word";
			// 
			// txtSetNameMatch
			// 
			this.txtSetNameMatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSetNameMatch.Location = new System.Drawing.Point(551, 145);
			this.txtSetNameMatch.Name = "txtSetNameMatch";
			this.txtSetNameMatch.Size = new System.Drawing.Size(443, 27);
			this.txtSetNameMatch.TabIndex = 12;
			this.txtSetNameMatch.Text = "Latin";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1061, 633);
			this.Controls.Add(this.txtSetNameMatch);
			this.Controls.Add(this.lblToThoseContaining);
			this.Controls.Add(this.chkRestrict);
			this.Controls.Add(this.lblRestrictSets);
			this.Controls.Add(this.txtResults);
			this.Controls.Add(this.btnCopyToClipboard);
			this.Controls.Add(this.lblCategoryOfInterest);
			this.Controls.Add(this.ddlCategory);
			this.Controls.Add(this.lblProgress);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnTest);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.blMainHeading);
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Investigate Character Sets";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label blMainHeading;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnTest;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Label lblProgress;
		private System.Windows.Forms.ComboBox ddlCategory;
		private System.Windows.Forms.Label lblCategoryOfInterest;
		private System.Windows.Forms.Button btnCopyToClipboard;
		private System.Windows.Forms.TextBox txtResults;
		private System.Windows.Forms.Label lblRestrictSets;
		private System.Windows.Forms.CheckBox chkRestrict;
		private System.Windows.Forms.Label lblToThoseContaining;
		private System.Windows.Forms.TextBox txtSetNameMatch;
	}
}

