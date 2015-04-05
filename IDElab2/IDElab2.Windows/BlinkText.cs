using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace IDElab2
{
    public sealed class BlinkText : Control
    {
        public BlinkText()
        {
            this.DefaultStyleKey = typeof(BlinkText);
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(BlinkText), new PropertyMetadata(0));
        public Brush TextColor
        {
            get { return (Brush)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextColorProperty =
            DependencyProperty.Register("TextColor", typeof(Brush), typeof(BlinkText), new PropertyMetadata(0));

        public bool Blink
        {
            get { return (bool)GetValue(BlinkProperty); }
            set { SetValue(BlinkProperty, value); }
        }

        // Using a DependencyProperty enables animation, styling, binding, etc.
        public static readonly DependencyProperty BlinkProperty =
            DependencyProperty.Register(
                "Blink",                  // The name of the DependencyProperty
                typeof(bool),             // The type of the DependencyProperty
                typeof(BlinkText),       // The type of the owner of the DependencyProperty
                new PropertyMetadata(     // OnBlinkChanged will be called when Blink changes
                    false,                // The default value of the DependencyProperty
                    new PropertyChangedCallback(OnBlinkChanged)
                )
            );

        private DispatcherTimer _timer = null;
        private DispatcherTimer timer
        {
            get
            {
                if (_timer == null)
                {
                    _timer = new DispatcherTimer();
                    _timer.Interval = TimeSpan.FromSeconds(0.5);
                    _timer.Tick += _timer_Tick;
                }

                return _timer;
            }
        }

        private static void OnBlinkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = d as BlinkText;
            if (instance != null)
                if (instance.timer.IsEnabled != instance.Blink)
                    if (instance.Blink)
                        instance.timer.Start();
                    else
                        instance.timer.Stop();
        }


        private void _timer_Tick(object sender, object e)
        {
            DoBlink();
        }
        private void DoBlink()
        {
            this.Opacity = (this.Opacity + 1) % 2;
        }
    }
}
