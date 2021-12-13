
namespace AutoQuickAssist
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.QuickAssistIDTextBox = new System.Windows.Forms.TextBox();
            this.WriteQuickAssistIDButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.활성화ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // QuickAssistIDTextBox
            // 
            this.QuickAssistIDTextBox.Location = new System.Drawing.Point(12, 12);
            this.QuickAssistIDTextBox.Name = "QuickAssistIDTextBox";
            this.QuickAssistIDTextBox.Size = new System.Drawing.Size(202, 21);
            this.QuickAssistIDTextBox.TabIndex = 0;
            // 
            // WriteQuickAssistIDButton
            // 
            this.WriteQuickAssistIDButton.Location = new System.Drawing.Point(220, 12);
            this.WriteQuickAssistIDButton.Name = "WriteQuickAssistIDButton";
            this.WriteQuickAssistIDButton.Size = new System.Drawing.Size(58, 21);
            this.WriteQuickAssistIDButton.TabIndex = 1;
            this.WriteQuickAssistIDButton.Text = "저장";
            this.WriteQuickAssistIDButton.UseVisualStyleBackColor = true;
            this.WriteQuickAssistIDButton.Click += new System.EventHandler(this.AutoQuickAssistButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "자동실행시작";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "빠른지원자동실행";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.활성화ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(111, 48);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // 활성화ToolStripMenuItem
            // 
            this.활성화ToolStripMenuItem.Name = "활성화ToolStripMenuItem";
            this.활성화ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.활성화ToolStripMenuItem.Text = "활성화";
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 130);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.WriteQuickAssistIDButton);
            this.Controls.Add(this.QuickAssistIDTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "빠른지원자동실행";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox QuickAssistIDTextBox;
        private System.Windows.Forms.Button WriteQuickAssistIDButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 활성화ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
    }
}

