using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaproKarta
{
    public class ObservationClass
    {
        //public Image _markerImage;
        public String MarkerImageDescriptionTag;
        public DateTime Data;
        public String Literki;
        public String Cyferki;
        public String CyferkiCD;
        public String Ilerazy;
        public List<String> Uwagi;
        public List<String> NoteMarks;
        public List<String> NotesContent;
        public int Col, Row;
        public Point LocationPoint;
        public String UserPictureFileInfo;

        public ObservationClass()
        {
        }

        public ObservationClass(ObservationCtrl obsCtrl)
        {
            MarkerImageDescriptionTag = obsCtrl.MarkerImageDescriptionTag;
            Data=obsCtrl.Date;
            Literki = obsCtrl.Literki;
            Cyferki = obsCtrl.Cyferki;
            CyferkiCD = obsCtrl.CyferkiCD;
            Ilerazy = obsCtrl.IleRazy;
            Uwagi = obsCtrl.Uwagi;
            NoteMarks = obsCtrl.NoteMarks;
            NotesContent = obsCtrl.NotesContent;
            Col = obsCtrl.col;
            Row = obsCtrl.row;
            LocationPoint = obsCtrl.Location;
            this.UserPictureFileInfo=obsCtrl.UserPictureFileInfo;
    }

        public void ObservationClassToCtrl(ObservationCtrl obsCtrl)
        {
            obsCtrl.MarkerImageDescriptionTag = MarkerImageDescriptionTag;
            obsCtrl.Date = Data;
            obsCtrl.Literki = Literki;
            obsCtrl.Cyferki = Cyferki;
            obsCtrl.CyferkiCD = CyferkiCD;
            obsCtrl.IleRazy = Ilerazy;
            obsCtrl.Uwagi = Uwagi;
            obsCtrl.NoteMarks = NoteMarks;
            obsCtrl.NotesContent = NotesContent;
            obsCtrl.row = Row;
            obsCtrl.Location = LocationPoint;
            obsCtrl.UserPictureFileInfo=this.UserPictureFileInfo;
}
    }
}
