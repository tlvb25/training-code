using System;
using System.Linq;
using MediaWorld.Domain.Models;
using MediaWorld.Domain.Singletons;
using MediaWorld.Storage;
using MediaWorld.Storage.Adapters;
using MediaWorld.Storage.Repositories;

namespace MediaWorld.Client
{
  internal class Program
  {
    private static readonly AudioRepository _ar = new AudioRepository();

    private static void Main(string[] args)
    {
      PlayBook();
      //PlayAudio();
      //FileAdapter.Write(_ar.List().ToList());
    }

    private static void PlayBook()
    {
      var b = new Book();

      b.Read(HowToRead.Upper);
      b.ReadAction((string s) => { Console.WriteLine(s.ToLowerInvariant()); });
      b.ReadFunction((string s) => { Console.WriteLine(s.ToUpperInvariant()); return string.Empty; });
      b.ReadDelegate((string s) => { Console.WriteLine(s.ToLowerInvariant()); });
    }

    private static void PlayAudio()
    {
      // first step
      // AudioPlayer ap = new AudioPlayer();
      // Console.WriteLine(ap);

      // middle step
      // AudioPlayer.Play();

      // final-ish step
      // var ap = AudioPlayer.GetInstance();

      // the csharp way
      var ap = AudioPlayer.Instance;
      var ac = new AudioRepository();
      var ac2 = new AudioRepositoryGeneric<Song>();
      var ac3 = new AudioRepositoryGeneric<Book>();
      
      // if (ac.Playlist() != null)
      // {
      //   foreach (var item in ac.Playlist())
      //   {
      //     ap.Play(item);
      //   }
      // }

      try
      {
        foreach (var item in ac.List())
        {
          ap.Play(item);
        }
      }
      catch(NullReferenceException err)
      {
        Console.WriteLine("NO Playlist for you");
      }
      catch(IndexOutOfRangeException err)
      {
        Console.WriteLine("NO song for you");
      }
      catch(Exception ex)
      {
        // throw;
        throw new Exception("error", ex);
      }
      finally
      {
        GC.Collect();
      }
    }
  }
}
