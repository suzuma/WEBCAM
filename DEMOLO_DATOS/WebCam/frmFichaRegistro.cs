using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;
using WebCam.Commun;
using System.Drawing.Imaging;

using DEMELO_DATOS.Modelo;
using WebCam.DataModelManager;

namespace WebCam
{
    public partial class frmFichaRegistro : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;

        public String ImagenString { get; set; }
        public Bitmap ImagenBitmap { get; set; }

        private List<String> CamarasDetectadas = new List<string>();

        public frmFichaRegistro()
        {
            InitializeComponent();
        }



        private void videoSource_newFrame(object sender, NewFrameEventArgs eventArgs)
        {
            ImagenBitmap = (Bitmap)eventArgs.Frame.Clone();
            ImagenString = ToolImagen.ToBase64String(ImagenBitmap, ImageFormat.Jpeg);
            picImagen.Image = ImagenBitmap;
        }
        public void FinalizarControles()
        {
            if (videoSource.IsRunning)
            {
                videoSource.Stop();
            }
        }
        public void PonerFotografia(String pathImagen)
        {
            ImagenBitmap = new System.Drawing.Bitmap(pathImagen);
            ImagenString = ToolImagen.ToBase64String(ImagenBitmap, ImageFormat.Jpeg);
            picImagen.Image = ImagenBitmap;
        }

        private void frmFichaRegistro_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo device in videoDevices)
            {
                CamarasDetectadas.Add(device.Name);
            }
            if (CamarasDetectadas.Count > 0)
            {
                videoSource = new VideoCaptureDevice();
                btnTomar.Enabled = true;
            }
            else
            {

                btnTomar.Enabled = false;
            }
        }

        private void btnTomar_Click(object sender, EventArgs e)
        {
            if (videoSource.IsRunning)
            {
                videoSource.Stop();
                this.picImagen.Image = ImagenBitmap;
                picImagen.Invalidate();
                btnTomar.Text = "Activar";
            }
            else
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(videoSource_newFrame);
                videoSource.Start();
                btnTomar.Text = "Capturar";
            }
        }
 
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (videoSource.IsRunning) {
                videoSource.Stop();               
            }
            //LIMIAMOS
            txtNombre.Text = "";
            txtApellidos.Text = "";
            picImagen.Image = null;
        }

        
        /// SI SE SIERRA LA VENTAN HAY QUE VALIDAR QUE LA CAMARA SE APAGUE        
        private void frmFichaRegistro_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (videoSource.IsRunning)
            {
                videoSource.Stop();
                picImagen.Image = null;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Empleado nEmpleado = new Empleado();
            nEmpleado.sNombre = txtNombre.Text;
            nEmpleado.sApellido = txtApellidos.Text;
            nEmpleado.sImagen = ImagenString;
            EmpleadoManager.Guardar(nEmpleado);

            //LIMIAMOS
            txtNombre.Text = "";
            txtApellidos.Text = "";
            picImagen.Image = null;
        }
    }
}
