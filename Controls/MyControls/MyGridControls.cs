using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevComponents.DotNetBar.SuperGrid;
using System.Collections;
using System.Drawing;

namespace VPS.Controls.MyControls
{
    internal class FragrantComboBox : GridComboBoxExEditControl
    {
        public FragrantComboBox(IEnumerable orderArray)
        {
            DataSource = orderArray;
        }
    }


    internal class ImagePanel : GridLabelXEditControl
    {
        #region Private variables

        #endregion

        public ImagePanel(Image image)
        {
            Image = image;
        }

    }

    internal class ImageCheckBox : GridCheckBoxXEditControl
    {
        #region Private variables
        #endregion

        public ImageCheckBox(Image image)
        {
            this.CheckBoxImageChecked = image;
        }
    }

    internal class AltitudeFrame : GridComboBoxExEditControl
    {
        public AltitudeFrame()
        {
            this.DataSource = new List<string>() { "Relative", "Absolute", "Terrain" };
        }
    }
}
