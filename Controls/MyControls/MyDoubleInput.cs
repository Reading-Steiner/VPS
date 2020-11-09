using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevComponents.Editors;
using System.Text.RegularExpressions;

namespace VPS.Controls.MyControls
{
    public partial class MyDoubleInput : DoubleInput
    {
        public MyDoubleInput()
            : base()
        {
            InitializeComponent();

        }

        public MyDoubleInput(IContainer container)
            : base()
        {
            container.Add(this);

            InitializeComponent();
        }

        private void MyDoubleInput_ConvertFreeTextEntry(object sender, FreeTextEntryConversionEventArgs e)
        {
            if (double.TryParse(e.ValueEntered, out double value))
            {
                e.IsValueConverted = true;
                e.ControlValue = value;
            }
            else
            {
                if (Regex.IsMatch(e.ValueEntered, "[+-]?([0-9]+)([.][0-9]+)?"))
                {
                    e.IsValueConverted = true;

                    var match = Regex.Match(e.ValueEntered, "[+-]?([0-9]+)([.][0-9]+)?");
                    int value1 = int.Parse(match.Value);

                    e.ControlValue = value1;
                }
            }
        }
    }
}
