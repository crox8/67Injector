namespace CroxMod
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView listProcesses;
        private System.Windows.Forms.TextBox txtDLLPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnInject;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnShowApps;
        private System.Windows.Forms.Button btnShowSystem;
        private System.Windows.Forms.Button btnSortAlpha;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listProcesses = new System.Windows.Forms.ListView();
            this.txtDLLPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnInject = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnShowApps = new System.Windows.Forms.Button();
            this.btnShowSystem = new System.Windows.Forms.Button();
            this.btnSortAlpha = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listProcesses
            // 
            this.listProcesses.FullRowSelect = true;
            this.listProcesses.HideSelection = false;
            this.listProcesses.Location = new System.Drawing.Point(12, 35);
            this.listProcesses.Name = "listProcesses";
            this.listProcesses.Size = new System.Drawing.Size(360, 180);
            this.listProcesses.TabIndex = 0;
            this.listProcesses.UseCompatibleStateImageBehavior = false;
            this.listProcesses.View = System.Windows.Forms.View.Details;
            this.listProcesses.SelectedIndexChanged += new System.EventHandler(this.listProcesses_SelectedIndexChanged);
            // add columns
            this.listProcesses.Columns.Add("PID", 80, System.Windows.Forms.HorizontalAlignment.Left);
            this.listProcesses.Columns.Add("Name", 150, System.Windows.Forms.HorizontalAlignment.Left);
            this.listProcesses.Columns.Add("Category", 100, System.Windows.Forms.HorizontalAlignment.Left);
            // 
            // txtDLLPath
            // 
            this.txtDLLPath.Location = new System.Drawing.Point(12, 220);
            this.txtDLLPath.Name = "txtDLLPath";
            this.txtDLLPath.Size = new System.Drawing.Size(280, 20);
            this.txtDLLPath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(300, 218);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 250);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnInject
            // 
            this.btnInject.Location = new System.Drawing.Point(100, 250);
            this.btnInject.Name = "btnInject";
            this.btnInject.Size = new System.Drawing.Size(75, 23);
            this.btnInject.TabIndex = 4;
            this.btnInject.Text = "Inject";
            this.btnInject.Click += new System.EventHandler(this.btnInject_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(12, 9);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(75, 23);
            this.btnShowAll.TabIndex = 5;
            this.btnShowAll.Text = "All";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnShowApps
            // 
            this.btnShowApps.Location = new System.Drawing.Point(100, 9);
            this.btnShowApps.Name = "btnShowApps";
            this.btnShowApps.Size = new System.Drawing.Size(75, 23);
            this.btnShowApps.TabIndex = 6;
            this.btnShowApps.Text = "Applications";
            this.btnShowApps.UseVisualStyleBackColor = true;
            this.btnShowApps.Click += new System.EventHandler(this.btnShowApps_Click);
            // 
            // btnShowSystem
            // 
            this.btnShowSystem.Location = new System.Drawing.Point(181, 9);
            this.btnShowSystem.Name = "btnShowSystem";
            this.btnShowSystem.Size = new System.Drawing.Size(75, 23);
            this.btnShowSystem.TabIndex = 7;
            this.btnShowSystem.Text = "Processes";
            this.btnShowSystem.UseVisualStyleBackColor = true;
            this.btnShowSystem.Click += new System.EventHandler(this.btnShowSystem_Click);
            // 
            // btnSortAlpha
            // 
            this.btnSortAlpha.Location = new System.Drawing.Point(262, 9);
            this.btnSortAlpha.Name = "btnSortAlpha";
            this.btnSortAlpha.Size = new System.Drawing.Size(113, 23);
            this.btnSortAlpha.TabIndex = 8;
            this.btnSortAlpha.Text = "Sort Alphabetically";
            this.btnSortAlpha.UseVisualStyleBackColor = true;
            this.btnSortAlpha.Click += new System.EventHandler(this.btnSortAlpha_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(384, 291);
            this.Controls.Add(this.btnSortAlpha);
            this.Controls.Add(this.btnShowSystem);
            this.Controls.Add(this.btnShowApps);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.listProcesses);
            this.Controls.Add(this.txtDLLPath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnInject);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "67 Injector";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}