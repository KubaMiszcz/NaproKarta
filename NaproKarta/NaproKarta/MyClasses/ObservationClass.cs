using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaproKarta
{
	public class ObservationClass
	{
		//pola wazne
		private String _markerDescription;
		private DateTime _date;
		private String _literki;
		private String _literkiCD;
		private String _cyferki;
		private String _cyferkiCD;
		private String _ilerazy;
		private List<String> _uwagi;
		private List<String> _notesContent;
		private List<bool> _isNotesImportant;
		private List<String> _userPictureFileInfoList;
		//private String _userPictureFileInfo;
		public int col, row;

		//ogarnij
		private bool _isPeak;

		//inne pola
		//private readonly List<String> _markerDescriptionsList;
		//private readonly List<Image> _markerImagesList;


		#region properties gettery settery
		public String MarkerDescription
		{
			get { return this._markerDescription; }
			set
			{
				List<String> _markerDescriptionsList = SharedObjects.MarkerDescriptionsList;
				int i = _markerDescriptionsList.IndexOf(value);
				if (i >= 0 && i <= _markerDescriptionsList.Count) //7 znaczkow
				{
					_markerDescription = _markerDescriptionsList.ElementAt(i); //ustawia odpowiedni obrazek
				}
				else
				{
					_markerDescription = "";
				}
			}
		}

		public DateTime Date
		{
			get { return this._date; }
			set
			{
				if (value < SharedObjects.NoDateTime)
				{
					//this._date = DateTime.Parse("1900-01-01");
					this._date = SharedObjects.NoDateTime;
				}
				else
				{
					this._date = value;
				}
			}
		}

		public String Literki
		{
			get { return this._literki; }
			set
			{
				this._literki = value;
			}
		}

		public String LiterkiCD
		{
			get { return this._literkiCD; }
			set
			{
				this._literkiCD = value;
			}
		}

		public String Cyferki
		{
			get { return this._cyferki; }
			set
			{
				this._cyferki = value;
			}
		}
		public String CyferkiCD
		{
			get { return this._cyferkiCD; }
			set
			{
				this._cyferkiCD = value;
			}
		}
		public String IleRazy
		{
			get { return this._ilerazy; }
			set
			{
				this._ilerazy = value;
			}
		}
		public List<String> Uwagi
		{
			get { return this._uwagi; }
			set
			{
				List<String> lstr = new List<String>();
				if (value != null)
				{
					foreach (var str in value)
					{
						if (str.Length > 0) lstr.Add(str.Trim().Substring(0, 1));
						else lstr.Add("");
					}
				}
				else
				{
					lstr = new List<string>() { "", "", "" };
				}
				this._uwagi = lstr;
			}
		}

		public List<String> NotesContent
		{
			get { return this._notesContent; }
			set
			{
				List<String> lstr = new List<String>();
				if (value != null)
				{
					foreach (var VARIABLE in value)
					{
						lstr.Add(VARIABLE);
					}
				}
				else
				{
					lstr = new List<string>() { "", "", "" };
				}
				this._notesContent = lstr;
			}
		}

		public List<bool> IsNotesImportant
		{
			get { return this._isNotesImportant; }
			set
			{
				List<bool> lbool = new List<bool>();
				if (value != null)
				{
					foreach (var VARIABLE in value)
					{
						lbool.Add(VARIABLE);
					}
				}
				else
				{
					lbool = new List<bool>() {false,false,false};
				}
				this._isNotesImportant = lbool;
			}
		}

		public List<String> UserPicturesFileInfoList
		{
			get { return _userPictureFileInfoList;}
			set
			{
					List<String> lstr = new List<String>();
					if (value != null)
					{
						foreach (String VARIABLE in value)
						{
							lstr.Add(VARIABLE);
						}
					}
					_userPictureFileInfoList = lstr;
			}
		}
		#endregion properties gettery settery

		/// <summary>
		/// KONSTRUKTOR
		/// </summary>
		public ObservationClass()
		{
			_markerDescription = "";
			_date = SharedObjects.NoDateTime;
			_literki = "";
			_literkiCD = "";
			_cyferki = "";
			_cyferkiCD = "";
			_ilerazy = "";
			_uwagi = new List<string>() { "", "", "" };
			_notesContent = new List<string>() { "", "", "" }; 
			_isNotesImportant = new List<bool>() { false, false, false };
			_userPictureFileInfoList=new List<String>();
		}

		public void ClearObservationData()
		{

		}

	}
}
