namespace Drawers
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
            btnClear = new Button();
            btnHTree = new Button();
            btnSierpinskiTriangle = new Button();
            btnPythagoras = new Button();
            Depth = new NumericUpDown();
            canvas = new Panel();
            ((System.ComponentModel.ISupportInitialize)Depth).BeginInit();
            SuspendLayout();
            // 
            // btnClear
            // 
            btnClear.Location = new Point(138, 12);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 0;
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnHTree
            // 
            btnHTree.Location = new Point(219, 12);
            btnHTree.Name = "btnHTree";
            btnHTree.Size = new Size(75, 23);
            btnHTree.TabIndex = 1;
            btnHTree.Text = "H-TREE";
            btnHTree.UseVisualStyleBackColor = true;
            btnHTree.Click += btnHTree_Click;
            // 
            // btnSierpinskiTriangle
            // 
            btnSierpinskiTriangle.Location = new Point(300, 12);
            btnSierpinskiTriangle.Name = "btnSierpinskiTriangle";
            btnSierpinskiTriangle.Size = new Size(75, 23);
            btnSierpinskiTriangle.TabIndex = 2;
            btnSierpinskiTriangle.Text = "SIERPINSKI";
            btnSierpinskiTriangle.UseVisualStyleBackColor = true;
            btnSierpinskiTriangle.Click += btnSierpinskiTriangle_Click;
            // 
            // btnPythagoras
            // 
            btnPythagoras.Location = new Point(381, 12);
            btnPythagoras.Name = "btnPythagoras";
            btnPythagoras.Size = new Size(97, 23);
            btnPythagoras.TabIndex = 3;
            btnPythagoras.Text = "PYTHAGORAS";
            btnPythagoras.UseVisualStyleBackColor = true;
            btnPythagoras.Click += btnPythagoras_Click;
            // 
            // Depth
            // 
            Depth.Location = new Point(12, 12);
            Depth.Name = "Depth";
            Depth.Size = new Size(120, 23);
            Depth.TabIndex = 6;
            // 
            // canvas
            // 
            canvas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            canvas.AutoSize = true;
            canvas.Location = new Point(12, 41);
            canvas.Name = "canvas";
            canvas.Size = new Size(776, 397);
            canvas.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(canvas);
            Controls.Add(Depth);
            Controls.Add(btnPythagoras);
            Controls.Add(btnSierpinskiTriangle);
            Controls.Add(btnHTree);
            Controls.Add(btnClear);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)Depth).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClear;
        private Button btnHTree;
        private Button btnSierpinskiTriangle;
        private Button btnPythagoras;
        private NumericUpDown Depth;
        private Panel canvas;
    }
}
