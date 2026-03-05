// Must install NuGet package NAudio.Midi
// Instuments are 0 - 127
// Volume is also 0 - 127

using NAudio.Midi;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Synthesizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MidiKeyboard _myKeyboard = new MidiKeyboard();
        private bool[] IsDown = new bool[128];
        private int lastNote = 0;
        private int octave = 0;

        public MainWindow()
        {
            InitializeComponent();
            BuildInstrumentMenu();
        }

        private async void Note_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag != null)
            {
                if (int.TryParse(btn.Tag.ToString(), out int note))
                {
                    await _myKeyboard.PlayNote(note, 500);
                }
            }
        }

        private void Instrument_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem item && item.Tag != null)
            {
                if (int.TryParse(item.Tag.ToString(), out int instrumentId))
                {
                    _myKeyboard.ChangeInstrument(instrumentId);
                }

                // Optional: Update the window title so the user knows what they're playing
                this.Title = $"Synthesizer: {item.Header}";
            }
        }

        private void BuildInstrumentMenu()
        {
            string[] _categories = {
                "Piano", "Chromatic Percussion", "Organ", "Guitar",
                "Bass", "Strings", "Ensemble", "Brass",
                "Reed", "Pipe", "Synth Lead", "Synth Pad",
                "Synth Effects", "Ethnic", "Percussive", "Sound Effects"
            };

            string[] _instruments =
            {
                "Acoustic Grand",
                "Bright Acoustic",
                "Electric Grand",
                "Honky-Tonk",
                "Electric Piano 1",
                "Electric Piano 2",
                "Harpsichord",
                "Clavinet",
                "Celesta",
                "Glockenspiel",
                "Music Box",
                "Vibraphone",
                "Marimba",
                "Xylophone",
                "Tubular Bells",
                "Dulcimer",
                "Drawbar Organ",
                "Percussive Organ",
                "Rock Organ",
                "Church Organ",
                "Reed Organ",
                "Accoridan",
                "Harmonica",
                "Tango Accordian",
                "Nylon String Guitar",
                "Steel String Guitar",
                "Electric Jazz Guitar",
                "Electric Clean Guitar",
                "Electric Muted Guitar",
                "Overdriven Guitar",
                "Distortion Guitar",
                "Guitar Harmonics",
                "Acoustic Bass",
                "Electric Bass (finger)",
                "Electric Bass (pick)",
                "Fretless Bass",
                "Slap Bass 1",
                "Slap Bass 2",
                "Synth Bass 1",
                "Synth Bass 2",
                "Violin",
                "Viola",
                "Cello",
                "Contrabass",
                "Tremolo Strings",
                "Pizzicato Strings",
                "Orchestral Strings",
                "Timpani",
                "String Ensemble 1",
                "String Ensemble 2",
                "SynthStrings 1",
                "SynthStrings 2",
                "Choir Aahs",
                "Voice Oohs",
                "Synth Voice",
                "Orchestra Hit",
                "Trumpet",
                "Trombone",
                "Tuba",
                "Muted Trumpet",
                "French Horn",
                "Brass Section",
                "SynthBrass 1",
                "SynthBrass 2",
                "Soprano Sax",
                "Alto Sax",
                "Tenor Sax",
                "Baritone Sax",
                "Oboe",
                "English Horn",
                "Bassoon",
                "Clarinet",
                "Piccolo",
                "Flute",
                "Recorder",
                "Pan Flute",
                "Blown Bottle",
                "Skakuhachi",
                "Whistle",
                "Ocarina",
                "Square Wave",
                "Saw Wave",
                "Syn. Calliope",
                "Chiffer Lead",
                "Charang",
                "Solo Vox",
                "5th Saw Wave",
                "Bass & Lead",
                "Fantasia",
                "Warm Pad",
                "Polysynth",
                "Space Voice",
                "Bowed Glass",
                "Metal Pad",
                "Halo Pad",
                "Sweep Pad",
                "Ice Rain",
                "Soundtrack",
                "Crystal",
                "Atmosphere",
                "Brightness",
                "Goblin",
                "Echo Drops",
                "Star Theme",
                "Sitar",
                "Banjo",
                "Shamisen",
                "Koto",
                "Kalimba",
                "Bagpipe",
                "Fiddle",
                "Shanai",
                "Tinkle Bell",
                "Agogo",
                "Steel Drums",
                "Woodblock",
                "Taiko Drum",
                "Melodic Tom",
                "Synth Drum",
                "Reverse Cymbal",
                "Guitar Fret Noise",
                "Breath Noise",
                "Seashore",
                "Bird Tweet",
                "Telephone Ring",
                "Helicopter",
                "Applause",
                "Gunshot"
            };

            for (int i = 0; i < _categories.Length; i++)
            {
                // Create the Category (e.g., "Piano")
                MenuItem categoryItem = new MenuItem { Header = _categories[i] };

                // Add 8 instruments to this category
                for (int j = 0; j < 8; j++)
                {
                    int midiIndex = (i * 8) + j;

                    MenuItem instrumentItem = new MenuItem
                    {
                        Header = _instruments[midiIndex],
                        Tag = midiIndex
                    };

                    instrumentItem.Click += Instrument_Click;
                    categoryItem.Items.Add(instrumentItem);
                }

                InstrumentsMenu.Items.Add(categoryItem);
            }
        }

        private async void PianoWindow_KeyDown(object sender, KeyEventArgs e)
        {
            int note = 0;
            switch (e.Key)
            {
                case Key.Q: note = 48; break;
                case Key.D2: note = 49; break;
                case Key.W: note = 50; break;
                case Key.D3: note = 51; break;
                case Key.E: note = 52; break;
                case Key.R: note = 53; break;
                case Key.D5: note = 54; break;
                case Key.T: note = 55; break;
                case Key.D6: note = 56; break;
                case Key.Y: note = 57; break;
                case Key.D7: note = 59; break;
                case Key.U: note = 59; break;
                case Key.I: note = 60; break;
                case Key.Z: note = 60; break;
                case Key.S: note = 61; break;
                case Key.X: note = 62; break;
                case Key.D: note = 63; break;
                case Key.C: note = 64; break;
                case Key.V: note = 65; break;
                case Key.G: note = 66; break;
                case Key.B: note = 67; break;
                case Key.H: note = 68; break;
                case Key.N: note = 69; break;
                case Key.J: note = 70; break;
                case Key.M: note = 71; break;
                case Key.OemComma: note = 72; break;
            }
            if (note > 0) note += octave * 12;

            if (!IsDown[note] && note > 0)
            {
                await _myKeyboard.NoteDown(note);
                IsDown[note] = true;
                Debug.WriteLine($"note down = {note}");
            }
        }

        private async void PianoWindow_KeyUp(object sender, KeyEventArgs e)
        {
            int note = 0;
            switch (e.Key)
            {
                case Key.Q: note = 48; break;
                case Key.D2: note = 49; break;
                case Key.W: note = 50; break;
                case Key.D3: note = 51; break;
                case Key.E: note = 52; break;
                case Key.R: note = 53; break;
                case Key.D5: note = 54; break;
                case Key.T: note = 55; break;
                case Key.D6: note = 56; break;
                case Key.Y: note = 57; break;
                case Key.D7: note = 59; break;
                case Key.U: note = 59; break;
                case Key.I: note = 60; break;
                case Key.Z: note = 60; break;
                case Key.S: note = 61; break;
                case Key.X: note = 62; break;
                case Key.D: note = 63; break;
                case Key.C: note = 64; break;
                case Key.V: note = 65; break;
                case Key.G: note = 66; break;
                case Key.B: note = 67; break;
                case Key.H: note = 68; break;
                case Key.N: note = 69; break;
                case Key.J: note = 70; break;
                case Key.M: note = 71; break;
                case Key.OemComma: note = 72; break;
            }

            if (note > 0)
            {
                note += octave * 12;
                await _myKeyboard.NoteUp(note);
                IsDown[note] = false;
                Debug.WriteLine($"note up = {note}");
            }
        }

        private async void NoteDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button btn && btn.Tag != null)
            {
                if (int.TryParse(btn.Tag.ToString(), out int note) && !IsDown[note])
                {
                    note += octave * 12;
                    await _myKeyboard.NoteDown(note);
                    lastNote = note;
                    Debug.WriteLine($"Button Mouse Down called. Note={lastNote}");
                    IsDown[note] = true;
                    Mouse.Capture(this);
                }
            }
        }

        private async void NoteUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine($"Button Mouse Up called. Note={lastNote}");
            if (sender is Button btn && btn.Tag != null)
            {
                if (int.TryParse(btn.Tag.ToString(), out int note))
                {
                    await _myKeyboard.NoteUp(lastNote);
                    //lastNote = 0;
                    IsDown[lastNote] = false;
                    Mouse.Capture(null);  // releases capture
                }
            }
        }

        private async void PianoWindow_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine($"Window Mouse Up called. Note={lastNote}");
            await _myKeyboard.NoteUp(lastNote);
            //lastNote = 0;
            IsDown[lastNote] = false;
            Mouse.Capture(null);  // releases capture
        }

        private void Lower_Click(object sender, RoutedEventArgs e)
        {
            if (octave > -3) octave--;
            LeftC.Text = $"C{octave + 3}";
            MiddleC.Text = $"C{octave + 4}";
            RightC.Text = $"C{octave + 5}";
        }

        private void Higher_Click(object sender, RoutedEventArgs e)
        {
            if (octave < 4) octave++;
            LeftC.Text = $"C{octave + 3}";
            MiddleC.Text = $"C{octave + 4}";
            RightC.Text = $"C{octave + 5}";
        }
    }
}