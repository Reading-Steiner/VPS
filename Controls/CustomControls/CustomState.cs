using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPS.Controls.CustomControls
{
    public partial class CustomState : UserControl
    {
        public CustomState()
        {
            InitializeComponent();
        }

        string state = "";

        private Dictionary<string, Color> states = new Dictionary<string, Color>();

        public void AddState(string state, Color display)
        {
            states.Add(state, display);
            if (state == this.state)
                this.DisplayColor.BackColor = display;
        }

        public void SetState(string state)
        {
            this.state = state;
            this.DisplayText.Text = state;
            if (states.ContainsKey(state))
                this.DisplayColor.BackColor = states[state];
            else
                this.DisplayColor.BackColor = Color.Lime;
        }
    }
}
