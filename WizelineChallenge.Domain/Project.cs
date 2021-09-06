using System.Text.Json.Serialization;

namespace WizelineChallenge.Domain
{
    // TODO add JsonPropertyName to all properties
    public class Project
    {
        public long Id { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("comment_count")]
        public int CommentCount { get; set; }

        public int Order { get; set; }

        public int Color { get; set; }

        public bool Shared { get; set; }

        [JsonPropertyName("sync_id")]
        public long SyncId { get; set; }

        public bool Favorite { get; set; }

        [JsonPropertyName("parent_id")]
        public long ParentId { get; set; }

        [JsonPropertyName("team_inbox")]
        public bool TeamInbox { get; set; }

        [JsonPropertyName("inbox_project")]
        public bool InboxProject { get; set; }

        public string Url { get; set; }
    }
}
