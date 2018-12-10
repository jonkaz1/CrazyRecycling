using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Controllers.Memento
{
    public class Profile
    {
        private string _playerName = null;
        private readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private readonly string _saveFile;

        public Profile()
        {

        }

        public Profile(string saveFile)
        {
            _saveFile = saveFile;
        }

        public string PlayerName
        {
            get
            {
                if (_playerName == null)
                {
                    if (File.Exists(Path.Combine(path, _saveFile)))
                    {
                        using (StreamReader inputFile = new StreamReader(Path.Combine(path, _saveFile)))
                        {
                            _playerName = inputFile.ReadLine();
                        }
                    }
                    else
                    {
                        PlayerName = "";                        
                    }
                }
                return _playerName;
            }
            set
            {
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, _saveFile), false))
                {
                    outputFile.WriteLine(value);
                }
                _playerName = value;
            }
        }
    }
}
