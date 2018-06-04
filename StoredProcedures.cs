using Microsoft.SqlServer.Server;
using System;
using System.Data.SqlTypes;
using System.IO;
using System.Net;

namespace SampleCLR
{
    public partial class StoredProcedures
    {
        [Microsoft.SqlServer.Server.SqlProcedure]
        public static void SampleWSGet(SqlString weburl, out SqlString returnval)
        {
            string url = Convert.ToString(weburl);
            string feedData = string.Empty;

            try
            {
                HttpWebRequest request = null;
                HttpWebResponse response = null;

                Stream stream = null;
                StreamReader streamReader = null;

                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET"; // you have to change to

                //PUT/POST/GET/DELETE based on your scenerio…


                request.ContentLength = 0;
                response = (HttpWebResponse)request.GetResponse();

                stream = response.GetResponseStream();
                streamReader = new StreamReader(stream);

                feedData = streamReader.ReadToEnd();

                response.Close();
                stream.Dispose();

                streamReader.Dispose();

            }

            catch (Exception ex)
            {
                SqlContext.Pipe.Send(ex.Message.ToString());
            }
            returnval = feedData;
        }


        [Microsoft.SqlServer.Server.SqlProcedure]
        public static void SampleWSPost(SqlString weburl, out SqlString returnval)
        {
            string url = Convert.ToString(weburl);
            string feedData = string.Empty;
            try
            {
                HttpWebRequest request = null;
                HttpWebResponse response = null;
                Stream stream = null;
                StreamReader streamReader = null;
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                response = (HttpWebResponse)request.GetResponse();
                stream = response.GetResponseStream();
                streamReader = new StreamReader(stream);
                feedData = streamReader.ReadToEnd();
                response.Close();
                stream.Dispose();
                streamReader.Dispose();
            }
            catch (Exception ex)
            {
                SqlContext.Pipe.Send(ex.Message.ToString());
            }
            returnval = feedData;
        }
    }
}
