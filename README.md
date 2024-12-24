# Practice_Linq_2024_Task
ПОСТАНОВКА ЗАДАЧІ

Завдання:
1.	Скопіювати віддалений репозиторій (зробити Fork) за наданим посиланням у власний акаунт на GitHub:
https://github.com/IlonaShevchenko/Practice_Linq_2024
У вашому акаунті на GitHub має з’явитися репозиторій-копія (fork).
2.	Клонувати отриманий fork-репозиторій на власний комп’ютер.
3.	Перевірити, що склонований проєкт запускається і виводить на екран тестове значення 13049 (це кількість всіх матчів збірних, які були проведені з 2010 року включно).
4.	Ознайомитися зі структурою проєкту.
У проєкті наявний код:
•	опис класу FootballGame, який описує футбольний матч (FootballGame.сs);
•	у файлі Program.cs вже реалізований метод ReadFromFileJson(), який десеріалізаціє json-файл (data/results_2010.json) у колекцію List;
•	також у файлі Program.cs повністю реалізований метод Main().
5.	Необхідно реалізувати методи Query1(), Query2(), …, Query10(), а саме: за допомогою мови LINQ реалізувати запити, формулювання яких оформлені у вигляді коментарів до кожного методу. Крім запиту мовою LINQ у кожному методі має бути реалізований вивід на екран результатів запиту (приклад оформлення виводу див. у файлі output.txt).
6.	Після реалізації кожного методу QueryN() необхідно робити commit, вказуючи номер N реалізованого запиту.
7.	Оформити Readme.md файл.  
ВИКОНАННЯ РОБОТИ
Реалізація запитів
Запит 1: Вивести всі матчі, які відбулися в Україні у 2012 році.
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
Запит 2: Вивести Friendly матчі збірної Італії, які вона провела з 2020 року.
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
Запит 3: Вивести всі домашні матчі збірної Франції за 2021 рік, де вона зіграла у нічию.
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
Запит 4: Вивести всі матчі збірної Германії з 2018 року по 2020 рік (включно), в яких вона на виїзді програла.
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
Запит 5: Вивести всі кваліфікаційні матчі (UEFA Euro qualification), які відбулися у Києві чи у Харкові, а також за умови перемоги української збірної.
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
Запит 6: Вивести всі матчі останнього чемпіоната світу з футболу (FIFA World Cup), починаючи з чвертьфіналів (тобто останні 8 матчів). Матчі мають відображатися від фіналу до чвертьфіналів (тобто у зворотній послідовності).
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
Запит 7: Вивести перший матч у 2023 році, в якому збірна України виграла.
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
Запит 8: Перетворити всі матчі Євро-2012 (UEFA Euro), які відбулися в Україні, на матчі з наступними властивостями: MatchYear – рік матчу, Team1 – назва приймаючої команди, Team2 – назва гостьової команди, Goals – сума всіх голів за матч
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

Запит 9: Перетворити всі матчі UEFA Nations League у 2023 році на матчі з наступними властивостями: MatchYear – рік матчу, Game – назви обох команд через дефіс (першою – Home_team), Result – результат для першої команди (Win, Loss, Draw)
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
Запит 10: Вивести з 5-го по 10-тий (включно) матчі Gold Cup, які відбулися у липні 2023 р.
    // Запит 10
    static void Query10(List<FootballGame> games)
    {
        //Query 10: Вивести з 5-го по 10-тий (включно) матчі Gold Cup, які відбулися у липні 2023 р.
        var selectedGames = games
            .Where(g => g.Tournament == "Gold Cup" && g.Date.Year == 2023 && g.Date.Month == 7) 
            .Skip(4) 
            .Take(6);
            

// Перевірка
Console.WriteLine("\n======================== QUERY 10 ========================");

        foreach (var game in selectedGames)
        {
            Console.WriteLine($"{game.Date.ToShortDateString()} {game.Home_team} - {game.Away_team}, Score: {game.Home_score} - {game.Away_score}, Country: {game.Country}");
        }

    }



}
Результат роботи програми
Test value = 13049.
======================== QUERY 1 ========================
09.06.2012 Germany - Portugal, Score: 1 - 0, Country: Ukraine
09.06.2012 Netherlands - Denmark, Score: 0 - 1, Country: Ukraine
11.06.2012 France - England, Score: 1 - 1, Country: Ukraine
11.06.2012 Ukraine - Sweden, Score: 2 - 1, Country: Ukraine
13.06.2012 Denmark - Portugal, Score: 2 - 3, Country: Ukraine
13.06.2012 Netherlands - Germany, Score: 1 - 2, Country: Ukraine
15.06.2012 Sweden - England, Score: 2 - 3, Country: Ukraine
15.06.2012 Ukraine - France, Score: 0 - 2, Country: Ukraine
17.06.2012 Denmark - Germany, Score: 1 - 2, Country: Ukraine
17.06.2012 Portugal - Netherlands, Score: 2 - 1, Country: Ukraine
19.06.2012 Sweden - France, Score: 2 - 0, Country: Ukraine
19.06.2012 Ukraine - England, Score: 0 - 1, Country: Ukraine
23.06.2012 Spain - France, Score: 2 - 0, Country: Ukraine
24.06.2012 England - Italy, Score: 0 - 0, Country: Ukraine
27.06.2012 Portugal - Spain, Score: 0 - 0, Country: Ukraine
01.07.2012 Spain - Italy, Score: 4 - 0, Country: Ukraine
15.08.2012 Ukraine - Czech Republic, Score: 0 - 0, Country: Ukraine
16.10.2012 Ukraine - Montenegro, Score: 0 - 1, Country: Ukraine
======================== QUERY 2 ========================
07.10.2020 Italy - Moldova, Score: 6 - 0, Country: Italy
11.11.2020 Italy - Estonia, Score: 4 - 0, Country: Italy
28.05.2021 Italy - San Marino, Score: 7 - 0, Country: Italy
04.06.2021 Italy - Czech Republic, Score: 4 - 0, Country: Italy
29.03.2022 Turkey - Italy, Score: 2 - 3, Country: Turkey
16.11.2022 Albania - Italy, Score: 1 - 3, Country: Albania
20.11.2022 Austria - Italy, Score: 2 - 0, Country: Austria
======================== QUERY 3 ========================
24.03.2021 France - Ukraine, Score: 1 - 1, Country: France
01.09.2021 France - Bosnia and Herzegovina, Score: 1 - 1, Country: France
======================== QUERY 4 ========================
02.06.2018 Austria - Germany, Score: 2 - 1, Country: Austria
27.06.2018 South Korea - Germany, Score: 2 - 0, Country: Russia
13.10.2018 Netherlands - Germany, Score: 3 - 0, Country: Netherlands
16.10.2018 France - Germany, Score: 2 - 1, Country: France
17.11.2020 Spain - Germany, Score: 6 - 0, Country: Spain
======================== QUERY 5 ========================
11.10.2019 Ukraine - Lithuania, Score: 2 - 0, Country: Ukraine
14.10.2019 Ukraine - Portugal, Score: 2 - 1, Country: Ukraine
======================== QUERY 6 ========================
18.12.2022 Argentina - France, Score: 3 - 3, Country: Qatar
17.12.2022 Croatia - Morocco, Score: 2 - 1, Country: Qatar
14.12.2022 France - Morocco, Score: 2 - 0, Country: Qatar
13.12.2022 Argentina - Croatia, Score: 3 - 0, Country: Qatar
10.12.2022 Morocco - Portugal, Score: 1 - 0, Country: Qatar
10.12.2022 England - France, Score: 1 - 2, Country: Qatar
09.12.2022 Croatia - Brazil, Score: 1 - 1, Country: Qatar
09.12.2022 Netherlands - Argentina, Score: 2 - 2, Country: Qatar
======================== QUERY 7 ========================
16.06.2023 North Macedonia - Ukraine, Score: 2 - 3, Country: North Macedonia
======================== QUERY 8 ========================
2012 Germany - Portugal, Goals: 1
2012 Netherlands - Denmark, Goals: 1
2012 France - England, Goals: 2
2012 Ukraine - Sweden, Goals: 3
2012 Denmark - Portugal, Goals: 5
2012 Netherlands - Germany, Goals: 3
2012 Sweden - England, Goals: 5
2012 Ukraine - France, Goals: 2
2012 Denmark - Germany, Goals: 3
2012 Portugal - Netherlands, Goals: 3
2012 Sweden - France, Goals: 2
2012 Ukraine - England, Goals: 1
2012 Spain - France, Goals: 2
2012 England - Italy, Goals: 0
2012 Portugal - Spain, Goals: 0
2012 Spain - Italy, Goals: 4
======================== QUERY 9 ========================
2023 Netherlands-Croatia, Result for team1: Loss
2023 Spain-Italy, Result for team1: Win
2023 Netherlands-Italy, Result for team1: Loss
2023 Croatia-Spain, Result for team1: Draw
======================== QUERY 10 ========================
02.07.2023 Honduras - Haiti, Score: 2 - 1, Country: United States
02.07.2023 Mexico - Qatar, Score: 0 - 1, Country: United States
04.07.2023 Costa Rica - Martinique, Score: 6 - 4, Country: United States
04.07.2023 Panama - El Salvador, Score: 2 - 2, Country: United States
04.07.2023 Guadeloupe - Guatemala, Score: 2 - 3, Country: United States
04.07.2023 Canada - Cuba, Score: 4 - 2, Country: United States
D:\labs\Practice2\Practice_Linq_2024\Practice_Linq_2024\bin\Debug\net8.0\Practice_Linq_2024.exe (процесс 11956) завершил работу с кодом 0 (0x0).
Посилання на GitHub: https://github.com/Dmyryi/Practice_Linq_2024)
