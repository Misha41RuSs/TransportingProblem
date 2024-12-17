namespace WindowsFormsApp1
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
        public void InitializeComponent()
        {
            this.dataGridForMinEL = new System.Windows.Forms.DataGridView();
            this.buttonNW = new System.Windows.Forms.Button();
            this.buttonMinEL = new System.Windows.Forms.Button();
            this.buttonPotents = new System.Windows.Forms.Button();
            this.textBoxForF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridForMinEL)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridForMinEL
            // 
            this.dataGridForMinEL.AllowUserToAddRows = false;
            this.dataGridForMinEL.AllowUserToDeleteRows = false;
            this.dataGridForMinEL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridForMinEL.Location = new System.Drawing.Point(403, 149);
            this.dataGridForMinEL.Name = "dataGridForMinEL";
            this.dataGridForMinEL.ReadOnly = true;
            this.dataGridForMinEL.Size = new System.Drawing.Size(676, 207);
            this.dataGridForMinEL.TabIndex = 1;
            // 
            // buttonNW
            // 
            this.buttonNW.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNW.Location = new System.Drawing.Point(94, 35);
            this.buttonNW.Name = "buttonNW";
            this.buttonNW.Size = new System.Drawing.Size(254, 70);
            this.buttonNW.TabIndex = 3;
            this.buttonNW.Text = "Опорный план методом Северо-Западного угла";
            this.buttonNW.UseVisualStyleBackColor = true;
            this.buttonNW.Click += new System.EventHandler(this.buttonNW_Click);
            // 
            // buttonMinEL
            // 
            this.buttonMinEL.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMinEL.Location = new System.Drawing.Point(94, 149);
            this.buttonMinEL.Name = "buttonMinEL";
            this.buttonMinEL.Size = new System.Drawing.Size(249, 70);
            this.buttonMinEL.TabIndex = 4;
            this.buttonMinEL.Text = "Опорный план методом минимального элемента";
            this.buttonMinEL.UseVisualStyleBackColor = true;
            this.buttonMinEL.Click += new System.EventHandler(this.buttonMinEL_Click);
            // 
            // buttonPotents
            // 
            this.buttonPotents.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPotents.Location = new System.Drawing.Point(94, 276);
            this.buttonPotents.Name = "buttonPotents";
            this.buttonPotents.Size = new System.Drawing.Size(254, 70);
            this.buttonPotents.TabIndex = 5;
            this.buttonPotents.Text = "Оптимальный план методом потенциалов";
            this.buttonPotents.UseVisualStyleBackColor = true;
            this.buttonPotents.Click += new System.EventHandler(this.buttonPotents_Click);
            // 
            // textBoxForF
            // 
            this.textBoxForF.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxForF.Location = new System.Drawing.Point(394, 403);
            this.textBoxForF.Multiline = true;
            this.textBoxForF.Name = "textBoxForF";
            this.textBoxForF.Size = new System.Drawing.Size(139, 41);
            this.textBoxForF.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(510, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 40);
            this.label1.TabIndex = 7;
            this.label1.Text = "Транспортная задача";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(39, 403);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(342, 31);
            this.label2.TabIndex = 8;
            this.label2.Text = "Общая стоимость перевозок";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(617, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 33);
            this.label3.TabIndex = 9;
            this.label3.Text = "Текущий план";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 481);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxForF);
            this.Controls.Add(this.buttonPotents);
            this.Controls.Add(this.buttonMinEL);
            this.Controls.Add(this.buttonNW);
            this.Controls.Add(this.dataGridForMinEL);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridForMinEL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataGridView dataGridForMinEL;
        public System.Windows.Forms.Button buttonNW;
        public System.Windows.Forms.Button buttonMinEL;
        public System.Windows.Forms.Button buttonPotents;
        public System.Windows.Forms.TextBox textBoxForF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

