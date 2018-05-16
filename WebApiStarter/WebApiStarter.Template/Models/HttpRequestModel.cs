using System;
using System.IO;

namespace WebApiStarter.Template.Models
{
    /// <summary>
    /// Represents a model that contain information and data about received HttpRequest.
    /// </summary>
    public class HttpRequestModel
    {
        public string Method { get; set; }

        public string Host { get; set; }

        public string PathBase { get; set; }

        public string Path { get; set; }

        public string QueryString { get; set; }

        public string Scheme { get; set; }

        public string Protocol { get; set; }

        public string Body { get; set; }

        public string Uri
        {
            get
            {
                return
                    string.IsNullOrWhiteSpace(QueryString)
                        ? Scheme + "://" + Host + PathBase + Path
                        : Scheme + "://" + Host + PathBase + Path + QueryString;
            }
        }

        #region Helpers

        public static string ConvertToString(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            try
            {
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    stream = null;
                    var serializedStream = reader.ReadToEnd();

                    return serializedStream;
                }
            }
            finally
            {
                stream?.Dispose();
            }
        }

        #endregion
    }
}