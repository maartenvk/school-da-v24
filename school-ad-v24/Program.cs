using school_ad_v24.les1;

// Console.WriteLine(string.Join(',', Sieve_of_eratosthenes.Solve(10)));

Game_of_life gol = new(40, 25);
gol.PutGlider();
gol.Play();
