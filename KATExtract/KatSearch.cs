using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATExtract
{
    public class KATParamsExeption : Exception
    {
        public KATParamsExeption(string message) : base(message) { }
    }

    public class KatSearch
    {
        List<List<SearchResult>> listOfListOfResult;
        Params mainParams;
        int currentPage = 1;

        public Params Params
        {
            get
            {
                return mainParams;
            }

            set
            {
                if (listOfListOfResult == null) listOfListOfResult = new List<List<SearchResult>>();
                else listOfListOfResult.Clear();
                currentPage = 1;
                mainParams = value;
            }
        }

        public int CurrentPage
        {
            get
            {
                return currentPage;
            }

            set
            {
                currentPage = value;
            }
        }

        public KatSearch()
        {
            listOfListOfResult = new List<List<SearchResult>>();
        }


        public KatSearch(Params para)
        {
            this.mainParams = para;
            listOfListOfResult = new List<List<SearchResult>>();
        }

        void checkParams()
        {
            if (mainParams == null)
            {
                throw new KATParamsExeption("Params have not yet been defined");
            }
            if (String.IsNullOrEmpty(mainParams.Words) && String.IsNullOrEmpty(mainParams.AnyWords) && String.IsNullOrEmpty(mainParams.SubstractWords))
            {
                throw new KATParamsExeption("Params do not have any words query. Words, AnyWordds or SubstractWords are null or empty");
            }
        }



        /// <summary>
        /// Retrieve new amount of SearchResult asynchronous
        /// </summary>
        /// <exception cref="KATParamsExeption">Throws a exeption if given params are incorrect</exception>
        /// <returns></returns>
        public async Task<List<SearchResult>> getResultsAsync()
        {
          

            checkParams();
            mainParams.page = 1;
            List<SearchResult> currentSearch = await KAT.getResult(mainParams);
            listOfListOfResult.Clear();
            listOfListOfResult.Add(currentSearch);

            return currentSearch;
        }

        /// <summary>
        /// Retrieve next amount of SearchResult
        /// if there is no more pages, this will return first page results
        /// </summary>
        /// <returns></returns>
        public async Task<List<SearchResult>> nextPage()
        {
            if (listOfListOfResult.Count == 0)
                return await getResultsAsync();

            if (currentPage <= mainParams.page)
                return listOfListOfResult.ElementAt(currentPage++);

            checkParams();
            CurrentPage = ++mainParams.page;
            List<SearchResult> currentSearch = KAT.getResult(mainParams).Result;
            listOfListOfResult.Add(currentSearch);
            return currentSearch;
        }

        /// <summary>
        /// Retrieve next amount of SearchResult asynchronous
        /// if there is no more pages, this will return first page results
        /// </summary>
        /// <returns></returns>
        public async Task<List<SearchResult>> nextPageAsync()
        {
            if (currentPage <= mainParams.page)
                return listOfListOfResult.ElementAt(currentPage++);

            checkParams();
            CurrentPage = ++mainParams.page;
            List<SearchResult> currentSearch = await KAT.getResult(mainParams);
            listOfListOfResult.Add(currentSearch);
            return currentSearch;
        }

        /// <summary>
        /// Retrieves the previous page amout result
        /// </summary>
        /// <returns></returns>
        public List<SearchResult> previousPage()
        {
            if (listOfListOfResult.Count == 0)
            {
                throw new System.IndexOutOfRangeException("No previous search result was downloaded");
            }
            if (CurrentPage == 1)
            {
                Debug.WriteLine("Already in first page");
                return listOfListOfResult.ElementAt(0);
            }
            else
            {
                CurrentPage--;
                return listOfListOfResult.ElementAt(CurrentPage-1);
            }
        }




    }
}
