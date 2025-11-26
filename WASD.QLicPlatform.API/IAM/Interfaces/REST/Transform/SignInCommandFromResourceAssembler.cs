using WASD.QLicPlatform.API.IAM.Domain.Model.Commands;
using WASD.QLicPlatform.API.IAM.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.IAM.Interfaces.REST.Transform;

/// <summary>
/// Assembler to create a SignInCommand from a SignInResource.
/// </summary>
public static class SignInCommandFromResourceAssembler
{
    /// <summary>
    /// Converts a SignInResource to a SignInCommand.
    /// </summary>
    /// <param name="resource">The sign-in resource.</param>
    /// <returns>The sign-in command.</returns>
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}