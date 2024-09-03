using Microsoft.AspNetCore.Mvc;
using sitemate_challenge.Models;
using sitemate_challenge.Repositories;

namespace sitemate_challenge.Controllers
{
    [ApiController]
    [Route("api/issues")]
    public class IssuesController : ControllerBase
    {
        private readonly ILogger<IssuesController> _logger;
        private readonly IIssueRepository _issueRepository;
        public IssuesController(ILogger<IssuesController> logger, IIssueRepository issueRepository)
        {
            _logger = logger;
            _issueRepository = issueRepository;
        }

        [HttpGet]
        public IEnumerable<Issue> Get()
        {
            return _issueRepository.GetAll();
        }

        [HttpPost]
        public void Create(Issue issue)
        {
            _issueRepository.Create(issue);
        }

        [HttpPut]
        public void Update(Issue issue)
        {
            _issueRepository.Update(issue);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _issueRepository.Delete(id);
        }
    }
}
