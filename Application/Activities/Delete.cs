using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Delete
    {
         public class DCommand : IRequest
                {
                    public Guid Id { get; set; }
                }
        
                public class Handler : IRequestHandler<DCommand>
                {
                    private readonly DataContext _contex;
                    public Handler(DataContext contex)
                    {
                        _contex = contex;
                    }
        
                    public async Task<Unit> Handle(DCommand request, CancellationToken cancellationToken)
                    {
                        var activity = await _contex.Activities.FindAsync(request.Id);
                        if (activity == null)
                            throw new Exception ("Could not find Activity / No se pudo encontrar la actividad");

                        _contex.Remove(entity: activity);

                        var succes = await _contex.SaveChangesAsync() > 0;
        
                        if(succes) return Unit.Value;
        
                        throw new Exception("Problem savig Data, Im in Create.cs");
        
                    }
                }
    }
}