using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Stud_io.Authentication.Interfaces;
using Stud_io.Configuration;

namespace Stud_io.Authentication.Photos
{
    public class SetMain
    {
        public class Command : IRequest<Unit>
        {
            public string Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly ApplicationDbContext _context;
            private readonly IUserAccessor _userAccessor;
            public Handler(ApplicationDbContext context, IUserAccessor userAccessor)
            {
                _context = context;
                _userAccessor = userAccessor;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.Include(p => p.Photos)
                    .FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());

                if (user == null) throw new Exception("User is null");

                var photo = user.Photos.FirstOrDefault(x => x.Id == request.Id);

                if (photo == null) throw new Exception("Photo is null");

                var currentMain = user.Photos.FirstOrDefault(x => x.IsMain);

                if (currentMain != null) currentMain.IsMain = false;

                photo.IsMain = true;

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem setting main photo");
            }
        }
    }
}