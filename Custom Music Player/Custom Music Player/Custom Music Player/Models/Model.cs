using System;
using System.Timers;
using System.Windows.Threading;

namespace Custom_Music_Player.Models  
{  
    public class Model 
    { 
        public string[] Files { get; set; } 
        public int Hour { get; set; }
        public bool IsFirstMusic { get; set; }
        public bool IsPause { set; get; }
        public bool IsVisible { get; set; }
        public int ItemIndex { get; set; }
        public string ListBoxItem { get; set; }
        public int Minute { get; set; }
        public string[] Paths { get; set; }
        public int Repeatt { get; set; }
        public TimeSpan Span { get; set; }
        public int Second { get; set; }
        public DispatcherTimer Timer { get; set; } = new DispatcherTimer();
        public Timer Timer1 { get; set; }
        public double Value { get; set; } = 0;
        public string Value1 { get; set; }
        public bool Returnn { get; set; }

        public double Maximum { get; set; } = 1;
        public bool TimeStartEnable { get; set; }
    } 
}  