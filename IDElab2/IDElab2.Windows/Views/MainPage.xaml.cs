using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using IDElab2.ViewModels;
using System.Diagnostics;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace IDElab2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ShipStatus shipStatusViewModel;
        SelfDestroy selfDestroyViewModel;
        Random random = new Random();
        DispatcherTimer mainEventsTimer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
        public MainPage()
        {
            this.InitializeComponent();

            shipStatusViewModel = (ShipStatus)this.Resources["shipStatusViewModel"];
            selfDestroyViewModel = (SelfDestroy)this.Resources["selfDestroyViewModel"];

            mainEventsTimer.Tick += mainEventsTimer_Tick;

            mainEventsTimer.Start();
        }

        void mainEventsTimer_Tick(object sender, object e)
        {
            if (!LogicClass.checkShipStatus(ref shipStatusViewModel))
            {
                mainEventsTimer.Stop();
                boom();
            }
        }




        private void selfDestructionActivated(object sender, RoutedEventArgs e)
        {
            int timerIncrementor = 0;
            mainEventsTimer.Stop();

            selfDestroyViewModel.destroyButtonEnabled = false;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s,ve) => {
                if (timerIncrementor > 5)
                {
                    timer.Stop();
                    boom();
                }
                else
                    selfDestroyViewModel.selfDestroyTimer = (5 - timerIncrementor).ToString();
                timerIncrementor++;
            };
            timer.Start();
        }

        async void boom()
        {
            selfDestroyViewModel.visibility = Visibility.Visible;
            boomSound.Play();
            await Task.Delay(TimeSpan.FromSeconds(2));

            MessageDialog message = new MessageDialog("The ship was destroyed, close the the dialog to start again.");
            await message.ShowAsync();

            shipStatusViewModel.health = shipStatusViewModel.fuel =  100;
            shipStatusViewModel.sliderValue = 50;
            shipStatusViewModel.battleLog.Clear();
            shipStatusViewModel.alienWeakness = "Find Aliens Weakness";
            shipStatusViewModel.useWeapons = false;
            shipStatusViewModel.useShields = false;
            shipStatusViewModel.useHighPowerShields = true;
            shipStatusViewModel.useHighPowerWeapons = true;


            selfDestroyViewModel.destroyButtonEnabled = true;
            selfDestroyViewModel.visibility = Visibility.Collapsed;
            selfDestroyViewModel.selfDestroyTimer = string.Empty;

            mainEventsTimer.Start();

            boomSound.Stop();
        }

        public static string calcWeakness()
        {
            for (int i = 0; i < 5e8; i++)
            {
                Math.Sqrt(i);
            }
            return "42";
        }

        private async void findAlienWeaknessButton_Click(object sender, RoutedEventArgs e)
        {
            shipStatusViewModel.alienWeakness = "Calculating...";
            shipStatusViewModel.alienWeakness = await Task.Run(() => calcWeakness());
        }

        private void changeHeaderColor(object sender, TappedRoutedEventArgs e)
        {
            header.TextColor = new SolidColorBrush(Color.FromArgb((byte)random.Next(100, 255), (byte)random.Next(100, 255), (byte)random.Next(100, 255), 255));
        }
    }
}
