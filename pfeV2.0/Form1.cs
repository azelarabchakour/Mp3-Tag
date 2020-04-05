using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mp3Lib;

namespace pfeV2._0
{
    public partial class Form1 : Form
    {
        private File file;
        private File fileUpdated;
        private Mp3File mp3File;
        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
            file = new File();
            //mp3File = new Mp3File(" ");
            controller.openFile();
            file = controller.getFile();
            mp3File = controller.GetMp3File();
            pathLabel.Text = file.getPath();
            
            artistBox.Text = file.getArtist();
            titleBox.Text = file.getTitle();
            albumBox.Text = file.getAlbum();
            dateBox.Text = file.getDate();
            genreBox.Text = file.getGenre();
            diskCountBox.Text = file.getDiskCount();
            diskNbrBox.Text = file.getDiskNbr();
            trackCountBox.Text = file.getTrackCount();
            trackNbrBox.Text = file.getTrackNbr();
        }

        private void fillButton_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
            fileUpdated = new File();
            fileUpdated = controller.getData(file);
            
            pathLabel.Text = fileUpdated.getPath();
            artistBox.Text = fileUpdated.getArtist();
            titleBox.Text = fileUpdated.getTitle();
            albumBox.Text = fileUpdated.getAlbum();
            dateBox.Text = fileUpdated.getDate();
            genreBox.Text = fileUpdated.getGenre();
            diskCountBox.Text = fileUpdated.getDiskCount();
            diskNbrBox.Text = fileUpdated.getDiskNbr();
            trackCountBox.Text = fileUpdated.getTrackCount();
            trackNbrBox.Text = fileUpdated.getTrackNbr();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
            controller.updateFile(fileUpdated, mp3File);
            MessageBox.Show("The file is filled with missing details");
            
        }
    }
}
