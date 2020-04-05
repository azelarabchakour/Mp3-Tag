using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pfeV2._0
{
    class API
    {
        
        public API()
        {

        }

        public File getData(String title, String artist)
        {
            String str;
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString("http://itunes.apple.com/search?term=" + title);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                //return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<File>(json_data) : new File();
                
                var details = JObject.Parse(json_data);
                str = details["results"].ToString();
            }
            
            ////Remove '[' and ']' from json file 
            String[] s1 = str.Split('[');
            String[] s2 = s1[1].Split(']');

            //Split json file and remove "},"
            string[] s3 = s2[0].Split(new string[] { "}," }, StringSplitOptions.RemoveEmptyEntries);

            int j = s3.Length;
            String final = "";
            for (int i = 0; i < j; i++)
            {
                if (i != j - 1)
                    s3[i] += '}'; //Add the missing '}' tht we removed before
                var d = JObject.Parse(s3[i]);
                //MessageBox.Show(d["artistName"].ToString());
                if (d["artistName"].ToString() == artist) // check if the artist in the json is the artist tht we want
                {
                    final = s3[i];
                    break;
                }
            }
            //return final;

            var da = JObject.Parse(final);
            //create a File object with the data from the json  
            File file = new File();
            file.setArtist(da["artistName"].ToString());
            file.setTitle(da["trackName"].ToString());
            file.setAlbum(da["collectionName"].ToString());
            file.setDate(da["releaseDate"].ToString());
            file.setGenre(da["primaryGenreName"].ToString());
            file.setDiskCount(da["discCount"].ToString());
            file.setDiskNbr(da["discNumber"].ToString());
            file.setTrackCount(da["trackCount"].ToString());
            file.setTrackNbr(da["trackNumber"].ToString());
            //return da["artistName"].ToString();
            return file;
        }

    }
}
