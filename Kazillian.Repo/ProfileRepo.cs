using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j;
using Neo4jClient;
using Kazillian.Model;

namespace Kazillian.Repo
{
    public class ProfileRepo
    {
        private const string GraphUrl = "http://localhost:7474/db/data";
        public SalesPerson GetSalesperson(string username)
        {
            var Client = new GraphClient(new Uri(GraphUrl), "neo4j", "password");
            Client.Connect();
            var Result = Client.Cypher
                .Match("(skill:Skill)<-[:HAS_SKILL]-(salesperson:SalesPerson)-[:SPEAKS]-(language:Language)") 
                .Where((SalesPerson salesperson) => salesperson.Username == username) 
                .Return((salesperson, language, skill) => new { SalesPerson = salesperson.As<SalesPerson>(), Languages = language.CollectAs<Language>(), Skills = skill.CollectAs<Skill>()  }  ).Results.FirstOrDefault();

            var LanguageList = Result.Languages.Select(x => x.Name);
            Result.SalesPerson.Languages = new List<string>();
            Result.SalesPerson.Languages.AddRange(LanguageList);

            var SkillList = Result.Skills.Select(x => x.Name);
            Result.SalesPerson.Skills = new List<string>();
            Result.SalesPerson.Skills.AddRange(SkillList);

            return Result.SalesPerson; 
        }
    }
}
