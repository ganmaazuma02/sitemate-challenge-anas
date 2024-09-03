using sitemate_challenge.Models;

namespace sitemate_challenge.Repositories
{
    public interface IIssueRepository
    {
        List<Issue> GetAll();
        Issue GetOne(int id);
        void Create(Issue issue);
        void Update(Issue issue);
        void Delete(int id);
    }
}
