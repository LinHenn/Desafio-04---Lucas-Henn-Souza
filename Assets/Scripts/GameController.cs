using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Linq;

public class GameController : MonoBehaviour
{
    public Text telona;

    private InfoPlayer IP;
    public PlayersInfo[] PI;


    private void Start()
    {
        string str1 = File.ReadAllText(Application.dataPath + "/Resources/data8.json");

        var saved = JsonUtility.FromJson<InfoPlayer>(str1);

        IP = saved;
        PI = IP.players;
    }



    public void Q1()    //Feito
    {
        telona.text = "Listar em ordem descendente, os 3 jogadores com maior número de pontos.\n";

        var result = PI.OrderByDescending(n => n.points).Where((n, i) => i <= 2);


        foreach(var res in result)
        {
            telona.text += "\nPoints: " + res.points + "\t\tName: " + res.name;
        }

    }



    public void Q2()    //Feito
    {
        telona.text = "Ordenar por país os jogadores que ainda não criaram heróis\n";

        var result = PI.Where(n => n.heroes.Count == 0).OrderBy(n => n.countryName);


        foreach(var res in result)
        {
            telona.text += "\nCountry: " + res.countryName + "\t\tPlayer: " + res.name;
        }

    }



    public void Q3()    //Feito
    {
        telona.text = "Qual é a classe de herói mais criada e a menos criada.\n";

        List<CharsInfo> CI = new List<CharsInfo>();

        var result = PI.Select(n => n.heroes).Aggregate(CI,(ci, h) =>
        {
            ci.AddRange(h.ToArray());
            return ci;
        }).ToList();


        var result1 = CI.GroupBy(i => i.heroClassIndex)
                .Select(j => new
                {
                    heroclass = j.Key,
                    count = j.Count()
                }).ToList().OrderByDescending(n => n.count).First();
      
        
        telona.text += "\nClasse: " + result1.heroclass + "\t\tContagem: " +result1.count;
        
    }



    public void Q4()    //Feito
    {
        telona.text = "Qual é o país que possue mais jogadores\n";

        var result = PI.GroupBy(n => n.countryName).Select(group => new
        {
            country = group.Key,
            Count = group.Count()
        }).OrderByDescending(x => x.Count).First();


        telona.text += "\nContagem: " + result.Count + "\t\t País: " + result.country;
    }



    public void Q5()    //Feito
    {
        telona.text = "Qual plataforma possue os jogadores com melhores pontos.\n";

        var result = PI.GroupBy(i => i.platformName).Select(j => new
        {
            plat = j.Key,
            Points = j.Average(c => c.points)
        }).OrderByDescending(j => j.Points);

        foreach (var res in result)
        {
            telona.text += "\n\nPlataforma: " + res.plat + "\n\tMedia de pontos: " +res.Points;
        }
    }



    public void Q6() //Feito
    {
        telona.text = "Listar os 10 jogadores com maior total de 'gold'.\n";

        var result = PI.OrderByDescending(n => n.heroes.Sum(m => m.gold)).Take(10);


        foreach (var res in result)
        {
            telona.text += "\nGold: " + res.heroes.Sum(m => m.gold) + "\t\tPlayer: " +res.name;
        }
    }
}
