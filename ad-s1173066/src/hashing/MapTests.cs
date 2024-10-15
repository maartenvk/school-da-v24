using NUnit.Framework;


namespace AD.Hashing;

[TestFixture]
public class MapTests
{
    [Test]
    public void Map_Simple_Set()
    {
        IMap<char, int> map = new Map<char, int>();
        map['A'] = 65;
        map['F'] = 70;
        map['G'] = 71;
        map['K'] = 75;
        map['B'] = 66;

        Assert.That(map.Contains('A'), Is.True);
        Assert.That(map.Contains('F'), Is.True);
        Assert.That(map.Contains('G'), Is.True);
        Assert.That(map.Contains('K'), Is.True);
        Assert.That(map.Contains('B'), Is.True);

        Assert.That(map.Contains('Z'), Is.False);
        Assert.That(map.Contains('a'), Is.False);
        Assert.That(map.Contains('b'), Is.False);
    }

    [Test]
    public void Map_Get()
    {
        IMap<char, int> map = new Map<char, int>();
        map['A'] = 65;
        map['F'] = 70;
        map['G'] = 71;
        map['K'] = 75;
        map['B'] = 66;

        Assert.That(map['A'], Is.EqualTo(65));
        Assert.That(map['F'], Is.EqualTo(70));
        Assert.That(map['G'], Is.EqualTo(71));
        Assert.That(map['K'], Is.EqualTo(75));
        Assert.That(map['B'], Is.EqualTo(66));
    }

    [Test]
    public void Map_Resize()
    {
        IMap<char, int> map = new Map<char, int>(initialSize: 5);
        map['A'] = 65;
        map['F'] = 70;
        map['G'] = 71;
        map['K'] = 75;

        Assert.That(map.Capacity(), Is.EqualTo(5));
        Assert.That(map.Count(), Is.EqualTo(4));

        map['B'] = 66; // expects a resize

        Assert.That(map.Capacity(), Is.EqualTo(11)); // next prime
        Assert.That(map.Count(), Is.EqualTo(5));
    }

    [Test]
    public void Map_Big()
    {
        IMap<int, int> map = new Map<int, int>();

        for (int i = 0; i < 101; i++)
        {
            map[i] = i;
        }

        for (int i = 0; i < 101; i++)
        {
            Assert.That(map[i], Is.EqualTo(i));
        }
    }
}
