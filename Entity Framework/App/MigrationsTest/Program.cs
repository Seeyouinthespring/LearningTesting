using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Common;
using MigrationsTest.Repository;
using System.Runtime.CompilerServices;
using System.Threading;

namespace MigrationsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContex db = new ApplicationContex())
            {

                //tournaments creation
                //Tournament t1 = new Tournament { name = "England Premier League", prizepool = 1000000000 };
                //Tournament t2 = new Tournament { name = "LaLiga", prizepool = 500000000 };
                //Tournament t3 = new Tournament { name = "Champions League", prizepool = 350000000 };
                //db.Tournaments.AddRange(new List<Tournament> { t1, t2, t3 });
                //db.SaveChanges();

                //добавление команд в лиги
                //Team tm1 = db.Teams.Find(1);
                //Team tm2 = db.Teams.Find(2);

                //tm1.Tournaments.Add(t2);
                //tm1.Tournaments.Add(t3);
                //tm2.Tournaments.Add(t3);
                //tm2.Tournaments.Add(t1);
                //db.SaveChanges();

                //вывод лиг и их команд
                foreach (Tournament t in db.Tournaments.Include(t => t.Teams))
                {
                    Console.WriteLine("В {0} участвуют: ", t.name);
                    foreach (Team tm in t.Teams)
                    {
                        Console.WriteLine("- {0} {1}", tm.title, tm.city);
                    }
                    Console.WriteLine("Призовой фонд = {0}", t.prizepool);
                    Console.WriteLine();
                }


                //Создание объекктов команд
                //Team t1 = new Team { title = "Real", city = "Madrid" };
                //Team t2 = new Team { title = "Chelsea", city = "London" };
                //Team t3 = new Team { title = "Tottenham", city = "London" };
                //db.Teams.Add(t3);
                //db.SaveChanges();
                //Coach coach = new Coach { Id=t3.Id, fullname = "Jose Mourinho", experience = 12 }; //??????????????????????
                //db.Coaches.Add(coach);
                //db.SaveChanges();


                //добавление команд в таблицу
                //db.Teams.Add(t1);
                //db.Teams.Add(t2);
                //db.SaveChanges();

                // создаем два объекта Player
                //Player p1 = new Player { fullname = "Lionel Messi", number=10 , birthdate=DateTime.Parse("1987-06-24") };
                //Player p2 = new Player { fullname = "Ngolo Kante", number = 7, birthdate = DateTime.Parse("1991-07-09") };
                //Player p1 = new Player { fullname = "Sergio Ramos", number=4 , birthdate=DateTime.Parse("1988-02-21") };
                //Player p2 = new Player { fullname = "Kepa Arrizabalaga", number = 1, birthdate = DateTime.Parse("1994-10-03") };
                //Player p1 = new Player { fullname = "Mason Mount", number = 19, birthdate = DateTime.Parse("1998-08-03"), TeamId = 2 }; 
                //Player p2 = new Player { fullname = "Marcos Alonso", number = 3, birthdate = DateTime.Parse("1991-09-23"), TeamId = 2 };
                //Player p3 = new Player { fullname = "Olivier Giroud", number = 18, birthdate = DateTime.Parse("1988-09-30"), TeamId = 2 };
                //Player p4 = new Player { fullname = "Karim Benzema", number = 11, birthdate = DateTime.Parse("1989-11-12"), TeamId = 1 };
                //Player p5 = new Player { fullname = "Isco", number = 22, birthdate = DateTime.Parse("1993-01-03"), TeamId = 1 };
                //Player p6 = new Player { fullname = "Luka Modric", number = 8, birthdate = DateTime.Parse("1990-06-06"), TeamId = 1 };
                //Player p7 = new Player { fullname = "Tibaut Courtois", number = 1, birthdate = DateTime.Parse("1998-12-13"), TeamId = 1 };
                //Player p8 = new Player { fullname = "Kepa Arrizabalag", number = 1, birthdate = DateTime.Parse("1994-10-03") };
                //добавление игроков в таблицу
                //db.Players.Add(p1);
                //db.Players.Add(p2);
                //db.SaveChanges();
                //db.Players.AddRange(new List<Player> { p1, p2, p3, p4, p5, p6, p7 });
                //db.SaveChanges();

                //добавление связи с командой
                //Player p1 = db.Players.FirstOrDefault();
                //p1.TeamId = 1;
                //db.SaveChanges();
                //Player plr = db.Players.Find(2);
                //plr.TeamId = 2;
                //db.SaveChanges();
                //Console.WriteLine($"{plr.number} { plr.fullname} { plr.birthdate}");

                //Player plr = db.Players.Find(3);
                //plr.TeamId = 1;
                //Player plr2 = db.Players.Find(4);
                //plr2.TeamId = 2;
                //db.SaveChanges();

                // добавляем их в бд
                //db.Users.Add(user1);
                //db.Users.Add(user2);
                //db.SaveChanges();
                //Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var players = db.Players.Include(p => p.Team).ToList();
                Console.WriteLine("Список игроков:");
                foreach (Player p in players)
                {
                    if (p.Team != null)
                        Console.WriteLine("{0}.{1} {2} - {3} {4}", p.number, p.fullname, p.birthdate, p.Team.title, p.Team.city);
                }
                Console.WriteLine();

                // получаем объекты из бд и выводим на консоль
                var teams = db.Teams;

                //Team teamone = teams.Find(1);
                //Team teamtwo = teams.Find(2);
                //Coach c1 = new Coach {  fullname = "Zinedin Zedane", experience = 3 };
                //Coach c2 = new Coach {  fullname = "Frank Lampard", experience = 2 };
                //db.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[Coaches] ON");
                //db.Coaches.Add(c1);
                //db.Coaches.Add(c2);
                //db.SaveChanges();
                //db.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[Coaches] OFF");

                Console.WriteLine("Список команд:");
                foreach (Team tm in teams.Include("Coach").ToList())
                {
                    Console.WriteLine("{0}.{1} {2} Тренер- {3} стаж работы - {4} лет", tm.Id, tm.title, tm.city, tm.coach.fullname, tm.coach.experience);
                }
                Console.WriteLine();

                // получаем объекты из бд и выводим на консоль
                //var users = db.Users;
                //Console.WriteLine("Список пользователей:");
                //foreach (User u in users)
                //{
                //    Console.WriteLine("{0}.{1} - {2}", u.Id, u.Name, u.Age);
                //}

                //Игроки первой команды
                var allteams = db.Teams.Include("Players").Include("Coach").ToList();
                foreach (Team t in allteams) { 
                    Console.WriteLine($"{t.title} {t.city}");
                    Console.WriteLine($"Тренер - { t.coach.fullname}");
                    Console.WriteLine($"состав");
                    foreach (var pl in t.Players)
                        Console.WriteLine($"    {pl.fullname} {pl.number}");
                }
                Console.WriteLine();

                //LINQ TESTS
                //var q = db.Teams.Select(p => new
                //{
                //    title = p.title,
                //    city = p.city,
                //    coach = p.coach.fullname
                //});
                //foreach (var p in q)
                //    Console.WriteLine("{0} {1} {2}", p.title, p.city, p.coach);
                //Console.WriteLine();

                //var plrs = db.Players.OrderBy(a => a.number);
                //foreach (var a in plrs)
                //    Console.WriteLine("{0}  {1}  {2}", a.number, a.fullname, a.Team.title);
                //Console.WriteLine();

                //var list = db.Players.Join(db.Teams,
                //    p => p.TeamId,
                //    t => t.Id,
                //    (p, t) => new
                //    {
                //        name = p.fullname,
                //        date = p.birthdate,
                //        title = t.title,
                //        city = t.city
                //    });
                //foreach (var b in list)
                //    Console.WriteLine("{0}  {1}  {2}  {3}", b.name, b.date, b.title, b.city);

                //var mates = from pla in db.Players
                //            group pla by pla.Team.title;
                //foreach (var m in mates)
                //{
                //    Console.WriteLine(m.Key);
                //    foreach (var pla in m)
                //        Console.WriteLine("{0} - {1}", pla.fullname, pla.number);
                //    Console.WriteLine();
                //}

                //IQueryable<Player> plEnum = db.Players;
                //IEnumerable<Player> plEnum = db.Players;
                //var allplayers = plEnum.Where(p => p.number > 5).ToList();
                //foreach (var m in allplayers)
                //    Console.WriteLine("{0} - {1}", m.fullname, m.number);

                //IQueryable<Player> toedit = db.Players.Where(p => p.fullname == "Lionel Messi");
                //List<Player> he = toedit.AsNoTracking().ToList();
                //foreach (var m in he)
                //    Console.WriteLine("{0} - {1}", m.fullname, m.number);

                //Player messi = db.Players.FirstOrDefault();// тут был AsNoTracking() для теста
                //messi.fullname = "Toni Kroos";
                //db.SaveChanges();

                //List<Player> he = db.Players.AsNoTracking().ToList();
                //foreach (var m in he)
                //    Console.WriteLine("{0}__{1}", m.fullname, m.number);

                Console.WriteLine(db.Database.Connection.ConnectionString);

                var leagues = db.Database.SqlQuery<Tournament>("SELECT * FROM Tournaments");
                foreach (var t in leagues)
                    Console.WriteLine("{0}  {1}  {2}",t.Id,t.name,t.prizepool);


                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@name", "%a%");
                var plaaa = db.Database.SqlQuery<Player>("SELECT * FROM Players WHERE fullname LIKE @name", param);
                foreach (var i in plaaa)
                    Console.WriteLine(i.fullname+"  "+i.number);



                Console.WriteLine();
                Console.WriteLine();
                GenericRepository<Player> repo = new GenericRepository<Player>(db);

                //Добавление через репозиторий
                //Player ptot = new Player() {fullname="Son Hyn Min", number=9, birthdate= DateTime.Parse("1996-01-10"), TeamId=3 };
                //repo.Create(ptot);

                //Изменение через репозиторий
                //Player pl1 = db.Players.Find(1);//now has number=10
                //Player pl2 = db.Players.Find(10);//now has number=8
                //pl1.number = 8;
                //pl2.number = 10;
                //repo.Update(pl1);
                //repo.Update(pl2);

                //выборка по условию через репозиторий
                //IEnumerable<Player> list = repo.Get(x => x.number>10);
                //foreach (Player a in list)
                //{
                //    Console.WriteLine($"{a.number} {a.fullname}");
                //}
                //Console.WriteLine("-----------------------------------");

                //тест валидации поля
                //Player y = new Player() { fullname = "Hugo Lloris", number = 190, birthdate = DateTime.Parse("1990-11-21"), TeamId = 3 };
                //repo.Create(y);

                //Вывод через репозиторий с include
                IEnumerable<Player> aaa = repo.GetWithInclude(x => x.Team.city.Equals("London"), p => p.Team);
                foreach (Player a in aaa)
                {
                    Console.WriteLine($"{a.number} {a.fullname} - {a.Team.title} {a.Team.city}");
                }


                //Добавление матча
                GenericRepository<Match> repoMatch = new GenericRepository<Match>(db);
                //Match m1 = new Match()
                //{
                //    start = new DateTime(2020, 7, 20, 18, 30, 0),
                //    arena = "Stamford Bridge",
                //    locationCity = "London",
                //    guestTeamId = 1,
                //    homeTeamId = 2 
                //};
                //Match m2 = new Match()
                //{
                //    start = new DateTime(2020, 7, 28, 21, 00, 0),
                //    arena = "Santiago Bernabeu",
                //    locationCity = "Madrid",
                //    guestTeamId = 2,
                //    homeTeamId = 1
                //};
                //repoMatch.Create(m1);
                //repoMatch.Create(m2);

                //Удаление матчей
                var mtodelete = db.Matches.Where(p => p.id < 3).ToList();
                foreach(Match m in mtodelete) repoMatch.Remove(m);

                var allmatches = db.Matches.Include(g=>g.guestTeam).Include(h=>h.homeTeam).ToList();
                foreach (Match a in allmatches)
                {
                    Console.WriteLine($"{a.locationCity} {a.arena} {a.start}");
                    Console.WriteLine($" {a.homeTeam.title} {a.homeScore} - {a.guestScore} {a.guestTeam.title}");
                }
                Console.WriteLine("____________________________________");

                async Task GetObjectsAsync()
                {
                    using (db)
                    {
                        await db.Players.ForEachAsync(p =>
                        {
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("{0} {1}", p.number, p.fullname);
                        });
                    }
                }

                Task task = GetObjectsAsync();
                task.Wait();
            }
            Console.Read();
        }
    }
}
