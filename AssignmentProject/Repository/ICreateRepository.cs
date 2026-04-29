using AssignmentProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssignmentProject.Repository
{
    public interface ICreateRepository
    {
        Task<int> AddNewEvent(CreateEventModel model, string email);
        Task<List<CreateEventModel>> GetAllEvents();
        Task<CreateEventModel> GetEventById(int id);
        Task<List<CreateEventModel>> GetMyEvents(string loggedInEmail);
        Task<List<CreateEventModel>> GetIvites(string email);
        Task<int> EditEvent(CreateEventModel model);
        Task<int> AddComment(string comment, int id);
    }
}