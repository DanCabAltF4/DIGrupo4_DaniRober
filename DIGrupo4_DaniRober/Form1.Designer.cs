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
            btn_Enviar = new Button();
            rtbox_prompt = new RichTextBox();
            flowLayout = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // btn_Enviar
            // 
            btn_Enviar.Location = new Point(594, 365);
            btn_Enviar.Name = "btn_Enviar";
            btn_Enviar.Size = new Size(75, 47);
            btn_Enviar.TabIndex = 1;
            btn_Enviar.Text = "Enviar";
            btn_Enviar.UseVisualStyleBackColor = true;
            btn_Enviar.Click += btn_Enviar_Click;
            // 
            // rtbox_prompt
            // 
            rtbox_prompt.Location = new Point(152, 365);
            rtbox_prompt.Name = "rtbox_prompt";
            rtbox_prompt.Size = new Size(436, 47);
            rtbox_prompt.TabIndex = 3;
            rtbox_prompt.Text = "";
            // 
            // flowLayout
            // 
            flowLayout.AutoScroll = true;
            flowLayout.FlowDirection = FlowDirection.TopDown;
            flowLayout.Location = new Point(152, 12);
            flowLayout.Name = "flowLayout";
            flowLayout.Size = new Size(517, 347);
            flowLayout.TabIndex = 4;
            flowLayout.WrapContents = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flowLayout);
            Controls.Add(rtbox_prompt);
            Controls.Add(btn_Enviar);
            Name = "Form1";
            Text = "Form1";
       
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox1;
        private Button btn_Enviar;
        private FlowLayoutPanel flowLayoutPanel1;
        private RichTextBox rtbox_prompt;
        private FlowLayoutPanel flowLayout;
    }
}
