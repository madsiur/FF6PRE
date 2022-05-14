using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using static FF6PRE.Enums;

namespace FF6PRE
{
    public static class Utils
    {

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

        public static void ShowOperandError(string value, OperandType type)
        {
            if(type == OperandType.INT)
            {
                MessageBox.Show("Operand value " + value + " is not a valid integer.", "Operand value error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (type == OperandType.FLOAT)
            {
                MessageBox.Show("Operand value " + value + " is not a valid float.", "Operand value error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static AiScript Clone<AiScript>(this AiScript source)
        {
            var serialized = JsonSerializer.Serialize(source);
            return JsonSerializer.Deserialize<AiScript>(serialized);
        }
    }
}
