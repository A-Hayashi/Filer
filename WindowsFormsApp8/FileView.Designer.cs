namespace WindowsFormsApp8
{
    partial class FileView
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.folder_info_panel = new System.Windows.Forms.Panel();
            this.drive_info_panel = new System.Windows.Forms.Panel();
            this.list_view = new System.Windows.Forms.ListView();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.fileSystemWatcher2 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).BeginInit();
            this.SuspendLayout();
            // 
            // folder_info_panel
            // 
            this.folder_info_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.folder_info_panel.Location = new System.Drawing.Point(0, 0);
            this.folder_info_panel.Name = "folder_info_panel";
            this.folder_info_panel.Size = new System.Drawing.Size(434, 56);
            this.folder_info_panel.TabIndex = 0;
            // 
            // drive_info_panel
            // 
            this.drive_info_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.drive_info_panel.Location = new System.Drawing.Point(0, 319);
            this.drive_info_panel.Name = "drive_info_panel";
            this.drive_info_panel.Size = new System.Drawing.Size(434, 56);
            this.drive_info_panel.TabIndex = 1;
            // 
            // list_view
            // 
            this.list_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_view.Location = new System.Drawing.Point(0, 56);
            this.list_view.Name = "list_view";
            this.list_view.Size = new System.Drawing.Size(434, 263);
            this.list_view.TabIndex = 2;
            this.list_view.UseCompatibleStateImageBehavior = false;
            this.list_view.View = System.Windows.Forms.View.Details;
            this.list_view.Enter += new System.EventHandler(this.List_view_Enter);
            this.list_view.KeyDown += new System.Windows.Forms.KeyEventHandler(this.List_view_KeyDown);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // fileSystemWatcher2
            // 
            this.fileSystemWatcher2.EnableRaisingEvents = true;
            this.fileSystemWatcher2.SynchronizingObject = this;
            // 
            // FileView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.list_view);
            this.Controls.Add(this.drive_info_panel);
            this.Controls.Add(this.folder_info_panel);
            this.Name = "FileView";
            this.Size = new System.Drawing.Size(434, 375);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel folder_info_panel;
        private System.Windows.Forms.Panel drive_info_panel;
        private System.Windows.Forms.ListView list_view;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.IO.FileSystemWatcher fileSystemWatcher2;
    }
}
