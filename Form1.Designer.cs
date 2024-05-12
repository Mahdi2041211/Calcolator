namespace Calcolator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Btn1 = new Button();
            screen = new TextBox();
            BtnSub = new Button();
            Btn3 = new Button();
            Btn2 = new Button();
            ButtonPower = new Button();
            ButtonDiv = new Button();
            ButtonC = new Button();
            Btn8 = new Button();
            Btn9 = new Button();
            BtnMult = new Button();
            Btn7 = new Button();
            Btn5 = new Button();
            Btn6 = new Button();
            BtnSum = new Button();
            Btn4 = new Button();
            BtnComa = new Button();
            BtnEqwal = new Button();
            Btn0 = new Button();
            list = new ComboBox();
            SuspendLayout();
            // 
            // Btn1
            // 
            Btn1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn1.Location = new Point(29, 490);
            Btn1.Name = "Btn1";
            Btn1.Size = new Size(106, 82);
            Btn1.TabIndex = 0;
            Btn1.Text = "1";
            Btn1.UseVisualStyleBackColor = true;
            Btn1.Click += ClickNum;
            // 
            // screen
            // 
            screen.Font = new Font("Stencil", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            screen.Location = new Point(29, 23);
            screen.Multiline = true;
            screen.Name = "screen";
            screen.Size = new Size(499, 128);
            screen.TabIndex = 1;
            screen.KeyPress += KeyPress;
            // 
            // BtnSub
            // 
            BtnSub.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnSub.Location = new Point(422, 490);
            BtnSub.Name = "BtnSub";
            BtnSub.Size = new Size(106, 82);
            BtnSub.TabIndex = 8;
            BtnSub.Text = "-";
            BtnSub.UseVisualStyleBackColor = true;
            BtnSub.Click += ClickOp;
            // 
            // Btn3
            // 
            Btn3.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn3.Location = new Point(292, 490);
            Btn3.Name = "Btn3";
            Btn3.Size = new Size(106, 82);
            Btn3.TabIndex = 9;
            Btn3.Text = "3";
            Btn3.UseVisualStyleBackColor = true;
            Btn3.Click += ClickNum;
            // 
            // Btn2
            // 
            Btn2.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn2.Location = new Point(159, 490);
            Btn2.Name = "Btn2";
            Btn2.Size = new Size(106, 82);
            Btn2.TabIndex = 10;
            Btn2.Text = "2";
            Btn2.UseVisualStyleBackColor = true;
            Btn2.Click += ClickNum;
            // 
            // ButtonPower
            // 
            ButtonPower.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonPower.Location = new Point(292, 188);
            ButtonPower.Name = "ButtonPower";
            ButtonPower.Size = new Size(106, 82);
            ButtonPower.TabIndex = 13;
            ButtonPower.Text = "^";
            ButtonPower.UseVisualStyleBackColor = true;
            ButtonPower.Click += ClickOp;
            // 
            // ButtonDiv
            // 
            ButtonDiv.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonDiv.Location = new Point(422, 188);
            ButtonDiv.Name = "ButtonDiv";
            ButtonDiv.Size = new Size(106, 82);
            ButtonDiv.TabIndex = 12;
            ButtonDiv.Text = "/";
            ButtonDiv.UseVisualStyleBackColor = true;
            ButtonDiv.Click += ClickOp;
            // 
            // ButtonC
            // 
            ButtonC.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonC.Location = new Point(29, 188);
            ButtonC.Name = "ButtonC";
            ButtonC.Size = new Size(236, 82);
            ButtonC.TabIndex = 11;
            ButtonC.Text = "C";
            ButtonC.UseVisualStyleBackColor = true;
            ButtonC.Click += clickClear;
            // 
            // Btn8
            // 
            Btn8.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn8.Location = new Point(159, 292);
            Btn8.Name = "Btn8";
            Btn8.Size = new Size(106, 82);
            Btn8.TabIndex = 18;
            Btn8.Text = "8";
            Btn8.UseVisualStyleBackColor = true;
            Btn8.Click += ClickNum;
            // 
            // Btn9
            // 
            Btn9.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn9.Location = new Point(292, 292);
            Btn9.Name = "Btn9";
            Btn9.Size = new Size(106, 82);
            Btn9.TabIndex = 17;
            Btn9.Text = "9";
            Btn9.UseVisualStyleBackColor = true;
            Btn9.Click += ClickNum;
            // 
            // BtnMult
            // 
            BtnMult.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnMult.Location = new Point(422, 292);
            BtnMult.Name = "BtnMult";
            BtnMult.Size = new Size(106, 82);
            BtnMult.TabIndex = 16;
            BtnMult.Text = "*";
            BtnMult.UseVisualStyleBackColor = true;
            BtnMult.Click += ClickOp;
            // 
            // Btn7
            // 
            Btn7.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn7.Location = new Point(29, 292);
            Btn7.Name = "Btn7";
            Btn7.Size = new Size(106, 82);
            Btn7.TabIndex = 15;
            Btn7.Text = "7";
            Btn7.UseVisualStyleBackColor = true;
            Btn7.Click += ClickNum;
            // 
            // Btn5
            // 
            Btn5.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn5.Location = new Point(159, 392);
            Btn5.Name = "Btn5";
            Btn5.Size = new Size(106, 82);
            Btn5.TabIndex = 22;
            Btn5.Text = "5";
            Btn5.UseVisualStyleBackColor = true;
            Btn5.Click += ClickNum;
            // 
            // Btn6
            // 
            Btn6.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn6.Location = new Point(292, 392);
            Btn6.Name = "Btn6";
            Btn6.Size = new Size(106, 82);
            Btn6.TabIndex = 21;
            Btn6.Text = "6";
            Btn6.UseVisualStyleBackColor = true;
            Btn6.Click += ClickNum;
            // 
            // BtnSum
            // 
            BtnSum.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnSum.Location = new Point(422, 392);
            BtnSum.Name = "BtnSum";
            BtnSum.Size = new Size(106, 82);
            BtnSum.TabIndex = 20;
            BtnSum.Text = "+";
            BtnSum.UseVisualStyleBackColor = true;
            BtnSum.Click += ClickOp;
            // 
            // Btn4
            // 
            Btn4.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn4.Location = new Point(29, 392);
            Btn4.Name = "Btn4";
            Btn4.Size = new Size(106, 82);
            Btn4.TabIndex = 19;
            Btn4.Text = "4";
            Btn4.UseVisualStyleBackColor = true;
            Btn4.Click += ClickNum;
            // 
            // BtnComa
            // 
            BtnComa.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnComa.Location = new Point(159, 589);
            BtnComa.Name = "BtnComa";
            BtnComa.Size = new Size(106, 82);
            BtnComa.TabIndex = 26;
            BtnComa.Text = ".";
            BtnComa.UseVisualStyleBackColor = true;
            BtnComa.Click += ClickComa;
            // 
            // BtnEqwal
            // 
            BtnEqwal.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnEqwal.Location = new Point(292, 589);
            BtnEqwal.Name = "BtnEqwal";
            BtnEqwal.Size = new Size(236, 82);
            BtnEqwal.TabIndex = 25;
            BtnEqwal.Text = "=";
            BtnEqwal.UseVisualStyleBackColor = true;
            BtnEqwal.Click += ClickEqual;
            // 
            // Btn0
            // 
            Btn0.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn0.Location = new Point(29, 589);
            Btn0.Name = "Btn0";
            Btn0.Size = new Size(106, 82);
            Btn0.TabIndex = 23;
            Btn0.Text = "0";
            Btn0.UseVisualStyleBackColor = true;
            Btn0.Click += ClickNum;
            // 
            // list
            // 
            list.FormattingEnabled = true;
            list.Location = new Point(29, 154);
            list.Name = "list";
            list.Size = new Size(499, 28);
            list.TabIndex = 27;
            list.SelectedIndexChanged += chose;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(533, 690);
            Controls.Add(list);
            Controls.Add(BtnComa);
            Controls.Add(BtnEqwal);
            Controls.Add(Btn0);
            Controls.Add(Btn5);
            Controls.Add(Btn6);
            Controls.Add(BtnSum);
            Controls.Add(Btn4);
            Controls.Add(Btn8);
            Controls.Add(Btn9);
            Controls.Add(BtnMult);
            Controls.Add(Btn7);
            Controls.Add(ButtonPower);
            Controls.Add(ButtonDiv);
            Controls.Add(ButtonC);
            Controls.Add(Btn2);
            Controls.Add(Btn3);
            Controls.Add(BtnSub);
            Controls.Add(screen);
            Controls.Add(Btn1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "الة حاسبة";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Btn1;
        private TextBox screen;
        private Button BtnSub;
        private Button Btn3;
        private Button Btn2;
        private Button ButtonPower;
        private Button ButtonDiv;
        private Button ButtonC;
        private Button Btn8;
        private Button Btn9;
        private Button BtnMult;
        private Button Btn7;
        private Button Btn5;
        private Button Btn6;
        private Button BtnSum;
        private Button Btn4;
        private Button BtnComa;
        private Button BtnEqwal;
        private Button Btn0;
        private ComboBox list;
    }
}
