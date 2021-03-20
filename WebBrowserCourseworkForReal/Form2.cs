using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
//using MudaT.Services;
//using MudaT.Entities;
//using GoogleMaps.LocationServices;
using System.Collections;
using System.Globalization;

namespace WebBrowserCourseworkForReal
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            gMap.ShowCenter = false;
            gMap.DragButton = MouseButtons.Left;
            gMap.CanDragMap = true;
            gMap.MapProvider = GMapProviders.GoogleMap;
            gMap.MinZoom = 0;
            gMap.MaxZoom = 24;
            gMap.Zoom = 12;
            gMap.AutoScroll = true;
            gMap.Position = new PointLatLng(39.4702, -0.376805);
        }
    }
}
