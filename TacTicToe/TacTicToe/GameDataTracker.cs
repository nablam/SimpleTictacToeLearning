using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacTicToe
{
    public class GameDataTracker
    {
        HashSet<string> Games; public HashSet<string> Games_0_win;
        public HashSet<string> Games_1_win;
        public HashSet<string> Games_3_win; List<string> _myList; string curGame123456789P; public GameDataTracker()
        {
            Games = new HashSet<string>();
            curGame123456789P = "";
            Games_0_win = new HashSet<string>();
            Games_1_win = new HashSet<string>();
            Games_3_win = new HashSet<string>(); _myList = new List<string>() {
                "15392     0",
                "31296745  1",
                "56931     0",
                "12935     0",
                "1593764   0",
                "9678531   0",
                "95147836  1",
                "593147268 3",
                "51397     0",
                "417539    1",
                "15963278  1",
                "196785324 3",
                "59614     0"
            };
        }
        public void ResetString() { curGame123456789P = ""; }
        public void BuildData(char argc)
        { curGame123456789P += argc; }
        public string GetCurGameString_fortheWin()
        {
            foreach (string str in Games)
            {
                if (str[str.Length - 1] == '0') { Games_0_win.Add(str); }
                else
                if (str[str.Length - 1] == '1') { Games_1_win.Add(str); }
                else
                if (str[str.Length - 1] == '3') { Games_3_win.Add(str); }
            }
            return curGame123456789P;
        }
        public string GetCurGameString()
        {
            return curGame123456789P;
        }
        public void AddCurGame(int argWhoWonEvenOrOdd)
        {
            string paddedString = curGame123456789P.PadRight(10);
            paddedString += argWhoWonEvenOrOdd.ToString();
            if (!Games.Contains(paddedString))
            {
                Games.Add(paddedString);
            }
        }
        public void PrintSetElements()
        {
            int curline = 0;
            foreach (string str in Games)
            {
                curline++;
            }
        }
        string _filename = "entries_0.txt"; public void SaveListToFile()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderPath = Path.Combine(desktopPath, "TEST_dir");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string filePath = Path.Combine(folderPath, _filename);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string item in Games)
                {
                    writer.WriteLine(item);
                }
            }
        }
        public void LoadListFromFile()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderPath = Path.Combine(desktopPath, "TEST_dir");
            string filePath = Path.Combine(folderPath, _filename); if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (string item in _myList)
                    {
                        writer.WriteLine(item);
                    }
                }
            }
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Games.Add(line);
                }
            }
            foreach (string str in Games)
            {
                if (str[str.Length - 1] == '0') { Games_0_win.Add(str); }
                else
                if (str[str.Length - 1] == '1') { Games_1_win.Add(str); }
                else
                if (str[str.Length - 1] == '3') { Games_3_win.Add(str); }
            }
        }
    }
}
