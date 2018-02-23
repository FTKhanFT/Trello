using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello
{
    class Json
    {
        public static void Serializer(List<Boards.Board> list,string path)
        {
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, list);
            }
        }
       
        public static List<Boards.Board> Deserializer(List<Boards.Board> boards,string path)
        {
            if (!File.Exists(path))
                return null;
            using (StreamReader file = File.OpenText(@"datas.json"))
            {
                JsonSerializer deserializer = new JsonSerializer();
                boards = (List<Boards.Board>)deserializer.Deserialize(file, typeof(List<Boards.Board>));
                return boards;
            }

        }
    }
}
