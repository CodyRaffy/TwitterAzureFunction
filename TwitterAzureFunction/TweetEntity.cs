using Microsoft.WindowsAzure.Storage.Table;

namespace TwitterAzureFunction
{
    public class TweetEntity : TableEntity
    {
        public TweetEntity() : base()
        {

        }

        public TweetEntity(string partitionKey, string rowKey) : base(partitionKey, rowKey) {

        }

        public long AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorScreenName { get; set; }

        public string FullText { get; set; }
    }
}