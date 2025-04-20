namespace GeneticAlgorithmProject
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtPopulationSize;
        private System.Windows.Forms.TextBox txtCrossoverRate;
        private System.Windows.Forms.TextBox txtMutationRate;
        private System.Windows.Forms.TextBox txtElitismCount;
        private System.Windows.Forms.TextBox txtGenerations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblBestSolution;
        private System.Windows.Forms.Label lblBestFitness;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;

        // Dispose method to clean up components
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Initialize components of the form
        private void InitializeComponent()
        {
            this.txtPopulationSize = new System.Windows.Forms.TextBox();
            this.txtCrossoverRate = new System.Windows.Forms.TextBox();
            this.txtMutationRate = new System.Windows.Forms.TextBox();
            this.txtElitismCount = new System.Windows.Forms.TextBox();
            this.txtGenerations = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblBestSolution = new System.Windows.Forms.Label();
            this.lblBestFitness = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();

            // txtPopulationSize
            this.txtPopulationSize.Location = new System.Drawing.Point(150, 20);
            this.txtPopulationSize.Name = "txtPopulationSize";
            this.txtPopulationSize.Size = new System.Drawing.Size(100, 20);
            this.txtPopulationSize.TabIndex = 0;

            // txtCrossoverRate
            this.txtCrossoverRate.Location = new System.Drawing.Point(150, 50);
            this.txtCrossoverRate.Name = "txtCrossoverRate";
            this.txtCrossoverRate.Size = new System.Drawing.Size(100, 20);
            this.txtCrossoverRate.TabIndex = 1;

            // txtMutationRate
            this.txtMutationRate.Location = new System.Drawing.Point(150, 80);
            this.txtMutationRate.Name = "txtMutationRate";
            this.txtMutationRate.Size = new System.Drawing.Size(100, 20);
            this.txtMutationRate.TabIndex = 2;

            // txtElitismCount
            this.txtElitismCount.Location = new System.Drawing.Point(150, 110);
            this.txtElitismCount.Name = "txtElitismCount";
            this.txtElitismCount.Size = new System.Drawing.Size(100, 20);
            this.txtElitismCount.TabIndex = 3;

            // txtGenerations
            this.txtGenerations.Location = new System.Drawing.Point(150, 140);
            this.txtGenerations.Name = "txtGenerations";
            this.txtGenerations.Size = new System.Drawing.Size(100, 20);
            this.txtGenerations.TabIndex = 4;

            // label1 (Population Size)
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Popülasyon Boyutu";

            // label2 (Crossover Rate)
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Çaprazlama Oranı";

            // label3 (Mutation Rate)
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mutasyon Oranı";

            // label4 (Elitism Count)
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Seçkinlik Oranı";

            // label5 (Generations Count)
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Jenerasyon Sayısı";

            // btnStart (Start Button)
            this.btnStart.Location = new System.Drawing.Point(150, 180);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 30);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Başlat";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);

            // lblBestSolution (Best Solution Label)
            this.lblBestSolution.AutoSize = true;
            this.lblBestSolution.Location = new System.Drawing.Point(20, 230);
            this.lblBestSolution.Name = "lblBestSolution";
            this.lblBestSolution.Size = new System.Drawing.Size(0, 13);
            this.lblBestSolution.TabIndex = 11;

            // lblBestFitness (Best Fitness Label)
            this.lblBestFitness.AutoSize = true;
            this.lblBestFitness.Location = new System.Drawing.Point(20, 260);
            this.lblBestFitness.Name = "lblBestFitness";
            this.lblBestFitness.Size = new System.Drawing.Size(0, 13);
            this.lblBestFitness.TabIndex = 12;

            // chart1 (Chart Control)
            this.chart1.Location = new System.Drawing.Point(300, 20);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(400, 300);
            this.chart1.TabIndex = 13;
            this.chart1.Text = "chart1";

            // Form1 (Form Settings)
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 350);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.lblBestFitness);
            this.Controls.Add(this.lblBestSolution);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGenerations);
            this.Controls.Add(this.txtElitismCount);
            this.Controls.Add(this.txtMutationRate);
            this.Controls.Add(this.txtCrossoverRate);
            this.Controls.Add(this.txtPopulationSize);
            this.Name = "Form1";
            this.Text = "Genetik Algoritma Optimizasyonu";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}