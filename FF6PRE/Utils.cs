using FF6PRE.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Media;
using static FF6PRE.Enums;

namespace FF6PRE
{
    public static class Utils
    {
        public static Brush redButtonBrush = new SolidColorBrush(Color.FromArgb(255, 200, 80, 80));
        public static Brush greenButtonBrush = new SolidColorBrush(Color.FromArgb(255, 80, 200, 80));

        public static SortedDictionary<int, string> AbilityKeyValues;

        public static bool isActMnemonic(Mnemonic m)
        {
            AiMnemonic am = m.AiMnemon;
            return am == AiMnemonic.Act || am == AiMnemonic.CounterAct || am == AiMnemonic.CounterActReceiveCommand ||
                   am == AiMnemonic.FirstAttackAct || am == AiMnemonic.FinalAttackAct || am == AiMnemonic.CounterActAll;
        }

        public static bool DirectoryExists(string path)
        {
            if(!Directory.Exists(path))
            {
                MessageBox.Show("Directory " + path + " does not exist.", "Missing directory", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        public static bool FileExists(string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("File " + path + " does not exist.", "Missing file", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        public static void showWarning(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static AiScript Clone<AiScript>(this AiScript source)
        {
            var serialized = JsonSerializer.Serialize(source);
            return JsonSerializer.Deserialize<AiScript>(serialized);
        }
    }
}
