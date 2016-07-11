using System;
using System.Text;

namespace KATExtract
{
    public class Params
    {
        /// <summary>
        /// Order const params
        /// </summary>
        public static class OrderByOptions
        {
            public const string SizeDescendent = @"\?field=size&sorder=desc";
            public const string SizeAscendent = @"\?field=size&sorder=asc";
            public const string FilesCountAscendent = @"\?field=files_count&sorder=asc";
            public const string FilesCountDescendent = @"\?field=files_count&sorder=desc";
            public const string TimesAddedAscendent = @"\?field=time_add&sorder=asc";
            public const string TimesAddedDescendent = @"\?field=time_add&sorder=desc";
            public const string SeddersAscendent = @"\?field=seeders&sorder=asc";
            public const string SeddersDescendent = @"\?field=seeders&sorder=desc";
            public const string LecheersAscendent = @"\?field=leechers&sorder=asc";
            public const string LecheersDescendent = @"\?field=leechers&sorder=desc";
        }
        /// <summary>
        /// Categories const params
        /// </summary>
        public static class Categories
        {
            public const string Any = "0";

            public static class ANIME
            {
                public const string AllAnimeCategory = "anime";
                public const string AnimeMusicVideo = "amv";
                public const string Englishtranslated = "english-translated";
                public const string Movie = "anime-movie";
                public const string OtherAnime = "other-anime";
            }
            public static class APPLICATIONS
            {
                public const string AllApplicationsCategory = "applications";
                public const string Windows = "windows";
                public const string Mac = "mac-software";
                public const string UNIX = "unix";
                public const string Linux = "linux";
                public const string iOS = "ios";
                public const string Android = "android";
                public const string Handheld = "handheld-applications";
                public const string OtherApplications = "other-applications";

            }
            public static class BOOKS
            {
                public const string AllBooksCategory = "books";
                public const string Ebooks = "ebooks";
                public const string Comics = "comics";
                public const string Manga = "manga";
                public const string Magazines = "magazines";
                public const string Textbooks = "textbooks";
                public const string Fiction = "fiction";
                public const string Nonfiction = "non-fiction";
                public const string Audiobooks = "audio-books";
                public const string Academic = "academic";
                public const string Poetry = "poetry";
                public const string Newspapers = "newspapers";
                public const string Programming = "programming";
                public const string Medical = "medical";
                public const string Cooking = "cooking";
                public const string Sport = "sport-books";
                public const string OtherBooks = "other-books";

            }
            public static class GAMES
            {
                public const string AllGamesCategory = "games";
                public const string Windows = "windows-games";
                public const string Mac = "mac-games";
                public const string Linux = "linux-games";
                public const string PS2 = "ps2";
                public const string XBOX360 = "xbox360";
                public const string XboxONE = "xbox-one";
                public const string Wii = "wii";
                public const string Handheld = "handheld-games";
                public const string NDS = "nds";
                public const string PSP = "psp";
                public const string PS3 = "ps3";
                public const string PS4 = "ps4";
                public const string PSVita = "ps-vita";
                public const string iOS = "ios-games";
                public const string Android = "android-games";
                public const string Cheats = "cheats";
                public const string OtherGames = "other-games";

            }
            public static class MOVIES
            {
                public const string AllMoviesCategory = "movies";
                public const string Movies3D = "3d-movies";
                public const string Musicvideos = "music-videos";
                public const string Movieclips = "movie-clips";
                public const string Handheld = "handheld-movies";
                public const string iPad = "ipad-movies";
                public const string HighresMovies = "highres-movies";
                public const string UltraHD = "ultrahd";
                public const string Bollywood = "bollywood";
                public const string Concerts = "concerts";
                public const string DubbedMovies = "dubbed-movies";
                public const string Asian = "asian";
                public const string Animation = "animation";
                public const string Documentary = "documentary";
                public const string AcademicMovies = "academic-movies";
                public const string Sport = "sport-videos";
                public const string Trailer = "trailer";
                public const string OtherMovies = "other-movies";

            }
            public static class MUSIC
            {
                public const string AllMusicCategory = "music";
                public const string Mp3 = "mp3";
                public const string AAC = "aac";
                public const string Lossless = "lossless";
                public const string Transcode = "transcode";
                public const string Soundtrack = "soundtrack";
                public const string RadioShows = "radio-shows";
                public const string Karaoke = "karaoke";
                public const string Classic = "classic";
                public const string OtherMusic = "other-music";

            }
            public static class OTHER
            {
                public const string AllOtherCategory = "other";
                public const string Pictures = "pictures";
                public const string Soundclips = "sound-clips";
                public const string Covers = "covers";
                public const string Wallpapers = "wallpapers";
                public const string Tutorials = "tutorials";
                public const string Subtitles = "subtitles";
                public const string Fonts = "fonts";
                public const string Unsorted = "unsorted";

            }
            public static class TV
            {
                public const string AllTVCategory = "tv";
                public const string OtherTV = "other-tv";

            }
            public static class XXX
            {
                public const string AllXXXCategory = "xxx";
                public const string Video = "xxx-video";
                public const string HDVideo = "xxx-hd-video";
                public const string UltraHD = "xxx-ultrahd";
                public const string Pictures = "xxx-pictures";
                public const string Magazines = "xxx-magazines";
                public const string Books = "xxx-books";
                public const string Hentai = "hentai";
                public const string XXXGames = "xxx-games";
                public const string OtherXXX = "other-xxx";

            }

        }
        /// <summary>
        /// Age / Added at const params
        /// </summary>
        public static class Added
        {
            public const string Lasthour = "hour";
            public const string Last24hours = "24h";
            public const string Lastweek = "week";
            public const string Lastmonth = "month";
            public const string Lastyear = "year";
        }
        /// <summary>
        /// Movie or Tv Language enum
        /// </summary>
        public enum MovieOrTvLanguages
        {
            English = 2,
            Albanian = 42,
            Arabic = 7,
            Basque = 44,
            Bengali = 46,
            Brazilian = 39,
            Bulgarian = 37,
            Cantonese = 45,
            Catalan = 47,
            Chinese = 10,
            Croatian = 34,
            Czech = 32,
            Danish = 26,
            Dutch = 8,
            Filipino = 11,
            Finnish = 31,
            French = 5,
            German = 4,
            Greek = 30,
            Hebrew = 25,
            Hindi = 6,
            Hungarian = 27,
            Italian = 3,
            Japanese = 15,
            Kannada = 49,
            Korean = 16,
            Lithuanian = 43,
            Malayalam = 21,
            Mandarin = 23,
            Nepali = 48,
            Norwegian = 19,
            Persian = 33,
            Polish = 9,
            Portuguese = 17,
            Punjabi = 35,
            Romanian = 18,
            Russian = 12,
            Serbian = 28,
            Slovenian = 36,
            SpanishLatin = 41,
            SpanishSpain = 14,
            Swedish = 20,
            Tamil = 13,
            Telugu = 22,
            Thai = 24,
            Turkish = 29,
            Ukrainian = 40,
            Urdu = 50,
        }
        /// <summary>
        /// Games Platform enum
        /// </summary>
        public enum GamePlatforms
        {
            Android = 4,
            BlackBerry = 7,
            GameCube = 15,
            iPad = 18,
            iPhone = 19,
            iPod = 20,
            Java = 22,
            Linux = 24,
            MAC = 25,
            Nintendo3DS = 31,
            NintendoDS = 33,
            NUONDVD = 35,
            Other = 65,
            PalmOS = 37,
            PC = 38,
            PlayStation2 = 43,
            PlayStation3 = 44,
            PlayStation4 = 66,
            PSP = 45,
            Symbian = 52,
            Wii = 56,
            WiiU = 68,
            WindowsCE = 57,
            WindowsMobile = 58,
            WindowsPhone = 59,
            Xbox = 61,
            Xbox360 = 62,
            XboxOne = 67,
        }

        internal int page = 1;
        string orderBy;
        string words;
        string exactWords;
        string anyWords;
        string substractWords;
        string category;
        string user;
        string minimumSeeds;
        string addedtipe;
        string numberOfFiles;
        string imdbId;
        string tvMazeId;
        string isbn;
        MovieOrTvLanguages? movieTvLanguage;
        bool? familySafetyFilter;
        bool? justVerifedTorrents;
        string tvseason;
        string tvepisode;
        GamePlatforms? gamePlatforms;

        /// <summary>
        /// All these words
        /// Represents the query text to submit
        /// </summary>
        public string Words
        {
            get
            {
                return words;
            }

            set
            {
                words = value;
            }
        }

        /// <summary>
        /// This exact wording or phrase
        /// Represents the query text to submit
        /// </summary>
        public string ExactWords
        {
            get
            {
                return exactWords;
            }

            set
            {
                exactWords = value;
            }
        }

        /// <summary>
        /// Any of these words
        /// Represents the query text to submit
        /// </summary>  
        public string AnyWords
        {
            get
            {
                return anyWords;
            }

            set
            {
                anyWords = value;
            }
        }

        /// <summary>
        /// Subtract specified word
        /// Represents the query text to submit
        /// </summary> 
        public string SubstractWords
        {
            get
            {
                return substractWords;
            }

            set
            {
                substractWords = value;
            }
        }
        /// <summary>
        /// Category Of search
        /// See Param.Categories to get string const
        /// Exemple: Param.Categories.APPLICATIONS.Windows
        /// </summary>
        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }
        /// <summary>
        /// Uploads by certain user
        /// </summary>
        public string User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }

        /// <summary>
        /// Minimal seeders filter
        /// </summary>
        public int MinimumSeeds
        {
            get
            {
                return int.Parse(minimumSeeds);
            }

            set
            {
                minimumSeeds = "" + value;
            }
        }

        /// <summary>
        /// Added at
        /// See Param.Added to get string const
        /// Exemple: Param.Added.LastHour
        /// </summary>
        public string AddedAt
        {
            get
            {
                return addedtipe;
            }

            set
            {
                addedtipe = value;
            }
        }
        /// <summary>
        /// Certain number of files
        /// </summary>
        public int NumberOfFiles
        {
            get
            {
                return int.Parse(numberOfFiles);
            }

            set
            {
                numberOfFiles = "" + value;
            }
        }
        /// <summary>
        /// IMDb id
        /// </summary>
        public string IMDBId
        {
            get
            {
                return IMDBId;
            }

            set
            {
                IMDBId = value;
            }
        }
        /// <summary>
        /// TVMaze id	
        /// </summary>
        public string TVMazeId
        {
            get
            {
                return TVMazeId;
            }

            set
            {
                TVMazeId = value;
            }
        }
        /// <summary>
        /// ISBN (10 or 13)
        /// </summary>
        public string ISBN
        {
            get
            {
                return ISBN;
            }

            set
            {
                ISBN = value;
            }
        }

        /// <summary>
        /// Movie or TV show language	
        /// see Params MovieOrTvLanguages enum
        /// </summary>
        public MovieOrTvLanguages? MovieTvLanguage
        {
            get
            {
                return movieTvLanguage;
            }

            set
            {
                movieTvLanguage = value;
            }
        }
        /// <summary>
        /// Family Safety Filter
        /// This option turns off all the pornographic content on the website
        /// </summary>
        public bool? FamilySafetyFilter
        {
            get
            {
                return FamilySafetyFilter;
            }

            set
            {
                FamilySafetyFilter = value;
            }
        }
        /// <summary>
        /// Show only verified torrents
        /// </summary>
        public bool? JustVerifedTorrents
        {
            get
            {
                return JustVerifedTorrents;
            }

            set
            {
                JustVerifedTorrents = value;
            }
        }
        /// <summary>
        /// For games only
        /// See Param.GamePlatforms to get enum
        /// Exemple: Param.GamePlatforms.Wii 
        /// </summary>
        public GamePlatforms? GamePlatform
        {
            get
            {
                return gamePlatforms;
            }

            set
            {
                gamePlatforms = value;
            }
        }
        /// <summary>
        /// For TV shows only
        /// Certain season
        /// </summary>
        public int Tvseason
        {
            get
            {
                return int.Parse(tvseason);
            }

            set
            {
                tvseason = "" + value;
            }
        }
        /// <summary>
        /// For TV shows only
        /// Certain episode
        /// </summary>
        public int Tvepisode
        {
            get
            {
                return int.Parse(tvepisode);
            }

            set
            {
                tvepisode = "" + value;
            }
        }
        /// <summary>
        /// Order of torrents
        /// See Param.OrderByOptions to get string const
        /// Exemple: OrderByOptions.SeddersAscendent 
        /// </summary>
        public string OrderByOption
        {
            get
            {
                return orderBy;
            }

            set
            {
                orderBy = value;
            }
        }

        public override string ToString()
        {
            //https://kat.cr/usearch/
            //game %20of%20throne s%20
            //"Game" %20 
            //Of %20
            //category:tv %20 
            //user:algumUser %20 
            //seeds:123
            //%20 age:24h %20 
            //files:1 %20
            //imdb:1234567 %20
            //tv:9876543 %20 
            //isbn:1111111 %20 
            //lang_id:17 %20 
            //is_safe:1 %20 
            //verified:1 %20 
            //season:1 %20 
            //episode:3 %20 
            //platform_id:44/
            StringBuilder buider = new StringBuilder();
            buider.Append("https://kat.cr/usearch/");

            if (!String.IsNullOrEmpty(words))
            {
                buider.Append(Words.Replace(" ", "%20"));
                buider.Append("%20");
            }
            if (!String.IsNullOrEmpty(exactWords))
            {
                buider.Append("\"" + exactWords + "\"");
                buider.Append("%20");
            }
            if (!String.IsNullOrEmpty(anyWords))
            {
                buider.Append(anyWords);
                buider.Append("%20");
            }
            if (!String.IsNullOrEmpty(category))
            {
                buider.Append("category%3A" + category);
                buider.Append("%20");
            }
            if (!String.IsNullOrEmpty(user))
            {
                buider.Append("user%3A" + user);
                buider.Append("%20");
            }
            if (!String.IsNullOrEmpty(minimumSeeds))
            {
                buider.Append("seeds%3A" + minimumSeeds);
                buider.Append("%20");
            }
            if (!String.IsNullOrEmpty(addedtipe))
            {
                buider.Append("age%3A" + addedtipe);
                buider.Append("%20");
            }
            if (!String.IsNullOrEmpty(numberOfFiles))
            {
                buider.Append("files%3A" + numberOfFiles);
                buider.Append("%20");
            }
            if (!String.IsNullOrEmpty(imdbId))
            {
                buider.Append("imdb%3A" + imdbId);
                buider.Append("%20");
            }
            if (!String.IsNullOrEmpty(tvMazeId))
            {
                buider.Append("tv%3A" + tvMazeId);
                buider.Append("%20");
            }
            if (!String.IsNullOrEmpty(isbn))
            {
                buider.Append("isbn%3A" + isbn);
                buider.Append("%20");
            }
            if (movieTvLanguage != null)
            {
                buider.Append("lang_id%3A" + (int)movieTvLanguage);
                buider.Append("%20");
            }
            if (familySafetyFilter != null)
            {
                buider.Append("is_safe%3A" + (familySafetyFilter ?? false));
                buider.Append("%20");
            }
            if (justVerifedTorrents != null)
            {
                buider.Append("verified%3A" + (justVerifedTorrents ?? false));
                buider.Append("%20");
            }
            if (!String.IsNullOrEmpty(tvseason))
            {
                buider.Append("season%3A" + tvseason);
                buider.Append("%20");
            }
            if (!String.IsNullOrEmpty(tvepisode))
            {
                buider.Append("episode" + tvepisode);
                buider.Append("%20");
            }
            if (gamePlatforms != null)
            {
                buider.Append("platform_id%3A" + (int)gamePlatforms);
            }

            buider.Append("/" + (page > 0 ? ""+ page : "" ));

            if (!String.IsNullOrEmpty(orderBy))
                buider.Append(orderBy);

            return buider.ToString();
        }
    }
}
