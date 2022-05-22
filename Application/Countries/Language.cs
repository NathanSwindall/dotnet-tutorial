using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Countries
{
    public class Language
    {
        public class Query : IRequest<List<Country>> { 
            public string Language { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<Country>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;

            }
            public async Task<List<Country>> Handle(Query request, CancellationToken cancellationToken)
            {
                return  await _context.Countries.Where((Country country) => country.Language.ToLower() == request.Language.ToLower()).ToListAsync();
            }
        }
    }

}