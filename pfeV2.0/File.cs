using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pfeV2._0
{
    class File
    {
        private String path;
        private String artist;
        private String title;
        private String album;
        private String date;
        private String genre;
        private String diskCount;
        private String diskNbr;
        private String trackCount;
        private String trackNbr;
        private String picture;

        public File()
        {

        }
        public File(string artist, string title, string album, string date, string genre, 
                    string diskCount, string diskNbr, string trackCount, string trackNbr,string picture)
        {
            this.artist = artist;
            this.title = title;
            this.album = album;
            this.date = date;
            this.genre = genre;
            this.diskCount = diskCount;
            this.diskNbr = diskNbr;
            this.trackCount = trackCount;
            this.trackNbr = trackNbr;
            this.picture = picture;
        }

        public void setArtist(String artist)
        {
            this.artist = artist;
        }
        public void setTitle(String title)
        {
            this.title = title;
        }
        public void setAlbum(String album)
        {
            this.album = album;
        }
        public void setDate(String date)
        {
            this.date = date;
        }
        public void setGenre(String genre)
        {
            this.genre = genre;
        }
        public void setDiskCount(String diskCount)
        {
            this.diskCount = diskCount;
        }
        public void setDiskNbr(String diskNbr)
        {
            this.diskNbr = diskNbr;
        }
        public void setTrackCount(String trackCount)
        {
            this.trackCount = trackCount;
        }
        public void setTrackNbr(String trackNbr)
        {
            this.trackNbr = trackNbr;
        }
        public void setPicture(String picture)
        {
            this.picture = picture;
        }

        public String getTitle()
        {
            return this.title;
        }
        public String getArtist()
        {
            return this.artist;
        }
        public String getAlbum()
        {
            return this.album;
        }
        public String getDate()
        {
            return this.date;
        }
        public String getGenre()
        {
            return this.genre;
        }
        public String getDiskCount()
        {
            return this.diskCount;
        }
        public String getDiskNbr()
        {
            return this.diskNbr;
        }
        public String getTrackCount()
        {
            return this.trackCount;
        }
        public String getTrackNbr()
        {
            return this.trackNbr;
        }
        public String getPicture()
        {
            return this.picture;
        }
        public String getPath()
        {
            return this.path;
        }
        public void setPath(String path)
        {
            this.path = path;
        }

    }
}
