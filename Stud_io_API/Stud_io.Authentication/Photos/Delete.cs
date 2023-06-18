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
    public class Delete
    {
        public class Command : IRequest<Unit>
        {
            public string Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly ApplicationDbContext _context;
            private readonly IPhotoAccessor _photoAccessor;
            private readonly IUserAccessor _userAccssor;
            public Handler(ApplicationDbContext context, IPhotoAccessor photoAccessor, IUserAccessor userAccessor)
            {
                _context = context;
                _photoAccessor = photoAccessor;
                _userAccssor = userAccessor;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.Include(p => p.Photos)
                    .FirstOrDefaultAsync(x => x.UserName == _userAccssor.GetUsername());

                if (user == null) throw new Exception("User is null");

                var photo = user.Photos.FirstOrDefault(x => x.Id == request.Id);

                if (photo == null) throw new Exception("Photo is null");
                //if (photo.IsMain) throw new Exception("You cannot delete your main photo");

                var result = await _photoAccessor.DeletePhoto(photo.Id);

                if (result == null) throw new Exception("Problem deleting photo from Cloudinary");

                user.Photos.Remove(photo);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem deleting photo from API");
            }
        }
    }
}