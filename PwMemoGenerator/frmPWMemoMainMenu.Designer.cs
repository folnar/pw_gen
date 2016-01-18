namespace PwMemoGenerator
{
    partial class frmPWMemoMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPWMemoMainMenu));
            this.btnGenerateNewPWs = new System.Windows.Forms.Button();
            this.btnCloseAndExit = new System.Windows.Forms.Button();
            this.btnPrintPWMemos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerateNewPWs
            // 
            this.btnGenerateNewPWs.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateNewPWs.Location = new System.Drawing.Point(12, 12);
            this.btnGenerateNewPWs.Name = "btnGenerateNewPWs";
            this.btnGenerateNewPWs.Size = new System.Drawing.Size(179, 78);
            this.btnGenerateNewPWs.TabIndex = 1;
            this.btnGenerateNewPWs.Text = "&Generate New Passwords";
            this.btnGenerateNewPWs.UseVisualStyleBackColor = true;
            this.btnGenerateNewPWs.Click += new System.EventHandler(this.btnGenerateNewPWs_Click);
            // 
            // btnCloseAndExit
            // 
            this.btnCloseAndExit.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseAndExit.Location = new System.Drawing.Point(382, 12);
            this.btnCloseAndExit.Name = "btnCloseAndExit";
            this.btnCloseAndExit.Size = new System.Drawing.Size(179, 78);
            this.btnCloseAndExit.TabIndex = 3;
            this.btnCloseAndExit.Text = "E&xit Application";
            this.btnCloseAndExit.UseVisualStyleBackColor = true;
            this.btnCloseAndExit.Click += new System.EventHandler(this.btnCloseAndExit_Click);
            // 
            // btnPrintPWMemos
            // 
            this.btnPrintPWMemos.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintPWMemos.Location = new System.Drawing.Point(197, 12);
            this.btnPrintPWMemos.Name = "btnPrintPWMemos";
            this.btnPrintPWMemos.Size = new System.Drawing.Size(179, 78);
            this.btnPrintPWMemos.TabIndex = 2;
            this.btnPrintPWMemos.Text = "&Print Existing Password Memos";
            this.btnPrintPWMemos.UseVisualStyleBackColor = true;
            this.btnPrintPWMemos.Click += new System.EventHandler(this.btnPrintPWMemos_Click);
            // 
            // frmPWMemoMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 105);
            this.Controls.Add(this.btnPrintPWMemos);
            this.Controls.Add(this.btnCloseAndExit);
            this.Controls.Add(this.btnGenerateNewPWs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPWMemoMainMenu";
            this.Text = "Password Memos Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateNewPWs;
        private System.Windows.Forms.Button btnCloseAndExit;
        private System.Windows.Forms.Button btnPrintPWMemos;
    }
}

