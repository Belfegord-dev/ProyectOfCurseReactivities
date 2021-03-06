using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public DateTime Date { get; set; }
            public string City { get; set; }
            public string Venue { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _contex;
            public Handler(DataContext contex)
            {
                _contex = contex;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                //throw new NotImplementedException();
                var activity = new Activity{
                    Id = request.Id,
                    Title = request.Title,
                    Description = request.Description,
                    Category = request.Category,
                    Date = request.Date,
                    City = request.City,
                    Venue = request.Venue
                };

                _contex.Activities.Add(activity);
                var succes = await _contex.SaveChangesAsync() > 0;

                if(succes) return Unit.Value;

                throw new Exception("Problem savig Data, Im in Create.cs");

            }
        }
    }
}