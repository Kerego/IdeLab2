﻿using IDElab2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace IDElab2
{
    public class LogicClass
    {

        public static bool checkShipStatus(ref ShipStatus shipStatus)
        {
            if (shipStatus.battleLog.Count > 10)
                for (int i = 5; i < shipStatus.battleLog.Count; )
                    shipStatus.battleLog.RemoveAt(i);

            if (shipStatus.health > 0)
                checkForDamage(ref shipStatus);
            else
                return false;

            if (shipStatus.health < 100)
                checkForRepair(ref shipStatus);

            if (shipStatus.fuel > 0)
            {
                shipStatus.fuel -= shipStatus.sliderValue / 15;
                shipStatus.fuel -= (shipStatus.useWeapons ? (shipStatus.useHighPowerWeapons ? 2 : 0) + (shipStatus.useLowPowerWeapons ? 1 : 0) : 0);
                shipStatus.fuel -= (shipStatus.useShields ? (shipStatus.useHighPowerShields ? 2 : 0) + (shipStatus.useLowPowerShields ? 1 : 0) : 0);
            }
            else
                return false;

            return true;
        }

        public static void checkForDamage(ref ShipStatus shipStatus)
        {
            Random random = new Random();
            if (random.Next(100) < 81)
            {
                var damage = (100 - shipStatus.sliderValue) / 10 + random.Next(5) - (shipStatus.useShields ? (shipStatus.useHighPowerShields ? 4 : 0) + (shipStatus.useLowPowerShields ? 2 : 0) : 0);
                shipStatus.health -= damage;
                shipStatus.battleLog.Insert(0, new TextBlock() { Text = "An enemy ship attacked our ship. -" + damage + "HP", Foreground = new SolidColorBrush(Colors.Red), TextAlignment = TextAlignment.Center, Width = 488 });
            }
        }

        public static void checkForRepair(ref ShipStatus shipStatus)
        {
            Random random = new Random();
            if (random.Next(100) < 51)
            {
                var damage = shipStatus.sliderValue / 10 + random.Next(5);
                shipStatus.health += damage;
                shipStatus.battleLog.Insert(0, new TextBlock() { Text = "Our mechanics managed to repair the ship. +" + damage + "HP", Foreground = new SolidColorBrush(Colors.Green), TextAlignment = TextAlignment.Center, Width = 488 });
            }
        }
    }
}
