using school_ad_v24.les1;

// Console.WriteLine(string.Join(',', Sieve_of_eratosthenes.Solve(10)));

// Game_of_life gol = new(40, 25);
// gol.PutGlider();
// gol.Play();

Aoc_game_of_life aocGol = Aoc_game_of_life.CreateFromString("""
L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL
""");
// aocGol.Play();

//FizzBuzz.PrintRange(1, 100);

var array = ArrayUtils.Populate(25, 0.0, 100.0);
int maxi = ArrayUtils.MaxIndex(array);
var max = ArrayUtils.MaxValue(array);

Console.WriteLine(string.Join(',', array));
Console.WriteLine($"max: {maxi}, is: {max}");
