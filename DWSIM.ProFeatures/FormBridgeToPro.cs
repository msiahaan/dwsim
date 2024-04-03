﻿using DWSIM.Interfaces;
using System;
using System.Windows.Forms;

namespace DWSIM.ProFeatures
{

    public partial class FormBridgeToPro:Form
    {

        public IFlowsheet CurrentFlowsheet;
        private bool Transitioning = false;

        public FormBridgeToPro()
        {
            InitializeComponent();
            lblFeature = _lblFeature;
            _lblFeature.Name = "lblFeature";
        }

        private void FormBridgeToPro_Load(object sender, EventArgs e)
        {

            ExtensionMethods.FormExtensions.ChangeDefaultFont(this);

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            CurrentFlowsheet.FlowsheetOptions.FlowsheetTransitionObject = null;

            Close();

        }

        private void Button2_Click(object sender, EventArgs e)
        {

            Transitioning = true;

            Functions.ProcessTransition(CurrentFlowsheet);

            Close();

        }

        private void FormBridgeToPro_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {

            if (!Transitioning)
                CurrentFlowsheet.FlowsheetOptions.FlowsheetTransitionObject = null;

        }

    }
}