using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Stud_io.Authentication.Models;
using Stud_io.Authentication.Interfaces;
using Stud_io.Authentication.Photos;
using Stud_io.Configuration;

namespace Stud_io.Photos
{
    public class Add
    {
        public class Command : IRequest<Photo>
        {
            public IFormFile File { get; set; }
        }

        public class Handler : IRequestHandler<Command, Photo>
        {
            private readonly ApplicationDbContext _context;
            private readonly IUserAccessor _userAccessor;
            private readonly IPhotoAccessor _photoAccessor;
            public Handler(ApplicationDbContext context, IUserAccessor userAccessor, IPhotoAccessor photoAccessor)
            {
                _photoAccessor = photoAccessor;
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Photo> Handle(Command request, CancellationToken cancellationToken)
            {
                var photoUploadResult = await _photoAccessor.AddPhoto(request.File);

                var user = await _context.Users.Include(p => p.Photos)
                .FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());

                // var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());

                var photo = new Photo
                {
                    Url = photoUploadResult.Url,
                    Id = photoUploadResult.PublicId
                };

                if (!user.Photos.Any(x => x.IsMain))
                    photo.IsMain = true;

                user.Photos.Add(photo);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return photo;

                throw new Exception("Problem saving changes");
            }

        }
    }
}