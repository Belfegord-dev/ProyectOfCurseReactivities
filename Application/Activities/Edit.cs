using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Edit
    {
         public class ECommand : IRequest
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public DateTime? Date { get; set; } //colocando el ? se dice que es opcional            
            public string City { get; set; }
            public string Venue { get; set; }
        }
        public class Handler : IRequestHandler<ECommand>
        {
            private readonly DataContext _contex;
            public Handler(DataContext contex)
            {
                _contex = contex;
            }

            public async Task<Unit> Handle(ECommand request, CancellationToken cancellationToken)
            {
                var activity = await _contex.Activities.FindAsync(request.Id);
                if (activity == null)
                    throw new Exception ("Could don't find Activity / No se pudo encontrar la actividad");

                activity.Title = request.Title ?? activity.Title;
                activity.Description = request.Description ?? activity.Description;
                activity.Category = request.Category ?? activity.Category;
                activity.Date = request.Date ?? activity.Date;
                activity.City = request.City ?? activity.City;
                activity.Venue = request.Venue ?? activity.Venue;


                var succes = await _contex.SaveChangesAsync() > 0;

                if(succes) return Unit.Value;

                throw new Exception("Problem savig Data, Im in Edit.cs");

            }
        }
    }
}