using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MyGolfApp.Repository.Interfaces;

namespace MyGolfApp.Interfaces;

public interface IUserService
{
    int Create(string email, string username, string password);
    IEnumerable<IUser> GetAll();
}