using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
public class DatabaseService
{
    public class LeaderboardPlayer
    {
        public string Nickname;
        public int Score;

        public LeaderboardPlayer(string nickname, int score)
        {
            Nickname = nickname;
            Score = score;
        }
    }
    
    public static string MongoClientSettings ="mongodb+srv://Location1:123@cluster0.lzf8c.mongodb.net/?retryWrites=true&w=majority";
    public static string MongoDatabaseName = "Location1";
    public static string MongoCollectionName = "Leaderboard";
    public static int TopLength = 3;
    private static DatabaseService _instance;
    
    private readonly MongoClient client;
    private readonly IMongoDatabase database;
    private readonly IMongoCollection<LeaderboardPlayer> databaseCollection;
    
    public IEnumerable<LeaderboardPlayer> Leaderboard { get; private set; }

    private DatabaseService()
    {
        client = new MongoClient(MongoClientSettings);
        database = client.GetDatabase(MongoDatabaseName);
        databaseCollection = database.GetCollection<LeaderboardPlayer>(MongoCollectionName);
    }
    
    public static DatabaseService Instance()
    {
        if (_instance == null)
        {
            _instance = new DatabaseService();
        }
        
        return _instance;
    }
    
    public async void AddToLeaderboard(string nickname, int score) => 
        await databaseCollection.InsertOneAsync(new LeaderboardPlayer(nickname, score));
    
    
    public async Task<List<LeaderboardPlayer>> GetTopPlayers()
    {
        var getScoresTask = databaseCollection.FindAsync<BsonDocument>(FilterDefinition<LeaderboardPlayer>.Empty);
        var scoresAwaited = await getScoresTask;
        
        var result = new List<LeaderboardPlayer>();
        //
        foreach (var scoreRaw in scoresAwaited.ToList())
        {
            LeaderboardPlayer score = new LeaderboardPlayer(scoreRaw["Nickname"].ToString(), scoreRaw["Score"].ToInt32());
            result.Add(score);
        }
        var topPlayers = result.OrderByDescending(x => x.Score).Take(TopLength);
        return topPlayers.ToList();
    }

}
