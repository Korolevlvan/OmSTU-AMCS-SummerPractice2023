using Newtonsoft.Json.Linq;
using System.CommandLine;
/*var FilInput = new Option<string>
    ("--FilI");
var FilOutput = new Option<string>
    ("--FilO");
var rootCommand = new RootCommand("Parameter binding");
rootCommand.Add(FilInput);
rootCommand.Add(FilOutput);
string[] files = new string[2];
rootCommand.SetHandler(
    (FildI, FildO) =>
    {
       files = GetFILES(FildI, FildO);// DisplayIntAndString(delayOptionValue, messageOptionValue);
    },
    FilInput, FilOutput);

await rootCommand.InvokeAsync(args);
*/
class Program
{  
    static string CTS(JToken a)
    {
            return Convert.ToString(a);
    }
    static string[] GetFILES(string a, string b)
    {
        return new string[2] {a, b};
    }
    public class HAH
    {
        public string Cadet{ get; set;}
        public double GPA{ get; set;}
    }
    public class HAH2
    {
        public string Cadet{ get; set;}
        public string group{ get; set;}
        public double GPA{ get; set;}
    }
    public static void Main(string[] argu)
    {
        JObject o1 = JObject.Parse(File.ReadAllText(argu[0]));

        if(Convert.ToString(o1["taskName"]) == "GetStudentsWithHighestGPA")
        {
            var Respons = o1["data"].GroupBy(x => x["name"],x => Convert.ToInt32(x["mark"])
            , (n, m)=> new HAH{Cadet = Convert.ToString(n), GPA = Convert.ToDouble(m.Average())});
            List<double> marks = Respons.Select(x => x.GPA).ToList<double>();
            List<HAH> Resp = Respons.Where(x => (x.GPA == marks.Max())).ToList<HAH>();
            List<JObject> Respo = Resp.Select(x => new JObject {{"Cadet", x.Cadet},{"GPA", x.GPA}}).ToList<JObject>();
            JObject Ansver = new JObject{};
            Ansver["Response"] = JToken.FromObject(Respo);
            File.WriteAllText(argu[1], Ansver.ToString());
        }
        if(Convert.ToString(o1["taskName"]) == "CalculateGPAByDiscipline")
        {
            var Respons = o1["data"].GroupBy(x => x["discipline"],x => Convert.ToInt32(x["mark"])
            , (n, m)=> new HAH{Cadet = Convert.ToString(n), GPA = Convert.ToDouble(m.Average())});
            List<JObject> Respo = Respons.Select(x => new JObject {{x.Cadet, x.GPA}}).ToList<JObject>();
            JObject Ansver = new JObject{};
            Ansver["Response"] = JToken.FromObject(Respo);
            File.WriteAllText(argu[1], Ansver.ToString());
        }
        if(Convert.ToString(o1["taskName"]) == "GetBestGroupsByDiscipline")
        {
            var Respons = o1["data"].Where(y =>
            (o1["data"].Where(j => (CTS(j["discipline"]) == CTS(y["discipline"])) && (CTS(j["group"]) == CTS(y["group"])))
            .Select(j => Convert.ToInt32(j["mark"])).Sum() >
            o1["data"].Where(j => (CTS(j["discipline"]) == CTS(y["discipline"]))&& (CTS(j["group"]) != CTS(y["group"])))
            .Select(j => Convert.ToInt32(j["mark"])).Sum()));
            var Resp = Respons.GroupBy(x => x["group"], x => Convert.ToInt32(x["mark"]), 
            (a, b) => new JObject{{"Discipline", Respons.Where(j => CTS(j["group"]) == CTS(a))
            .Select(y => CTS(y["discipline"])).First<string>()}
            , {"Group", Convert.ToString(a)}, {"GPA", b.Average()}}).Reverse();
            JObject Ansver = new JObject();
            Ansver["Response"] = JToken.FromObject(Resp.ToList<JObject>());
            File.WriteAllText(argu[1], Ansver.ToString());
        }
    }
}
