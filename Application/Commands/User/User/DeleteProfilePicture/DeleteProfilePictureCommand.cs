using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.User.DeleteProfilePicture;

public class DeleteProfilePictureCommand : UserRequest<Unit>;