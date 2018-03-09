using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Great_Circle_Distances
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       double C_RADIUS_EARTH_KM = 6371.1;
       double C_RADIUS_EARTH_MI= 3958.82;
       double C_PI = 3.14159265358979;
       double GreatCircleDistance(double Latitude1, double Longitude1,
                     double Latitude2, double Longitude2, bool ValuesAsDecimalDegrees,
                     bool ResultAsMiles)
       {
            double Lat1;
            double Lat2;
            double Long1;
            double Long2;
            long X; 
             double Delta;

            if (ValuesAsDecimalDegrees ==true)
                X = 1;
            else
                X = 24;
            
            // convert to decimal degrees
            Lat1 = Latitude1 * X;
            Long1 = Longitude1 * X;
            Lat2 = Latitude2 * X;
            Long2 = Longitude2 * X;
           
           // convert to radians: radians = (degrees/180) * PI
            Lat1 = (Lat1 / 180) * C_PI;
            Lat2 = (Lat2 / 180) * C_PI;
            Long1 = (Long1 / 180) * C_PI;
            Long2 = (Long2 / 180) * C_PI;
           // get the central spherical angle

            Delta = (2 * Math.Asin(Math.Sqrt((Math.Pow(Math.Sin((Lat1 - Lat2) / 2), 2) + Math.Cos(Lat1) * Math.Cos(Lat2) * (Math.Pow(Math.Sin((Long1 - Long2) / 2), 2))))));
               
            if( ResultAsMiles ==true)
                return( Delta * C_RADIUS_EARTH_MI);
            else
               return(Delta * C_RADIUS_EARTH_KM);
                       
       
       }







        private void Calculate_Click(object sender, EventArgs e)
        {
          

            double Lat1;
            double Lat2;
            double Long1;
            double Long2;
            double result;
            bool resultasmiles;
            
            Lat1=double.Parse(textBox1.Text);
            Lat2=double.Parse(textBox2.Text);
            Long1 =double.Parse(textBox3.Text);
            Long2 =double.Parse(textBox4.Text);
            if (comboBox1.SelectedIndex == 0)
                resultasmiles = true;
            else
                resultasmiles = false;
            result=GreatCircleDistance(Lat1, Long1, Lat2, Long2, true, resultasmiles);
            textBox5.Text = result.ToString();
    




        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // for example different two point
            textBox1.Text = "38,3689";
            textBox2.Text = "38,3695";
            textBox3.Text = "27,1204";
            textBox4.Text = "27,1239";
            textBox5.Text = "0";
            comboBox1.SelectedIndex = 0;
            label8.Text = comboBox1.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            double result;
            label8.Text = comboBox1.Text;
            if (comboBox1.Text == "Miles ")
                result = 0.621372 * (double.Parse(textBox5.Text));
            else
                result =1.609343* (double.Parse(textBox5.Text));

            textBox5.Text = result.ToString();

            

        }
    }
}
