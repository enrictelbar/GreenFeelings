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
            GMapOverlay markers = new GMapOverlay("markers");
            GMapMarker marker1 = new GMarkerGoogle(new PointLatLng(39.4722, -0.376845), GMarkerGoogleType.green);
            GMapMarker marker2 = new GMarkerGoogle(new PointLatLng(39.4712, -0.376875), GMarkerGoogleType.green);
            GMapMarker marker3 = new GMarkerGoogle(new PointLatLng(39.4702, -0.376805), GMarkerGoogleType.green);
            marker1.ToolTipText = "Arbol Grande";
            marker1.ToolTip.Fill = Brushes.Black;
            marker1.ToolTip.Foreground = Brushes.White;
            marker1.ToolTip.Stroke = Pens.Black;
            marker1.ToolTip.TextPadding = new Size(15, 15);
            marker2.ToolTipText = "Arbol Mediano";
            marker2.ToolTip.Fill = Brushes.Black;
            marker2.ToolTip.Foreground = Brushes.White;
            marker2.ToolTip.Stroke = Pens.Black;
            marker2.ToolTip.TextPadding = new Size(15, 15);
            markers.Markers.Add(marker1);
            markers.Markers.Add(marker2);
            markers.Markers.Add(marker3);
            gMap.Overlays.Add(markers);
            gMap.OnMarkerClick += new MarkerClick(gMap_OnMarkerClick);
        }
        private void gMap_OnMarkerClick(GMapMarker item, MouseEventArgs m)
        {
            Console.WriteLine("Hola");
        }
    }
}
