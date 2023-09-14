namespace Assistant
{
    partial class AssistantForm
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
            AssistantLog = new RichTextBox();
            AssistnatInput = new TextBox();
            AssistantPost = new Button();
            SuspendLayout();
            // 
            // AssistantLog
            // 
            AssistantLog.BackColor = Color.Black;
            AssistantLog.ForeColor = Color.White;
            AssistantLog.Location = new Point(12, 12);
            AssistantLog.Name = "AssistantLog";
            AssistantLog.ReadOnly = true;
            AssistantLog.ScrollBars = RichTextBoxScrollBars.Vertical;
            AssistantLog.Size = new Size(920, 448);
            AssistantLog.TabIndex = 2;
            AssistantLog.TabStop = false;
            AssistantLog.Text = "";
            // 
            // AssistnatInput
            // 
            AssistnatInput.BackColor = Color.Black;
            AssistnatInput.ForeColor = Color.White;
            AssistnatInput.Location = new Point(12, 466);
            AssistnatInput.Name = "AssistnatInput";
            AssistnatInput.Size = new Size(839, 23);
            AssistnatInput.TabIndex = 0;
            AssistnatInput.TabStop = false;
            // 
            // AssistantPost
            // 
            AssistantPost.Location = new Point(857, 466);
            AssistantPost.Name = "AssistantPost";
            AssistantPost.Size = new Size(75, 23);
            AssistantPost.TabIndex = 1;
            AssistantPost.TabStop = false;
            AssistantPost.Text = "Send";
            AssistantPost.UseVisualStyleBackColor = true;
            // 
            // AssistantForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(944, 501);
            Controls.Add(AssistantPost);
            Controls.Add(AssistnatInput);
            Controls.Add(AssistantLog);
            Name = "AssistantForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Assistant";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox AssistantLog;
        private TextBox AssistnatInput;
        private Button AssistantPost;
    }
}