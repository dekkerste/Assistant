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
            Log = new RichTextBox();
            Input = new TextBox();
            AssistantPost = new Button();
            SuspendLayout();
            // 
            // Log
            // 
            Log.BackColor = Color.Black;
            Log.ForeColor = Color.White;
            Log.Location = new Point(12, 12);
            Log.Name = "Log";
            Log.ReadOnly = true;
            Log.ScrollBars = RichTextBoxScrollBars.Vertical;
            Log.Size = new Size(920, 448);
            Log.TabIndex = 2;
            Log.TabStop = false;
            Log.Text = "";
            // 
            // Input
            // 
            Input.BackColor = Color.Black;
            Input.ForeColor = Color.White;
            Input.Location = new Point(12, 466);
            Input.Name = "Input";
            Input.Size = new Size(839, 23);
            Input.TabIndex = 0;
            Input.TabStop = false;
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
            Controls.Add(Input);
            Controls.Add(Log);
            Name = "AssistantForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Assistant";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox Log;
        private TextBox Input;
        private Button AssistantPost;
    }
}