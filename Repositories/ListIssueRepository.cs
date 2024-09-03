using Newtonsoft.Json;
using sitemate_challenge.Models;

namespace sitemate_challenge.Repositories
{
    public class ListIssueRepository : IIssueRepository
    {
        private readonly List<Issue> _issues;

        private readonly ILogger<ListIssueRepository> _logger;
        public ListIssueRepository(ILogger<ListIssueRepository> logger)
        {
            _issues = new List<Issue>
            {
                new Issue
                {
                    ID = 1,
                    Title = "Fix Dashboard",
                    Description = "The dashboard is broken. Fix it.",
                },
                new Issue
                {
                    ID = 2,
                    Title = "New Field - Project Notes",
                    Description = "Add a new field called project notes in the view/edit project page.",
                },
                new Issue
                {
                    ID = 3,
                    Title = "New Page - Task Type",
                    Description = "Create a new page which shows all task types available in the system.",
                },
            };
            _logger = logger;
        }

        public void Create(Issue issue)
        {
            issue.ID = _issues.Last().ID + 1;
            _issues.Add(issue);
                Console.WriteLine($"Issue created: {JsonConvert.SerializeObject(issue)}");
            _logger.Log(LogLevel.Debug, $"Issue created: {JsonConvert.SerializeObject(issue)}");
        }

        public void Delete(int id)
        {
            var issue = _issues.FirstOrDefault(i => i.ID == id);
            if (issue != null)
            {
                _logger.Log(LogLevel.Debug, $"Deleting issue: {JsonConvert.SerializeObject(issue)}");
                Console.WriteLine($"Deleting issue: {JsonConvert.SerializeObject(issue)}");
                _issues.Remove(issue);
                return;
            }

            throw new Exception($"issue with id {id} not found");
        }

        public List<Issue> GetAll()
        {
            return _issues;
        }

        public Issue GetOne(int id)
        {
            var issue = _issues.FirstOrDefault(i => i.ID == id);
            if (issue != null)
            {
                return issue;
            }

            throw new Exception($"issue with id {id} not found");
        }

        public void Update(Issue issue)
        {
            var existingIssue = _issues.FirstOrDefault(i => i.ID == issue.ID);
            if (existingIssue != null)
            {
                existingIssue.Title = issue.Title;
                existingIssue.Description = issue.Description;
                _logger.Log(LogLevel.Debug, $"Updating issue: {JsonConvert.SerializeObject(issue)}");
                Console.WriteLine($"Updating issue: {JsonConvert.SerializeObject(issue)}");
                return;
            }
            throw new Exception($"issue with id {issue.ID} not found");
        }
    }
}
