namespace Game2048
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
            this.lSteps = new System.Windows.Forms.Label();
            this.lCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lSteps
            // 
            this.lSteps.AutoSize = true;
            this.lSteps.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lSteps.Location = new System.Drawing.Point(12, 23);
            this.lSteps.Name = "lSteps";
            this.lSteps.Size = new System.Drawing.Size(51, 20);
            this.lSteps.TabIndex = 0;
            this.lSteps.Text = "label1";
            // 
            // lCount
            // 
            this.lCount.AutoSize = true;
            this.lCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lCount.Location = new System.Drawing.Point(156, 23);
            this.lCount.Name = "lCount";
            this.lCount.Size = new System.Drawing.Size(51, 20);
            this.lCount.TabIndex = 1;
            this.lCount.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 375);
            this.Controls.Add(this.lCount);
            this.Controls.Add(this.lSteps);
            this.Name = "Form1";
            this.Text = "Игра 2048";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lSteps;
        private System.Windows.Forms.Label lCount;
    }
}

