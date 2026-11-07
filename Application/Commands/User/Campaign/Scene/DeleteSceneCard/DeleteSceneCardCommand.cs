using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Scene.DeleteSceneCard;

public class DeleteSceneCardCommand : UserRequest<Unit>
{
    public Guid CardId { get; set; }
}