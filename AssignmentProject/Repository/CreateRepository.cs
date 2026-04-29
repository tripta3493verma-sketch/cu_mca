using AssignmentProject.Data;
using AssignmentProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentProject.Repository
{
    public class CreateRepository : ICreateRepository
    {
        private readonly EventContext _context = null;

        public CreateRepository(EventContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewEvent(CreateEventModel model,string email)
        {
            int length = 0;
            if (model.InviteByEmail != null)
            {
                if (model.InviteByEmail.Contains(","))
                {
                    List<string> tokens = model.InviteByEmail.Split(',').ToList();
                    length = tokens.Count();
                }
                else
                {
                    length = 1;
                }
            }
            var newBook = new EventAdd()
            {
                Title = model.Title,
                Date = model.Date,
                Location = model.Location,
                StartTime = model.StartTime,
                Type = model.Type,
                Duration = model.Duration,
                Description = model.Description,
                OtherDetails = model.OtherDetails,
                InviteByEmail = model.InviteByEmail,
                CreatedBy=email,
                TotalInvites=length
            };
            await _context.EventAdd.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }
       

        public async Task<CreateEventModel> GetEventById(int id)
        {

            return await _context.EventAdd.Where(x => x.Id == id).Select(book => new CreateEventModel()
            {
             Id = book.Id, 
              Title = book.Title, 
              Date = book.Date, 
              Location = book.Location, 
              StartTime = book.StartTime, 
              Type = book.Type, 
              Duration = book.Duration,
              Description = book.Description, 
              OtherDetails = book.OtherDetails,
              InviteByEmail = book.InviteByEmail,
              TotalInvites = book.TotalInvites, 
              Comments = book.Comments
            }).FirstOrDefaultAsync();
        }


        public async Task<List<CreateEventModel>> GetAllEvents()
        {
            return await _context.EventAdd
                  .Select(EventAdd => new CreateEventModel()
                  {
                      Id=EventAdd.Id,
                      Title = EventAdd.Title,
                      Date = EventAdd.Date,
                      Location = EventAdd.Location,
                      StartTime = EventAdd.StartTime,
                      Type = EventAdd.Type,
                      Duration = EventAdd.Duration,
                      Description = EventAdd.Description,
                      OtherDetails = EventAdd.OtherDetails,
                      InviteByEmail = EventAdd.InviteByEmail,
                      Comments=EventAdd.Comments,
                      TotalInvites=EventAdd.TotalInvites
                  }).ToListAsync();
        }
        public async Task<List<CreateEventModel>> GetMyEvents(string MyEmail)
        {
            var events = new List<CreateEventModel>();
            var myEvents = await _context.EventAdd.ToListAsync();
            if (myEvents?.Any()==true)
            {
                foreach (var book in myEvents)
                {
                    if (book.CreatedBy != null && book.CreatedBy.Equals(MyEmail))
                    {
                        events.Add(new CreateEventModel()
                        {
                            Id = book.Id,
                            Title = book.Title,
                            Date = book.Date,
                            Location = book.Location,
                            StartTime = book.StartTime,
                            Type = book.Type,
                            Duration = book.Duration,
                            Description = book.Description,
                            OtherDetails = book.OtherDetails,
                            InviteByEmail=book.InviteByEmail,
                            CreatedBy = book.CreatedBy,
                            Comments = book.Comments,
                        });
                    }
                }
            }
            events.Sort((x, y) => DateTime.Compare(y.Date, x.Date));
            return events;
        }
        public async Task<List<CreateEventModel>> GetIvites(string email)
        {
            var events = new List<CreateEventModel>();
            var allevents = await _context.EventAdd.ToListAsync();
            if (allevents?.Any() == true)
            {
                foreach (var book in allevents)
                {
                    if (book.InviteByEmail != null && book.InviteByEmail.Contains(email))
                    {
                        events.Add(new CreateEventModel()
                        {
                            Id = book.Id,
                            Title = book.Title,
                            Date = book.Date,
                            Location = book.Location,
                            StartTime = book.StartTime,
                            Type = book.Type,
                            Duration = book.Duration,
                            Description = book.Description,
                            OtherDetails = book.OtherDetails,
                            InviteByEmail = book.InviteByEmail,
                            CreatedBy = book.CreatedBy,
                            Comments = book.Comments
                        });
                    }
                }
            }
            return events;
        }
        public async Task<int> EditEvent(CreateEventModel model)
        {
            int length = 0;
            if (model.InviteByEmail != null)
            {
                if (model.InviteByEmail.Contains(","))
                {
                    List<string> tokens = model.InviteByEmail.Split(',').ToList();
                    length = tokens.Count();
                }
                else
                {
                    length = 1;
                }
            }
            var temp = _context.EventAdd.Find(model.Id);
            temp.Title = model.Title;
            temp.Date = model.Date;
            temp.Location = model.Location;
            temp.StartTime = model.StartTime;
            temp.Type = model.Type;
            temp.Duration = model.Duration;
            temp.Description = model.Description;
            temp.OtherDetails = model.OtherDetails;
            temp.InviteByEmail = model.InviteByEmail;
            temp.TotalInvites = length;
            //await _context.Books.AddAsync(newBook);
            _context.EventAdd.Update(temp);
            await _context.SaveChangesAsync();
            return temp.Id;
        }
        public async Task<int> AddComment(string comment, int id)
        {
            var temp = _context.EventAdd.Find(id);
            if (temp.Comments == null)
            {
                temp.Comments = comment;
            }
            else
            {
                temp.Comments = temp.Comments + ", " + comment;
            }
            _context.EventAdd.Update(temp);
            await _context.SaveChangesAsync();
            return temp.Id;
        }
       
    }
}
