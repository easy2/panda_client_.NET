using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Panda.Core;
using Panda.Domain;

namespace Panda.Tests.Core
{
    [TestFixture]
    public class JsonSerializerTest
    {
        private readonly JsonSerializer _jsonSerializer = new JsonSerializer();

        [Test]
        public void Can_Deserialize_Encoding()
        {
            const string jsonTest = @"[{""id"":""0b0c52d17067c939920739da662f5167"",""extname"":"".mp4"",""video_id"":""3b64a025902b2073138fe0d632c1eaaf"",""height"":480,""width"":586,""created_at"":""2012/05/28 02:28:52 +0000"",""updated_at"":""2012/05/28 02:30:59 +0000"",""started_encoding_at"":""2012/05/28 02:30:34 +0000"",""video_bitrate"":1919,""audio_bitrate"":null,""audio_channels"":null,""audio_sample_rate"":null,""fps"":60.0,""audio_codec"":null,""video_codec"":""h264"",""encoding_time"":17,""duration"":10000,""file_size"":2407269,""profile_id"":""cb3204d09927d5282b9f688f9fac262d"",""encoding_progress"":100,""status"":""success"",""mime_type"":""video/mp4"",""path"":""0b0c52d17067c939920739da662f5167"",""profile_name"":""h264"",""files"":[""0b0c52d17067c939920739da662f5167.mp4""]},{""id"":""7640eec7028c25222a46c2acc9eb7cb2"",""extname"":"".mp4"",""video_id"":""3b64a025902b2073138fe0d632c1eaaf"",""height"":720,""width"":880,""created_at"":""2012/05/28 02:28:52 +0000"",""updated_at"":""2012/05/28 02:30:37 +0000"",""started_encoding_at"":""2012/05/28 02:28:57 +0000"",""video_bitrate"":4419,""audio_bitrate"":null,""audio_channels"":null,""audio_sample_rate"":null,""fps"":60.0,""audio_codec"":null,""video_codec"":""h264"",""encoding_time"":89,""duration"":10000,""file_size"":5531926,""profile_id"":""2141019354f9e412618bfe1b5495add0"",""encoding_progress"":100,""status"":""success"",""mime_type"":""video/mp4"",""path"":""7640eec7028c25222a46c2acc9eb7cb2"",""profile_name"":""h264.hi"",""files"":[""7640eec7028c25222a46c2acc9eb7cb2.mp4""]}]";

            var result = _jsonSerializer.Deserialize<IList<VideoEncoding>>(jsonTest);
            Assert.IsNotNull(result);
        }

        [Test]
        public void Can_Deserialize_Video()
        {
            const string jsonTest = @"[{
                                  ""id"":""d891d9a45c698d587831466f236c6c6c"",
                                  ""original_filename"":""test.mp4"",
                                  ""extname"":"".mp4"",
                                  ""path"":""d891d9a45c698d587831466f236c6c6c"",
                                  ""video_codec"":""h264"",
                                  ""audio_codec"":""aac"",
                                  ""height"":240,
                                  ""width"":300,
                                  ""fps"":29,
                                  ""duration"":14000,
                                  ""file_size"": 39458349,
                                  ""created_at"":""2009/10/13 19:11:26 +0100"",
                                  ""updated_at"":""2009/10/13 19:11:26 +0100""
                                }]";

            var result = _jsonSerializer.Deserialize<IList<Video>>(jsonTest);
            var firstVideo = result.First();

            Assert.IsNotNull(firstVideo);
            Assert.AreEqual("d891d9a45c698d587831466f236c6c6c", firstVideo.id);
            Assert.AreEqual("test.mp4", firstVideo.original_filename);
            Assert.AreEqual(".mp4", firstVideo.extname);
            Assert.AreEqual("d891d9a45c698d587831466f236c6c6c", firstVideo.path);
            Assert.AreEqual("h264", firstVideo.video_codec);
            Assert.AreEqual("aac", firstVideo.audio_codec);
            Assert.AreEqual(240, firstVideo.height);
            Assert.AreEqual(300, firstVideo.width);
            Assert.AreEqual(29, firstVideo.fps);
            Assert.AreEqual(14000, firstVideo.duration);
            Assert.AreEqual(39458349, firstVideo.file_size);
            Assert.AreEqual(new DateTime(2009, 10, 13, 14, 11, 26), firstVideo.created_at);
            Assert.AreEqual(new DateTime(2009, 10, 13, 14, 11, 26), firstVideo.updated_at);
        }

        [Test]
        public void Can_Deserialize_Video_With_Decimal_FPS()
        {
            const string jsonTest = @"[{
                                  ""id"":""d891d9a45c698d587831466f236c6c6c"",
                                  ""original_filename"":""test.mp4"",
                                  ""extname"":"".mp4"",
                                  ""path"":""d891d9a45c698d587831466f236c6c6c"",
                                  ""video_codec"":""h264"",
                                  ""audio_codec"":""aac"",
                                  ""height"":240,
                                  ""width"":300,
                                  ""fps"":29.7,
                                  ""duration"":14000,
                                  ""file_size"": 39458349,
                                  ""created_at"":""2009/10/13 19:11:26 +0100"",
                                  ""updated_at"":""2009/10/13 19:11:26 +0100""
                                }]";

            var result = _jsonSerializer.Deserialize<IList<Video>>(jsonTest);
            var firstVideo = result.First();

            Assert.IsNotNull(firstVideo);
            Assert.AreEqual(29.7, firstVideo.fps);
        }
    }
}