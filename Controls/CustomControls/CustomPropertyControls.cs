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
            var Map = new CustomControls.CustomMap();
            if (value is LoadAndSave.FeaturesInfo)
                Map.List = ((LoadAndSave.FeaturesInfo)value).features;
            if (value is LoadAndSave.FeatureInfo)
                Map.AddList(((LoadAndSave.FeatureInfo)value).features);
            if (value is LoadAndSave.PolygonInfo)
                Map.AddList(((LoadAndSave.PolygonInfo)value).features);
            if (value is LoadAndSave.ProjectListInfo)
                Map.AddList(((LoadAndSave.ProjectListInfo)value).features);
            service.DropDownControl(Map);
            PropertyNode propertyNode = (PropertyNode)context;
            propertyNode.UpdateDisplayedValue();
            return value;
        }
    }

    class PositionUITypeEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            var form = new CustomGridControl.GridPosition((VPS.Controls.LoadAndSave.Position)value);

            service.ShowDialog(form);
            PropertyNode propertyNode = (PropertyNode)context;
            propertyNode.UpdateDisplayedValue();
            return value;
        }
    }

    class RectUITypeEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            var form = new CustomGridControl.GridRect((VPS.Controls.LoadAndSave.Rect)value);

            service.ShowDialog(form);
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

    class WPOrPolyFileUITypeEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            var openFile = new CustomControls.CustomFileSelecter();
            openFile.FileFilter = "Google Earth KML(*kml;*.kmz) |*.kml;*.kmz|ShapeFile(*.shp)|*.shp";
            service.DropDownControl(openFile);
            PropertyNode propertyNode = (PropertyNode)context;
            propertyNode.UpdateDisplayedValue();
            return value;
        }
    }
}
