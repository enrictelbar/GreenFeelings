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
            ArrayList trees = new ArrayList();
            ArrayList markersList = new ArrayList();
            trees.Add(new Tree("Arbol Grande", 39.4722, -0.376845, "Dueño", "Arbol grande en el centro de Valencia", "Calle ...", true));
            trees.Add(new Tree("Arbol Mediano", 39.4712, -0.376875, "Dueño 2", "Arbol mediano en el centro de Valencia", "Plaza ...", true));
            trees.Add(new Tree("Arbol Pequeño", 39.4702, -0.376805, "Dueño 3", "Arbol pequeño en el centro de Valencia", "Paseo ...", true));
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
            foreach (Tree tr in trees)
            {
                GMapMarker aux = new GMarkerGoogle(new PointLatLng(tr.getLatitude(), tr.getLongitude()), GMarkerGoogleType.green);
                aux.ToolTipText = tr.getName();
                aux.ToolTip.Fill = Brushes.Black;
                aux.ToolTip.Foreground = Brushes.White;
                aux.ToolTip.Stroke = Pens.Black;
                aux.ToolTip.TextPadding = new Size(15, 15);
                markersList.Add(aux);
            }
            foreach (GMapMarker gmm in markersList)
            {
                markers.Markers.Add(gmm);
            }
            gMap.Overlays.Add(markers);
            gMap.OnMarkerClick += new MarkerClick(gMap_OnMarkerClick);
        }
        private void gMap_OnMarkerClick(GMapMarker item, MouseEventArgs m)
        {
            Console.WriteLine("Hola");
        }
    }
}
