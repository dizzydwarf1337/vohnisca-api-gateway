using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.CreateMap;

// A new workshop map; its levels are saved from the table.
public class CreateMapCommand : UserRequest<CreatedContent>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Visibility { get; set; } = "Private";
}
