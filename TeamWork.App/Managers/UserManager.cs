using TeamWork.App.Abstract;
using TeamWork.Domain.Entity;

namespace TeamWork.App.Managers;

public class UserManager
{
    public IService<User> _userService;

    public UserManager(IService<User> userService)
    {
        _userService = userService;
        Seed();
    }

    private void Seed()
    {
        _userService.AddItem(new User(1, "ExampleUser"));
        _userService.AddItem(new User(2, "ExampleUser2"));
        _userService.AddItem(new User(3, "ExampleUser3"));
        _userService.AddItem(new User(4, "ExampleUser4"));
        _userService.AddItem(new User(5, "ExampleUser5"));
        _userService.AddItem(new User(6, "ExampleUser6"));
        _userService.AddItem(new User(7, "ExampleUser7"));
    } 
}