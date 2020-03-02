using System;
using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Models
{
  public class Book : AAudio
  {
    public delegate void CasingDelegate(string s);

    public void Read(HowToRead r)
    {
      var text = "Read The Book";

      switch(r)
      {
        case HowToRead.Upper:
          Console.WriteLine(text.ToUpperInvariant());
          break;
        
        case HowToRead.Lower:
          Console.WriteLine(text.ToLowerInvariant());
          break;
      }
    }

    public void ReadAction(Action<string> d)
    {
      var text = "read from action";

      d(text);
    }

    public void ReadFunction(Func<string, string> d)
    {
      var text = "read form function";

      d(text);
    }

    public void ReadDelegate(CasingDelegate d)
    {
      var text = "read from delegate";

      d(text);
    }
  }

  public enum HowToRead
  {
    Upper,
    Lower
  }
}
