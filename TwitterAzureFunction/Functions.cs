using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace TwitterAzureFunction
{
    public static class Functions
    {
        [FunctionName("ReadTrumpTweets")]
        public static void Run([TimerTrigger("0/15 * * * * *"), Disable()]TimerInfo myTimer, TraceWriter log)
        {
            Auth.SetUserCredentials(
                TwitterConnectionInfo.ConsumerKey,
                TwitterConnectionInfo.ConsumerSecret,
                TwitterConnectionInfo.AccessToken,
                TwitterConnectionInfo.AccessTokenSecret);

            var searchParameter = new SearchTweetsParameters("Trump")
            {
                //GeoCode = new GeoCode(-122.398720, 37.781157, 1, DistanceMeasure.Miles),
                Lang = LanguageFilter.English,
                SearchType = SearchResultType.Recent,
                MaximumNumberOfResults = 15,
                //Until = new DateTime(2015, 06, 02),
                //SinceId = 399616835892781056,
                //MaxId = 405001488843284480,
                //Filters = TweetSearchFilters.Images
            };

            var tweets = Search.SearchTweets(searchParameter);

            foreach (var tweet in tweets)
            {
                log.Info($"Tweet: {tweet.FullText}");
                log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
            }
        }
    }
}