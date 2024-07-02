namespace DrawingFX
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Create = new System.Windows.Forms.Button();
            this.inputValue = new System.Windows.Forms.TextBox();
            this.Clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Create
            // 
            this.Create.Location = new System.Drawing.Point(12, 38);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(100, 23);
            this.Create.TabIndex = 0;
            this.Create.Text = "Create";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // inputValue
            // 
            this.inputValue.Location = new System.Drawing.Point(12, 12);
            this.inputValue.Name = "inputValue";
            this.inputValue.Size = new System.Drawing.Size(100, 20);
            this.inputValue.TabIndex = 1;
            this.inputValue.Text = "2";
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(12, 67);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(100, 23);
            this.Clear.TabIndex = 2;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 861);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.inputValue);
            this.Controls.Add(this.Create);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResizeEnd += new System.EventHandler(this.Create_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.TextBox inputValue;
        private System.Windows.Forms.Button Clear;
    }
}

