using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace IDElab2.ViewModels
{
    public class ShipStatus : CommonBase
    {
        public ShipStatus()
        {
            health = 100;
            fuel = 100;
            battleLog = new ObservableCollection<TextBlock>();
            sliderValue = 50;
            alienWeakness = "Find Aliens Weakness";
            useHighPowerWeapons = false;
            useLowPowerWeapons = false;
            useHighPowerShields = false;
            useLowPowerShields = false;
            useShields = false;
            useWeapons = false;

        }

        private int _health;
        public int health
        {
            get { return _health; }
            set
            {
                if (value < 100 && value > 0)
                    _health = value;
                else if (value > 99)
                    _health = 100;
                else
                    _health = 0;
                OnPropertyChanged("health");
            }
        }

        private int _fuel;
        public int fuel
        {
            get { return _fuel; }
            set
            {
                if (value < 100 && value > 0)
                    _fuel = value;
                else if (value > 99)
                    _fuel = 100;
                else
                    _fuel = 0;
                OnPropertyChanged("fuel");
            }
        }

        private ObservableCollection<TextBlock> _battleLog;
        public ObservableCollection<TextBlock> battleLog
        {
            get { return _battleLog; }
            set { 
                _battleLog = value;
                OnPropertyChanged("battleLog");
            }
        }

        private int _sliderValue;
        public int sliderValue
        {
            get { return _sliderValue; }
            set {
                if (value < 100 && value > 0)
                    _sliderValue = value;
                else if (value > 99)
                    _sliderValue = 100;
                else
                    _sliderValue = 0;
                OnPropertyChanged("sliderValue");
            }
        }

        private string _alienWeakness;
        public string alienWeakness
        {
            get { return _alienWeakness; }
            set { _alienWeakness = value;
            OnPropertyChanged("alienWeakness");
            }
        }

        private bool _useHighPowerWeapons;
        public bool useHighPowerWeapons
        {
            get { return _useHighPowerWeapons; }
            set
            {
                _useHighPowerWeapons = value;
                OnPropertyChanged("useHighPowerWeapons");
            }
        }
        private bool _useLowPowerWeapons;
        public bool useLowPowerWeapons
        {
            get { return _useLowPowerWeapons; }
            set
            {
                _useLowPowerWeapons = value;
                OnPropertyChanged("useLowPowerWeapons");
            }
        }

        private bool _useHighPowerShields;
        public bool useHighPowerShields
        {
            get { return _useHighPowerShields; }
            set
            {
                _useHighPowerShields = value;
                OnPropertyChanged("useHighPowerShields");
            }
        }
        private bool _useLowPowerShields;
        public bool useLowPowerShields
        {
            get { return _useLowPowerShields; }
            set
            {
                _useLowPowerShields = value;
                OnPropertyChanged("useLowPowerShields");
            }
        }

        private bool _useWeapons;
        public bool useWeapons
        {
            get { return _useWeapons; }
            set
            {
                _useWeapons = value;
                OnPropertyChanged("useWeapons");
            }
        }

        private bool _useShields;
        public bool useShields
        {
            get { return _useShields; }
            set
            {
                _useShields = value;
                OnPropertyChanged("useShields");
            }
        }

        
    }
}
