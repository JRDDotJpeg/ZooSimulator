using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZooSimulator.ServiceLayer;

namespace ZooSimulator.InterfaceLayer
{
    public partial class MainDisplay : Form
    {
        private const string cTimeAtTheZoo = "Time at the Zoo: ";

        private IZoo _zoo;
        private Timer _timer = new Timer();
        public MainDisplay()
        {
            InitializeComponent();
            _timer.Start();
            _timer.Interval = 1000;
            _timer.Tick += OnTimerTick;  
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void FeedButton_Click(object sender, EventArgs e)
        {
            _zoo.FeedAllAnimals();
        }

        private void UpdateDisplay()
        {
            TimeDisplay.Text = cTimeAtTheZoo + _zoo.GetTimeAtTheZoo();

            var data = _zoo.GetAnimalData();

        }
    }
}
