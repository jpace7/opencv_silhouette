using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Image<Gray, byte> img2gray;
            Image<Gray, byte> img3;

           

            Mat testimg = new Mat();
          
            Image<Bgr, Byte> img = new Image<Bgr, byte>(@"c:\test\original.jpg");

            img2gray = img.Convert<Gray, Byte>();


           
            Mat smoothedFrame = new Mat();
            CvInvoke.GaussianBlur(img, smoothedFrame, new Size(3, 3), 1);
            img3 = img2gray.AbsDiff(smoothedFrame.ToImage<Gray, Byte>());//.Convert<Gray, Byte>());
            img3 = img3.ThresholdBinary(new Gray(7), new Gray(255));
 
            



            //Using the Threshold methond  wiht not blur or Absdiff
            Mat img4 = new Mat();
            CvInvoke.Threshold(img2gray, img4, 40, 300, ThresholdType.Binary);


           
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();

            IOutputArray hierarchy = null;

       

            Rectangle rect = new Rectangle();

            
            //Saved Images to compare
            img4.Save("Threshold.jpg");
            img3.Save("processed.jpg");




            Image<Gray, Byte> imgProcessed1;

            Image<Bgr, Byte> imgProcessed = new Image<Bgr, byte>(@"C:\test\original.jpg");

            imgProcessed1 = imgProcessed.Convert<Gray, byte>();
          
            Image<Gray, float> img_final = imgProcessed1.Sobel(0, 1, 3).Add(imgProcessed1.Sobel(1, 0, 3)).AbsDiff(new Gray(0.0));


            img_final.Save("sobel.jpg");


            // Using Canny
            Image<Gray, Byte> Ncanny;
            Ncanny = img2gray.Canny(10, 60);
            Ncanny.Sobel(1, 0, 3);
            Ncanny.Save("img2gray.jpg");



        }

  


    }
}
