using Kazillian.Model;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace Kazillian.Repo
{
    public class UserRepo
    {

        public User CreateUser()
        { 
            return null;
        }

        public User AuthenticateUser(string username, string password)
        {
            var Match    = GetSalesperson(username);
            var SaltedPW = new SaltedPassword(Match.Salt, Match.Password);
            var IsValid  = TestPassword(password, SaltedPW);

            if (IsValid)
                return Match;

            return null; 
        }
         
        private const string GraphUrl = "http://localhost:7474/db/data";

        public SalesPerson GetSalesperson(string username)
        {
            var Client = new GraphClient(new Uri(GraphUrl), "neo4j", "password");
            Client.Connect();
            var Result = Client.Cypher
                .Match("(identity:Identity {Handle:'" + username + "'})-[:IDENTIFIES]->(person:SalesPerson)")
                .With("identity,person")
                .Match("(skill:Skill)<-[:HAS_SKILL]-(person)-[:SPEAKS]-(language:Language)") 
                .Return((identity, person, language, skill) => new { SalesPerson = person.As<SalesPerson>(), Languages = language.CollectAs<Language>(), Skills = skill.CollectAs<Skill>() }).Results.FirstOrDefault();

            var LanguageList = Result.Languages.Select(x => x.Name);
            Result.SalesPerson.Languages = new List<string>();
            Result.SalesPerson.Languages.AddRange(LanguageList);

            var SkillList = Result.Skills.Select(x => x.Name);
            Result.SalesPerson.Skills = new List<string>();
            Result.SalesPerson.Skills.AddRange(SkillList);

            return Result.SalesPerson;
        }

        private SaltedPassword EncryptPassword(string password)
        {
            SaltedPassword Password = null;
            // specify that we want to randomly generate a 20-byte salt
            using (var deriveBytes = new Rfc2898DeriveBytes(password, 20))
            {
                var salt = ByteConverter.ToString(deriveBytes.Salt);
                var key = ByteConverter.ToString(deriveBytes.GetBytes(20));  // derive a 20-byte key

                Password = new SaltedPassword(salt, key);
                // save salt and key to database
            }
            return Password;
        }

        private bool TestPassword(string password, SaltedPassword saltedPassword)
        {
            var SaltBytes = ByteConverter.FromString(saltedPassword.Salt);
            var KeyBytes = ByteConverter.FromString(saltedPassword.Password);

            using (var deriveBytes = new Rfc2898DeriveBytes(password, SaltBytes))
            {
                byte[] newKey = deriveBytes.GetBytes(20);  // derive a 20-byte key

                if (!newKey.SequenceEqual(KeyBytes))
                    return false;
            }

            return true;
        }
       
        
    }
}
