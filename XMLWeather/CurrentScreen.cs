using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class CurrentScreen : UserControl
    {
        Image image1 = Properties.Resources.images; 
        public CurrentScreen()
        {
            InitializeComponent();
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {
            // the current information is in index 0, thus why all information is retreived from there
            cityOutput.Text = Form1.days[0].location;
            tempLabel.Text = Form1.days[0].currentTemp;
            minOutput.Text = Form1.days[0].tempLow;
            maxOutput.Text = Form1.days[0].tempHigh;
            rainConditions.Text = Form1.days[0].precipitation + "% chance";
            cloudsConditions.Text = Form1.days[0].condition;

            int con = Convert.ToInt32(Form1.days[0].condition);
            int rain = Convert.ToInt32(Form1.days[0].precipitation); 
            if(con >= 500 && con <= 599)
            {
                conditonImage.BackgroundImage = Properties.Resources.images; 
            }
            else if (con >= 200 && con <= 499)
            {
                conditonImage.BackgroundImage = Properties.Resources.download; 
            }
            else if (con >= 0 && con <=199)
            {
                conditonImage.BackgroundImage = Properties.Resources._38_388521_happy_ecstatic_sel_sun_mostly_sunny_symbol_weather;
            }
            if(rain >=99 && rain <=500 )
            {
                conditonImage.BackgroundImage = Properties.Resources.rain_512; 
            }
        }

        /// <summary>
        /// When the forecast label is clicked this user control is removed from the form
        /// and the ForecastScreen user control is added to the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }
    }
}
