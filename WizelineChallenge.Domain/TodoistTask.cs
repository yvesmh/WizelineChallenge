using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WizelineChallenge.Domain
{
    public class TodoistTask
    {
        /// <summary>
        /// Task ID.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Task's project ID (read-only).
        /// </summary>
        [JsonPropertyName("project_id")]
        public long ProjectId { get; set; }

        /// <summary>
        /// ID of section task belongs to.
        /// </summary>
        [JsonPropertyName("section_id")]
        public long SectionId { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("completed")]
        public bool Completed { get; set; }

        [JsonPropertyName("label_ids")]
        public List<long> LabelIds { get; set; }

        [JsonPropertyName("parent_id")]
        public long ParentId { get; set; }

        [JsonPropertyName("order")]
        public int Order { get; set; }

        [JsonPropertyName("priority")]
        public int Priority { get; set; }

        [JsonPropertyName("due")]
        public Due Due { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
        
        [JsonPropertyName("comment_count")]
        public int CommentCount { get; set; }

        [JsonPropertyName("asignee")]
        public int Assignee { get; set; }

        [JsonPropertyName("assigner")]
        public int Assigner { get; set; }
    }
}
