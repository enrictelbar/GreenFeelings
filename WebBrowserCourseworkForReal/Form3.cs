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
    //private aaa service;
    public partial class Form3 : Form
    {
        public Form3(String service)
        {
            InitializeComponent();
            //this.service = service;
            string image = "null";
            Tree tree0 = new Tree(0, "Arbol Grande", 39.475383063453215, -0.3978636030402102, "Ms. Gwen", "Arbol grande en el centro de Valencia", "Rio de Valencia, Valencia, Spain", true);
            if (service == "0") {
                tree0 = new Tree(0, "Arbol Grande", 39.475383063453215, -0.3978636030402102, "Ms. Gwen", "Arbol grande en el centro de Valencia", "Rio de Valencia, Valencia, Spain", true);
                image = "gdg";
            }

            if (service == "1") {
                tree0 = new Tree(1, "Arbol Mediano", 39.4712, -0.376875, "Mr. Peter", "Arbol mediano en el centro de Valencia", "Plaza de la Mare de Deu, Valencia, Spain", true);
                image = "gdm";
            }

            if (service == "2") {
                tree0 = new Tree(2, "Arbol Pequeño", 39.471680668554924, -0.38815797923306555, "Alex", "Arbol pequeño en el centro de Valencia", "Paseo de los arboles, Valencia, Spain", true);
                image = "gdp";
            }
            labelNombre.Text = tree0.getName();
            labelOwner.Text = tree0.getOwner();
            labelAddress.Text = tree0.getAddress();
            labelDesc.Text = tree0.getDescription();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(image);
        }
        
    }
}
