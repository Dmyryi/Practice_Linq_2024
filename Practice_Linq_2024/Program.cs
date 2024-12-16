using Newtonsoft.Json;

namespace Practice_Linq_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"../../../data/results_2010.json";

            List<FootballGame> games = ReadFromFileJson(path);

            int test_count = games.Count();
            Console.WriteLine($"Test value = {test_count}.");    // 13049

            Query1(games);
            Query2(games);
            Query3(games);
            Query4(games);
            Query5(games);
            Query6(games);
            Query7(games);
            Query8(games);
            Query9(games);
            Query10(games);
        }


        // Десеріалізація json-файлу у колекцію List<FootballGame>
        static List<FootballGame> ReadFromFileJson(string path)
        {

            var reader = new StreamReader(path);
            string jsondata = reader.ReadToEnd();

            List<FootballGame> games = JsonConvert.DeserializeObject<List<FootballGame>>(jsondata);


            return games;

        }


        // Запит 1
        static void Query1(List<FootballGame> games)
        {
            //Query 1: Вивести всі матчі, які відбулися в Україні у 2012 році.

            var selectedGames = games.Where(g => g.Country == "Ukraine" && g.Date.Year == 2012);


            // Перевірка
            Console.WriteLine("\n======================== QUERY 1 ========================");

            // див. приклад як має бути виведено:
            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToShortDateString()} {game.Home_team} - {game.Away_team}, Score:{game.Home_score} - {game.Away_score}, Country:{game.Country}");
            }

        }

        // Запит 2
        static void Query2(List<FootballGame> games)
        {
            //Query 2: Вивести Friendly матчі збірної Італії, які вона провела з 2020 року.  

            var selectedGames = games.Where(g => g.Tournament == "Friendly" && (g.Away_team == "Italy" || g.Home_team == "Italy") && g.Date.Year >= 2020);// Корегуємо запит !!!


            // Перевірка
            Console.WriteLine("\n======================== QUERY 2 ========================");

            // див. приклад як має бути виведено:

            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToShortDateString()} {game.Home_team} - {game.Away_team}, Score:{game.Home_score} - {game.Away_score}, Country:{game.Country}");
            }
        }

        // Запит 3
        static void Query3(List<FootballGame> games)
        {
            //Query 3: Вивести всі домашні матчі збірної Франції за 2021 рік, де вона зіграла у нічию.

            var selectedGames = games.Where(g =>g.Country=="France"&& g.Home_team == "France" && g.Date.Year == 2021 && g.Away_score == g.Home_score);// Корегуємо запит !!!


            // Перевірка
            Console.WriteLine("\n======================== QUERY 3 ========================");

            // див. приклад як має бути виведено:

            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToShortDateString()} {game.Home_team} - {game.Away_team}, Score:{game.Home_score} - {game.Away_score}, Country:{game.Country}");
            }
        }

        // Запит 4
        static void Query4(List<FootballGame> games)
        {
            //Query 4: Вивести всі матчі збірної Германії з 2018 року по 2020 рік (включно), в яких вона на виїзді програла.

            var selectedGames = games.Where(g=>g.Away_team == "Germany"&&g.Date.Year >=2018&&g.Date.Year<=2020&&g.Away_score<g.Home_score);   // Корегуємо запит !!!


            // Перевірка
            Console.WriteLine("\n======================== QUERY 4 ========================");

            // див. приклад як має бути виведено:
            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToShortDateString()} {game.Home_team} - {game.Away_team}, Score:{game.Home_score} - {game.Away_score}, Country:{game.Country}");
            }

        }

        // Запит 5
        static void Query5(List<FootballGame> games)
        {
            //Query 5: Вивести всі кваліфікаційні матчі (UEFA Euro qualification), які відбулися у Києві чи у Харкові, а також за умови перемоги української збірної.


            var selectedGames = games.Where(g=>g.Tournament == "UEFA Euro qualification"&&(g.City=="Kyiv"||g.City=="Kharkiv")&&g.Home_team=="Ukraine"&&g.Home_score>g.Away_score);  // Корегуємо запит !!!


            // Перевірка
            Console.WriteLine("\n======================== QUERY 5 ========================");

            // див. приклад як має бути виведено:
            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToShortDateString()} {game.Home_team} - {game.Away_team}, Score:{game.Home_score} - {game.Away_score}, Country:{game.Country}");
            }

        }

        // Запит 6
        static void Query6(List<FootballGame> games)
        {
            //Query 6: Вивести всі матчі останнього чемпіоната світу з футболу (FIFA World Cup), починаючи з чвертьфіналів (тобто останні 8 матчів).
            //Матчі мають відображатися від фіналу до чвертьфіналів (тобто у зворотній послідовності).

            var selectedGames = games.Where(g => g.Tournament == "FIFA World Cup").OrderByDescending(g => g.Date).Take(8);


            // Перевірка
            Console.WriteLine("\n======================== QUERY 6 ========================");

            // див. приклад як має бути виведено:
            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToShortDateString()} {game.Home_team} - {game.Away_team}, Score:{game.Home_score} - {game.Away_score}, Country:{game.Country}");
            }

        }

        // Запит 7
        static void Query7(List<FootballGame> games)
        {
            //Query 7: Вивести перший матч у 2023 році, в якому збірна України виграла.

            FootballGame g = games.FirstOrDefault(g => g.Date.Year == 2023 && g.Away_team=="Ukraine" && (g.Home_score<g.Away_score));


            // Перевірка
            Console.WriteLine("\n======================== QUERY 7 ========================");

            // див. приклад як має бути виведено:

            if(g != null)
                Console.WriteLine($"{g.Date.ToShortDateString()} {g.Home_team} - {g.Away_team}, Score:{g.Home_score} - {g.Away_score}, Country:{g.Country}");
            
        }

        // Запит 8
        static void Query8(List<FootballGame> games)
        {
            //Query 8: Перетворити всі матчі Євро-2012 (UEFA Euro), які відбулися в Україні, на матчі з наступними властивостями:
            // MatchYear - рік матчу, Team1 - назва приймаючої команди, Team2 - назва гостьової команди, Goals - сума всіх голів за матч

            var selectedGames = games.Where(g => g.Tournament == "UEFA Euro" &&g.Country=="Ukraine"&& g.Date.Year == 2012)
                                         .Select(g => new
                                         {
                                             MatchYear = g.Date.Year,
                                             Team1 = $"{g.Home_team}",Team2=$"{g.Away_team}",
                                             Goals = g.Home_score+g.Away_score,
                                         });   // Корегуємо запит !!!

            // Перевірка
            Console.WriteLine("\n======================== QUERY 8 ========================");

            // див. приклад як має бути виведено:

            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.MatchYear} {game.Team1}-{game.Team2}, Goals:{game.Goals}");
            }
        }


        // Запит 9
        static void Query9(List<FootballGame> games)
        {
            //Query 9: Перетворити всі матчі UEFA Nations League у 2023 році на матчі з наступними властивостями:
            // MatchYear - рік матчу, Game - назви обох команд через дефіс (першою - Home_team), Result - результат для першої команди (Win, Loss, Draw)

            var selectedGames = games.Where(g=>g.Tournament=="UEFA Nations League"&& g.Date.Year == 2023).Select(g => new
            {
                MatchYear = g.Date.Year,
                Game = $"{g.Home_team} - {g.Away_team}",
                Result = g.Home_score > g.Away_score ? "Win" :
                g.Home_score < g.Away_score ? "Loss" :
                "Draw"
            });   // Корегуємо запит !!!

            // Перевірка
            Console.WriteLine("\n======================== QUERY 9 ========================");

            // див. приклад як має бути виведено:

            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.MatchYear} {game.Game}, Result for team1:{game.Result}");
            }

        }

        // Запит 10
        static void Query10(List<FootballGame> games)
        {
            //Query 10: Вивести з 5-го по 10-тий (включно) матчі Gold Cup, які відбулися у липні 2023 р.
            var selectedGames = games
                .Where(g => g.Tournament == "Gold Cup" && g.Date.Year == 2023 && g.Date.Month == 7) // Filter by Gold Cup and July 2023
                .Skip(4)  // Skip the first 4 games (0-based index, so this starts at the 5th game)
                .Take(6);
            // Take the next 6 games (which will give us the 5th to 10th matches)

    // Перевірка
    Console.WriteLine("\n======================== QUERY 10 ========================");

            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToShortDateString()} {game.Home_team} - {game.Away_team}, Score: {game.Home_score} - {game.Away_score}, Country: {game.Country}");
            }

        }



    }
}
