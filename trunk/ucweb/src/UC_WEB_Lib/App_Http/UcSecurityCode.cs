using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Collections;
using System.IO;
using System.Web.SessionState;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

namespace UCENTRIK.ImageHandlers
{

    public class UcSecurityCode : IHttpHandler, IRequiresSessionState
    {


        const Int32 width = 150;
        const Int32 height = 50;
        
        protected Random rnd;



        public bool IsReusable
        {
            get { return true; }
        }







        public void ProcessRequest(HttpContext context)
        {
            string text = "";

            object obj = context.Session["SecurityCode"];
            if (obj != null)
                text = obj.ToString();


            Bitmap bmp = new Bitmap(width, height);
            Graphics Graph = Graphics.FromImage(bmp);
            Graph.Clear(Color.FromArgb(224, 224, 224));

            if (text != "")
            {
                rnd = new Random(DateTime.Now.Millisecond);





                for (int i = 0; i < 50; i++)
                {
                    drawRandomLine(Graph);
                }


                //for (int i = 0; i < 10; i++)
                //{
                //    drawRandomEllipse(Graph);
                //}




                Int32 pos = 25;
                foreach (char c in text.ToCharArray())
                {
                    Int32 randomNumber = rnd.Next(12, 24);
                    
                    
                    Int32 randomColorR = rnd.Next(64, 192);
                    Int32 randomColorG = rnd.Next(64, 192);
                    Int32 randomColorB = 64 + (384 - randomColorR - randomColorG) / 3;

                    Graph.TextRenderingHint = TextRenderingHint.AntiAlias;
                    Graph.SmoothingMode = SmoothingMode.AntiAlias;

                    //Colour brush to use for generator
                    Brush textBrush = new SolidBrush(Color.FromArgb(randomColorR, randomColorG, randomColorB));

                    //font to write as
                    Font fnt = new Font("Arial", randomNumber, FontStyle.Bold);

                    //Point to start at
                    Point pnt = new Point(pos, 10);

                    pos = pos + randomNumber;

                    Graph.DrawString(c.ToString(), fnt, textBrush, pnt);
                }
            }
            //---------------------------------------------------

            MemoryStream imageStream = new MemoryStream();
            bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);

            byte[] imageContent = new Byte[imageStream.Length];
            imageStream.Position = 0;
            imageStream.Read(imageContent, 0, (int)imageStream.Length);

            context.Response.Clear();
            context.Response.ContentType = "image/jpeg";
            context.Response.BinaryWrite(imageContent);
            context.Response.End();

        }





        public bool ThumbnailCallback()
        {
            return true;
        }



















        protected Color getRandomColor()
        {
            Int32 randomR = rnd.Next(0, 255);
            Int32 randomG = rnd.Next(0, 255);
            Int32 randomB = rnd.Next(0, 255);
            Int32 randomT = rnd.Next(0, 255);


            Color color = Color.FromArgb(randomT, randomR, randomG, randomB);
            return color;
        }








        protected void drawRandomLine(Graphics graph)
        {
            Pen pen = new Pen(Color.FromArgb(255, 255, 255), 1);

            Int32 randomX = rnd.Next(-width, 2 * width);
            Int32 randomY = rnd.Next(-height, 2 * height);
            Point pt1 = new Point(randomX, randomY);

            randomX = rnd.Next(-width, 2 * width);
            randomY = rnd.Next(-height, 2 * height);
            Point pt2 = new Point(randomX, randomY);

            graph.DrawLine(pen, pt1, pt2);


        }


        protected void drawRandomEllipse(Graphics graph)
        {
            Pen pen = new Pen(getRandomColor(), 1);

            Int32 randomX = rnd.Next(0, width);
            Int32 randomY = rnd.Next(0, height);

            Int32 randomWidth = rnd.Next(-randomX, width - randomX);
            Int32 randomHeight = rnd.Next(-randomY, height - randomY);

            Rectangle rect = new Rectangle(randomX, randomY, randomWidth, randomHeight);

            graph.DrawEllipse(pen, rect);
        }



        protected void drawRandomRectangle(Graphics graph)
        {
        //for (int i = 0; i < 5; i++)
        //{
        //    Pen pen = new Pen(Color.FromArgb(180, 180, 180), 1);
        //    Int32 randomX = rnd.Next(0, width);
        //    Int32 randomY = rnd.Next(0, height);
        //    Int32 randomWidth = rnd.Next(0, width - randomX);
        //    Int32 randomHeight = rnd.Next(0, height - randomY);
        //    Rectangle rect = new Rectangle(randomX, randomY, randomWidth, randomHeight);
        //    Graph.DrawRectangle(pen, rect);
        //}
        }






        //---
    }
}
