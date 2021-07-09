using System;
using System.Collections.ObjectModel;
using System.Windows; 
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Custom_Music_Player.Commands.TeamApplication.Commands;
using Custom_Music_Player.Models; 
using MaterialDesignThemes.Wpf; 
using Microsoft.Win32;

namespace Custom_Music_Player.ViewModels 
{
    public class Works
    {
        
        #region Commands
    
            private ICommand?[] _commands = new ICommand[13];
            public ICommand OpenFileBut
            {
                set => _commands[0] = value;
                get { return _commands[0] ??= new RelayCommand(OpenFile); }
            }
            public ICommand RepeatBut
            {
                set => _commands[1] = value;
                get { return _commands[1] ??= new RelayCommand(Repeat); }
            }
            public ICommand PreviousBut
            {
                set => _commands[2] = value;
                get { return _commands[2] ??= new RelayCommand(PreviousTitle); }
            }
            public ICommand PlayBut
            {
                set => _commands[3] = value;
                get { return _commands[3] ??= new RelayCommand(Play); }
            }
            public ICommand StopBut
            {
                set => _commands[4] = value;
                get { return _commands[4] ??= new RelayCommand(Stop); }
            }
            public ICommand PauseBut
            {
                set => _commands[5] = value;
                get { return _commands[5] ??= new RelayCommand(Pause); }
            }
            public ICommand NextBut
            {
                set => _commands[6] = value;
                get { return _commands[6] ??= new RelayCommand(NextTitle); }
            }
            public ICommand MuteBut
            {
                set => _commands[7] = value;
                get { return _commands[7] ??= new RelayCommand(Mute); }
            }
            public ICommand SoundBut
            {
                set => _commands[8] = value;
                get { return _commands[8] ??= new RelayCommand(Sound); }
            }
            public ICommand TitleAddBut
            {
                set => _commands[9] = value;
                get { return _commands[9] ??= new RelayCommand(ListAddMusic); }
            }
            public ICommand TitleRemoveBut
            {
                set => _commands[10] = value;
                get { return _commands[10] ??= new RelayCommand(ListDeleteMusic); }
            }
            public ICommand TitleClearBut
            {
                set => _commands[11] = value;
                get { return _commands[11] ??= new RelayCommand(ListClear); }
            }
            
            public ICommand MouseUpBut
            {
                set => _commands[12] = value;
                get { return _commands[12] ??= new RelayCommand(ProgressSliderOnMouseUp); }
            }
        #endregion
        
        public MediaElement Element { get; set; }
        public Model Model { get; set; }
        public ObservableCollection<string> Contents { get; set; }
        public ListBox Box { get; set; }
        public Slider Volume { get; set; }
        public Slider ProgressSlider { get; set; }
        public Button RepeatButton { get; set; }
        
                
        public Works()
        {
            Element = new MediaElement();
            Model = new Model();
            Contents = new ObservableCollection<string>();
            Box = new ListBox();
            Volume = new Slider();
            ProgressSlider = new Slider();
            RepeatButton = new Button();
            
            initializeComponent();
        }


        private void initializeComponent()
        {
            // DispatcherTimer initialize
            Model.Timer.Interval = TimeSpan.FromSeconds(1);
            
            //  Media Element initialize
                Element.Volume = 0.2;
                Element.LoadedBehavior = MediaState.Manual;
                Element.UnloadedBehavior = MediaState.Manual;
                Element.MediaOpened += ElementOnMediaOpened;
                Element.MediaEnded += ElementOnMediaEnded;
            
            // Labels initialize
                Contents.Add(new string("00:00:00"));
                Contents.Add(new string("00:00:00"));
            
            // Buttons initialize
                PackIcon packIcon = new PackIcon { Kind = PackIconKind.RepeatOff, Width = 20, Height = 20 };
                RepeatButton.Content = packIcon;
                RepeatButton.Width = 81;
                RepeatButton.Background = Brushes.Black;
                RepeatButton.Foreground = Brushes.White;
                RepeatButton.Margin = new Thickness(5, 0, 0, 0);
                RepeatButton.BorderThickness = new Thickness(4);
                RepeatButton.BorderBrush = new SolidColorBrush(Colors.DodgerBlue);

             // Sliders initialize
                Volume.Value = 20;
                Volume.Maximum = 100;
                Volume.Minimum = 0;
                Volume.Visibility = Visibility.Hidden;
                Volume.ValueChanged += Volume_OnValueChanged;
                
                ProgressSlider.Value = 0;
                ProgressSlider.Maximum = 1;
                
            // Dispatcher Timer initialize
                Model.Timer.Tick += TimerOnTick;
        }

        private void OpenFile(object sender)
        {

            OpenFileDialog openFile = new OpenFileDialog { Multiselect = true };

            var trueAndFalse = openFile.ShowDialog();

            if (trueAndFalse == true)
            {
                Box.Items.Clear();

                Model.Files = openFile.SafeFileNames;
                Model.Paths = openFile.FileNames;

                for (int i = 0; i < Model.Files.Length; i++)
                {
                    Box.Items.Add((i + 1) + ". " + Model.Files[i]);
                }
            }
        }
        
        private void Play(object sender)
        {
            if (Box == null || Box.Items.Count == 0) return;

            if (Model.Returnn == true)
            {
                Uri newUri = new Uri(Element.Source.ToString());
                Element.Source = newUri;
                Element.LoadedBehavior = MediaState.Play;
                Element.Play();
                Model.Returnn = false;
                ProgressSlider.Value = 0;
                Model.Timer.Start(); Model.TimeStartEnable = true;
            }
            else if (Model.ListBoxItem == null && Box.SelectedIndex <= 0)
            {
                Element.Source = new Uri(Model.Paths[0]);
                Element.LoadedBehavior = MediaState.Play;
                Element.Play();

                Model.ListBoxItem = Box.Items[0].ToString();
                Model.ItemIndex = 0;
                Model.IsFirstMusic = true;
                ProgressSlider.Value = 0;
                Model.Timer.Start(); Model.TimeStartEnable = true; 
            }
            else if (Model.IsPause)
            {
                Element.LoadedBehavior = MediaState.Play;
                Element.Play();
                Model.IsPause = false; 
                Model.Timer.Start(); Model.TimeStartEnable = true; 
                return;
            }
            else if (Model.ListBoxItem != null && Model.ListBoxItem == Box.SelectedItems.ToString())
            {
                Uri newUri = new Uri(Element.Source.ToString());
                Element.Source = newUri;
                Element.LoadedBehavior = MediaState.Play;
                Element.Play();
                Model.Returnn = false;
                ProgressSlider.Value = 0;
                Model.Timer.Start(); Model.TimeStartEnable = true;
            }
            else if (Model.ListBoxItem == Box.SelectedItems.ToString() && Model.ItemIndex == Box.SelectedIndex)
            {
                if (Model.IsPause)
                {
                    Model.IsPause = false;
                    Element.LoadedBehavior = MediaState.Play;
                    Element.Play();
                    Model.Timer.Start(); Model.TimeStartEnable = true;
                    return;
                }
                else { return; }
            }
            else
            {
                Uri newUri = new Uri(Element.Source.ToString());
                Element.Source = newUri;
                Element.LoadedBehavior = MediaState.Play;
                Element.Play();
                Model.Returnn = false;
                ProgressSlider.Value = 0;
                Model.Timer.Start(); Model.TimeStartEnable = true;
            }
            Model.IsPause = false;
        }
        
        private void secondsCalculate()
        {
            int temp = Convert.ToInt32(Model.Value);
            Model.Value = temp;
            
            int  minute = 0, hour = 0;
            
            while (true) 
            {
                if (Model.Value >= 3600)
                {
                    hour++;
                    Model.Value -= 3600;
                }
                else if (Model.Value >= 60)
                {
                    minute++;
                    Model.Value -= 60;
                }
                else break;
            }

            Model.Second = Convert.ToInt32(Model.Value);
            Model.Minute = minute;
            Model.Hour = hour;
        }

        private void Mute(object sender)
        {
            if (Element.IsMuted == false)
            {
                Element.IsMuted = true;
                return;
            }

            Element.IsMuted = false;
        }

        private void Sound(object sender)
        {
            if (Model.IsVisible)
            {
                Model.IsVisible = false;
                Volume.Visibility = Visibility.Hidden;
                return;
            }

            Model.IsVisible = true;
            Volume.Visibility = Visibility.Visible;
        }

        private void Repeat(object sender)
        {
            if (Model.Repeatt == 0)
            {
                PackIcon packIcon = new PackIcon { Kind = PackIconKind.Repeat, Width = 20, Height = 20 };

                RepeatButton.Content = packIcon;
                Model.Repeatt++;
            }
            else if (Model.Repeatt == 1)
            {
                PackIcon packIcon = new PackIcon { Kind = PackIconKind.RepeatOnce, Width = 20, Height = 20 };

                RepeatButton.Content = packIcon;
                Model.Repeatt++;
            }
            else if (Model.Repeatt == 2)
            {
                PackIcon packIcon = new PackIcon { Kind = PackIconKind.RepeatOff, Width = 20, Height = 20 };

                RepeatButton.Content = packIcon;
                Model.Repeatt = 0;
            }
        }

        private void PreviousTitle(object sender)
        {
            string[] path = Element.Source.ToString().Split('/');

            for (int i = 0; i < Model.Paths.Length; i++)
            {
                string[] tempPath = Model.Paths[i].Split('\\');
                if (path[path.Length - 1] == tempPath[tempPath.Length - 1])
                {
                    if (i == 0) { return; }
                    else
                    {
                        Element.Source = new Uri(Model.Paths[i - 1]);
                        Model.Returnn = true;
                        Play(null);
                        return;
                    }
                }
            }
        }

        private void NextTitle(object sender)
        {
            string[] path = Element.Source.ToString().Split('/');

            for (int i = 0; i < Model.Paths.Length; i++)
            {
                string[] tempPath = Model.Paths[i].Split('\\');
                if (path[path.Length - 1] == tempPath[tempPath.Length - 1])
                {
                    if (i == Model.Paths.Length - 1) { return; }
                    else
                    {
                        Element.Source = new Uri(Model.Paths[i + 1]);
                        Model.Returnn = true;
                        Play(null);
                        return;
                    }
                }
            }
        }

        private void Pause(object sender)
        {
            if (Box.Items.Count == 0) return;

            if (!Model.IsPause)
            {
                Element.LoadedBehavior = MediaState.Pause;
                Model.Timer.Stop();
                Model.TimeStartEnable = false;
                Model.IsPause = true;
            }
        }

        private void Stop(object sender)
        {
            if (Box.Items.Count == 0) return;

            if (Element.LoadedBehavior != MediaState.Close)
            {
                Contents[0] = "00:00:00";
                Contents[1] = "00:00:00";
                ProgressSlider.Value = 0;
                Model.TimeStartEnable = false;
                Element.LoadedBehavior = MediaState.Close;
            }
        }

        private void ListAddMusic(object sender)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            var trueAndFalse = openFileDialog.ShowDialog();

            if (trueAndFalse == true)
            {
                if (Box.Items.Count == 0)
                {
                    Model.Files = openFileDialog.SafeFileNames;
                    Model.Paths = openFileDialog.FileNames;
                    
                    
                }
                else
                {
                    string[] newMusicPaths = openFileDialog.FileNames;
                    string[] newMusicFiles = openFileDialog.SafeFileNames;

                    int length = Model.Paths.Length + newMusicPaths.Length;

                    string[] combinePaths = new string[length];
                    string[] combineFiles = new string[length];


                    for (int i = 0; i < Model.Paths.Length; i++)
                    {
                        combinePaths[i] = Model.Paths[i];
                    }

                    for (int i = Model.Paths.Length, j = 0; i < combinePaths.Length; i++, j++)
                    {
                        combinePaths[i] = newMusicPaths[j];
                    }

                    for (int i = 0; i < Model.Files.Length; i++)
                    {
                        combineFiles[i] = Model.Files[i];
                    }

                    for (int i = Model.Files.Length, j = 0; i < combineFiles.Length; i++, j++)
                    {
                        combineFiles[i] = newMusicFiles[j];
                    }

                    Model.Paths = new string[combinePaths.Length];
                    Model.Paths = combinePaths;

                    Model.Files = new string[combineFiles.Length];
                    Model.Files = combineFiles;

                    Box.Items.Clear();
                }

                for (int i = 0; i < Model.Files.Length; i++) { Box.Items.Add((i + 1) + ". " + Model.Files[i]); }
            }
        }

        private void ListDeleteMusic(object sender)
        {
            if (Box.Items.Count == 0 || Box.SelectedItems == null) return;

            int deleteItemIndex = Box.SelectedIndex;
            string deleteItem = "";

            for (int i = 0; i < Model.Paths.Length; i++)
            {
                if (i == deleteItemIndex)
                {
                    deleteItem = Model.Paths[i];
                    break;
                }
            }

            Uri checkUri = new Uri(deleteItem);

            if (Element.Source == checkUri)
            {
                if (deleteItemIndex == (Box.Items.Count - 1)) { PreviousTitle(null); }
                else { NextTitle(null); }
            }

            string[] Files = new string[Model.Files.Length - 1];
            string[] Paths = new string[Model.Paths.Length - 1];

            for (int i = 0, j = 0; i < Model.Files.Length; i++)
            {
                if (i != deleteItemIndex)
                {
                    Files[j] = Model.Files[i];
                    Paths[j] = Model.Paths[i];
                    j++;
                }
            }

            Model.Paths = new string[Paths.Length];
            Model.Files = new string[Files.Length];
            Model.Paths = Paths;
            Model.Files = Files;

            Box.Items.Clear();

            for (int i = 0; i < Model.Files.Length; i++) { Box.Items.Add((i + 1) + ". " + Model.Files[i]); }
        }

        private void ListClear( object sender)
        {
            if (Box.Items.Count == 0) return;

            if (Element.LoadedBehavior == MediaState.Play || Element.LoadedBehavior == MediaState.Pause) { Element.LoadedBehavior = MediaState.Close; }

            Element.Source = null;
            Box.Items.Clear();
        }
        
        private void TimerOnTick(object? sender, EventArgs e)
        {
            ProgressSlider.Value++;
            Model.Value = ProgressSlider.Value;
            
            secondsCalculate();
            
            string second = "", minute = "", hour = "";
            
            if (Model.Second >= 0 && Model.Second <= 9) { second = new string("0" + Model.Second); }
            else { second = new string(Model.Second.ToString()); }
            
            if (Model.Minute >= 0 && Model.Minute <= 9) { minute = new string("0" + Model.Minute); }
            else { minute = new string(Model.Minute.ToString()); }
            
            if (Model.Hour >= 0 && Model.Hour <= 9) { hour = new string("0" + Model.Hour); }
            else { hour = new string(Model.Hour.ToString()); }
            
            Contents[0] = new string($"{hour}:{minute}:{second}");
        }

        private void Volume_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) { Element.Volume = Volume.Value / 100; }
        
        private void ElementOnMediaOpened(object sender, RoutedEventArgs e)
        {
            ProgressSlider.Maximum = Element.NaturalDuration.TimeSpan.TotalSeconds;
            
            if (ProgressSlider.Value == 0) { ProgressSlider.Value = 1; }

            if (Element.HasAudio)
            {
                var tempValue = Element.NaturalDuration.TimeSpan.ToString();

                var temporaryVlaue = tempValue.Split('.');

                Contents[1] = temporaryVlaue[0];
            }
            
            Contents[1] = Element.NaturalDuration.TimeSpan.ToString();
        }
        
        private void ElementOnMediaEnded(object sender, RoutedEventArgs e)
        {
            Model.Timer.Stop();
            Model.TimeStartEnable = false;
            if (Model.Repeatt == 1)
            {
                Model.Value = 0;
                NextTitle(null);
                return;
            }
            else if (Model.Repeatt == 2)
            {
                Model.Value = 0;
                Play(null);
                return;
            }
        }

        private void ProgressSliderOnMouseUp(object sender)
        {
            if (Model.TimeStartEnable == false)
            {
                if (ProgressSlider.Value >= Element.Position.TotalSeconds)
                {
                    ProgressSlider.Value = Element.Position.TotalSeconds;
                    Model.TimeStartEnable = true;
                    Model.Timer.Start();
                }
            }
            Model.Value = ProgressSlider.Value;
            secondsCalculate();

            Element.Position = new TimeSpan(Model.Hour, Model.Minute, Model.Second);
        }
    }
} 