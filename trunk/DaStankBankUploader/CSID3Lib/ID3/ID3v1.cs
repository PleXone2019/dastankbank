// Copyright(C) 2002-2009 Hugo Rumayor Montemayor, All rights reserved.
namespace Id3Lib
{
    using System;
    using System.IO;
    using System.Text;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    /// <summary>
    /// Manage ID3v1 frames
    /// </summary>
    /// <remarks>
    /// The <b>ID3v1</b> class can read an ID3v1 frame form a mp3 file returning the <see cref="FrameModel"/> and
    /// write an ID3v1 form the FrameModel to a mp3 file, it will ignore any fields not supported in ID3v1 tag format.
    /// </remarks>
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "ID", Justification = "It is the name of the standard"),
     SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "v")]
    public class ID3v1
    {
        #region Fields
        private readonly byte[] _id3 = { 0x54, 0x41, 0x47 }; //"TAG"
        private readonly string[] _genres =
		{
			"Blues","Classic Rock","Country","Dance","Disco","Funk","Grunge","Hip-Hop","Jazz","Metal",
			"New Age","Oldies","Other","Pop","R&B","Rap","Reggae","Rock","Techno","Industrial",
			"Alternative","Ska","Death Metal","Pranks","Soundtrack","Euro-Techno","Ambient","Trip-Hop",
			"Vocal","Jazz+Funk","Fusion","Trance","Classical","Instrumental","Acid","House",
			"Game","Sound Clip","Gospel","Noise","Alternative Rock","Bass","Soul","Punk","Space",
			"Meditative","Instrumental Pop","Instrumental Rock","Ethnic","Gothic",
			"Darkwave","Techno-Industrial","Electronic","Pop-Folk","Eurodance","Dream",
			"Southern Rock","Comedy","Cult","Gangsta","Top 40","Christian Rap","Pop/Funk","Jungle",
			"Native American","Cabaret","New Wave","Psychadelic","Rave","Showtunes","Trailer","Lo-Fi",
			"Tribal","Acid Punk","Acid Jazz","Polka","Retro","Musical","Rock & Roll","Hard Rock","Folk",
			"Folk/Rock","National Folk","Swing","Fast-Fusion","Bebob","Latin","Revival","Celtic","Bluegrass",
			"Avantgarde","Gothic Rock","Progressive Rock","Psychedelic Rock","Symphonic Rock","Slow Rock",
			"Big Band","Chorus","Easy Listening","Acoustic","Humour","Speech","Chanson","Opera","Chamber Music",
			"Sonata","Symphony","Booty Bass","Primus","Porn Groove","Satire","Slow Jam","Club",
			"Tango","Samba","Folklore","Ballad","Power Ballad","Rhytmic Soul","Freestyle","Duet",
			"Punk Rock","Drum Solo","Acapella","Euro-House","Dance Hall","Goa","Drum & Bass","Club-House",
			"Hardcore","Terror","Indie","BritPop","Negerpunk","Polsk Punk","Beat","Christian Gangsta Rap",
			"Heavy Metal","Black Metal","Crossover","Contemporary Christian",
			"Christian Rock","Merengue","Salsa","Trash Metal","Anime","JPop","SynthPop"
		};

        private string _song;
        private string _artist;
        private string _album;
        private string _year;
        private string _comment;
        private byte _track;
        private byte _genre;
        #endregion

        #region Properties

        /// <summary>
        /// ID3v1 tag length
        /// </summary>
        public static uint TagLength
        {
            get { return 128; }
        }

        /// <summary>
        /// Get the title/songname/content description.
        /// </summary>
        public string Song
        {
            get { return _song; }
        }

        /// <summary>
        /// Get the lead performer/soloist.
        /// </summary>
        public string Artist
        {
            get { return _artist; }
        }

        /// <summary>
        /// Get the production year.
        /// </summary>
        public string Year
        {
            get { return _year; }
        }

        /// <summary>
        /// Get the album title.
        /// </summary>
        public string Album
        {
            get { return _album; }
        }

        /// <summary>
        /// Get the track/artist comment.
        /// </summary>
        public string Comment
        {
            get { return _comment; }
        }

        /// <summary>
        /// Get the track number.
        /// </summary>
        public byte Track
        {
            get { return _track; }
        }

        /// <summary>
        /// Get the track genere.
        /// </summary>
        public byte Genre
        {
            get { return _genre; }
        }
        /// <summary>
        /// Get the track genre.
        /// </summary>
        [Obsolete("This spelling is obsolete; use Genre instead")]
        public byte Genere
        {
            get { return _genre; }
        }

        /// <summary>
        /// Get or set the ID3v2 FrameModel.
        /// </summary>

        [SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily", Justification="The cast is preformed once per frame.")]
        public FrameModel FrameModel
        {
            get
            {
                FrameModel frameModel = new FrameModel();
                FrameText frameText = (FrameText)FrameFactory.Build("TIT2");
                frameText.TextCode = TextCode.Ascii;
                frameText.Text = _song;
                frameModel.Add(frameText);

                frameText = (FrameText)FrameFactory.Build("TPE1");
                frameText.TextCode = TextCode.Ascii;
                frameText.Text = _artist;
                frameModel.Add(frameText);

                frameText = (FrameText)FrameFactory.Build("TALB");
                frameText.TextCode = TextCode.Ascii;
                frameText.Text = _album;
                frameModel.Add(frameText);

                frameText = (FrameText)FrameFactory.Build("TYER");
                frameText.TextCode = TextCode.Ascii;
                frameText.Text = _year;
                frameModel.Add(frameText);

                frameText = (FrameText)FrameFactory.Build("TRCK");
                frameText.TextCode = TextCode.Ascii;
                frameText.Text = _track.ToString(CultureInfo.InvariantCulture);
                frameModel.Add(frameText);

                FrameFullText frameFullText = (FrameFullText)FrameFactory.Build("COMM");
                frameFullText.TextCode = TextCode.Ascii;
                frameFullText.Language = "eng";
                frameFullText.Description = "";
                frameFullText.Text = _comment;
                frameModel.Add(frameFullText);

                if (_genre != 255)
                {
                    // from suggestion in http://sourceforge.net/tracker2/?func=detail&aid=920249&group_id=89188&atid=589317
                    frameText = (FrameText)FrameFactory.Build("TCON");
                    frameText.TextCode = TextCode.Ascii;
                    // "References to the ID3v1 genres can be made by, as first byte, 
                    // enter "(" followed by a number from the genres list (appendix A) 
                    // and ended with a ")" character."
                    frameText.Text = "(" + _genre.ToString(CultureInfo.InvariantCulture) + ")";
                    frameModel.Add(frameText);
                }

                //TODO: Fix this code!!!!!!!!
                frameModel.Header.TagSize = 0;    //TODO: Invalid size, not filled in until write
                frameModel.Header.Version = 3;    // ID3v2.[3].[0]
                frameModel.Header.Revision = 0;
                frameModel.Header.Unsync = false;
                frameModel.Header.Experimental = false;
                frameModel.Header.Footer = false;
                frameModel.Header.ExtendedHeader = false;

                return frameModel;
            }
            set
            {
                Reset();
                foreach (IFrame frame in value)
                {
                    switch (frame.FrameId)
                    {
                        case "TIT2":
                                _song = ((FrameText)frame).Text; ;
                                break;
                        case "TPE1":
                                _artist = ((FrameText)frame).Text;
                                break;
                        case "TALB":
                                _album = ((FrameText)frame).Text;
                                break;
                        case "TYER":
                                _year = ((FrameText)frame).Text;
                                break;
                        case "TRCK":
                                if (!byte.TryParse(((FrameText)frame).Text, out _track))
                                    _track = 0;
                                break;
                        case "TCON":
                                _genre = ParseGenre(((FrameText)frame).Text);
                                break;
                        case "COMM":
                                _comment = ((FrameFullText)frame).Text;
                                break;
                    }
                }
            }
        }

        private byte ParseGenre(string sGenre)
        {
            if (String.IsNullOrEmpty(sGenre))
                return 255;

            // test for a simple number in the field
            byte nGenre;
            if (byte.TryParse(sGenre, out nGenre))
                return nGenre;

            // "References to the ID3v1 genres can be made by, as first byte, 
            // enter "(" followed by a number from the genres list (appendix A) 
            // and ended with a ")" character."
            if (sGenre[0] == '(' && sGenre[1] != '(')
            {
                int close = sGenre.IndexOf(')');
                if (close != -1)
                {
                    string sGNum = sGenre.Substring(1, close - 1);
                    if (byte.TryParse(sGNum, out nGenre))
                        return nGenre;
                }
            }

            // not a number, see if it's one of the predefined genre name strings
            byte index = 0;
            foreach (string name in _genres)
            {
                string trimname = name.Trim();
                if (trimname == sGenre)
                    return index;
                ++index;
            }

            return 12; // "Other"
        }

        #endregion

        #region Constructors
        /// <summary>
        /// ID3v1 tag manager
        /// </summary>
        public ID3v1()
        {
            Reset();
        }
        #endregion

        #region Methods
        private void Reset()
        {
            _song = "";
            _artist = "";
            _album = "";
            _year = "";
            _comment = "";
            _track = 0;
            _genre = 255;
        }

        /// <summary>
        /// Load tag from sream
        /// </summary>
        /// <param name="src">Binary stream to load</param>
        public void Deserialize(Stream stream)
        {
            BinaryReader reader = new BinaryReader(stream);

            // check for ID3v1 tag
            Encoding encoding = Encoding.GetEncoding(1252); // Should be ASCII
            reader.BaseStream.Seek(-128, SeekOrigin.End);

            byte[] idTag = new byte[3];

            // Read the tag identifier
            reader.Read(idTag, 0, 3);
            // Compare the readed tag
            if (Memory.Compare(_id3, idTag, 3) != true)
                throw new TagNotFoundException("ID3v1 tag was not found");

            byte[] tag = new byte[30]; // Allocate ID3 tag

            reader.Read(tag, 0, 30);
            // I had to use Memory.FindByte fuction because the encoding function
            // retrives the 0x00 values and dosen't stop on the first zero. so makes strings with
            // many trailing zeros at the end when converted to XML these are added in binary text.
            int index = Memory.FindByte(tag, 0x00, 0);

            if (index == -1)
            {
                _song = encoding.GetString(tag);
            }
            else
            {
                _song = encoding.GetString(tag, 0, index);
            }
            reader.Read(tag, 0, 30);
            index = Memory.FindByte(tag, 0x00, 0);
            if (index == -1)
            {
                _artist = encoding.GetString(tag);
            }
            else
            {
                _artist = encoding.GetString(tag, 0, index);
            }
            reader.Read(tag, 0, 30);
            index = Memory.FindByte(tag, 0x00, 0);
            if (index == -1)
            {
                _album = encoding.GetString(tag);
            }
            else
            {
                _album = encoding.GetString(tag, 0, index);
            }
            reader.Read(tag, 0, 4);
            if (tag[0] != 0 && tag[1] != 0 && tag[2] != 0 && tag[3] != 0)
            {
                _year = encoding.GetString(tag, 0, 4);
            }
            else
            {
                _year = "";
            }
            reader.Read(tag, 0, 30);
            if (tag[28] == 0) //Track number was stored at position 29 later hack of the original standard.
            {
                _track = tag[29];
                index = Memory.FindByte(tag, 0x00, 0);
                if (index != -1)
                {
                    _comment = encoding.GetString(tag, 0, index);
                }
            }
            else
            {
                _track = 0;
                index = Memory.FindByte(tag, 0x00, 0);
                if (index == -1)
                {
                    _comment = encoding.GetString(tag);
                }
                else
                {
                    _comment = encoding.GetString(tag, 0, index);
                }
            }
            _genre = reader.ReadByte();
        }

        /// <summary>
        /// Save tag from sream
        /// </summary>
        /// <param name="stream">Binary stream to save</param>
        public void Serialize(Stream stream)
        {
            byte[] idTag = new byte[3];

            // open a reader on the underlying stream but don't use 'using'
            // or Dispose will close the underlying stream at the end
            BinaryReader reader = new BinaryReader(stream);

            // check for ID3v1 tag
            reader.BaseStream.Seek(-128, SeekOrigin.End);

            // Read the tag identifier
            reader.Read(idTag, 0, 3);

            // Is there a ID3v1 tag already?
            if (Memory.Compare(_id3, idTag, 3) == true)
            {
                //Found a ID3 tag so we will over write the old tag
                // (and the 'TAG' label too, so WriteAtStreamPosition is clean)
                stream.Seek(-128, SeekOrigin.End);

                WriteAtStreamPosition(stream);
            }
            else
            {
                //Create a new Tag
                long streamPosition = stream.Position;
                stream.Seek(0, SeekOrigin.End);
                //TODO: fix this ugly code, at first make the error visible to the user by some mean,
                // a start can be trhrowing the exception in an inner exception 
                try
                {
                    WriteAtStreamPosition(stream);
                }
                catch
                {
                    // There was an error while creating the tag
                    // Restore the file to the original state, I hope.
                    stream.SetLength(streamPosition);
                }
            }
        }

        /// <summary>
        /// overwrite or append ID3v1 tag at current location in the stream
        /// </summary>
        /// <param name="stream"></param>
        public void WriteAtStreamPosition(Stream stream)
        {
            // open a writer on the underlying stream but don't use 'using'
            // or Dispose will close the underlying stream at the end
            BinaryWriter writer = new BinaryWriter(stream);

            Encoding encoding = Encoding.GetEncoding(1252); // Should be ASCII

            writer.Write(_id3, 0, 3); // Write the ID3 TAG ID: 'TAG'

            byte[] tag = new byte[30];

            if (_song.Length > 30)
            {
                _song = _song.Substring(0, 30);
            }
            encoding.GetBytes(_song, 0, _song.Length, tag, 0);
            writer.Write(tag, 0, 30);
            Memory.Clear(tag, 0, 30);

            if (_artist.Length > 30)
            {
                _artist = _artist.Substring(0, 30);
            }
            encoding.GetBytes(_artist, 0, _artist.Length, tag, 0);
            writer.Write(tag, 0, 30);
            Memory.Clear(tag, 0, 30);

            if (_album.Length > 30)
            {
                _album = _album.Substring(0, 30);
            }
            encoding.GetBytes(_album, 0, _album.Length, tag, 0);
            writer.Write(tag, 0, 30);
            Memory.Clear(tag, 0, 30);

            if (String.IsNullOrEmpty(_year))
            {
                Memory.Clear(tag, 0, 30);
            }
            else
            {
                UInt16 year;
                if (!UInt16.TryParse(_year, out year))
                    _year = "0";

                if (year > 9999)
                    _year = "0";

                encoding.GetBytes(_year, 0, _year.Length, tag, 0);
            }
            writer.Write(tag, 0, 4);
            Memory.Clear(tag, 0, 30);

            if (_comment.Length > 28)
            {
                _comment = _comment.Substring(0, 28);
            }
            encoding.GetBytes(_comment, 0, _comment.Length, tag, 0);

            writer.Write(tag, 0, 28);
            Memory.Clear(tag, 0, 30);
            writer.Write((byte)0);
            writer.Write((byte)_track);
            writer.Write((byte)_genre);
        }
        #endregion
    }
}

