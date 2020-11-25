using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace VPS.Controls.CustomControls
{
    class PositionListUITypeEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            service.DropDownControl(
                new CustomControls.CustomMap()
                {
                    List = ((LoadAndSave.FeaturesInfo)value).features
                });
            PropertyNode propertyNode = (PropertyNode)context;
            propertyNode.UpdateDisplayedValue();
            return value;
        }
    }

    class ContentUITypeEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }


        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            CustomForms.CustomContent form = new CustomForms.CustomContent() { Text = "编辑", Content = (string)value };
            service.ShowDialog(form);
            PropertyNode propertyNode = (PropertyNode)context;
            propertyNode.UpdateDisplayedValue();
            return form.Content;
        }
    }
}
