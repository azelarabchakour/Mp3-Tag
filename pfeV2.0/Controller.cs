using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mp3Lib;

namespace pfeV2._0
{
    class Controller
    {
        File file;
        //File fileUpdated;
        String fileName;
        Mp3File mp3File;

        public File getFile()
        {
            return this.file;
        }
        public Mp3File GetMp3File()
        {
            return this.mp3File;
        }


        /// <summary>
        /// U open a dialog to choose a file , when u choose it u fill its metadata in the attribut file from this class
        /// </summary>
        public void openFile()
        {
            file = new File();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //only show the audio files
            openFileDialog.Filter = "All Supported Audio | *.mp3; *.wma | MP3s | *.mp3 | WMAs | *.wma";
            //the directory to be displayed when the open file dialog appears first time
            openFileDialog.InitialDirectory = @"C:\";
            //the title of the dialog
            openFileDialog.Title = "Choose The mp3 File";
            //show the dialog
            openFileDialog.ShowDialog();
            //fill the fileName string with the full path of the file selected
            fileName = openFileDialog.FileName;
            mp3File = new Mp3File(fileName);
            file.setPath(fileName);
            file.setArtist(mp3File.TagHandler.Artist);
            file.setTitle(mp3File.TagHandler.Title);
            file.setAlbum(mp3File.TagHandler.Album);
            file.setDate(mp3File.TagHandler.Year);
            file.setGenre(mp3File.TagHandler.Genre);
        }


        
        /// <summary>
        /// U gonna use this methode after filling a File object with shit from api
        /// </summary>
        /// <param name="file"> The file tht u filled with data from API</param>
        /// <param name="mp3File">The metadata of file u wanna modify </param>
        public void updateFile(File file, Mp3File mp3File)
        {
            if(mp3File.TagHandler.Title == "")
            {
                mp3File.TagHandler.Title = file.getTitle();
            }
            if (mp3File.TagHandler.Artist == "")
            {
                mp3File.TagHandler.Artist = file.getArtist();
            }
            if (mp3File.TagHandler.Album == "")
            {
                mp3File.TagHandler.Album = file.getAlbum();
            }
            if (mp3File.TagHandler.Year == "")
            {
                mp3File.TagHandler.Year = file.getDate();
            }
            if (mp3File.TagHandler.Genre == "")
            {
                mp3File.TagHandler.Genre = file.getGenre();
            }
            mp3File.Update();
        }
        /// <summary>
        /// Returns a File object fill with missing data
        /// </summary>
        /// <param name="mp3File"></param>
        /// <returns></returns>
        public File getData(File file)
        {
            File f = new File();
            String title = file.getTitle();
            String artist = file.getArtist();
            if (artist != "" && title != "")
            {
                API sample = new API();
                f = sample.getData(title, artist);
                return f;
            }
            else
            {
                String[] s = getArtistAndTitle(file.getPath());
                s[0] = removeTheLastWhiteSpace(s[0]);
                API sample = new API();
                f = sample.getData(s[1], s[0]);
                return sample.getData(s[1],s[0]) ;
            }
        }
        /// <summary>
        /// Returns a table first case contains artist, the second contains title
        /// </summary>
        /// <param name="str">the full path of </param>
        /// <returns></returns>
        public String[] getArtistAndTitle(String str)
        {
            String[] s;
            String ss;
            s = str.Split(new string[] { @"\" }, StringSplitOptions.RemoveEmptyEntries);
            ss = s[s.Length - 1];
            s = ss.Split('.');
            ss = s[0];
            s = ss.Split('-');
            return s;
        }

        public String removeTheLastWhiteSpace(String str)
        {
            return str.Remove(str.Length - 1);
        }
    }
}
