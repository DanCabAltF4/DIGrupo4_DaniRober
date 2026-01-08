namespace DIGrupo4_DaniRober
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
            textBox1 = new TextBox();
            btn_Enviar = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            richTextBox1 = new RichTextBox();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(78, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(436, 23);
            textBox1.TabIndex = 0;
            // 
            // btn_Enviar
            // 
            btn_Enviar.Location = new Point(594, 365);
            btn_Enviar.Name = "btn_Enviar";
            btn_Enviar.Size = new Size(75, 47);
            btn_Enviar.TabIndex = 1;
            btn_Enviar.Text = "Enviar";
            btn_Enviar.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(textBox1);
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(152, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(517, 347);
            flowLayoutPanel1.TabIndex = 2;
            flowLayoutPanel1.WrapContents = false;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(152, 365);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(436, 47);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(btn_Enviar);
            Name = "Form1";
            Text = "Form1";
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox1;
        private Button btn_Enviar;
        private FlowLayoutPanel flowLayoutPanel1;
        private RichTextBox richTextBox1;
    }
}
