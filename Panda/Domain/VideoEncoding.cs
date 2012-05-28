using System;

namespace Panda.Domain
{
    public class VideoEncoding
    {
        public DateTime? created_at { get; set; }
        public int? duration { get; set; }
        public int? encoding_progress { get; set; }
        public int? encoding_time { get; set; }
        public string extname { get; set; }
        public long? file_size { get; set; }
        public string[] files { get; set; }
        public decimal? fps { get; set; }
        public int? height { get; set; }
        public string id { get; set; }
        public string mime_type { get; set; }
        public string path { get; set; }
        public string profile_id { get; set; }
        public string profile_name { get; set; }
        public DateTime? started_encoding_at { get; set; }
        public string status { get; set; }
        public DateTime? updated_at { get; set; }
        public string video_id { get; set; }
        public int? width { get; set; }

        // these were null during testing
        //   "video_bitrate":null,
        //   "audio_bitrate":null,
        //   "audio_channels":null,
        //   "audio_sample_rate":null,
        //   "audio_codec":null,
        //   "video_codec":null,
    }
}