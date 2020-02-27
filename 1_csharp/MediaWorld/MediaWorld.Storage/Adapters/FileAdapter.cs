using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MediaWorld.Domain.Abstracts;
using MediaWorld.Domain.Models;

namespace MediaWorld.Storage.Adapters
{
  public class FileAdapter
  {
    private static string path = @"./medialib.xml";
    private static string pathw = @"../medialibw.xml";
    
    public static IEnumerable<AMedia> Read()
    {
      var reader = new StreamReader(path);
      var xml = new XmlSerializer(typeof(List<Song>));
      var la = xml.Deserialize(reader) as List<Song>;

      return la;
    }

    public static void Write()
    {
      var writer = new StreamWriter(pathw);
      var xml = new XmlSerializer(typeof(List<Song>));
      var lib = new List<Song>()
      {
        new Song()
      };

      xml.Serialize(writer, lib);
    }
  }
}
