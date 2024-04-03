﻿using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DWSIM.ProFeatures
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class FormCosting
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCosting));
            Panel1 = new System.Windows.Forms.Panel();
            Label4 = new System.Windows.Forms.Label();
            Button2 = new System.Windows.Forms.Button();
            Button2.Click += new EventHandler(Button2_Click);
            PictureBox2 = new System.Windows.Forms.PictureBox();
            _lblFeature = new System.Windows.Forms.Label();
            Label1 = new System.Windows.Forms.Label();
            PictureBox1 = new System.Windows.Forms.PictureBox();
            Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            Panel1.BackColor = System.Drawing.Color.White;
            Panel1.Controls.Add(Label4);
            Panel1.Controls.Add(Button2);
            Panel1.Controls.Add(PictureBox2);
            Panel1.Controls.Add(_lblFeature);
            Panel1.Controls.Add(Label1);
            Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            Panel1.Location = new System.Drawing.Point(0, 471);
            Panel1.Name = "Panel1";
            Panel1.Size = new System.Drawing.Size(915, 123);
            Panel1.TabIndex = 2;
            // 
            // Label4
            // 
            Label4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Label4.Location = new System.Drawing.Point(675, 68);
            Label4.Name = "Label4";
            Label4.Size = new System.Drawing.Size(228, 43);
            Label4.TabIndex = 14;
            Label4.Text = "Your flowsheet will be automatically saved on Simulate365 Dashboard";
            Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Button2
            // 
            Button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            Button2.BackColor = System.Drawing.Color.FromArgb(31, 166, 13);
            Button2.Font = new System.Drawing.Font("Calibri", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Button2.ForeColor = System.Drawing.Color.White;
            Button2.Location = new System.Drawing.Point(675, 11);
            Button2.Name = "Button2";
            Button2.Size = new System.Drawing.Size(228, 50);
            Button2.TabIndex = 13;
            Button2.Text = "Switch to DWSIM Pro";
            Button2.UseVisualStyleBackColor = false;
            // 
            // PictureBox2
            // 
            PictureBox2.Image = My.Resources.Resources.Icon512;
            PictureBox2.Location = new System.Drawing.Point(8, 12);
            PictureBox2.Name = "PictureBox2";
            PictureBox2.Size = new System.Drawing.Size(99, 99);
            PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            PictureBox2.TabIndex = 10;
            PictureBox2.TabStop = false;
            // 
            // lblFeature
            // 
            _lblFeature.AutoSize = true;
            _lblFeature.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            _lblFeature.Location = new System.Drawing.Point(112, 12);
            _lblFeature.Name = "_lblFeature";
            _lblFeature.Size = new System.Drawing.Size(368, 31);
            _lblFeature.TabIndex = 9;
            _lblFeature.Text = "CAPEX + OPEX Estimation";
            // 
            // Label1
            // 
            Label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            Label1.Location = new System.Drawing.Point(114, 50);
            Label1.Name = "Label1";
            Label1.Size = new System.Drawing.Size(557, 60);
            Label1.TabIndex = 8;
            Label1.Text = "Estimate CAPEX + OPEX for your flowsheet. Use the integrated optimizer to minimiz" + "e the overall process costs.";
            // 
            // PictureBox1
            // 
            PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            PictureBox1.Image = My.Resources.Resources._7;
            PictureBox1.Location = new System.Drawing.Point(0, -1);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new System.Drawing.Size(915, 587);
            PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            PictureBox1.TabIndex = 3;
            PictureBox1.TabStop = false;
            // 
            // FormCosting
            // 
            this.AllowEndUserDocking = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96.0f, 96.0f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(915, 594);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(Panel1);
            this.Controls.Add(PictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            this.Name = "FormCosting";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.TabText = "Costing";
            this.Text = "Costing";
            Panel1.ResumeLayout(false);
            Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            this.Load += FormCosting_Load;
            this.ResumeLayout(false);

        }

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.PictureBox PictureBox2;
        private System.Windows.Forms.Label _lblFeature;

        public virtual System.Windows.Forms.Label lblFeature
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblFeature;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _lblFeature = value;
            }
        }
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button Button2;
    }
}