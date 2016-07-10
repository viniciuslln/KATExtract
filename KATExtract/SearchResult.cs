using Newtonsoft.Json;

namespace KATExtract
{
    public class SearchResult
    {
        string nome;
        string pageUrl;
        string torrentUrl;
        string magneticUrl;
        string size;
        string files;
        string age;
        string seed;
        string leech;
        string user;

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public string PageUrl
        {
            get
            {
                return pageUrl;
            }

            set
            {
                pageUrl = value;
            }
        }

        public string TorrentUrl
        {
            get
            {
                return torrentUrl;
            }

            set
            {
                torrentUrl = value;
            }
        }

        public string MagneticUrl
        {
            get
            {
                return magneticUrl;
            }

            set
            {
                magneticUrl = value;
            }
        }

        public string Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }

        public string Files
        {
            get
            {
                return files;
            }

            set
            {
                files = value;
            }
        }

        public string Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        public string Seed
        {
            get
            {
                return seed;
            }

            set
            {
                seed = value;
            }
        }

        public string Leech
        {
            get
            {
                return leech;
            }

            set
            {
                leech = value;
            }
        }

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

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}
