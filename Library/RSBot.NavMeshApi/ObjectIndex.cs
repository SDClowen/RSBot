using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace RSBot.NavMeshApi;

public class ObjectIndex : IEnumerable<ObjectIndexEntry>
{
    private readonly Dictionary<int, ObjectIndexEntry> _objectMap = new Dictionary<int, ObjectIndexEntry>();
    private readonly List<ObjectIndexEntry> _objectList = new List<ObjectIndexEntry>();

    public void Load(Stream stream)
    {
        _objectList.Clear();
        _objectMap.Clear();

        using (var reader = new StreamReader(stream))
        {
            var signature = reader.ReadLine();
            if (signature != "JMXVOBJI1000")
                throw new Exception("Failed to load object index: invalid signature.");

            if (!int.TryParse(reader.ReadLine(), out int objectCount))
                throw new Exception("Failed to load object index: invalid object count format");

            //_objects.EnsureCapacity(objectCount);
            for (int i = 0; i < objectCount; i++)
            {
                var line = reader.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(line))
                    continue;

                var quoteCount = line.Count(c => c == '"');
                if (quoteCount == 1 && !line.EndsWith("\""))
                    line += "\"";

                var regex = "(?<id>\\d{5}) (?<flag>0x[a-fA-F0-9]{8}) \"(?<path>.+?)\"";

                var match = Regex.Match(line, regex);
                if (!int.TryParse(match.Groups["id"].Value, out int objectId))
                    throw new Exception($"Failed to load object index: malformed object id in {line}");

                if (
                    !int.TryParse(
                        match.Groups["flag"].Value.Substring(2),
                        NumberStyles.HexNumber,
                        NumberFormatInfo.InvariantInfo,
                        out int objectFlag
                    )
                )
                    throw new Exception($"Failed to load object index: malformed object flag in {line}");

                var objectPath = match.Groups["path"].Value;
                if (string.IsNullOrEmpty(objectPath))
                    throw new Exception($"Failed to load object index: malformed object path in {line}");

                var index = new ObjectIndexEntry(objectFlag, objectPath);
                _objectList.Add(index);
                _objectMap.Add(objectId, index);
            }
        }
    }

    public IEnumerator<ObjectIndexEntry> GetEnumerator()
    {
        return ((IEnumerable<ObjectIndexEntry>)_objectList).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_objectList).GetEnumerator();
    }

    public ObjectIndexEntry this[int id]
    {
        get
        {
            if (_objectMap.TryGetValue(id, out ObjectIndexEntry value))
                return value;

            return null;
        }
    }
}
