using GMap.NET.CacheProviders;
using VPS.ArduPilot;
using VPS.Comms;
using VPS.Controls;
using VPS.Utilities;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace VPS.Controls
{
    public partial class LayerManager : Form
    {
        public LayerManager()
        {
            InitializeComponent();
            Init();
        }

    }
}
