using System.Data;

namespace AdaMedicine.Net.Data.Helpers
{
    /// <summary>
    /// A delegate that gets a data reader parameter
    /// </summary>
    /// <param name="reader">The reader.</param>
    public delegate void ReaderCallBack(IDataReader reader);
}