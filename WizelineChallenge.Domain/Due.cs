using System.Text.Json.Serialization;

namespace WizelineChallenge.Domain
{
    public class Due
    {
        /// <summary>
        /// Human defined date in arbitrary format.
        /// </summary>
        // since "String" is a reserved word in C#, name it something else
        [JsonPropertyName("string")]
        public string HumanDefinedDate { get; set; }

        /// <summary>
        /// Date in format YYYY-MM-DD corrected to user's timezone.
        /// </summary>
        [JsonPropertyName("date")]
        public string Date { get; set; }

        /// <summary>
        ///  Whether the task has a recurring due date.
        /// </summary>
        [JsonPropertyName("recurring")]
        public bool Recurring { get; set; }

        /// <summary>
        /// Only returned if exact due time set (i.e. it's not a whole-day task), date and time in RFC3339 format in UTC.
        /// </summary>
        [JsonPropertyName("datetime")]
        public string RfcDateTime { get; set; }

        /// <summary>
        /// Only returned if exact due time set, user's timezone definition either in tzdata-compatible format ("Europe/Berlin") or as a string specifying east of UTC offset as "UTC±HH:MM" (i.e. "UTC-01:00").
        /// </summary>
        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }
    }
}
