using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelExpertManagement.BLL.Interfaces;
using TravelExpertManagement.Data.Models;

namespace TravelExpertManagement.Web.Controllers
{
    public class AgentController : Controller
    {
        private readonly IAgentRepository _agentRepository;

        public AgentController(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        // GET: AgentController
        public IActionResult Index()
        {
            var agents = _agentRepository.GetAllAgents();
            return View(agents);
        }

        // GET: AgentController/Details/5
        public IActionResult Details(int id)
        {
            var agent = _agentRepository.GetAgent(id);
            if (agent == null)
            {
                return NotFound();
            }
            return View(agent);
        }

        // GET: AgentController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AgentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Agent agent)
        {
            if (ModelState.IsValid)
            {
                _agentRepository.AddAgent(agent);
                return RedirectToAction(nameof(Index));
            }
            return View(agent);
        }

        // GET: AgentController/Edit/5
        public IActionResult Edit(int id)
        {
            var agent = _agentRepository.GetAgent(id);
            if (agent == null)
            {
                return NotFound();
            }
            return View(agent);
        }

        // POST: AgentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Agent agent)
        {
            if (id != agent.AgentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _agentRepository.UpdateAgent(agent);
                return RedirectToAction(nameof(Index));
            }
            return View(agent);
        }

        // GET: AgentController/Delete/5
        public IActionResult Delete(int id)
        {
            var agent = _agentRepository.GetAgent(id);
            if (agent == null)
            {
                return NotFound();
            }
            return View(agent);
        }

        // POST: AgentController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _agentRepository.DeleteAgent(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
