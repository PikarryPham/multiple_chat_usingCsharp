using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class common
    {
        //size
        public static Int32 buffer = 1024 * 25000;

        public byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            return stream.ToArray();
        }
        public object Deserialize(byte[] data)
        {
            //MemoryStream stream = new MemoryStream(data);
            //BinaryFormatter formatter = new BinaryFormatter();
            //stream.Position = 0;

            //formatter.Deserialize(stream);

            //return formatter.Deserialize(stream);

            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(data, 0, data.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);

            return obj;

        }
    }
}
