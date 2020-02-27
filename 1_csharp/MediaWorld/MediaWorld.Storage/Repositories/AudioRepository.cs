using System.Collections.Generic;
using MediaWorld.Domain.Abstracts;
using MediaWorld.Storage.Adapters;

namespace MediaWorld.Storage.Repositories
{
  public class AudioRepository
  {
    private readonly List<AMedia> _lib;

    public AudioRepository()
    {
      if (_lib == null)
      {
        // _lib = (List<AMedia>) FileAdapter.Read(); // error
        _lib = FileAdapter.Read() as List<AMedia>; // null
      }
    }

    public IEnumerable<AMedia> List()
    {
      return _lib;
    }
  }
}
