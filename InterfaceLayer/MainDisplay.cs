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
        private const string cDataHeader = "Type   | Health | State";
        private const string cPipe = " | ";
        private const string cNewLine = "\r\n";

        private readonly IZoo _zoo;
        // That we have two identical timers is amusing an feels inefficient but
        // removing the time from zoo would move business logic into the display layer
        private readonly Timer _timer = new Timer();

        public MainDisplay(IZoo zoo)
        {
            _zoo = zoo;
            InitializeComponent();
            _timer.Start();
            _timer.Interval = 1000;
            _timer.Tick += OnTimerTick;
            UpdateDisplay();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void FeedButton_Click(object sender, EventArgs e)
        {
            _zoo.FeedAllAnimals();
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            TimeDisplay.Text = cTimeAtTheZoo + _zoo.GetTimeAtTheZoo();

            var data = _zoo.GetAnimalData();

            var sb = new StringBuilder();
            sb.Append(cDataHeader);
            sb.Append(cNewLine);

            

            foreach (var animal in data)
            {
                sb.Append(animal.Type);
                sb.Append(cPipe);
                sb.Append(Math.Round(animal.Health, 2));
                sb.Append('%');
                sb.Append(cPipe);
                sb.Append(animal.State == State.DangerZone ? animal.PublicFacingDangerZoneName : animal.State.ToString());
                sb.Append(cNewLine);
            }

            DataDisplay.Text = sb.ToString();
        }
    }
}
