using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace Fangliste_2016
{
    public partial class Frm_FotoÜbersicht1 : Form
    {
        #region Variablen

        List<string> images;
        int index;

        #endregion

        #region Konstruktor

        public Frm_FotoÜbersicht1(List<string> images)
        {
            InitializeComponent();

            this.images = images;
        }

        #endregion

        #region Events

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.index = listView1.SelectedIndices[0];
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Frm_FotoÜbersicht1_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            backgroundWorker1.RunWorkerAsync();
        }

        #endregion

        #region Eigenschaften

        public int SelectedIndex
        {
            get { return this.index; }
        }

        #endregion

        #region Methoden

        private void Zeichnen(int index)
        {
            FileInfo fi = new FileInfo(images[index]);
            listView1.Items.Add(fi.Name, index);
        }

        private void AddImageToImageList(ImageList iml, Bitmap bm, string key, float wid, float hgt)
        {
            // Make the bitmap.
            Bitmap iml_bm = new Bitmap(
            iml.ImageSize.Width,
            iml.ImageSize.Height);
            using (Graphics gr = Graphics.FromImage(iml_bm))
            {
                gr.Clear(Color.Transparent);
                gr.InterpolationMode =  InterpolationMode.High;
                // See where we need to draw the image to scale it properly.
                RectangleF source_rect = new RectangleF(
                0, 0, bm.Width, bm.Height);
                RectangleF dest_rect = new RectangleF(
                0, 0, iml_bm.Width, iml_bm.Height);
                dest_rect = ScaleRect(source_rect, dest_rect);
                // Draw the image.
                gr.DrawImage(bm, dest_rect, source_rect,
                GraphicsUnit.Pixel);
            }
            // Add the image to the ImageList.
            this.Invoke(new MethodInvoker(delegate { iml.Images.Add(key, iml_bm); }));
        }

        private Bitmap BytesToImage(byte[] bytes)
        {
            using (MemoryStream image_stream =
            new MemoryStream(bytes))
            {
                Bitmap bm = new Bitmap(image_stream);
                return bm;
            }
        }

        private RectangleF ScaleRect(RectangleF source_rect, RectangleF dest_rect)
        {
            float source_aspect =
            source_rect.Width / source_rect.Height;
            float wid = dest_rect.Width;
            float hgt = dest_rect.Height;
            float dest_aspect = wid / hgt;
            if (source_aspect > dest_aspect)
            {
                // The source is relatively short and wide.
                // Use all of the available width.
                hgt = wid / source_aspect;
            }
            else
            {
                // The source is relatively tall and thin.
                // Use all of the available height.
                wid = hgt * source_aspect;
            }
            // Center it.
            float x = dest_rect.Left + (dest_rect.Width - wid) / 2;
            float y = dest_rect.Top + (dest_rect.Height - hgt) / 2;
            return new RectangleF(x, y, wid, hgt);
        }

        #endregion

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if ((images != null) || (images.Count != 0))
                {
                    listView1.Items.Clear();

                    for (int i = 0; i < images.Count; i++)
                    {
                        Bitmap b = new Bitmap(images[i]);
                        //this.Invoke(new MethodInvoker(delegate { imageList1.Images.Add(b); }));
                        AddImageToImageList(imageList1, b, "", imageList1.ImageSize.Width, imageList1.ImageSize.Height);
                        this.Invoke(new MethodInvoker(delegate { Zeichnen(i); }));
                    }
                }
            }
            catch { }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if ((images != null) || (images.Count != 0))
            //{
            //    listView1.Items.Clear();

            //    for (int i = 0; i < images.Count; i++)
            //    {
            //        FileInfo fi = new FileInfo(images[i]);
            //        listView1.Items.Add(fi.Name, i);
            //    }
            //}

            this.Cursor = Cursors.Default;
        }

        private void Frm_FotoÜbersicht1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //backgroundWorker1.CancelAsync();
        }
    }
}
